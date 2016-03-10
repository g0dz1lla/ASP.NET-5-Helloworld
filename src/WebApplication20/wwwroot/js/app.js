(function () {
    'use strict';

    var app = angular.module('AspNetApp', [

        // Angular modules 
        //'ngRoute'

        // Custom modules 

        // 3rd Party Modules
        "ngMessages",
        "ui.router"
    ]);

    app.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {

        $locationProvider.html5Mode({
            enabled: true//,
            //requireBase: false
        });

        $urlRouterProvider.otherwise('/Home');

        $stateProvider

            // HOME STATES AND NESTED VIEWS ========================================
            .state('home', {
                url: '/Home',
                
                template: "<div ui-view></div>"
            })

            .state('home.index', {
                url: '/',
                templateUrl: 'Home/IndexPartial'
            })

            // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
            .state('home.about', {
                url: '/About',
                templateUrl: 'Home/AboutPartial'
            })

            // ABOUT PAGE AND MULTIPLE NAMED VIEWS =================================
            .state('home.contact', {
                url: '/Contact',
                templateUrl: 'Home/ContactPartial'
            })

            //
            .state('account',{
                url: '/Account',
                abstract: true,
                template: "<div ui-view></div>"
            })

            //
            .state('account.register', {
                url: '/Register',
                templateUrl: 'Account/RegisterPartial',
                controller: 'AccountController',
                controllerAs: 'Acc'
            })

            //
            .state('account.login', {
                url: '/Login',
                templateUrl: 'Account/LoginPartial',
                controller: 'AccountController',
                controllerAs: 'Acc'
            })

            //
            .state('message', {
                url: '/Message',
                templateUrl: 'Message.html',
                controller: 'NoteController',
                controllerAs: 'NoteCtrl'
            })
            ;
    });
})();