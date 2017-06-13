(function (app) {
    'use strict';

    app.controller('sampleDetailsCtrl', sampleDetailsCtrl);

    sampleDetailsCtrl.$inject = ['$scope', '$location', '$routeParams', '$modal', 'apiService', 'notificationService'];

    function sampleDetailsCtrl($scope, $location, $routeParams, $modal, apiService, notificationService) {
        $scope.pageClass = 'page-Samples';
        $scope.Sample = {};
        $scope.loadingSample = true;
        $scope.isReadOnly = true;
        $scope.clearSearch = clearSearch;

        function loadSample() {
            $scope.loadingSample = true;
            apiService.get('/api/Samples/details/' + $routeParams.id, null,
            SampleLoadCompleted,
            SampleLoadFailed);
        }

        function loadSampleDetails() {
            loadSample();
            loadRentalHistory();
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

        loadSampleDetails();
    }

})(angular.module('SampleMag'));
