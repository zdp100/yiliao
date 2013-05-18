$(function () {
    $("#upload").uploadify({
        'auto': false,
        //'multi': false,
        //'uploadLimit': 1,
        'width': 60,
        'height': 30,
        'queueID': 'some_file_queue',
        'fileTypeDesc': 'Image Files',
        'fileTypeExts': '*.gif; *.jpg; *.png',
        'formData': { 'folder': '/UploadFile/images' },
        'buttonText': '选择图片',
        //'buttonClass': 'browser',
        'removeCompleted': true,
        'swf': "/Scripts/uploadify/uploadify.swf",
        'uploader': '/Upload/UploadList',
        'itemTemplate': false,
        'onUploadSuccess': function (file, data, response) {
            var str = $.parseJSON(data);
            var strurl = str.Folder + "/" + str.SaveName;
            //设置封面URL
            if ($("#ImageUrl").val() == "") {
                $("#ImageFile").show().find("img").attr("src", strurl);
                $("#ImageUrl").val(strurl);
            }



            sucadd(strurl, str.Id);
            //一个hide保存图片的ID<input id="hideimage" type="hide" value="1,2,3,4,5,6"/>


            //alert(file.name + "上传成功")
        }
    });

    function sucadd(strurl, id) {


        if ($("#Up_file_queue .clear") != null) {
            $("#Up_file_queue .clear").remove();
        }

        $("#image-hide .wenzi").html(id);

        $("#image-hide .cancel a").attr("imageid", id);
        $("#image-hide .fengmian a").attr("imageid", id);

        $("#hideImageAdd").val(setid($("#hideImageAdd").val(), id));


        $("#image-hide .image-queue-item img").attr("src", strurl);
        $("#Up_file_queue").append($("#image-hide").html());


        $("#Up_file_queue").append('<div class="clear" style="clear:both;"></div>');
        if ($("#Up_file_queue").html() != null) {
            $("#fieldset-image").show();
        }
        //封面
        $('#Up_file_queue .fengmian a[imageid="' + id + '"]').click(function () {
            var strurl1 = $(this).parent().siblings("img").attr("src");
            $("#ImageFile img").attr("src", strurl1);
            $("#ImageUrl").val(strurl1);

        });

        //删除
        $('#Up_file_queue .cancel a[imageid="' + id + '"]').click(function () {
            //alert("ffff");
            sucdel($(this).attr("imageid"));
        });


    }

    function sucdel(id) {
        //alert(id);
        var str = $("#hideImageAdd").val();
        var strarr = str.split(",");
        var strvar = "";
        for (var i = 0; i < strarr.length; i++) {
            if (id != strarr[i]) {
                strvar = setid(strvar, strarr[i]);
            }
        }
        $("#hideImageAdd").val(strvar);
        $("#hideImageDel").val(setid($("#hideImageDel").val(), id));
        $('#Up_file_queue .cancel a[imageid="' + id + '"]').parent().parent().remove();

    }

    function setid(str, id) {
        if (str == "") {
            str = id;
        } else {
            var strarr = str.split(",");
            var boolid = true;
            for (var i = 0; i < strarr.length; i++) {
                if (id == strarr[i]) {
                    boolid = false;
                }
            }
            if (boolid) {
                str = str + "," + id;
            }
        }
        return str;
    }

    $("#Up_file_queue .cancel a").click(function () {
        //alert($(this).attr("imageid"));
        sucdel($(this).attr("imageid"));
    });

    //封面
    $('#Up_file_queue .fengmian a').click(function () {
        var strurl1 = $(this).parent().siblings("img").attr("src");
        $("#ImageFile img").attr("src", strurl1);
        $("#ImageUrl").val(strurl1);

    });

});