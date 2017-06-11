(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope', '$http'];

    function indexCtrl($scope, $http) {
        $scope.genres = [];

        this.OnInit = function () {
            $http({
                method: 'GET',
                url: 'api/MusicGenres',
                data: {}
            }).then(function (response) {
                $scope.genres = response.data;
            });            
        }

        this.OnInit();
    }

})(angular.module('app'));