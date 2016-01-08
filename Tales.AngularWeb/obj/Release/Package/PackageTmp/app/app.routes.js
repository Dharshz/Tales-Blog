(function () {

    angular.module('blogApp').config(['$routeProvider', Router]);

    function Router($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'app/components/home/home.html',
            controller: 'homeController'
        });
        $routeProvider.when('/Post/:postId', {
            templateUrl: 'app/components/post/post.html',
            controller: 'postController'
        });

        $routeProvider.when('/login', {
            templateUrl: 'app/components/account/login.html',
            controller: 'userAccountController'
        });

        $routeProvider.when('/register', {
            templateUrl: 'app/components/account/register.html',
            controller: 'userAccountController'
        });

        $routeProvider.when('/tag/:tagId', {
            templateUrl: 'app/components/account/register.html',
            controller: 'userAccountController'
        });

        $routeProvider.otherwise({
            redirectTo: '/'
        });
    }

})();