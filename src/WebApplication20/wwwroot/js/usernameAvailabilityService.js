(function () {
    'use strict';

    angular
        .module('app')
        .factory('usernameAvailabilityService', usernameAvailabilityService);

    usernameAvailabilityService.$inject = ['$http'];

    function usernameAvailabilityService($http) {
        var service = {
            checkUserName: checkUserName
        };

        return service;

        function checkUserName(Name) {
            return $http.post('Account/CheckUserName', '"' + Name + '"');
        }
    }
})();