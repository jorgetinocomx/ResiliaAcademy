// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("#send-notification").on("click", function () {
	$.ajax({
		url: "https://localhost:7011/api/notification",
		type: "POST",
		dataType: "json",
		contentType: 'application/json',
		data: GenerateRandomData(),
		success: function () {
			console.log("Ajax success!");
		},
		error: function (err) {
			console.error("Ajax error" + err);
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
		"title": "string",
		"message": "string",
		"author": "user@example.com",
		"recipient": "user@example.com"
	}
	return JSON.stringify(data);
}