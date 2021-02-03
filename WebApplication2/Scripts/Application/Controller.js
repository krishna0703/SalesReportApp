app.controller('VendorController',
    function ($scope, vendorService,uiGridConstants, uiGridGroupingConstants) {
        $scope.gridOptions =
           {
               enableColumnResizing: true,
               showColumnFooter: true,
               multiSelect: false,
               paginationPageSizes: [25, 50, 75],
               rowHeight: 50,
               columnFooterHeight: 60,
               cellClass: 'regular',
               onRegisterApi: function (gridApi) {
                   $scope.gridApi = gridApi;
                   gridApi.cellNav.on.navigate($scope, function (newRowCol, oldRowCol) {
                       $scope.gridApi.selection.selectRow(newRowCol.row.entity);
                   });
               },
               columnDefs: [
                      {
                           field: 'Month'
                      },
                      {
                         name: 'Illinois', displayName: 'Illinois', 
                         aggregationType: function ()
                         {
                             if (!$scope.gridApi)
                                 return 0;
                             var sum = 0;
                             var avg;
                             var median;
                             //if it is filtered/sorted you want the filtered/sorted rows only)
                             var visibleRows = $scope.gridApi.core.getVisibleRows($scope.gridApi.grid);

                             for (var i = 0; i < visibleRows.length; i++) 
                                 {
                                     //you have to parse just in case the data is in string otherwise it will concatenate
                                 sum += parseInt(visibleRows[i].entity.Illinois);

                                 //getting Median
                                 visibleRows.sort(function (a, b) {
                                     return a - b;
                                 });
                                 var half = Math.floor(visibleRows.length / 2);

                                 if (visibleRows.length % 2)
                                     median = parseInt(visibleRows[half].entity.Illinois);

                                 median = (parseInt(visibleRows[half - 1].entity.Illinois) + parseInt(visibleRows[half].entity.Illinois)) / 2.0;
                             }
                             //Getting Average
                             avg = sum / visibleRows.length;

                             return [avg, sum, median];
                         },
                         footerCellTemplate: '<div col-index="renderIndex" class="ui-grid-cell-contents" style="background-color: Gray;color: White"><div>avg: {{ col.getAggregationValue()[0] | number : 2}}<br>total: {{ col.getAggregationValue()[1] | number : 2}}<br>med: {{ col.getAggregationValue()[2] | number : 3}}</div></div>'
                     },
                     {
                         name: 'Georgia', displayName: 'Georgia', aggregationType: "grid.appScope.averageAndTotal()", footerCellTemplate: '<div col-index="renderIndex" class="ui-grid-cell-contents" style="background-color: Gray;color: White"><div>avg: {{ col.getAggregationValue()[0] | number : 2}}<br>total: {{ col.getAggregationValue()[1] | number : 2}}<br>med: {{ col.getAggregationValue()[2] | number : 3}}</div></div>'
                     },
                     {
                         name: 'NewYork', displayName: 'New York',
                         footerCellTemplate: '<div col-index="renderIndex" class="ui-grid-cell-contents" style="background-color: Gray;color: White"><div>avg: {{ col.getAggregationValue()[0] | number : 2}}<br>total: {{ col.getAggregationValue()[1] | number : 2}}<br>med: {{ col.getAggregationValue()[2] | number : 3}}</div></div>'
                     },
                     {
                         name: 'California', displayName: 'California', footerCellTemplate: '<div col-index="renderIndex" class="ui-grid-cell-contents" style="background-color: Gray;color: White"><div>avg: {{ col.getAggregationValue()[0] | number : 2}}<br>total: {{ col.getAggregationValue()[1] | number : 2}}<br>med: {{ col.getAggregationValue()[2] | number : 3}}</div></div>'
                     },
                     {
                         name: 'Washington', displayName: 'Washington', footerCellTemplate: '<div col-index="renderIndex" class="ui-grid-cell-contents" style="background-color: Gray;color: White"><div>avg: {{ col.getAggregationValue()[0] | number : 2}}<br>total: {{ col.getAggregationValue()[1] | number : 2}}<br>med: {{ col.getAggregationValue()[2] | number : 3}}</div></div>'
                     },
                     {
                         name: 'Florida', displayName: 'Florida', footerCellTemplate: '<div col-index="renderIndex" class="ui-grid-cell-contents" style="background-color: Gray;color: White"><div>avg: {{ col.getAggregationValue()[0] | number : 2}}<br>total: {{ col.getAggregationValue()[1] | number : 2}}<br>med: {{ col.getAggregationValue()[2] | number : 3}}</div></div>'
                     },
                   {
                       name: 'Colorado', displayName: 'Colorado', footerCellTemplate: '<div col-index="renderIndex" class="ui-grid-cell-contents" style="background-color: Gray;color: White"><div>avg: {{ col.getAggregationValue()[0] | number : 2}}<br>total: {{ col.getAggregationValue()[1] | number : 2}}<br>med: {{ col.getAggregationValue()[2] | number : 3}}</div></div>'
                   }                   
               ]
           };        

        if (vendorService) {
                $scope.spinner = true;
                try {
                    var result = vendorService.getSalesReport(function (result) {
                        //$scope.gridOptions.data = result.salesreport;
                        $scope.gridOptions.data = JSON.parse(result.responsejson);
                        $scope.spinner = false;
                        $scope.gridApi.core.refresh();
                    });                        
                }
                catch (e) {
                    $scope.spinner = false;
                    $scope.griddiv = false;
                }
        }
    });