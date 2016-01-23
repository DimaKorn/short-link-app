(function () {
    function link(i) {
        this.orginalLink = "longUrl" + i;
        this.shortLink= "tinyUrl" + i;
        this.visitCount = i,
        this.createDate = "1999-22-11"
    }
    angular.module("shortLinkApp.tableView", ["ngRoute"])
      .config(["$routeProvider", function ($routeProvider) {
          $routeProvider.when("/tableView", {
              template: "<table-view/>"
             
          })
      }]).directive("tableView", function () {
          return {
              templateUrl: "templates/tableView.html",
              scope: {},
              bindToController: true,
              controllerAs: "vm",
              controller: ["$scope", "$http", function ($scope, $http) {
                  console.log($scope);
                  this.links = [];
                  for (var i = 0; i < 5; ++i) {
                      this.links.push(new link(i));
                  }
              }]
          }

      });
})();