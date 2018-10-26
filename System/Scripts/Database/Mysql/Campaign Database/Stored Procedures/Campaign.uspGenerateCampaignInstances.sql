DELIMITER $$

DROP PROCEDURE IF EXISTS `Campaign`.`uspGenerateCampaignInstances` $$

CREATE PROCEDURE `Campaign`.`uspGenerateCampaignInstances`
/*
	Description : This is to Generate Campaign Instances for a campaign.
				  It will be called only whenever there is a change in campaign schedule
	Paramenters : CampaignId
    Example		: CALL Campaign.uspGenerateCampaignInstances('3ed319d3-7e0c-4385-ba8f-ff248cbe6345');
*/
(
	IN campaignId VARCHAR(36)
)

CampaignInstanceBlock:BEGIN
	
    DECLARE isRecurrenceCampaign BIT;
    
    SET isRecurrenceCampaign = (SELECT EXISTS (SELECT CampaignId FROM campaign.schedule WHERE CampaignId = campaignId));
    
    IF (isRecurrenceCampaign = 0) 
    THEN
		INSERT INTO campaign.campaign_instance (InstanceId, CampaignId, StartDate, EndDate, StartTime, EndTime)
        SELECT uuid(),
			   CS.CampaignId,
               CS.StartDate,
               CS.EndDate,
               CS.StartTime,
               CS.EndTime
        FROM campaign.schedule CS
        WHERE CampaignId = campaignId;
        
        LEAVE CampaignInstanceBlock;
        
    END IF;
	
    SELECT @recurringType:= SCRP.RecurringType,
		   @separationCount:= SCRP.SeparationCount,
           @maxNumberOfOccurrences:= SCRP.MaxNumberOfOccurrences,
           @daysOfWeek:= SCRP.DaysOfWeek,
           @weekOfMonth:= SCRP.WeekOfMonth,
           @dayOfTheMonth:= SCRP.DayOfMonth,
           @monthOfYear:= SCRP.MonthOfYear,
           @startDate:= SC.StartDate,
           @endDate:= SC.EndDate,
           @startTime:= SC.StartTime,
           @endTime:= SC.EndTime
	FROM campaign.schedule SC
    INNER JOIN campaign.schedule_recurrencepattern SCRP
		ON SC.Id = SCRP.ScheduleId
	WHERE SC.CampaignId = campaignId;
        
    /* Daily Campaign*/
    IF (@recurringType = 1) 
    THEN
		CALL Campaign.uspGetDailyCampaignInstanceDates(@startDate, @endDate, @separationCount, @maxNumberOfOccurrences, @daysOfWeek);
    END IF;
    
    /* Create Campaign Instances*/
	INSERT INTO campaign.campaign_instance (InstanceId, CampaignId, StartDate, EndDate, StartTime, EndTime)
    SELECT uuid(),
		   campaignId,
           CID.InstanceDate,
           @endDate,
           @startTime,
           @endTime
    FROM campaigninstancedates CID;
    
END CampaignInstanceBlock$$

DELIMITER ;