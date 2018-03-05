(function (angular, undefined) {
    'use strict';

    function apiController($state, apiService) {
        var vm = this;

        function handleApiError(error) {
            toastr.error("" + error.status + " - " + error.statusText);
            if (error.status === 401) {
                localStorage.removeItem("claimsMobile.access_token");
                $state.go("login");
            }
        }
        
        function callApiService(fnApiCall) {
            vm.apiResponse = null;
            if (vm.claim) {
                apiService[fnApiCall](vm.claim.claimKey).then(function(resp) {
                    var formattedResp = JSON.stringify(resp.data, undefined, 2);
                    vm.apiResponse = formattedResp;
                }, handleApiError);
            }
        }

        vm.getClaimCandidates = function (claimNbr) {
            return apiService.getClaimCandidates(claimNbr).then(function(resp) {
                var candidates = [];
                angular.forEach(resp.data, function (c) {
                    c.displayName = c.claimNumber + " - " + c.insuredName;
                    candidates.push(c);
                });
                return candidates;
            }, handleApiError);
        }
    }

    angular.module("claimsMobileApp").controller("ApiController",
    ["$state", "apiService", apiController]);
}(window.angular));