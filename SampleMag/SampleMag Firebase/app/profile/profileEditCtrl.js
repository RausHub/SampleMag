(function (app) {
    'use strict';
 
    app.controller('profileEditCtrl', profileEditCtrl);
 
    customerEditCtrl.$inject = ['$scope', '$modalInstance','$timeout', 'apiService', 'notificationService'];
 
    function profileEditCtrl($scope, $modalInstance, $timeout, apiService, notificationService) {
 
        $scope.cancelEdit = cancelEdit;
        $scope.updateProfile = updateProfile;
 
        function updateProfile()
        {
            console.log($scope.EditedProfile);
            apiService.post('/api/profile/update/', $scope.EditedProfile,
            updateProfileCompleted,
            updateProfileLoadFailed);
        }
 
        function updateProfileCompleted(response)
        {
            notificationService.displaySuccess($scope.EditedProfile.username + ' has been updated');
            $scope.EditedProfile = {};
            $modalInstance.dismiss();
        }
 
        function updateProfileLoadFailed(response)
        {
            notificationService.displayError(response.data);
        }
 
        function cancelEdit() {
            $scope.isEnabled = false;
            $modalInstance.dismiss();
        }
 
       
        };
 
    }
 
})(angular.module('app'));