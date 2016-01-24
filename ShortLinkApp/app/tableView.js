(function () {
   
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
                  
                  this.links =null;
                  var self = this;
                  $http.get("/api/ShortLink").then(function (resp) {
                      self.links = [];
                      for(var i=0;i<resp.data.length;++i)
                      {
                          self.links.push(resp.data[i]);
                      }
                  }, function (resp) {
                      self.errorMessage = (resp.data && resp.data.Message) ? resp.data.Message : (resp.status + " " + resp.statusText);
                   

                  });
              }]
          }

      });
})();