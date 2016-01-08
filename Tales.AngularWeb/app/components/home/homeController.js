(function () {
    
    angular.module('blogApp').controller('homeController', ['$scope','$http','postService', homeController]);

    function homeController($scope, $http, postService) {
        $scope.Posts = {} || [];
        $scope.Count = 0;

        postService.getCurrentPostList().success(function (posts) {
            $scope.Posts = posts;
            $scope.Count = posts.length;
        });
        

    };

})();