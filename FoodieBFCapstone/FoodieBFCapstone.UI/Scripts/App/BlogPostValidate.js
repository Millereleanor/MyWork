$(document).ready(function () {
    $('#newBlogPost').validate({
        rules: {
            Title: {
                required: true
            },
            Summary: {
                required: true
            },
            MainPictureUrl: {
                required: true
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
        }
    });
});