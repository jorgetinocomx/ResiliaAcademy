
/**
 * Shows a toast notification.
 * @param {int} id - notification id
 * @param {string} title - notification title
 * @param {string} time - how long ago the notification was generated.
 * @param {string} body - notification text body.
 */
function ShowNotification(id,title, time, body) {
	$("#toast-template").clone().prop('id', id).appendTo("#notification-space");
	$(`#${id} .notification-title`).html(title);
	$(`#${id} .notification-time`).html(time);
	$(`#${id} .notification-body`).html(body);
	$(`#${id}`).toast('show');
}


/**
 * Generate random data to sent to the API.
 */
function UpdateNotificationsCenter() {
	let dataToSend = JSON.stringify({
		"userEmail": window.userEmail
	})
	$.ajax({
		url: "https://localhost:7011/api/notification",
		type: "GET",
		dataType: "json",
		contentType: 'application/json',
		data: {
			"userEmail": window.userEmail
		},
		success: function (notificationListResponse) {
			console.log("Updating notification center for: ", window.userEmail, notificationListResponse);
			RedrawNotificationsCenter(notificationListResponse);
		},
		error: function (err) {
			console.error("UpdateNotificationsCenter > Ajax error" + err);
		}

	});
}


/**
 * Generate random data to sent to the API.
 * @param {JSON} notificationsList - JSON object with all the notifications that should be printed in the notification center.
 */
function RedrawNotificationsCenter(notificationsList) {
	// update the notification number badged
	window.allNotifications = notificationsList;
	notificationsNumber = notificationsList.filter(notif => notif.isRead == false).length;
	$("#notifications-counter").html(notificationsNumber);

	// update the notification content
	if (notificationsNumber > 3)
		$("#show-all-notifications-button").show();
	else
		$("#show-all-notifications-button").hide();

	// add the notifications to the list
	let notificationsDisplayed = 0;
	$("#notifications-center").html("");
	window.allNotifications.forEach(function (item) {
		notificationsDisplayed++;
		if (notificationsDisplayed > 3)
			return;
		$(".notification-item#0").clone().prop('id', item.id).appendTo("#notifications-center")
		$(`.notification-item#${item.id} .notification-item-time-ago`).html(item.timeAgo);
		$(`.notification-item#${item.id} .notification-item-text`).html(item.message);
		$(`.notification-item#${item.id}`).show();
	});




}
