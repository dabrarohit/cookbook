cookbookApp.factory('recipeService', function ($http) {

    function getRecipes() {
        return $http.get('/api/recipes');
    }
    function getById(id) {
        return $http.get('/api/recipes/' + id);
    }
    function createRecipe(recipe) {
        $http.defaults.headers.post["Content-Type"] = "application/x-www-form-urlencoded";
        return $http({
            method: 'post',
            url: '/api/recipe',
            data: $.param(recipe)
        });
    }
    function updateRecipe(recipe) {
        $http.defaults.headers.post["Content-Type"] = "application/x-www-form-urlencoded";
        return $http({
            method: 'post',
            url: '/api/updaterecipe',
            data: $.param(recipe)
        });
    }
    function deleteRecipe(id) {
        return $http.get('/api/deleterecipe/' + id);
    }
    var service = {
        getRecipes: getRecipes,
        getById: getById,
        createRecipe: createRecipe,
        updateRecipe: updateRecipe,
        deleteRecipe: deleteRecipe
    };

    return service;
});