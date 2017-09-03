angular.module('testApp').service('moveService', ['$rootScope', function ($rootScope) {

    var self = {};

    self.init = function (pointsList) {
        pointsList.forEach(self.prepearElement);
    };

    self.prepearElement = function (element, index) {
        var ball = document.getElementById(element.id);

        ball.onmousedown = function (e) { // 1. отследить нажатие

            // подготовить к перемещению
            // 2. разместить на том же месте, но в абсолютных координатах
            ball.style.position = 'absolute';
            moveAt(e);
            // переместим в body, чтобы мяч был точно не внутри position:relative
            document.body.appendChild(ball);

            ball.style.zIndex = 1000; // показывать мяч над другими элементами

            // передвинуть мяч под координаты курсора
            // и сдвинуть на половину ширины/высоты для центрирования
            function moveAt(e) {
                    ball.style.left = e.pageX - ball.offsetWidth / 2 + 'px';
                    ball.style.top = e.pageY - ball.offsetHeight / 2 + 'px';
                    $rootScope.$broadcast('segmentWereMoved', {
                        elementId: e.currentTarget.id || e.target.id,
                        position: {
                            left: (e.pageX - ball.offsetWidth / 2),
                            top: (e.pageY - ball.offsetHeight / 2)
                        }
                    });

            }

            // 3, перемещать по экрану
            document.onmousemove = function (e) {
                console.log(e);
                moveAt(e);
            };

            // 4. отследить окончание переноса
            ball.onmouseup = function () {
                document.onmousemove = null;
                ball.onmouseup = null;
            };

        };
    };

    return self;
}]);