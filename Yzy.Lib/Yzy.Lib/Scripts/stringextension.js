
String.format = function () {
    
    var _args = arguments;

    if (typeof _args[0] !== 'string') {
        throw '第一个参数必须为字符串';
    }

    return _args[0].replace(/{(\d+)}/g, function (g1, g2) {
        return _args[Number(g2) + 1];
    });
}


String.prototype.contains = function () {

    var array = [];

    if (arguments[0] instanceof Array) {

        array = arguments[0];

    } else {

        //如果参数不是数组，则将参数添加到数组中。
        for (var i = 0; i < arguments.length; i++) {
            array.push(arguments[i]);
        }
    }

    for (var i in array) {

        if (this.indexOf(array[i]) >= 0) {
            return true;
        }
    }

    return false;
}

String.prototype.trimEnd = function () {

    return this.replace(/\s+$/, '');
}

String.prototype.trimStart = function () {

    return this.replace(/^\s+/, '');
}

String.prototype.trim = function () {

    return this.replace(/^\s+|\s+$/g, '');
}