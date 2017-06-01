(function (app) {
    'use strict';

    //app.service("sampleService", function ($http) {
        
    //    this.getall = function() {
    //        $http({
    //            method: 'GET',
    //            url: 'api/samples',
    //            data: {}
    //        }).then(function (response) {                
    //            console.log(response);
    //            return response.data;
    //        });     
    //    }        
    //});    

    app.controller('listsampleCtrl', ['$scope', '$http', 'sampleService', function ($scope, $http, sampleService) {
        $scope.posts = {};

        $scope.$on('sampleService:getAllLoaded', function () {
            $scope.posts = sampleService.samples;
        })

        console.log($scope.posts);
        //var onInit = function () {
        //    var x = 
        //    console.log("Dit is object", x);           
        //}

        //onInit(); }]);
    }]);


})(angular.module('app'));