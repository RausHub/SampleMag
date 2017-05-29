(function (app) {
    'use strict';

    app.controller('listsampleCtrl', listsampleCtrl);

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
    }

})(angular.module('app'));