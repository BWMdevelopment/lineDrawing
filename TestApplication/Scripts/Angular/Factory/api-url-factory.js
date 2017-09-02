angular.module('testApp').factory('apiUrlFactory', [function () {

    var me = this;

    me.GetSegment = '/Home/GetSegment';
    me.SaveSegment = '/Home/SaveSegment';

    return me;
}]);