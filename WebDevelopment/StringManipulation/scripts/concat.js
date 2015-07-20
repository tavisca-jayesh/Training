String.prototype.Concat = function (stringtoConcat) {
    var stringMain = this,
        ret_val = stringMain;
    //concatinating Character by character
    for (i = 0; i < stringtoConcat.length; i++) {
        ret_val += stringtoConcat.charAt(i);
    }
    return ret_val;
};