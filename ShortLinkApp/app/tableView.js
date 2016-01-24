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
                  var self = this;
                  $http.get("/api/ShortLink").then(function (resp) {
                      
                      for(var i=0;i<resp.data.length;++i)
                      {
                          self.links.push(resp.data[i]);
                      }
                  }, function (resp) {
                      self.errorMessage = (resp.data && resp.data.Message) ? resp.data.Message : (resp.status + " " + resp.statusText);
                      console.log("Error response:");
                      console.log(resp);

                  });
              }]
          }

      });
})();