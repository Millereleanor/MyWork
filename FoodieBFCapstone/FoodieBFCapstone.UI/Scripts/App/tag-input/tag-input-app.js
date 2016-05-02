$(function () {
    var uri = "/api/tags/";
    var sampleTags = $.getJSON(uri);
    $('#singleFieldTags').tagit({
        availableTags: sampleTags,
        singleField: true,
        allowSpaces: true,
        caseSensitive: false,
        removeConfirmation: true,
        placeholderText: "Enter to add",
        singleFieldNode: $('#mySingleField')
    });
});