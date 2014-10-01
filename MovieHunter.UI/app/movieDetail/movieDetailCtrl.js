(function () {
    "use strict";

    angular
        .module("movieHunter")
        .controller("MovieDetailCtrl",
                    ["$scope",
                     "$http",
                     "$routeParams",
                     MovieDetailCtrl]);

    function MovieDetailCtrl ($scope, $http, $routeParams) {
        $scope.movieId = $routeParams.movieId;

        // Callback after the promise on success
        var onMovieRetrieveComplete = function (response) {
            $scope.movie = response.data;
        };

        // Callback after the promise on error
        var onError = function (reason) {
            $scope.errorText = "Could not display the movie: " +
                reason.data + " - " + reason.statusText + " (" + reason.status + ")";
        };

        $http.get("http://localhost:1561/api/movies/" + $scope.movieId)
            .then(onMovieRetrieveComplete, onError);
    }
}());