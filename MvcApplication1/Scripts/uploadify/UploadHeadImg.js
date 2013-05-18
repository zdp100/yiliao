$(function () {
    $("#upload").uploadify({
        'multi': false,
        //'uploadLimit': 1,
        'width': 60,
        'height': 30,
        'queueID': 'some_file_queue',
        'fileTypeDesc': 'Image Files',
        'fileTypeExts': '*.gif; *.jpg; *.png',
        'formData': { 'folder': '/UploadFile/image' },
        'buttonText': '选择图片',
        //'buttonClass': 'browser',
        'removeCompleted': false,
        'swf': "/Scripts/uploadify/uploadify.swf",
        'uploader': '/Upload/Upload',
        'itemTemplate': true,
        'onUploadSuccess': function (file, data, response) {
            var str = $.parseJSON(data);
            var strurl = str.Folder + "/" + str.SaveName;
            $("#ImageFile").show().find("img").attr("src", strurl);
            $("#Images").attr("value", strurl);
            //alert(file.name + "上传成功")
        }
    });
});