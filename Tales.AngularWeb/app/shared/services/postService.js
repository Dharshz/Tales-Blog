(function () {

    angular.module('blogApp').factory('postService', ['$http', postService]);


    function postService($http) {

        var service = {} ||[];

        service.getPost = function (postId) {
            return $http.get('/api/posts/GetPost?postId=' + postId);
        }

        service.getCurrentPostList = function () {
            return $http.get('/api/posts/get');
        }

        

        service.saveComment = function (commenter) {
            return $http.post('/api/posts/saveComment', JSON.stringify(commenter), {
                headers: {
                    'Content-Type': 'application/json'
                }
            });
        }
        return service;
    }

})();