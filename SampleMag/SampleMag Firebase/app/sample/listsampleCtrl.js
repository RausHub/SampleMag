(function (app) {
    'use strict';

    app.controller('listsampleCtrl', listsampleCtrl);

    app.factory("sampleService", function () {
        return $resource('api/sample/:sample',
            { sample: "@sample" });
    });    

    listsampleCtrl.$inject = ['$scope','$http'];

    function listsampleCtrl($scope,$http) {

        $scope.posts = [];

        var onInit = function () {
            $http({
                method: 'GET',
                url: 'api/Samples'
            }).then(function (response) {
                console.log(response);
                $scope.posts = response.data;
            });
        }

        onInit();

        $scope.detail = sampleService.get({ sample: parseInt($scope.sampleId) });
    }

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
            samplesLoadCompleted,
            samplesLoadFailed);
        }
 
        function samplesLoadCompleted(result) {
            $scope.Samples = result.data.Items;
            $scope.page = result.data.Page;
            $scope.pagesCount = result.data.TotalPages;
            $scope.totalCount = result.data.TotalCount;
            $scope.loadingSamples = false;
 
            if ($scope.filterSamples && $scope.filterSamples.length)
            {
                notificationService.displayInfo(result.data.Items.length + ' samples found');
            }
             
        }
 
        function samplesLoadFailed(response) {
            notificationService.displayError(response.data);
        }
 
        function clearSearch() {
            $scope.filterSamples = '';
            search();
        }
 
        $scope.search();
    }
    
})(angular.module('app'));