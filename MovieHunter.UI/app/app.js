// Application definition
// Configures the UI routes
(function () {
    // Define the main module
    var app = angular.module("movieHunter", ["ngRoute"]);
  
    app.config(['$routeProvider',
        function ($routeProvider) {
            $routeProvider
                .when("/", {
                    templateUrl: "app/welcomeView.html"
                })
                .when("/searchByTitle", {
                    templateUrl: "app/movieSearch/searchByTitleView.html",
                    controller: "SearchByTitleCtrl"
                })
                .when("/showMovieDetail/:movieId", {
                    templateUrl: "app/movieDetail/movieDetailView.html",
                    controller: "MovieDetailCtrl"
                })
                .when("/searchByActor", {
                    templateUrl: "app/movieSearch/searchByActorView.html",
                    controller: "SearchByActorCtrl"
                })
                .when("/showActorDetail/:actorId", {
                    templateUrl: "app/movieDetail/actorDetailView.html",
                    controller: "ActorDetailCtrl"
                })
                .otherwise({
                    redirectTo: "/"
                })
        }]);
}());