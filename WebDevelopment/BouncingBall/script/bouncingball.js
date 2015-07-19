var step = 5;
var interval = 0;
var timeout = 10;
var yFlag = false;
var xFlag = false;
var xPosition = 20;
var yPosition = 20;
var containerHeight = 0;
var containerWidht = 0;

function displacingBall()
{
    //setting container Height and width
    containerHeight = window.innerHeight - 100;
    containerWidht = window.innerWidth - 100;

    //setting initial position
    document.getElementById('ball').style.top = yPosition;
    document.getElementById('ball').style.left = xPosition;

    if (yFlag) {
        yPosition = yPosition + step;
    }
    else {
        yPosition = yPosition - step;
    }

    if (yPosition < 0) {
        yFlag = true;
        yPosition = 0;
    }

    if (yPosition >= (containerHeight)) {
        yFlag = false;
        yPosition = (containerHeight);
    }

    if (xFlag) {
        xPosition = xPosition + step;
    }
    else {
        xPosition = xPosition - step;
    }

    if (xPosition < 0) {
        xFlag = true;
        xPos = 0;
    }

    if (xPosition >= (containerWidht)) {
        xFlag = false;
        xPosition = (containerWidht);
    }
}

function start() {
    interval = setInterval(displacingBall, timeout);
}

window.onclick = start;