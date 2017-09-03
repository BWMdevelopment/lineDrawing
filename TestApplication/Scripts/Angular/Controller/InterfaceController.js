angular.module('testApp').controller('interfaceController', ['$scope', 'segmentService', '$rootScope', 'moveService', 'lineService',
    function ($scope, segmentService, $rootScope, moveService, lineService) {
        var self = this;
        self.segmentData = {};
        isInitialized = false;

        self.init = function () {
            segmentService.GetSegmentFromServer();

        };

        self.updateSegment = function () {
            segmentService.GetSegmentFromServer();
        };
        self.saveSegment = function () {
            segmentService.SaveSegmentOnServer(self.segmentData.CoordinatesList);
        };

        $rootScope.$on('segmentWereGetted', function (event, data) {
            self.segmentData = data;
            if (!isInitialized) {
                for (var i = 0; i < self.segmentData.CoordinatesList.length; i++) {
                    segmentService.createElementForSegment('element' + (i + 1), self.segmentData.CoordinatesList[i], 'segmewntWorkSpace');
                    self.segmentData.CoordinatesList[i].id = 'element' + (i + 1);
                };
                lineService.appendLine(self.segmentData.CoordinatesList);
                isInitialized = true;
            }
            moveService.init(self.segmentData.CoordinatesList);
        });

        $rootScope.$on('segmentWereMoved', function (event, data) {
            for (var i = 0; i < self.segmentData.CoordinatesList.length; i++) {
                if (self.segmentData.CoordinatesList[i].id === data.elementId) {
                    $scope.$apply(function () {
                        self.segmentData.CoordinatesList[i].X = data.position.left;
                        self.segmentData.CoordinatesList[i].Y = data.position.top;
                        lineService.appendLine(self.segmentData.CoordinatesList);
                    });
                }
            }
        });

        return self;
    }]
);