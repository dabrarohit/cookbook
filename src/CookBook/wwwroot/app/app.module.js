var cookbookApp = angular.module('cookbookApp', ['ngRoute', 'yaru22.angular-timeago']);

cookbookApp.run(function ($rootScope, $location) {
 
    $rootScope.$back = function () {
        window.history.back();
    };

});