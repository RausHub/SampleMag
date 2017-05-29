(function () {
    'use strict';

    angular.module('app', ['common.core'])
        .config(config)

    config.$inject = ['$routeProvider','$locationProvider'];
    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/app/home/index.html",
                controller: "indexCtrl"
            })
            .when("/login", {
                templateUrl: "scripts/app/account/login.html",
                controller: "loginCtrl"
            })
            .when("/create", {
                templateUrl: "scripts/app/sample/create.html",
                controller: "createCtrl"
            })
            .otherwise({ redirectTo: "/" });

        $locationProvider.hashPrefix('');
    }    
})();

//var app = angular.module("app", ['ngRoute']);



//app.controller("testController", ['$scope', '$location', function ($scope, $location) {


//    $scope.data = "test";


//}]);

////RouteProviders
//app.config(function ($routeProvider) {
//    $routeProvider
//        .when('/', {
//            controller: 'testController',
//            templateUrl: '~/Scripts/app/sample/listsample.html'
//        })
//        .when('/create', {
//            controller: 'testController',
//            templateUrl: '~/Scripts/app/sample/create.html'
//        })
//        //.when('/login', {
//        //    controller: 'SmagController',
//        //    templateUrl: 'login.html'
//        //})
//        //.when('/register', {
//        //    controller: 'SmagController',
//        //    templateUrl: 'register.html'
//        //})
//        .otherwise({
//            redirectTo: '/'
//        });
//});