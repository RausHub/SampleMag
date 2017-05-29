(function (app) {
    'use strict';

    app.controller('loginCtrl', loginCtrl);

    loginCtrl.$inject = ['$scope', 'membershipService', 'notificationService','$rootScope', '$location'];

    function loginCtrl($scope, membershipService, notificationService, $rootScope, $location) {
        $scope.data = 'page-login';
       
    }

})(angular.module('common.core'));