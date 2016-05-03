$(document).ready(function () {
    $('#newBlogPost').validate({
        rules: {
            'NewBlog.Title': {
                required: true,
                maxlength:100

            },
            'NewBlog.Summary': {
                required: true,
                maxlength:255
            },
            'NewBlog.MainPictureUrl': {
                required: true,
                maxlength:125
            },
            'NewBlog.PostContent': {
                required: true
            }
        },
        messages: {
            'NewBlog.Title': "Please enter a title",
            'NewBlog.Summary': "Please enter a summary for the post",
            'NewBlog.MainPictureUrl': "Please enter a main picture for the post",
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