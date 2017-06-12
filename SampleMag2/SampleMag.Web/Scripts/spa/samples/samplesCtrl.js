(function (app) {
    'use strict';

    app.controller('samplesCtrl', samplesCtrl);

    samplesCtrl.$inject = ['$scope', 'apiService','notificationService'];

    function samplesCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-Samples';
        $scope.loadingSamples = true;
        $scope.page = 0;
        $scope.pagesCount = 0;
        
        $scope.Samples = [];

        $scope.search = search;
        $scope.clearSearch = clearSearch;

        function search(page) {
            page = page || 0;

            $scope.loadingSamples = true;

            var config = {
                params: {
                    page: page,
                    pageSize: 6,
                    filter: $scope.filterSamples
                }
            };

            apiService.get('/api/Samples/', config,
            SamplesLoadCompleted,
            SamplesLoadFailed);
        }

        function SamplesLoadCompleted(result) {
            $scope.Samples = result.data.Items;
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;
            $scope.loadingSamples = false;

            if ($scope.filterSamples && $scope.filterSamples.length)
            {
                notificationService.displayInfo(result.data.Items.length + ' Samples found');
            }
            
        }

        function SamplesLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function clearSearch() {
            $scope.filterSamples = '';
            search();
        }

        $scope.search();
    }

})(angular.module('SampleMag'));
