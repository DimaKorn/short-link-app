(function () {
    angular.module("shortLinkApp.tableView", ["ngRoute"])
      .config(["$routeProvider", function ($routeProvider) {
          $routeProvider.when("/tableView", {
              templateUrl: "templates/tableView.html"
             
          })
      }]);
})();