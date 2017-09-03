angular.module('testApp').service('lineService', ['$rootScope', function ($rootScope) {

    self.appendLine = function (pointsList) {
        drawLine(getOffsets(pointsList));
    };

    getOffsets = function (pointsList) {
        var offsets = [];
        offsets[0] = $('#' + pointsList[0].id).offset();
        offsets[1] = $('#' + pointsList[1].id).offset();
        return offsets;
    }
    pow2 = function (n) {
        return n * n;
    }

    drawLine = function (pointsList) {
        var dist = Math.sqrt(pow2(pointsList[0].left - pointsList[1].left) + pow2(pointsList[0].top - pointsList[1].top));
        var l = document.getElementById("line");
        var cos = (pointsList[1].left - pointsList[0].left) / Math.sqrt(pow2(pointsList[1].left - pointsList[0].left) + pow2(pointsList[1].top - pointsList[0].top));
        var behind = pointsList[0].left < pointsList[1].left;
        var higher = pointsList[0].top > pointsList[1].top;
        l.style.width = (dist * 2) + "px";
        l.style.left = (pointsList[0].left - dist) + "px";
        l.style.top = (pointsList[0].top) + "px";

        l.style.transform = "rotateZ(" + (higher ? -1 : 1) * Math.acos(cos) * (180 / Math.PI) + "deg)";
    };

    return self;
}]);