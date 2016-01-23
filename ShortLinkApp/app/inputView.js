(function () {
    angular.module("shortLinkApp.inputView", ["ngRoute"])
        .config(["$routeProvider", function ($routeProvider) {
            $routeProvider.when("/inputView", {
                templateUrl: "templates/inputView.html"

            })
        }]);
})();