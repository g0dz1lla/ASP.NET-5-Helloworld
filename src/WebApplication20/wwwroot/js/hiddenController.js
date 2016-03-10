(function () {
    'use strict';

    angular
        .module('hiddenApp')
        .controller('hiddenController', hiddenController);

    hiddenController.$inject = ['$location', '$scope', '$http'];

    function hiddenController($location, $scope, $http) {
        $scope.title = 'hiddenController';
        $scope.HiddenMessage = {
            Guid: $location.absUrl().split('guid=')[1],
            PasswordHash: undefined
        }
        $scope.messagetext = "";
        $scope.LoadNote = function () {
            $http.post('Message/ReadNote/' + $scope.HiddenMessage).then(
                function (result) {
                    $scope.messagetext = result.data;
                },
            function (result) {
            });
        };
        activate();

        function activate() { }
    }
})();
