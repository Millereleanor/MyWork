$(document).ready(function() {
    var pendingpost = false;
    $("#SubYo").on("click", function (event) {
        if (pendingpost === true) {
            pendingpost = false;
            return;
        }
        event.preventDefault();

        var frm = $("#newPost");
        var tinyIsValid = false;
        
        var tinyContent = tinyMCE.get('Textarea').getContent();

        if (tinyContent == '') {
            $("#tinyError").text("Please enter page content!");
            $("#tinyLabel").addClass("redText");
        } else {
            $("#tinyError").text("");
            $("#tinyLabel").removeClass("redText");
            tinyIsValid = true;
        }

        if ((frm.valid()) && (tinyIsValid)) {
            pendingpost = true;
            $(this).trigger('click')
        }

    });
});