(function () {

    angular.module('blogApp').factory('currentUser', ['$http','tokenKey', currentUser]);


    function currentUser($http, tokenKey) {

        var userProfile = {
            userName: "",
            token: "" ,
            IsLoggedIn : function()
            {
                return this.token;
            }

        };

        var setProfile = function (userName, token) {
            userProfile.userName = userName;
            userProfile.token = token;

        }

        var getProfile = function()
        {
            var profile = sessionStorage.getItem(tokenKey);
            if(profile)
            {
                profile = angular.fromJson(profile);

            }

            return profile;
        }

        return {
            profile: userProfile,
            setProfile: setProfile,
            getProfile: getProfile
        };

    }

})();