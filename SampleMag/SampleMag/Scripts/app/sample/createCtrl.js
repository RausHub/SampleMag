(function (app) {
    'use strict';

    app.controller('createCtrl', createCtrl);

    createCtrl.$inject = ['$scope','$http'];

    function createCtrl($scope,$http) {
        $scope.post = {};

        $scope.savePost = function () {
            $http({
                method: 'POST',
                url: 'api/samples',
                data: {sample:$scope.post}
            }).then(function (response) {
                $scope.post = {};
                console.log(response);
            });
        }
    }

})(angular.module('app'));