angular.module('testApp').controller('interfaceController', ['$scope', 'segmentService', '$rootScope',
    function ($scope, segmentService, $rootScope ) {
        var self = {};
        self.segmentData = {};

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
            console.log(data);             
        });
        return self;
    }]
);