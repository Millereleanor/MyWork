$(document).ready(function () {
    $('#newBlogPost').validate({
        rules: {
            'NewBlog.Title': {
                required: true,
                maxlength: 100
            },
            'NewBlog.Summary': {
                required: true,
                maxlength: 255
            },
            'NewBlog.MainPictureUrl': {
                required: true,
                maxlength: 125
            },
            'NewBlog.PostContent': {
                required: true
            }
        },
        messages: {
            'NewBlog.Title': {
                required: "Please enter a title",
                maxlength: "Please enter a shorter title"
            },
            'NewBlog.Summary': {
                required: "Please enter a summary for the post",
                maxlength: "Please enter a shorter summary"
            },
            'NewBlog.MainPictureUrl': {
                required: "Please enter a main picture for the post",
                maxlength: "Your URL is too long, please go to https://goo.gl/ to shorten it"
            },
            'NewBlog.PostContent': "Please enter blog content"
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