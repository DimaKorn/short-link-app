(function () {
    angular.module("shortLinkApp", ["ngRoute", "shortLinkApp.inputView", "shortLinkApp.tableView"])
        .config(["$routeProvider", function ($routeProvider) {
            $routeProvider.otherwise({ redirectTo: "/inputView" });
        }]);

})();