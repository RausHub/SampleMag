(function (app) {
    'use strict';

    app.controller('SampleDetailsCtrl', SampleDetailsCtrl);

    SampleDetailsCtrl.$inject = ['$scope', '$location', '$routeParams', '$modal', 'apiService', 'notificationService'];

    function SampleDetailsCtrl($scope, $location, $routeParams, $modal, apiService, notificationService) {
        $scope.pageClass = 'page-Samples';
        $scope.Sample = {};
        $scope.loadingSample = true;
        $scope.loadingRentals = true;
        $scope.isReadOnly = true;
        $scope.openRentDialog = openRentDialog;
        $scope.returnSample = returnSample;
        $scope.rentalHistory = [];
        $scope.getStatusColor = getStatusColor;
        $scope.clearSearch = clearSearch;
        $scope.isBorrowed = isBorrowed;

        function loadSample() {

            $scope.loadingSample = true;

            apiService.get('/api/Samples/details/' + $routeParams.id, null,
            SampleLoadCompleted,
            SampleLoadFailed);
        }

        function loadRentalHistory() {
            $scope.loadingRentals = true;

            apiService.get('/api/rentals/' + $routeParams.id + '/rentalhistory', null,
            rentalHistoryLoadCompleted,
            rentalHistoryLoadFailed);
        }

        function loadSampleDetails() {
            loadSample();
            loadRentalHistory();
        }

        function returnSample(rentalID) {
            apiService.post('/api/rentals/return/' + rentalID, null,
            returnSampleSucceeded,
            returnSampleFailed);
        }

        function isBorrowed(rental)
        {
            return rental.Status == 'Borrowed';
        }

        function getStatusColor(status) {
            if (status == 'Borrowed')
                return 'red'
            else {
                return 'green';
            }
        }

        function clearSearch()
        {
            $scope.filterRentals = '';
        }

        function SampleLoadCompleted(result) {
            $scope.Sample = result.data;
            $scope.loadingSample = false;
        }

        function SampleLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function rentalHistoryLoadCompleted(result) {
            console.log(result);
            $scope.rentalHistory = result.data;
            $scope.loadingRentals = false;
        }

        function rentalHistoryLoadFailed(response) {
            notificationService.displayError(response);
        }

        function returnSampleSucceeded(response) {
            notificationService.displaySuccess('Sample returned to SampleMag succeesfully');
            loadSampleDetails();
        }

        function returnSampleFailed(response) {
            notificationService.displayError(response.data);
        }

        function openRentDialog() {
            $modal.open({
                templateUrl: 'scripts/spa/rental/rentSampleModal.html',
                controller: 'rentSampleCtrl',
                scope: $scope
            }).result.then(function ($scope) {
                loadSampleDetails();
            }, function () {
            });
        }

        loadSampleDetails();
    }

})(angular.module('SampleMag'));
