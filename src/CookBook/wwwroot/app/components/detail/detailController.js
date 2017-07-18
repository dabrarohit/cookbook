cookbookApp.controller('detailController', function ($scope, $rootScope, $routeParams, recipeService, commentService) {
    $scope.id = $routeParams.id;
    $scope.rating = 0;
    $scope.comments = [];
    $scope.comment = {};

    recipeService.getById($scope.id).then(
        // callback function for successful http request
        function success(response) {
            $scope.recipe = response.data;
            $scope.rating = $scope.recipe.rating;
        },
        // callback function for error in http request
        function error(response) {
            // log errors
        });

    $scope.rateFunction = function (rating) {
        $scope.rating = rating;
        $scope.recipe.rating = $scope.rating;
        recipeService.updateRecipe($scope.recipe).then(
            // callback function for successful http request
            function success(response) {

            },
            // callback function for error in http request
            function error(response) {
                // log errors
            });
    }



    $scope.PostComment = function () {
        $scope.comment.recipeId = $scope.id;
        commentService.postComment($scope.comment).then(
        // callback function for successful http request
        function success(response) {
            $scope.comments.push(response.data);
            $scope.comment = {};
        },
        // callback function for error in http request
        function error(response) {
            // log errors
        });
    }

    $scope.DeleteComment = function (x, id) {
        commentService.deleteComment(id).then(
        // callback function for successful http request
        function success(response) {
            $scope.comments.splice(x, 1);
        },
        // callback function for error in http request
        function error(response) {
            // log errors
        });
    }


    commentService.getByRecipeId($scope.id).then(
        // callback function for successful http request
        function success(response) {
            $scope.comments = response.data;
        },
        // callback function for error in http request
        function error(response) {
            // log errors
        });
});