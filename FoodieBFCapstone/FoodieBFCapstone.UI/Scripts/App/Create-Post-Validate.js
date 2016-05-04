$(document).ready(function () {

    $("#SubYo").on("click", function(event) {
        event.preventDefault();

        var frm = $("#newBlogPost");

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
            $("#PendingReview").modal("show");
        }

    });

    $("#PendingSubmit").on("click", function (event) {
        event.preventDefault();
        var post = {
            "BlogId": $("#NewBlog_BlogId").val(),
            "UserId": $("#NewBlog_UserId").val(),
            "Subcategory": { "SubcategoryId": $("#NewBlog_Subcategory_SubcategoryId").val() },
            "MainPictureUrl": $("#NewBlog_MainPictureUrl").val(),
            "Title": $("#NewBlog_Title").val(),
            "PostContent": tinyMCE.activeEditor.getContent({ format: 'raw' }),
            "Summary": $("#NewBlog_Summary").val(),
            "CreatedOn": $("#NewBlog_CreatedOn").val(),
            "PublishDate": $("#NewBlog_PublishDate").val(),
            "ExpirationDate": $("#NewBlog_ExpirationDate").val(),
            "ApprovedOn": $("#NewBlog_ApprovedOn").val(),
            "Tags": []
        };
        $.each($("#singleFieldTags li>span"), function (index, item) {
            post.Tags.push({ TagName: $(item).text() });
        });

        var settings = {
            "url": "/api/ContributorPosts",
            "method": "POST",
            "headers": {
                "content-type": "application/json"
            },
            "data": JSON.stringify(post)
        }
        console.log(JSON.stringify(post));
        $.ajax(settings).success(function (response) {
            window.location.href = '@Url.Action("Index","Contributor")';
        }).error(function (error, status) {
            alert(error, status);
        });
    });
});