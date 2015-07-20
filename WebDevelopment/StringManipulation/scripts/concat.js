String.prototype.Concat = function () {
    var stringMain = this,
        ret_val = stringMain;
    //concatinating Character by character
    for (var i = 0; i < arguments.length; i++)
    {
        stringMain = arguments[i].toString();
        for (var j = 0; j < stringMain.length;j++)
        ret_val += stringMain.charAt(j);
    }
    return ret_val;
};