window.ball = window.ball || {
    xPosition: 0,
    yPosition: 0,
    stepX: 10,
    stepY: 10
};

ball.bounce = function () {
    var element = document.getElementById('circle');
    element.style.left = ball.xPosition + "px";
    element.style.top = ball.yPosition + "px";
    ball.container();
    ball.xPosition += ball.stepX;
    ball.yPosition += ball.stepY;
}
window.ball.start = function () {
    setInterval(ball.bounce, 20);
}