(function () {
    "use strict";

    angular
        .module("movieHunter")
        .controller("ActorDetailCtrl",
                    ["$scope",
                     "$http",
                     "$routeParams",
                     ActorDetailCtrl]);

    function ActorDetailCtrl ($scope, $http, $routeParams) {
        $scope.actorId = $routeParams.actorId;

        // Callback after the promise on success
        var onActorRetrieveComplete = function (response) {
            $scope.actor = response.data;
        };

        // Callback after the promise on error
        var onError = function (reason) {
            $scope.errorText = "Could not display the actor: " +
                reason.data + " - " + reason.statusText + " (" + reason.status + ")";
        };

        $http.get("http://localhost:1561/api/actors/" + $scope.actorId)
            .then(onActorRetrieveComplete, onError);

    }
}());