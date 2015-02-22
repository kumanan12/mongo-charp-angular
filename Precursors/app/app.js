(function() {
    var app = angular.module("pcr", []);
    app.controller("IndexCtrl", IndexCtrl);

    function IndexCtrl($http,$q) {
        var vm = this;
        vm.title = "Hello World";
        vm.selectedCustomer = {};

        function refresh() {
            var deferred = $q.defer();
            $http.get('/api/Customer').then(function (result) {
                vm.customers = result.data;

                deferred.resolve();
            }, function (error) {
                deferred.reject(error);
            });
        }

        function addCustomer() {
            var deferred = $q.defer();
            var newCustomer = {};
            vm.deleteCustomer={}
            newCustomer.Name = vm.Name;
            $http.post('/api/Customer', newCustomer).then(function (result) {
                refresh();
                vm.Name = '';
                console.log(result);
                deferred.resolve();
            }, function (error) {
                deferred.reject(error);
            });

            console.log(vm.Name);
        }

        function updateCustomer () {
            var deferred = $q.defer();
            var url = "/api/Customer/" + vm.selectedCustomer.Id;
            $http.put(url, vm.selectedCustomer).then(function (result) {
                vm.updateCustomer = {};
                vm.selectedCustomer = {};
                refresh();
                console.log(result);
                deferred.resolve();
            }, function (error) {
                deferred.reject(error);
            });
            
        }

        function deleteCustomer(selectedCustomer) {
            var deferred = $q.defer();
            var url = "/api/Customer/" + selectedCustomer.Id;
            $http.delete(url).then(function (result) {
                refresh();
                deferred.resolve();
            }, function (error) {
                refresh();
                deferred.reject(error);
            });
           
        }

       

        vm.addCustomer = addCustomer;
        vm.updateCustomer = updateCustomer;
        vm.deleteCustomer = deleteCustomer;


        vm.editCustomer=function(editCustomer) {
            vm.selectedCustomer = editCustomer;
        }

        refresh();
    }
})();