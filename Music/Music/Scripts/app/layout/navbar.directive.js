(function(app){
    'use strict';
    
    app.directive('navbar', navBar);
    
    function navBar($http){
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/app/layout/navBar.html',

            controller: function ($scope) {
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
        }
    }
}) (angular.module('common.ui'));