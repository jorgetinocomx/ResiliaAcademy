
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