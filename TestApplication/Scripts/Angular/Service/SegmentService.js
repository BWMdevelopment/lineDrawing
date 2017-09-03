angular.module('testApp').service('segmentService', ['$http', 'apiUrlFactory', '$rootScope', function ($http, apiUrlFactory, $rootScope ) {

    var self = this;

    self.GetSegmentFromServer = function () {
        $http.get(apiUrlFactory.GetSegment).then(function (response) {
            $rootScope.$broadcast('segmentWereGetted', response.data);
        });
    };
    self.SaveSegmentOnServer = function (segmentData) {
        self.segmentData = segmentData;
        $http.post(apiUrlFactory.SaveSegment, { pointsList: [{ X: 45, Y:15 }, { X:6, Y:85}]}, null).then(function (response) {
            var success = response.data;
        });
    };
    self.createElementForSegment = function (elementId, element, parentId) {
        $("#" + parentId).
            append("<div id='" + elementId + "' style='border-radius: 5px;width: 10px;background: white;position: absolute;height: 10px;top:" + element.Y + ";left:" + element.X + ";' />");
    }
    return self;
}]);