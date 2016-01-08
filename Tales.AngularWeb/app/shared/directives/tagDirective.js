(function () {

    angular.module('blogApp').directive('tagDirective', ['$http', tagDirective]);

    function tagDirective($http) {
        return {
            restrict: 'E',
            templateUrl: 'app/shared/directives/tagDirectiveTmpl.html',
            scope: {
            },
            controller: function ($scope) {
                $scope.tags = [];
                $http.get('/api/posts/GetTags').success(function (data) {
                    $scope.tags = data;
                }).error(function () {
                });
            }

        }
    }




})();