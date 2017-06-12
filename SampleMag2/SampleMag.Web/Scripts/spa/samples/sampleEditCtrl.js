(function (app) {
    'use strict';

    app.controller('SampleEditCtrl', SampleEditCtrl);

    SampleEditCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService'];

    function SampleEditCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService) {
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
            if (SampleImage) {
                fileUploadService.uploadImage(SampleImage, $scope.Sample.ID, UpdateSampleModel);
            }
            else
                UpdateSampleModel();
        }

        function UpdateSampleModel() {
            apiService.post('/api/Samples/update', $scope.Sample,
            updateSampleSucceded,
            updateSampleFailed);
        }

        function prepareFiles($files) {
            SampleImage = $files;
        }

        function updateSampleSucceded(response) {
            console.log(response);
            notificationService.displaySuccess($scope.Sample.Title + ' has been updated');
            $scope.Sample = response.data;
            SampleImage = null;
        }

        function updateSampleFailed(response) {
            notificationService.displayError(response);
        }

        function openDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.datepicker.opened = true;
        };

        loadSample();
    }

})(angular.module('SampleMag'));
