// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Define global variables:
window.userName = "NOT-SET"; //This value will be assigned using the Identity Platform used (the user that is currently logged in)
var notificationsNumber = 0;

$(document).ready(function () {
	window.userEmail = $("#user-id").val();
	UpdateNotificationsCenter();
});

$("#send-notification").on("click", function () {
	$.ajax({
		url: "https://localhost:7011/api/notification",
		type: "POST",
		dataType: "json",
		contentType: 'application/json',
		data: GenerateRandomData(),
		success: function () {
			console.log("Send notification -success!");
		},
		error: function (err) {
			if (err.status == 400 || err.statusText)
				alert("Send notification error: " + err.responseText);
			window.sendNotificationError = err;
		}

	});
});


/**
 * Generate random data to sent to the API.
 * @param {int} id - notification id
 * @param {string} title - notification title
 * @param {string} time - how long ago the notification was generated.
 * @param {string} body - notification text body.
 */
function GenerateRandomData() {
	
	var data = {
		"title": "App notification",
		"message": $("#message-to-send").val(),
		"author": $("#message-sender").val(),
		"recipient": window.userEmail
	}
	return JSON.stringify(data);
}