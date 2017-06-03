(function (app) {
    'use strict';

    app.controller('indexCtrl', indexCtrl);

    indexCtrl.$inject = ['$scope', 'apiService', 'notificationService'];

    function indexCtrl($scope) {
        //$scope.data = 'komaan is da hier een feestjeuh ofwa';
        $scope.pageClass = 'page-home';
        $scope.isReadOnly = true;
        $scope.votes = [];
        $scope.loadData = loadData;
        
        function loadData(){
            apiService.get('/api/samples/', null,
                          samplesLoadCompleted,
                          samplesLoadFailed);
            apiService.get('/api/genres/', null
                          genresLoadCompleted,
                          genresLoadFailed);
        }
        
        function samplesLoadCompleted(result){
            $scope.samples = result.data;
            $scope.loadingSamples = false;
        }
        
        function genresLoadFailed(response){
            notificationService.displayError(response.data);
        }
        
        function genresLoadCompleted(result){
            var genres = result.data;
            $scope.loadingGenres = false;
        }
        
        loadData();
    }

})(angular.module('app'));