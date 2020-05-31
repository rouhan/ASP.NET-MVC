$.connection.hub.start()
    .done(function () {

        console.log("Its working")
        $.connection.muHub.server.announce("Connected");

    })
    .fail(function () { alert("No") });

$.connection.muHub.client.announce = function (message) { alert(message) }