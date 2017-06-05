﻿(function () {
    'use strict';

    angular.module('app', ['common.core', 'common.ui'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider','$locationProvider'];
    function config($routeProvider, $locationProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/app/sample/listsample.html",
                controller: "listsampleCtrl"
            })
            .when("/login", {
                templateUrl: "scripts/app/account/login.html",
                controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "scripts/app/account/register.html",
                controller: "registerCtrl"
            })
            .when("/create", {
                templateUrl: "scripts/app/sample/create.html",
                controller: "createCtrl"
            })
            .when("/samples", {
                templateUrl: "scripts/app/sample/listsample.html",
                controller: "listsampleCtrl"
            })
            .when("/samples/genre/:genreID", {
                templateUrl: "scripts/app/sample/listsample.html",
                controller: "listsampleCtrl"
            })
            .otherwise({ redirectTo: "/" });

        $locationProvider.hashPrefix('');
    }  

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            //$(".fancybox").fancybox({
            //    openEffect: 'none',
            //    closeEffect: 'none'
            //});

            //$('.fancybox-media').fancybox({
            //    openEffect: 'none',
            //    closeEffect: 'none',
            //    helpers: {
            //        media: {}
            //    }
            //});

            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('#/login');
        }
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