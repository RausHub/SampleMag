(function(app) {
    app.service("sampleService", function ($http, $rootScope) {

        var service = this;

        service.samples = {}
        
        service.getall = function () {
            $http({
                method: 'GET',
                url: 'api/samples',
                data: {}
            }).then(function (response) {
                service.samples = response.data;
                console.log(service.samples);
                $rootScope.$broadcast('sampleService:getAllLoaded');
            });
        }

        service.getall();
    });   
})(angular.module('app'));