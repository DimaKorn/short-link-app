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
                    this.originalLink = "http://www.google.kz";
                    this.shortLink = null;
                    this.onUserInput = (function () {
                        if (this.shortLink) {
                            this.shortLink = null;
                        }
                    }).bind(this);
                    
                    this.onSave = (function () {
                        console.log("link to save " + this.orginalLink);
                        this.shortLink = "http://some/2345";
                        var self=this;
                        $http.post("/api/ShortLink", { OriginalLink: self.originalLink })
                            .then(function (response) {
                                console.log(response.data);
                                self.shortLink = response.data.ShortLink;
                            },function (e) {
                                console.log(arguments);
                            })
                    }).bind(this);
                }]
            };
        });;
})();