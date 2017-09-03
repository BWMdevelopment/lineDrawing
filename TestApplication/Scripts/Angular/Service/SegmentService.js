angular.module('testApp').service('segmentService', ['$http', 'apiUrlFactory', '$rootScope', function ($http, apiUrlFactory, $rootScope ) {

    var self = this;

    self.GetSegmentFromServer = function () {
        $http.get(apiUrlFactory.GetSegment).then(function (response) {
            $rootScope.$broadcast('segmentWereGetted', response.data);
        });
    };
    self.SaveSegmentOnServer = function (segmentData) {
        self.segmentData = segmentData;
        $http.post(apiUrlFactory.SaveSegment, { pointsList: self.segmentData}, null).then(function (response) {
            var success = response.data;
        });
    };
    self.createElementForSegment = function (elementId, element, parentId) {
        $("#" + parentId).
            append("<div id='" + elementId + "' style='top:" + element.Y + ";left:" + element.X + ";' class='segmentPoint'/>");
    }
    return self;
}]);