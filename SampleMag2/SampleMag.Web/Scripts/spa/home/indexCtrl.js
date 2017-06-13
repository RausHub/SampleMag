(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope','apiService', 'notificationService'];

    function indexCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home';
        $scope.loadingSamples = true;
        $scope.loadingGenres = true;
        $scope.isReadOnly = true;
        

        $scope.latestSamples = [];
        $scope.loadData = loadData;
        $scope.VoteSample = voteSample;

        function loadData() {
            apiService.get('/api/Samples/popular', null,
                        SamplesLoadCompleted,
                        SamplesLoadFailed);

            apiService.get("/api/genres/", null,
                genresLoadCompleted,
                genresLoadFailed);
        }

        function SamplesLoadCompleted(result) {
            console.log(result);
            $scope.latestSamples = result.data;
            $scope.loadingSamples = false;
        }

        function genresLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function SamplesLoadFailed(response) {
            notificationService.displayError(response.data);
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

        function genresLoadCompleted(result) {
            var genres = result.data;
            Morris.Bar({
                element: "genres-bar",
                data: genres,
                xkey: "Name",
                ykeys: ["NumberOfSamples"],
                labels: ["Number Of Samples"],
                barRatio: 0.4,
                xLabelAngle: 55,
                hideHover: "auto",
                resize: 'true'
            });
            //.on('click', function (i, row) {
            //    $location.path('/genres/' + row.ID);
            //    $scope.$apply();
            //});

            $scope.loadingGenres = false;
        }

        loadData();
    }

})(angular.module('SampleMag'));
