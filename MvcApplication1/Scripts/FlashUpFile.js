﻿var userAgent = navigator.userAgent.toLowerCase();
var is_opera = userAgent.indexOf('opera') != -1 && opera.version();
var is_moz = (navigator.product == 'Gecko') && userAgent.substr(userAgent.indexOf('firefox') + 8, 3);
var is_ie = (userAgent.indexOf('msie') != -1 && !is_opera) && userAgent.substr(userAgent.indexOf('msie') + 5, 3);
var is_mac = userAgent.indexOf('mac') != -1;
function AC_GetArgs(args, classid, mimeType) {
    var ret = new Object();
    ret.embedAttrs = new Object();
    ret.params = new Object();
    ret.objAttrs = new Object();
    for (var i = 0; i < args.length; i = i + 2) {
        var currArg = args[i].toLowerCase();
        switch (currArg) {
            case "classid": break;
            case "pluginspage": ret.embedAttrs[args[i]] = 'http://www.macromedia.com/go/getflashplayer'; break;
            case "src": ret.embedAttrs[args[i]] = args[i + 1]; ret.params["movie"] = args[i + 1]; break;
            case "codebase": ret.objAttrs[args[i]] = 'http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,0,0'; break;
            case "onafterupdate": case "onbeforeupdate": case "onblur": case "oncellchange": case "onclick": case "ondblclick": case "ondrag": case "ondragend":
            case "ondragenter": case "ondragleave": case "ondragover": case "ondrop": case "onfinish": case "onfocus": case "onhelp": case "onmousedown":
            case "onmouseup": case "onmouseover": case "onmousemove": case "onmouseout": case "onkeypress": case "onkeydown": case "onkeyup": case "onload":
            case "onlosecapture": case "onpropertychange": case "onreadystatechange": case "onrowsdelete": case "onrowenter": case "onrowexit": case "onrowsinserted": case "onstart":
            case "onscroll": case "onbeforeeditfocus": case "onactivate": case "onbeforedeactivate": case "ondeactivate": case "type":
            case "id": ret.objAttrs[args[i]] = args[i + 1]; break;
            case "width": case "height": case "align": case "vspace": case "hspace": case "class": case "title": case "accesskey": case "name":
            case "tabindex": ret.embedAttrs[args[i]] = ret.objAttrs[args[i]] = args[i + 1]; break;
            default: ret.embedAttrs[args[i]] = ret.params[args[i]] = args[i + 1];
        }
    }
    ret.objAttrs["classid"] = classid;
    if (mimeType) {
        ret.embedAttrs["type"] = mimeType;
    }
    return ret;
}
function AC_FL_RunContent() {
    var ret = AC_GetArgs(arguments, "clsid:d27cdb6e-ae6d-11cf-96b8-444553540000", "application/x-shockwave-flash");
    var str = '';
    if (is_ie && !is_opera) {
        str += '<object ';
        for (var i in ret.objAttrs) {
            str += i + '="' + ret.objAttrs[i] + '" ';
        }
        str += '>';
        for (var i in ret.params) {
            str += '<param name="' + i + '" value="' + ret.params[i] + '" /> ';
        }
        str += '</object>';
    } else {
        str += '<embed ';
        for (var i in ret.embedAttrs) {
            str += i + '="' + ret.embedAttrs[i] + '" ';
        }
        str += '></embed>';
    }
    return str;
}