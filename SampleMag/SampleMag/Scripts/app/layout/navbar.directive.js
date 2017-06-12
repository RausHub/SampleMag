(function(app){
    'use strict';
    
    app.directive('navbar' , navBar);
    
    function navBar($http, apiService, notificationService){
        return {
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/app/layout/navBar.html',

            controller: function ($scope) {
                $scope.genres = [];

                this.OnInit = function () {
                    apiService.get('api/genres', null, loadGenresSucces, loadGenresFailed);
                    //$http({
                    //    method: 'GET',
                    //    url: 'api/genres',
                    //    data: {}
                    //}).then(function (response) {
                    //    console.log(response);
                    //    $scope.genres = response.data;
                    //});
                }

                function loadGenresSucces(result) {
                    console.log(result);
                    $scope.genres = response.data;
                }

                function loadGenresFailed(result) {
                    notificationService.displayError(result.data);
                }

                this.OnInit();
            }
        }
    }
}) (angular.module('common.ui'));