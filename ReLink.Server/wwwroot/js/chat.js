"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var userInput = document.getElementById("userInput").value;
    var msg = ""
    if (userInput == user)
    {
        msg += '<div class="line__right">'
        msg += '  <div class="text">' + message + '</div>'
        msg += '</div>'
    }
    else
    {
        msg += '<div class="line__left">'
        msg += '  <figure>'
        msg += '    <img src="~/icon.png" />'
        msg += '  </figure>'
        msg += '  <div class="line__left-text">'
        msg += '    <div class="name">' + user + '</div>'
        msg += '    <div class="text">' + message + '</div>'
        msg += '  </div>'
        msg += '</div>'
    }

    var mesagesList = document.getElementById("messagesList");
    mesagesList.insertAdjacentHTML('beforeend', msg);
    mesagesList.scrollTop = mesagesList.scrollHeight;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});