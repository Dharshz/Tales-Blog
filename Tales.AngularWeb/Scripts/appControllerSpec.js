/// <reference path="C:\Darsh\Projects\TalesBlog Angular\Tales.AngularWeb\assets/lib/angular.min.js" />
/// <reference path="C:\Darsh\Projects\TalesBlog Angular\Tales.AngularWeb\assets/lib/angular-mocks.js" />
/// <reference path="appController.js" />


describe('When using appController ', function () {
    //initialize Angular
    beforeEach(module('app'));
    //parse out the scope for use in our unit tests.
    var scope;
    beforeEach(inject(function ($controller, $rootScope) {
        scope = $rootScope.$new();
        var ctrl = $controller('appController', { $scope: scope });
    }));

    it('initial value is 5', function () {
        expect(scope.value).toBe(5);
    });
});