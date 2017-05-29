(function (app) {
    'use strict';

    app.controller('createCtrl', createCtrl);

    createCtrl.$inject = ['$scope'];

    function createCtrl($scope) {
        $scope.data = 'create create create';
    }

})(angular.module('app'));