(function (app) {
    'use strict';

    app.controller('SampleAddCtrl', SampleAddCtrl);

    SampleAddCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService', 'fileUploadService'];

    function SampleAddCtrl($scope, $location, $routeParams, apiService, notificationService, fileUploadService) {

        $scope.pageClass = 'page-Samples';
        $scope.Sample = { GenreId: 1, Rating: 1, NumberOfStocks: 1 };

        $scope.genres = [];
        $scope.isReadOnly = false;
        $scope.AddSample = AddSample;
        $scope.prepareFiles = prepareFiles;
        $scope.openDatePicker = openDatePicker;
        $scope.changeNumberOfStocks = changeNumberOfStocks;

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

        function prepareFiles($files) {
            SampleImage = $files;
        }

        function addSampleSucceded(response) {
            notificationService.displaySuccess($scope.Sample.Title + ' has been submitted to Home Cinema');
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

        function changeNumberOfStocks($vent)
        {
            var btn = $('#btnSetStocks'),
            oldValue = $('#inputStocks').val().trim(),
            newVal = 0;

            if (btn.attr('data-dir') == 'up') {
                newVal = parseInt(oldValue) + 1;
            } else {
                if (oldValue > 1) {
                    newVal = parseInt(oldValue) - 1;
                } else {
                    newVal = 1;
                }
            }
            $('#inputStocks').val(newVal);
            $scope.Sample.NumberOfStocks = newVal;
            console.log($scope.Sample);
        }

        loadGenres();
    }

})(angular.module('SampleMag'));
