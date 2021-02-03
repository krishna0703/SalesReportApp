var app = angular.module('DemoCarApp',
    [
         'ngResource',
         'ui.grid',
         'ui.grid.pinning',
         'ui.grid.pagination',
         'ui.grid.selection',
         'ui.grid.grouping',
         'ui.grid.resizeColumns',
         'ui.grid.edit',
         'ui.grid.cellNav',
         'ngRoute'
    ]);

app.run(function ($location) {
    console.log('App initialized successfully!');
});

app.config(function ($routeProvider, $locationProvider, $httpProvider) {
    // configure the routing rules here
    $routeProvider.when('/home/Index/', {
        controller: 'VendorController'
    });

    // enable HTML5mode to disable hashbang urls
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
    $httpProvider.defaults.cache = false;
    if (!$httpProvider.defaults.headers.get) {
        $httpProvider.defaults.headers.get = {};
    }
    // disable IE ajax request caching
    $httpProvider.defaults.headers.get['If-Modified-Since'] = '0';
    $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
    $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';
});

