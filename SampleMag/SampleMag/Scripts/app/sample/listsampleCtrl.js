(function (app) {
    'use strict';

    app.controller('listsampleCtrl', ['$scope', 'apiService', '$routeParams', 'notificationService', function ($scope, apiService, $routeParams, notificationService) {
        $scope.posts = {};

        this.OnInit = function () {
            //if ($routeParams.genreID) {
            //    apiService.get('api/samples/genre/' + $routeParams.genreID, {}, samplesLoaded, samplesLoadedFailed);
            //} else {
            //    apiService.get('api/samples', {}, samplesLoaded, samplesLoadedFailed);
            //}
        }

        function samplesLoaded(result) {
            $scope.posts = result.data;
        }

        function samplesLoadedFailed(result) {
            notificationService.displayError(result.data);
        }

        this.OnInit();
    }]);

})(angular.module('app'));