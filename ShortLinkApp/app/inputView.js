(function () {
    angular.module("shortLinkApp.inputView", ["ngRoute"])
        .config(["$routeProvider", function ($routeProvider) {
            $routeProvider.when("/inputView", {
                template: "<input-view/>"

            })
        }]).directive("inputView", function () {
            return {
                templateUrl: "templates/inputView.html",
                scope: {},
                bindToController: true,
                controllerAs:"vm",
                controller: ["$scope","$http", function ($scope, $http) {
                    console.log($scope);
                    
                    this.shortLink = null;
                    this.onSave = (function () {
                                              
                        var self=this;
                        this.errorMessage=null;
                        $http.post("/api/ShortLink", { OriginalLink: self.originalLink })
                            .then(function (response) {
                                
                                self.shortLink = response.data.ShortLink;
                                if($scope.inputForm)
                                {
                                    $scope.inputForm.$setPristine();
                                }
                            },function (e) {
                                console.log(arguments);
                                var message = "";
                                if (e.data)
                                {
                                    if (e.data.ModelState) {
                                        for (var p in e.data.ModelState) {
                                            message += e.data.ModelState[p].join(";");
                                        }
                                    }
                                    else
                                        message = e.data.Message;                                 

                                }
                                self.errorMessage =message || (e.status+" "+e.statusText);
                            })
                    }).bind(this);
                }]
            };
        });;
})();