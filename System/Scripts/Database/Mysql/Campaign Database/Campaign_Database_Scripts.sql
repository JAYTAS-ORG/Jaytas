CREATE DATABASE 'campaign';

CREATE TABLE 'campaign'.'campaign' (
  'Id' int(19) unsigned NOT NULL AUTO_INCREMENT,
  'CampaignId' varchar(36) NOT NULL,
  'Name' varchar(150) NOT NULL,
  'NotificationChannels' int(11) NOT NULL,
  'IsWelcomeMessageRequired' bit(1) NOT NULL,
  'IsRemainderMessageRequired' bit(1) NOT NULL,
  'IsOverDueMessageRequired' bit(1) NOT NULL,
  'GroupId' varchar(36) NOT NULL,
  'SubscriptionId' varchar(36) NOT NULL,
  'Status' int(11) NOT NULL,
  'CampaignManagerMailId' varchar(255) DEFAULT NULL,
  PRIMARY KEY ('Id'),
  UNIQUE KEY 'CampaignId_UNIQUE' ('CampaignId')
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
  
CREATE TABLE 'campaign'.'campaign_instance' (
  'Id' int(19) unsigned NOT NULL AUTO_INCREMENT,
  'InstanceId' varchar(36) NOT NULL,
  'CampaignId' int(19) unsigned NOT NULL,
  'StartDate' date NOT NULL,
  'EndDate' date NOT NULL,
  'StartTime' time NOT NULL,
  'EndTime' time NOT NULL,
  PRIMARY KEY ('Id'),
  KEY 'FK_Campaign_CampaignInstance_idx' ('CampaignId'),
  CONSTRAINT 'FK_Campaign_CampaignInstance' FOREIGN KEY ('CampaignId') REFERENCES 'campaigns' ('Id') ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


CREATE TABLE 'campaign'.'campaign_instance_exception' (
  'Id' int(19) unsigned NOT NULL AUTO_INCREMENT,
  'CampaignInstanceExceptionId' varchar(36) NOT NULL,
  'InstanceId' int(19) unsigned NOT NULL,
  'Is_Rescheduled' bit(1) NOT NULL,
  'Is_Cancelled' bit(1) NOT NULL,
  'StartDate' date DEFAULT NULL,
  'EndDate' date DEFAULT NULL,
  'StartTime' time DEFAULT NULL,
  'EndTime' time DEFAULT NULL,
  PRIMARY KEY ('Id'),
  KEY 'FK_CampaignInstace_Exception_idx' ('InstanceId'),
  CONSTRAINT 'FK_CampaignInstace_Exception' FOREIGN KEY ('InstanceId') REFERENCES 'campaign_instance' ('Id') ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE 'campaign'.'message_templates' (
  'Id' int(19) unsigned NOT NULL AUTO_INCREMENT,
  'MessageId' varchar(36) NOT NULL,
  'CampaignId' int(19) unsigned NOT NULL,
  'NotificationChannel' int(11) NOT NULL,
  'WelcomeMessage' varchar(255) DEFAULT NULL,
  'RemainderMessage' varchar(255) DEFAULT NULL,
  'OverDueMessage' varchar(255) DEFAULT NULL,
  PRIMARY KEY ('Id'),
  KEY 'FK_Campaign_MessageTemplate_idx' ('CampaignId'),
  CONSTRAINT 'FK_Campaign_MessageTemplate' FOREIGN KEY ('CampaignId') REFERENCES 'campaigns' ('Id') ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE 'campaign'.'schedule' (
  'Id' int(19) unsigned NOT NULL AUTO_INCREMENT,
  'ScheduleId' varchar(36) NOT NULL,
  'CampaignId' int(19) unsigned NOT NULL,
  'Type' bit(1) NOT NULL,
  'StartDate' date NOT NULL,
  'EndDate' date NOT NULL,
  'StartTime' time NOT NULL,
  'EndTime' time NOT NULL,
  PRIMARY KEY ('Id'),
  KEY 'FK_Campaign_Schedule_idx' ('CampaignId'),
  CONSTRAINT 'FK_Campaign_Schedule' FOREIGN KEY ('CampaignId') REFERENCES 'campaigns' ('Id') ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE 'campaign'.'schedule_recurrencepattern' (
  'ScheduleId' int(19) unsigned NOT NULL,
  'RecurringType' int(11) NOT NULL,
  'SeparationCount' int(11) DEFAULT NULL,
  'MaxNumberOfOccurrences' int(11) DEFAULT NULL,
  'DayOfWeek' int(11) DEFAULT NULL,
  'WeekOfMonth' int(11) DEFAULT NULL,
  'DayOfMonth' int(11) DEFAULT NULL,
  'MonthOfYear' int(11) DEFAULT NULL,
  KEY 'FK_Schedule_RecurrencePattern_idx' ('ScheduleId'),
  CONSTRAINT 'FK_Schedule_RecurrencePattern' FOREIGN KEY ('ScheduleId') REFERENCES 'schedule' ('Id') ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;