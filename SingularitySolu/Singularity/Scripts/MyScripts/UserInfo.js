var app = angular.module('UserInfoApp', []);
app.controller('UserInfoCtrl', function ($scope, $http) {
    //alert("Test");
    //$scope.UserId = 0;

    $scope.loadPage = function () {
        $scope.userInformationList();
        $scope.UserInformation();
        $scope.GetSettings();
    }

    $scope.formSubmit = function () {
        $http.post('/Api/UserInformationApi/AddOrEditUser', $scope.userInfo).then(function (res) {
            alert(res.data.ErrorHtml);
            if (res.data.HasError == false) {
                $scope.userInfo = {};
                $scope.loadPage();
            }
        });
    }

    $scope.UserInformation = function () {
        $http.get('/Api/UserInformationApi/GetUserById', { params: { "id": 0 } }).then(function (result) {
            $scope.userInfo = result.data.Data;
            $scope.roleList = result.data.DataExtra.RoleList;
            //console.log(result.data.DataExtra.RoleList);
            //console.log($scope.userInfo);
        });
    };

    $scope.userInformationList = function () {
        $http.get('/Api/UserInformationListApi/GetUserList').then(function (result) {
            $scope.userInfoList = result.data.Data;
        });
    };

    $scope.getUserInformationById = function (userId) {
        $http.get('/Api/UserInformationApi/GetUserById', { params: { "id": userId } }).then(function (result) {
            $scope.userInfo = result.data.Data;
            $scope.roleList = result.data.DataExtra.RoleList;
            $scope.roleList.RoleId = $scope.userInfo.RoleId;
          
            //console.log(result.data.DataExtra.RoleList);
            //console.log($scope.userInfo);
        });
    };

    $scope.deleteUserByUserId = function (userId) {

        if (confirm("Are You Sure To Delete!") == true) {
            $http.delete('/Api/UserInformationApi/DeleteUserById', { params: { "id": userId } }).then(function (result) {
                $scope.loadPage();
                alert("Deleted Successfully !");
            });
        } else {
            alert("Not Deleted");
        }
    };

    $scope.viewUserInformationById=function(userId){
        $http.get('/Api/UserInformationApi/GetUserById', { params: { "id": userId } }).then(function (result) {
            $scope.singleUserInfo = result.data.Data;
           
        });
    }

    $scope.GetSettings = function () {
        $http.get('/Api/SettingsApi/GetSettings').then(function (result) {
            $scope.setting = result.data.Data;
        });
    };

    $scope.saveSettings = function () {
        $scope.setting;

        $http.post('/Api/SettingsApi/SaveSettings', $scope.setting).then(function (res) {
            alert("Saved Successfully");
            $scope.loadPage();
        });
    };





    $scope.loadPage();

});