(function (angular, undefined) {
    'use strict';

    function apiService($http, urlService) {
        function makeApiCall(url) {
            var token = localStorage.getItem("claimsMobile.access_token");
            return $http({
                url: url, 
                headers: {
					"Content-Type": "application/json; charset=utf-8",
                    "Authorization": "Bearer " + token
                },
                method: "GET"
            });
        }

        function getToken(userName, password) {
            var data = "grant_type=password&username=" + userName + "&password=" + password;
            return $http({
                url: urlService.apiUrl + "token",
                data: data,
                headers: { "Content-Type": "application/x-www-form-urlencoded" },
                method: "POST"
            });
        }

        function getClaimCandidates(claimNbr) {
            var formattedClaimNbr = encodeURIComponent(claimNbr);
            console.log(formattedClaimNbr);
            var url = urlService.apiUrl + "claims?search=" + formattedClaimNbr;
            return makeApiCall(url);
        }

        return {
            getToken: getToken,
            getClaimCandidates: getClaimCandidates
        };
    }

    angular.module('claimsMobileApp').factory('apiService', ['$http', 'urlService',
    apiService]);

}(window.angular));
