(function(angular, undefined) {
    'use strict';

    function loginController($state, apiService) {
        var vm = this;

        vm.getToken = function() {
            apiService.getToken(vm.userName, vm.password)
                .then(function(resp) {
                    console.log(resp.data.access_token);
                    localStorage.setItem("claimsMobile.access_token", resp.data.access_token);
                    $state.go("api");
                });
        };
    }

    angular.module("claimsMobileApp").controller("LoginController",
    ["$state", "apiService", loginController]);
}(window.angular));