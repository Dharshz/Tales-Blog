(function () {

    angular.module('blogApp').controller('userAccountController', ['$scope', '$http', 'tokenUrl', 'tokenKey', '$location','currentUser', userAccountCtrl]);

    function userAccountCtrl($scope, $http, tokenUrl, tokenKey, $location, currentUser) {
        $scope.email = '';
        $scope.loginEmail = '';
        $scope.loginPassword = '';
        $scope.password = '';
        $scope.password2 = '';
        $scope.hasLoginErrors = false;
        $scope.hasRegistrationErrors = false;
        $scope.loginErrorDescription = '';
        $scope.registrationErrorDescription = '';

        $scope.register = function () {
            $scope.hasRegistrationErrors = false;

            var registrationData = {
                Email: $scope.email,
                Password: $scope.password,
                ConfirmPassword: $scope.password2
            };

            $http.post('api/Account/Register', JSON.stringify(registrationData))
                .success(function (data) {
                    $location.path('/login');
                })
                .error(function (data) {
                    $scope.hasRegistrationErrors = true;
                    $scope.registrationErrorDescription = data.message;
                    console.log(data.message);
                    if (data.modelState['model.Email'])
                        $scope.registrationErrorDescription += data.modelState['model.Email'];

                    if (data.modelState['model.Password'])
                        $scope.registrationErrorDescription += data.modelState['model.Password'];

                    if (data.modelState['model.ConfirmPassword'])
                        $scope.registrationErrorDescription += data.modelState['model.ConfirmPassword'];

                    if (data.modelState[''])
                        $scope.registrationErrorDescription += data.modelState[''];

                });
        }


        $scope.login = function () {
            $scope.result = '';

            var loginData = {
                grant_type: 'password',
                username: $scope.loginEmail,
                password: $scope.loginPassword
            }

            $http({
                method: 'POST',
                url: tokenUrl,
                data: $.param(loginData),
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                }
            }).then(function (result) {
                console.log(result);
                $location.path("/");
              //  sessionStorage.setItem(tokenKey, result.data.access_token);
                currentUser.setProfile(loginData.username, result.data.access_token);
                sessionStorage.setItem(tokenKey, angular.toJson(currentUser.profile));
                $scope.hasLoginError = false;
                $scope.isAuthenticated = true;
            }, function (data, status, headers, config) {
                $scope.hasLoginError = true;
                $scope.loginErrorDescription = data.data.error_description;
            });

        }

    }

})();