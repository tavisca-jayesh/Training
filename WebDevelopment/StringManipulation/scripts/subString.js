String.prototype.SubString = function (startPosition, endPosition) {
    var stringMain = this,
        i = 0,
        ret_val = "";

    if (startPosition >= stringMain.length || startPosition < 0) {
        alert('Starting index out of bounds!');
        return;
    }
    if (endPosition >= stringMain.length || endPosition < startPosition) {
        alert('Entered End Index is out of bounds');
        return;
    }
    endPosition++;
    startPosition--;
    //building string character by character
    for (i = startPosition; i < endPosition; i++) {

        ret_val += stringMain.charAt(i);
    }
    return ret_val;
};