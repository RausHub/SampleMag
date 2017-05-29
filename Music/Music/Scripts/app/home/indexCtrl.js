(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope'];

    function indexCtrl($scope) {
        $scope.data = 'komaan is da hier een feestjeuh ofwa';
    }

})(angular.module('app'));