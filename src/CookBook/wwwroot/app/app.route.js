cookbookApp.config(function ($routeProvider) {
    $routeProvider

        .when('/', {
            templateUrl: 'app/components/home/home.html',
            controller: 'homeController'
        })
        .when('/home', {
            templateUrl: 'app/components/home/home.html',
            controller: 'homeController'
        })
        .when('/create', {
            templateUrl: 'app/components/create/create.html',
            controller: 'createController'
        })
        .when('/detail/:id', {
            templateUrl: 'app/components/detail/detail.html',
            controller: 'detailController'
        })
        .when('/update/:id', {
            templateUrl: 'app/components/create/create.html',
            controller: 'updateController'
        })
        .when('/delete/:id', {
            templateUrl: 'app/components/delete/delete.html',
            controller: 'deleteController'
        })
        .when('/about', {
            templateUrl: 'app/components/about/about.html'
        })
});