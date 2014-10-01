(function () {
    "use strict";

    angular
        .module("movieHunter")
        .controller("SearchByActorCtrl",
                    ["$scope",
                     "$http",
                     SearchByActorCtrl]);

    function SearchByActorCtrl ($scope, $http) {

        $scope.actorList = [];
        $scope.title = "Search by Actor";

        // Callback after the promise on success
        var onActorRetrieveComplete = function (response) {
            $scope.actorList = response.data;
        };

        // Callback after the promise on error
        var onError = function (reason) {
            $scope.errorText = "Could not display the actor list: " + reason.data;
        };

        // Asynchrous call returning a promise
        $http.get("http://localhost:1561/api/actors/")
            .then(onActorRetrieveComplete, onError);

    }

}());