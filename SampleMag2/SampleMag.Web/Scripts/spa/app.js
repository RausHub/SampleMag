(function () {
    'use strict';

    angular.module('SampleMag', ['common.core', 'common.ui'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "scripts/spa/home/index.html",
                controller: "indexCtrl"
            })
            .when("/login", {
                templateUrl: "scripts/spa/account/login.html",
                controller: "loginCtrl"
            })
            .when("/register", {
                templateUrl: "scripts/spa/account/register.html",
                controller: "registerCtrl"
            })
            .when("/samples", {
                templateUrl: "scripts/spa/samples/samples.html",
                controller: "samplesCtrl"
            })
            .when("/samples/add", {
                templateUrl: "scripts/spa/samples/add.html",
                controller: "sampleAddCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/samples/:id", {
                templateUrl: "scripts/spa/samples/details.html",
                controller: "sampleDetailsCtrl",
                resolve: { isAuthenticated: isAuthenticated }
            })
            .when("/samples/edit/:id", {
                templateUrl: "scripts/spa/samples/edit.html",
                controller: "sampleEditCtrl"
            })
            .when("/user/:id/list", {
                templateUrl: "scripts/spa/user/userList.html",
                controller: "userListCtrl"
            })
            .otherwise({ redirectTo: "/" });
    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            $(".fancybox").fancybox({
                openEffect: 'none',
                closeEffect: 'none'
            });

            $('.fancybox-media').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                helpers: {
                    media: {}
                }
            });

            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }

})();