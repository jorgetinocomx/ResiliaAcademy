﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7011/notificationshub", {
    skipNegotiation: true,
    transport: signalR.HttpTransportType.WebSockets
}).build();


//Disable the send button until connection is established.
document.getElementById("send-notification").disabled = true;

// Receives the SignalR hub broadcast message.
connection.on("ReceiveNotification", function (receivedData) {
    ShowNotification(receivedData.id, receivedData.title, receivedData.timeAgo, receivedData.message);
});

// Enable button after the connection was stablished
connection.start().then(function () {
    document.getElementById("send-notification").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});