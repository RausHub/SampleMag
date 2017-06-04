(function (app) {
    'use strict';

    app.controller('listsampleCtrl', ['$scope', '$http', 'sampleService', '$routeParams', function ($scope, $http, sampleService, $routeParams) {
        $scope.posts = {};

        //$scope.$on('sampleService:getAllLoaded', function () {
        //    $scope.posts = sampleService.samples;
        //})

        this.OnInit = function () {
            if ($routeParams.genreID) {
                $http({
                    method: 'GET',
                    url: 'api/samples/genre/' + $routeParams.genreID,
                    data: {}
                }).then(function (response) {
                    $scope.posts = response.data;
                });
            } else {
                $http({
                    method: 'GET',
                    url: 'api/samples',
                    data: {}
                }).then(function (response) {
                    $scope.posts = response.data;
                });
            }
        }

        this.OnInit();
    }]);

})(angular.module('app'));