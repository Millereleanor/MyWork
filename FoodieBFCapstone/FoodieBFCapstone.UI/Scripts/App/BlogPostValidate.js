$(document).ready(function () {
    $('#newBlogPost').validate({
        rules: {
            Title: {
                required: true,
                maxlength:100

            },
            Summary: {
                required: true,
                maxlength:255
            },
            MainPictureUrl: {
                required: true,
                maxlength:125
            },
            PostContent: {
                required: true
            }
        },
        messages: {
            Title: "Please enter a title",
            Summary: "Please enter a summary for the post",
            MainPictureUrl: "Please enter a main picture for the post",
            PostContent: "Please enter blog content"
        },
        errorPlacement: function (error, element) {
            if (element.parent('.form-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });
});