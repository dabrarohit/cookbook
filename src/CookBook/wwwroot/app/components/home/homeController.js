cookbookApp.controller('homeController', function ($scope, $rootScope, recipeService) {

    //Load data from server for first time only.
    recipeService.getRecipes().then(
    // callback function for successful http request
    function success(response) {
        $scope.recipes = response.data;
    },
    // callback function for error in http request
    function error(response) {
        // log errors
    });
});