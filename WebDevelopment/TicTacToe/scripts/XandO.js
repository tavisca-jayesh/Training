var table = document.getElementById("table");
var scoreX = 0, scoreO = 0, winner = 0, flag = true, currentRow = 0, currentCol = 0, countMoves = 0;
var winningScore = [7, 56, 448, 73, 146, 292, 273, 84];

function init() {
    table = document.getElementById("table");
    for (var i = 0; i < table.rows.length; i++) {
        for (var j = 0; j < table.rows[i].cells.length; j++)
            table.rows[i].cells[j].onclick = function () { playGame(this); };
    }
}
//reseting the Game
function reset() {
    table = document.getElementById("table");
    for (var i = 0; i < table.rows.length; i++) {
        for (var j = 0; j < table.rows[i].cells.length; j++)
            table.rows[i].cells[j].innerHTML = "<br />\xA0\xA0 <br />";
    }
    document.getElementById("displayResult").innerHTML = "";
    scoreX = 0; scoreO = 0; winner = 0; flag = true; currentRow = 0; currentCol = 0; countMoves = 0;
}

function playGame(tableCell) {
    countMoves++;
    flag = setScore(flag, tableCell);
    if (flag === false)
        document.getElementById(currentRow + "" + currentCol).innerHTML = "<br />X<br />";
    if (flag === true)
        document.getElementById(currentRow + "" + currentCol).innerHTML = "<br />O<br />";
    checkWinner();
}

function checkWinner() {
    if (winner == 2)
        document.getElementById("displayResult").innerHTML = "<b> X Wins <br />";
    else if (winner == 1)
        document.getElementById("displayResult").innerHTML = "<b> O Wins <br />";
    else if (countMoves == 9)
        document.getElementById("displayResult").innerHTML = "<b> Game Draw <br />";
    else
        return;
}

function isWinning() {
    for (var k = 0; k < winningScore.length; k += 1) {
        if ((winningScore[k] & scoreX) === winningScore[k]) {
            winner = 1;
            return winner;
        }
        if ((winningScore[k] & scoreO) === winningScore[k]) {
            winner = 2;
            return winner;
        }
    }
    winner = 0;
    return winner;
}

function setScore(flag, tableCell) {
    currentCol = parseInt(tableCell.id % 10);
    currentRow = parseInt(tableCell.id / 10);
    if (flag == false) {
        scoreX = scoreX + Math.pow(2, 3 * currentRow + currentCol);
        winner = isWinning();
        flag = true;
    }
    else {
        scoreO = scoreO + Math.pow(2, 3 * currentRow + currentCol);
        winner = isWinning();
        flag = false;
    }
    return flag;
}
window.onload = init;