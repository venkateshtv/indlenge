var app = angular.module('app',[]);
app.constant("config",{"url":"http://localhost:5000/"});

app.service('pricingService',['$http','$q','config',function($http,$q,config){
var result = {};
result.GetPricingData = function(){
	var deferred = $q.defer();
	 return $http.get(config.url + 'GetPricingData')
            .then(function (response) {
                // promise is fulfilled
                deferred.resolve(response.data);
                // promise is returned
                return deferred.promise;
            }, function (response) {
                // the following line rejects the promise 
                deferred.reject(response);
                // promise is returned
                return deferred.promise;
            });

	};
return result;
}]);
app.controller('mainCtrl',['$scope','pricingService',function($scope,pricingService){
	$scope.Message = "Pricing info";
	$scope.PricingData;
	function CalcDiff(firstVal,secondVal){
		return Math.round((secondVal-firstVal)/firstVal * 100,0)+150;
	};
	$scope.GetColor = function(competitorsPrice,index){
		var currentRow = $scope.PricingData.values[index];
		var mystorePrice = currentRow[currentRow.length-1];
		var greenVal=0;
		var redVal = 0;
		var blueVal =50;
		if(mystorePrice < competitorsPrice){
			greenVal=Math.min(255,CalcDiff(mystorePrice,competitorsPrice));
		}
		else if(mystorePrice > competitorsPrice){
			redVal=Math.min(255,CalcDiff(competitorsPrice,mystorePrice));
		}
		else{
			greenVal = redVal = blueVal = 255;
		}
		return "" + redVal + "," + greenVal + ","+blueVal;
	};
	// On load - Get the pricing data
	pricingService.GetPricingData()
	 .then(function (response) {
               $scope.PricingData = response;
            }, function (response) {
               console.log("Error",response);
            });
	
}]);