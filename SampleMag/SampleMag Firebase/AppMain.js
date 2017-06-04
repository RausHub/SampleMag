(function () {
    'use strict';
 
    angular.module('SampleMag', ['common.core', 'common.ui'])
        .config(config);
 
    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/home/index.html",
                controller: "indexCtrl"
            })
            .when("/login", {
                templateUrl: "scripts/account/login.html",
                controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "scripts/account/register.html",
                controller: "registerCtrl"
            })
            .when("/users", {
                templateUrl: "users/users.html",
                controller: "usersCtrl"
            })
            .when("/users/register", {
                templateUrl: "users/register.html",
                controller: "usersRegCtrl"
            })
            .when("/samples", {
                templateUrl: "samples/samples.html",
                controller: "samplesCtrl"
            })
            .when("/samples/add", {
                templateUrl: "samples/add.html",
                controller: "sampleAddCtrl"
            })
            .when("/samples/:id", {
                templateUrl: "samples/details.html",
                controller: "movieDetailsCtrl"
            })
            .when("/samples/edit/:id", {
                templateUrl: "samples/edit.html",
                controller: "movieEditCtrl"
            }).otherwise({ redirectTo: "/" });
    }
 
})();