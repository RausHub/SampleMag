//(function (app) {
//    'use strict';
//
//    app.controller('createCtrl', createCtrl);
//
//    createCtrl.$inject = ['$scope'];
//
//    function createCtrl($scope) {
//        $scope.data = 'create create create';
//    }
//
//})(angular.module('app'));

(function (app) {
    'use strict';
 
    app.controller('createCtrl', createCtrl);
 
    createCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService'];
 
    function createCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService) {
 
        $scope.pageClass = 'page-samples';
        $scope.sample = { GenreId: 1};
 
        $scope.genres = [];
        $scope.isReadOnly = false;
        $scope.AddSample = AddSample;
        $scope.prepareFiles = prepareFiles;
        $scope.votes = [];
 
        function loadGenres() {
            apiService.get('/api/genres/', null,
            genresLoadCompleted,
            genresLoadFailed);
        }
 
        function genresLoadCompleted(response) {
            $scope.genres = response.data;
        }
 
        function genresLoadFailed(response) {
            notificationService.displayError(response.data);
        }
 
        function AddSample() {
            AddSampleModel();
        }
 
        function AddSampleModel() {
            apiService.post('/api/samples/add', $scope.sample,
            addSampleSucceded,
            addSampleFailed);
        }
 
        function addSampleSucceded(response) {
            notificationService.displaySuccess($scope.Sample.Title + ' has been submitted!');
            $scope.sample = response.data;
        }
 
        function addSampleFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }
 
        loadGenres();
    }
 
})(angular.module('app'));