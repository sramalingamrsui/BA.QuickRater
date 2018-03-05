(function (angular, undefined) {

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

    angular.module('claimsMobileApp')
        .config([
            '$compileProvider', '$locationProvider', '$httpProvider', '$stateProvider', '$urlRouterProvider', '$urlMatcherFactoryProvider',
            function ($compileProvider, $locationProvider, $httpProvider, $stateProvider, $urlRouterProvider, $urlMatcherFactoryProvider) {
                $compileProvider.aHrefSanitizationWhitelist(/^\s*(https?|ftp|mailto|file|openapp|chrome-extension|blob:chrome-extension):/);
                //$locationProvider.html5Mode({
                //    enabled: true,
                //    requireBase: false
                //});
                $httpProvider.useApplyAsync(true);

                $urlMatcherFactoryProvider.caseInsensitive(true);
                $urlMatcherFactoryProvider.strictMode(false);

                var urlPrefix = "/" + getRootUrl(),
                    templateUrlPrefix = urlPrefix + "/templates/app/";

                $urlRouterProvider.otherwise(function ($injector, $location) {
                    var $state = $injector.get("$state");
                    var startPage = localStorage.getItem("claimsMobile.access_token") ? "api" : "login";
                    $state.go(startPage);
                });

                console.log(urlPrefix + "/login");

                $stateProvider
                    .state('login', {
                        url: '/login',
                        views: {
                            'view.content': {
                                templateUrl: templateUrlPrefix + 'login.html'
                            }
                        }
                    })
                    .state('api', {
                        url: '/api',
                        views: {
                            'view.content': {
                                templateUrl: templateUrlPrefix + 'apiCall.html'
                            }
                        }
                    });
            }
        ]);

}(window.angular));