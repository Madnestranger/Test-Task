(function () {
    'use strict';

    angular.module('app',['datatables']);


    angular.module('app').controller('gridCtrl', ['$scope', '$http', 'DTOptionsBuilder', 'DTColumnDefBuilder', function ($scope, $http, DTOptionsBuilder, DTColumnDefBuilder) {
        $scope.users = [];
        $scope.showTable = true;

        $scope.genders = ['Male', 'Female'];

        $scope.user = {};

        function load() {
            $http.get('/GridView/GetData').then(function (response) {
                $scope.users = response.data;
                for (var i = 0; i < $scope.users.length; i++) {
                    if ($scope.users[i].Gender === 1) {
                        $scope.users[i].Gender = 'Female';
                    }
                    else
                        $scope.users[i].Gender = 'Male';
                }
               
            })
        };

        $scope.newUser = function () {
            $scope.user.IsNew = true;
        };

        $scope.modify = function (index) {
            $scope.user = angular.copy($scope.users[index]);
        }

        $scope.remove = function (index) {
            if (confirm("Delete the user?")) {
                $http.post('/GridView/DeleteUser', { id: $scope.users[index].Id }).then(function (response) {
                    if (response.data) {
                        load();
                    }
                });
            }
        }
        $scope.save = function () {
            $http.post('/GridView/EditUser', { model: $scope.user }).then(function (response) {
                if (response.data) {
                    $scope.user = {};
                    load();
                }
            }, function myError(rejection) {
                alert("Save was not finished successfuly.");
                
            })
        }


        $scope.dtOptions = DTOptionsBuilder.newOptions().withPaginationType('full_numbers');
        $scope.dtColumnsDef = [
            DTColumnDefBuilder.newColumnDef(0),
            DTColumnDefBuilder.newColumnDef(1),
            DTColumnDefBuilder.newColumnDef(2),
            DTColumnDefBuilder.newColumnDef(3),
            DTColumnDefBuilder.newColumnDef(4),
            DTColumnDefBuilder.newColumnDef(5).notSortable()
        ];

        load();
    }]);
})();