(function () {
    "use strict";

    angular
        .module("movieHunter")
        .controller("SearchByTitleCtrl",
                    ["$scope",
                     "$http",
                     SearchByTitleCtrl]);

    function SearchByTitleCtrl($scope, $http) {

        $scope.movieList = [];
        $scope.title = "Search by Movie Title";
        $scope.showImage = false;

        $scope.toggleImage = function () {
            $scope.showImage = !$scope.showImage;
        };

        var onMovieRetrieveComplete = function (response) {
            $scope.movieList = response.data;
        };

        var onError = function (reason) {
            $scope.errorText = "Could not display the movie list: " +
                        (reason.statusText ? reason.statusText : reason.description);
        };

        $http.get("http://localhost:1561/api/movies/")
            .then(onMovieRetrieveComplete, onError);
    }
}());