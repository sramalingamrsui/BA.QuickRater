(function (angular, undefined) {
    'use strict';

    function urlService() {
        function getRootUrl() {
            var fullUrl = window.location.href,
                protocol = window.location.protocol,
                    host = window.location.hostname;

            var regEx = new RegExp("(" + protocol + ")?(\/{2})?" + host + "\/([A-Za-z0-9-_]+)(\/|#)", "gi");

            var matches = regEx.exec(fullUrl);

            if (matches && matches.length) {
                return matches[3];
            }
            return "";
        }

        var rootUrl = "/" + getRootUrl(),
            apiUrl = rootUrl + "/api/";

        return {
            rootUrl: rootUrl,
            apiUrl: apiUrl
        };
    }

    angular.module('claimsMobileApp').factory('urlService', [urlService]);

}(window.angular));