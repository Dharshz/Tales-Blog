(function () {

    angular.module('blogApp').controller('postController', ['$scope', '$timeout', '$http', '$routeParams', 'postService', postController]);

    function postController($scope, $timeout, $http, $routeParams, postService) {
        $scope.show = false;
        $scope.post = {} || [];
        $scope.commenter = {} || [];
        $scope.postId = $routeParams.postId;
        $scope.commentCount = 0;

        postService.getPost($scope.postId).success(function (post) {
            $scope.post = post;
            if (post.comments) {
                $scope.commentCount = post.comments.length;
            }
        });

        $scope.reset = function () {
            $scope.commenter = {} || [];
            $scope.myForm.$setPristine();
            $scope.myForm.$setUntouched();
        }

        $scope.saveComment = function () {

            $scope.commenter.PostId = $scope.postId;

            postService.saveComment($scope.commenter).success(function (data) {
                $scope.show = true;
                $timeout(function () {
                    $scope.show = false;
                }, 3000);
                $scope.reset();
            });
        }
    }

})();