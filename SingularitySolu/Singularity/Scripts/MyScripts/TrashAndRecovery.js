var app = angular.module('trashRecoveryApp', []);
app.controller('trashRecoveryCtrl', function ($scope, $http) {
    //alert("Test");
    $scope.loadPage = function () {
        $scope.userInformationList();
    }
    $scope.userInformationList = function () {
        $http.get('/Api/RecoveryApi/GetDeleteUserList').then(function (result) {
            $scope.userInfoList = result.data.Data;
        });
    };

    $scope.recoveryUserInformationById = function (user) {
        $http.post('/Api/RecoveryApi/UndoUser', user).then(function (res) {
            $scope.loadPage();
            alert("Undo Successfully !");
        });
    };


    $scope.loadPage();
});