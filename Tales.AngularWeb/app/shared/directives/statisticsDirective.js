(function () {

    angular.module('blogApp').directive('statisticsDirective', ['$http', statisticsDirective]);

    function statisticsDirective($http) {
        return {
            restrict: 'E',
            templateUrl: 'app/shared/directives/staticsDirectiveTmpl.html',
            scope: {
            },
            controller: function ($scope) {
                $scope.statisticData = [];
                $http.get('/api/posts/ShowStatistics').success(function (data) {
                    $scope.statisticData = data;
                }).error(function () {
                });
            }

        }
    }


})();