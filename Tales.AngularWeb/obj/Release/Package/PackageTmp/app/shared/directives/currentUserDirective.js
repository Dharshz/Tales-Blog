(function () {

    angular.module('blogApp').directive('currentUser', ['currentUser', currentUserDirective]);

    function currentUserDirective()
    {

        return {
            restrict: 'E',
            templateUrl: 'app/shared/directives/currentUser.html',
            scope: {
            },
            controller: function ($scope,currentUser) {
                $scope.isLoggedIn = false;
                var user = currentUser.getProfile();
                if (user)
                {
                    $scope.isLoggedIn = true;
                    $scope.userName = user.userName;
                }
                else
                {
                    $scope.isLoggedIn = false;
                }
               
                
            }
        };

    }

})();