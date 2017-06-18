(function (app) {
    'use strict';

    app.controller('sampleEditCtrl', sampleEditCtrl);

    sampleEditCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService'];

    function sampleEditCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService) {
        $scope.pageClass = 'page-Samples';
        $scope.Sample = {};
        $scope.genres = [];
        $scope.loadingSample = true;
        $scope.isReadOnly = false;
        $scope.UpdateSample = UpdateSample;
        $scope.prepareFiles = prepareFiles;
        $scope.openDatePicker = openDatePicker;

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };
        $scope.datepicker = {};

        var SampleImage = null;

        function loadSample() {
            $scope.loadingSample = true;
            apiService.get('/api/Samples/details/' + $routeParams.id, null,
            SampleLoadCompleted,
            SampleLoadFailed);
        }

        function SampleLoadCompleted(result) {
            $scope.Sample = result.data;
            $scope.loadingSample = false;

            loadGenres();
        }

        function SampleLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function genresLoadCompleted(response) {
            $scope.genres = response.data;
        }

        function genresLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function loadGenres() {
            apiService.get('/api/genres/', null,
            genresLoadCompleted,
            genresLoadFailed);
        }

        function UpdateSample() {
            //if (scope.Sample.User != $scope.username) {
            //    notificationService.displayError("not your sample");
            //}
            //else {
            //    UpdateSampleModel();
            //}
            UpdateSampleModel();
        }

        function UpdateSampleModel() {
            $scope.Sample.User = $scope.username;
            apiService.post('/api/Samples/update', $scope.Sample,
            updateSampleSucceded,
            updateSampleFailed);
        }

        function prepareFiles($files) {
            SampleImage = $files;
        }

        function updateSampleSucceded(response) {
            notificationService.displaySuccess($scope.Sample.Title + ' has been updated');
            $scope.Sample = response.data;
        }

        function updateSampleFailed(response) {
            notificationService.displayError(response.data.message);
        }

        function openDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.datepicker.opened = true;
        };

        loadSample();
    }

})(angular.module('SampleMag'));
