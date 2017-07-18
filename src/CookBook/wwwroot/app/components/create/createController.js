cookbookApp.controller('createController', function ($scope, recipeService, $location) {
    $scope.recipe = {};
    $scope.recipe.ingredients = [];
    $scope.recipe.instructions = [];
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
        $scope.recipe = {};
        $scope.recipe.ingredients = [];
        $scope.recipe.instructions = [];
    };
    $scope.Save = function () {
        recipeService.createRecipe($scope.recipe).then(
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