
var app = angular.module('logInApp', []);
app.controller('logInCtrl', function ($scope, $http) {
    //alert("Test");
    $scope.loadPage = function () {
        //$scope.userInformationList();
    }
    $scope.LogIn = {
        Email: '',
        Password: ''
    }

    $scope.GetAuth = function (LogIn) {
        $http.post('/LogIn/Auth', LogIn).then(function (res) {

            if (res.data.status == true) {
                window.location.pathname = '/UserInformation/User';
            }
            else {
                alert("Invelid User Name Or Password !");
            }
            //$scope.loadPage();
            //alert("Undo Successfully !");
        });
    };



    //$scope.userInformationList = function () {
    //    $http.get('/Api/RecoveryApi/GetDeleteUserList').then(function (result) {
    //        $scope.userInfoList = result.data.Data;
    //    });
    //};




    $scope.loadPage();
});