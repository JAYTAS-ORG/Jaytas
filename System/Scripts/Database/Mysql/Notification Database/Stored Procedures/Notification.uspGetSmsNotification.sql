DELIMITER $$

DROP PROCEDURE IF EXISTS `Notification`.`uspGetSmsNotification` $$

CREATE PROCEDURE `Notification`.`uspGetSmsNotification`
/*
	Description : This is to get Pending SMS Notifiation for specified date and time.
				  It will be scheduled to run every 5mins
	Paramenters : status - Pending, Initiated, Sent
				  notificationDate
                  notificationTime
    Example		: CALL Notification.uspGetSmsNotification(0, '30/10/2018', '09:40:00');
*/
(
	IN status INT(19),
    IN notificationDate DATE,
    IN notificationTime TIME
)

BEGIN
	
    SELECT NotificationId,
		   PhoneNumber,
           Message
    FROM notification.sms_notification
    WHERE Status = status AND
    NotificationDate = notificationDate AND
    NotificationTime = notificationTime;
    
END$$

DELIMITER ;