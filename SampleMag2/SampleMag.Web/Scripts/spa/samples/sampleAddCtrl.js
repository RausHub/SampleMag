(function (app) {
    'use strict';

    app.controller('sampleAddCtrl', sampleAddCtrl);

    sampleAddCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService'];

    function sampleAddCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService) {

        $scope.pageClass = 'page-Samples';
        $scope.Sample = { GenreId: 1, Rating: 1 };

        $scope.genres = [];
        $scope.isReadOnly = false;
        $scope.AddSample = AddSample;
        $scope.openDatePicker = openDatePicker;

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };
        $scope.datepicker = {};

        var SampleImage = null;

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
            apiService.post('/api/Samples/add', $scope.Sample,
            addSampleSucceded,
            addSampleFailed);
        }
        
        function addSampleSucceded(response) {
            notificationService.displaySuccess($scope.Sample.Title + ' has been submitted to SampleMag');
            $scope.Sample = response.data;

            if (SampleImage) {
                fileUploadService.uploadImage(SampleImage, $scope.Sample.ID, redirectToEdit);
            }
            else
                redirectToEdit();
        }

        function addSampleFailed(response) {
            console.log(response);
            notificationService.displayError(response.statusText);
        }

        function openDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.datepicker.opened = true;
        };

        function redirectToEdit() {
            $location.url('Samples/edit/' + $scope.Sample.ID);
        }
        
        loadGenres();
    }

})(angular.module('SampleMag'));
