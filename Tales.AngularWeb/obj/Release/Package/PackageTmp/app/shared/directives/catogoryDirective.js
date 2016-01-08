(function () {

    angular.module('blogApp').directive('categoryDirective', ['$http', categoryDirective]);

    function categoryDirective($http) {
        return {
            restrict: 'E',
            templateUrl: 'app/shared/directives/categoryDirectiveTmpl.html',
            scope: {
            },
            controller: function ($scope) {
                $scope.cats = ['a', 'b', 'c'];
                $http.get('/api/posts/GetCategories').success(function (data) {
                    $scope.cats = data;
                }).error(function () {
                });
            }

        }
    }


})();