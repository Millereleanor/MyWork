$(function () {
    var uri = "/api/tags/";
    var sampleTags = $.getJSON(uri);
    $('#singleFieldTags').tagit({
        availableTags: sampleTags,
        singleField: true,
        allowSpaces: true,
        singleFieldNode: $('#mySingleField')
    });
});