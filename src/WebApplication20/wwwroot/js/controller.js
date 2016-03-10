(function () {
    'use strict';

    var app = angular
        .module('AspNetApp');

    app.controller('NoteController', noteController);

    noteController.$inject = ['$location', '$scope', '$http'];

    function noteController($location, $scope, $http) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'NoteController';
        vm.confirmPassword = null;
        vm.showDetails = false;

        vm.message = {
            Guid: undefined,
            PasswordHash: undefined,
            Text: undefined,
            HoursToDelete: '0',
            Url: undefined
        }

        vm.toggleDetails = function () {
            if (vm.showDetails)
                vm.showDetails = false;
            else
                vm.showDetails = true;
        }

        vm.Create = function () {
            $http.post('Message', vm.message).then(
                function (result) {
                    vm.message.Guid = result.data;
                    vm.message.Url = 'http://localhost:43815/Message/' + vm.message.Guid;
                },
            function (result) {
            });
        };
        activate();

        function activate() { }
    }

    app.controller('AccountController', accountController);

    accountController.$inject = ['$location', '$scope', '$http'];

    function accountController($location, $scope, $http) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'AccountController';

        vm.user = {
            Email: null,
            Password: null,
            RememberMe: false
        }

        vm.signIn = function (form) {
            vm.user.__RequestVerificationToken = form.__RequestVerificationToken;
            $http.post('/Account/LoginAJAX', vm.user)
                .then(
                    function (result) {
                        alert("Success");
                    },
                    function (result) {
                        alert(result.data);
                    }
                );
        };

        activate();

        function activate() { }
    }



    var compareTo = function () {
        return {
            require: "ngModel",
            scope: {
                otherModelValue: "=compareTo"
            },
            link: function (scope, element, attributes, ngModel) {

                ngModel.$validators.compareTo = function (modelValue) {
                    return modelValue == scope.otherModelValue;
                };

                scope.$watch("otherModelValue", function () {
                    ngModel.$validate();
                });
            }
        };
    };

    app.directive("compareTo", compareTo);



})();
