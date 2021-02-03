app.factory('vendorService',
    function ($resource, $http, $q, $location) {
        $.ajaxSetup({ cache: false });  
        var service = {
            getSalesReport: function (scallback) {
                $.get("/Home/GetDtails", null, function (data) {
                    if (data !== null) {
                        return scallback(data);
                    }
                }).fail(function () { return "Fail"; });
            }
        };
        return service;
    });
