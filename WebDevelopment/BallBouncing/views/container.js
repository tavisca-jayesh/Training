window.ball = window.ball || {}

ball.container = function () {

    var height = (window.innerHeight - 50);
    var width = (window.innerWidth - 50);
    if (ball.yPosition >= height) {
        ball.stepY = -10;
    }
    if (ball.xPosition >= width) {
        ball.stepX = -10;
    }
    if (ball.yPosition <= 0) {
        ball.stepY = 10;
    }
    if (ball.xPosition <= 0) {
        ball.stepX = 10;
    }
}

