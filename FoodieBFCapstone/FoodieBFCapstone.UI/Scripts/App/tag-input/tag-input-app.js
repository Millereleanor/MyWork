$(function () {
    var sampleTags = ['Figure', 'Out', 'How', 'To', 'Load'];
    $('#singleFieldTags').tagit({
        availableTags: sampleTags,
        singleField: true,
        allowSpaces: true,
        singleFieldNode: $('#mySingleField')
    });
});