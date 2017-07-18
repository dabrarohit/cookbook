cookbookApp.controller('updateController', function ($scope, $rootScope, $routeParams, recipeService, $location) {
    $scope.id = $routeParams.id;
    $scope.recipe = {};

    recipeService.getById($scope.id).then(
       // callback function for successful http request
       function success(response) {
           $scope.initialData = response.data;
           $scope.recipe = angular.copy($scope.initialData);
       },
       // callback function for error in http request
       function error(response) {
           // log errors
       });

    $scope.addIngredient = function () {
        $scope.recipe.ingredients.push($scope.ingredient);
        $scope.ingredient = "";
    };
    $scope.removeIngredient = function (x) {
        $scope.recipe.ingredients.splice(x, 1);
    };
    $scope.addInstruction = function () {
        $scope.recipe.instructions.push($scope.instruction);
        $scope.instruction = "";
    };
    $scope.removeInstruction = function (x) {
        $scope.recipe.instructions.splice(x, 1);
    };
    $scope.Reset = function () {
        $scope.recipe = angular.copy($scope.initialData);
    };
    $scope.Save = function () {
        $scope.recipe.id = $scope.id;
        recipeService.updateRecipe($scope.recipe).then(
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