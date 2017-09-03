angular.module('testApp').service('moveService', ['$rootScope', function ($rootScope) {

    var self = this;
    self.elementsList = [];
    self.borderCoordinates = {
        left:0,
        right:0,
        top:0,
        bottom:0
    };
    self.init = function (pointsList) {
        self.createBorders(pointsList[0]);
        pointsList.forEach(self.prepearElement);
    };
    self.createBorders = function (id) {
        var element = $('#' + id);
        createLeftTopBorder(element)
        createRightBottomBorder(element)
        
    }
    createLeftTopBorder = function (element) {
        var offsets = element.offset();
        self.borderCoordinates.left = offsets.left;
        self.borderCoordinates.top = offsets.top;
    }
    createRightBottomBorder = function (element) {
        var parent = element.parent();
        self.borderCoordinates.right = self.borderCoordinates.left + parent.offsetWidth;
        self.borderCoordinates.bottom = self.borderCoordinates.top + parent.offsetHeight;
    };
    IsElementInBorders = function (element) {
        var a = element.pageX > self.borderCoordinates.left;

        var a = element.pageX < self.borderCoordinates.right;
        var a = element.pageY > self.borderCoordinates.top;
        var a = element.pageY < self.borderCoordinates.bottom;
    };
    self.prepearElement = function (id, index) {
        var ball = document.getElementById(id);

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
            }

            // 3, перемещать по экрану
            document.onmousemove = function (e) {
                    moveAt(e);
            };

            // 4. отследить окончание переноса
            ball.onmouseup = function () {
                document.onmousemove = null;
                ball.onmouseup = null;
            };
            ball.ondragstart = function () {
                return false;
            };
        };
    };

    return self;
}]);