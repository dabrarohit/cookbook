cookbookApp.factory('commentService', function ($http) {

    function getByRecipeId(id) {
        return $http.get('/api/comments/' + id);
    }
    function postComment(comment) {
        $http.defaults.headers.post["Content-Type"] = "application/x-www-form-urlencoded";
        return $http({
            method: 'post',
            url: '/api/comment',
            data: $.param(comment)
        });
    }
    function deleteComment(id) {
        return $http.get('/api/deletecomment/' + id);
    }
    var service = {
        getByRecipeId: getByRecipeId,
        postComment: postComment,
        deleteComment: deleteComment
    };

    return service;
});