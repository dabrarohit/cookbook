cookbookApp.controller('deleteController', function ($scope, $rootScope, $routeParams, recipeService, $location) {
    $scope.id = $routeParams.id;
    $scope.recipe = {};

    recipeService.getById($scope.id).then(
       // callback function for successful http request
       function success(response) {
           $scope.recipe = response.data;
       },
       // callback function for error in http request
       function error(response) {
           // log errors
       });

    $scope.Delete = function () {
        recipeService.deleteRecipe($scope.id).then(
            // callback function for successful http request
            function success(response) {
                //$scope.recipe = response.data;
                $location.path("/");
            },
            // callback function for error in http request
            function error(response) {
                // log errors
            });
    };
    

});