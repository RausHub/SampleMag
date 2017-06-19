(function (app) {
    'use strict';

    app.controller('userListCtrl', userListCtrl);

    userListCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function userListCtrl($scope, apiService, notificationService) {
        $scope.pageClass = 'page-home';
        $scope.loadingSamples = true;
        $scope.loadingGenres = true;
        $scope.isReadOnly = true;


        $scope.Samples = [];
        $scope.loadData = loadData;
        $scope.DeleteSample = deleteSample;

        function loadData() {
            apiService.get('/api/samples/user?username='+$scope.username, null,
                samplesLoadCompleted,
                samplesLoadFailed);
        }

        function samplesLoadCompleted(result) {            
            $scope.Samples = result.data;
            $scope.loadingSamples = false;
        }
       
        function samplesLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function deleteSample(Sample) {
            apiService.post('/api/samples/delete', Sample,
                deleteSucces,
                deleteFailed);
        }

        function deleteSucces() {
            notificationService.displaySuccess("Sample is deleted");
            loadData();
        }

        function deleteFailed(response) {
            notificationService.displayError(response.data);
        }        

        loadData();
    }

})(angular.module('SampleMag'));