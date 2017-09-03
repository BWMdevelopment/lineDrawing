angular.module('testApp').controller('interfaceController', ['$scope', 'segmentService', '$rootScope', 'moveService',
    function ($scope, segmentService, $rootScope, moveService) {
        var self = {};
        self.segmentData = {};

        self.init = function () {
            segmentService.GetSegmentFromServer();
            moveService.init(['element1', 'element2']);
        };

        self.updateSegment = function () {
            segmentService.GetSegmentFromServer();
        };
        self.saveSegment = function () {
            segmentService.SaveSegmentOnServer(self.segmentData.CoordinatesList);
        };

        $rootScope.$on('segmentWereGetted', function (event, data) {
            self.segmentData = data;
            console.log(data);             
        });
        return self;
    }]
);