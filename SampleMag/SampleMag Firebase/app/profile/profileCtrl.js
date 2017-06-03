(function (app) {
    'use strict';
 
    app.controller('profileCtrl', profileCtrl);
 
    customersCtrl.$inject = ['$scope','$modal', 'apiService', 'notificationService'];
 
    function profileCtrl($scope, $modal, apiService, notificationService) {
        $scope.pageClass = 'page-profile';
        $scope.loadprofile = true;
        $scope.page = 0;
        $scope.users = [];
        $scope.openEditDialog = openEditDialog;
 
        function openEditDialog(profile) {
            $scope.Editedprofile = profile;
            $modal.open({
                templateUrl: 'scripts/app/profile/editProfile.html',
                controller: 'profileEditCtrl',
                scope: $scope
            }).result.then(function ($scope) {
                clearSearch();
            }, function () {
            });
        }
 
        function profileLoadCompleted(result) {
            $scope.user = result.data.Item;
            $scope.page = result.data.Page;
            $scope.loadingProfile = false;
 
        }
 
        function profileLoadFailed(response) {
            notificationService.displayError(response.data);
        }
 
    }
 
})(angular.module('app'));