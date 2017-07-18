cookbookApp.directive("cookbookHeader", function () {
    return {
        restrict: "M",
        replace: true,
        templateUrl: 'app/shared/header/header.html'
    };
});