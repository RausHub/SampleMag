(function(app){
    'use strict';
    
    app.directive('navbar', navBar);
    
    function navBar(){
        return{
            restrict: 'E',
            replace: true,
            templateUrl: '/scripts/app/layout/navBar.html'
        }
    }
}) (angular.module('common.ui'));