(function (app) {
    'use strict';

    app.controller('listsampleCtrl', listsampleCtrl);

    app.factory("sampleService", function () {
        return $resource('api/sample/:sample',
            { sample: "@sample" });
    });    

    listsampleCtrl.$inject = ['$scope','$http'];

    function listsampleCtrl($scope,$http) {

        $scope.posts = [];

        var onInit = function () {
            $http({
                method: 'GET',
                url: 'api/Samples'
            }).then(function (response) {
                console.log(response);
                $scope.posts = response.data;
            });
        }

        onInit();

        $scope.detail = sampleService.get({ sample: parseInt($scope.sampleId) });
    }

})(angular.module('app'));