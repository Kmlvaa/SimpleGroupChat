var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.on("ReceiveMessage", function (user, message) {
    $("#chatBox").append("<p> <strong>" + user + "</strong>: " + message + "</p>");
});

connection.start().then(function () {
    console.log("Connected!");
}).catch(function (err) {
    console.error(err.toString());
});

$("#sendButton").click(function () {
    var user = $("#username").val();
    var message = $("#message").val();
    connection.invoke("SendMessage", user, message);
    $("#message").val("").focus();
});
