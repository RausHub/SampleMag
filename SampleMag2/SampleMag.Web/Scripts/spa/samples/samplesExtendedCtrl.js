(function (app) {
    'use strict';

    app.controller('samplesExtendedCtrl', samplesExtendedCtrl);

    samplesExtendedCtrl.$inject = ['$scope', '$http', 'apiService', 'notificationService'];

    function samplesExtendedCtrl($scope, $http, apiService, notificationService) {       

        $scope.loadingSamples = true;
        $scope.VoteSample = voteSample;
        $scope.Samples = [];
        $scope.selectedGenre = 0;

        $scope.search = search;
        $scope.clearSearch = clearSearch;
        $scope.GenreChanged = genreChanged;

        function search() {            
            $scope.loadingSamples = true;
            $scope.Samples = [];
            if ($scope.selectedGenre) {
                apiService.get('/api/Samples/genre/' + $scope.selectedGenre, null,
                    SamplesLoadCompleted,
                    SamplesLoadFailed);
            } else {
                apiService.get('/api/Samples/genre/0', null,
                    SamplesLoadCompleted,
                    SamplesLoadFailed);
            }
        }

        function SamplesLoadCompleted(result) {
            $scope.Samples = result.data;
            $scope.loadingSamples = false;            
            notificationService.displayInfo('Samples found');          
        }

        function SamplesLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.filterSamples = '';
            $scope.selectedGenre = 0;
            search();
        }

        function voteSample(Sample) {
            apiService.post('/api/Samples/upvote', Sample,
                VotedSucces,
                VotedFailed);
        }

        function VotedSucces() {
            notificationService.displaySuccess("Thank you for your vote");
        }

        function VotedFailed(response) {
            notificationService.displayError(response.data);
        }

        function genreChanged() {
            search();
        }

        $scope.search();
    }

})(angular.module('SampleMag'));
