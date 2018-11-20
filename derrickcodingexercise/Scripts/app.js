var app = angular.module("poll", []);

app.controller("gender", function ($scope) {
	$scope.male = 0;
	$scope.malePercent = 0;
	$scope.maleClass = "black";
	$scope.female = 0;
	$scope.femalePercent = 0;
	$scope.femaleClass = "black";

	$scope.load = function () {
		$scope.getData();
	};

	$scope.getData = function () {
		$.get("/CodingExercise/GetData",
			function (data) {
				var json = JSON.parse(data);
				$scope.male = json.Male;
				$scope.female = json.Female;

				// calculate percentage for each gender
				$scope.calculatePercentage();
			});
	};

	$scope.vote = function (male, female) {		
		$.get("/CodingExercise/SaveData/" + ($scope.male + male) + "/" + ($scope.female + female),
			function (data) {
				var json = JSON.parse(data);
				$scope.male = json.Male;
				$scope.female = json.Female;

				// calculate percentage for each gender
				$scope.calculatePercentage();
			});
	};

	$scope.calculatePercentage = function () {
		if ($scope.male !== 0 || $scope.female !== 0) {
			if ($scope.male === 0)
				$scope.femalePercent = 100;
			else if ($scope.female === 0)
				$scope.malePercent === 100;
			else {
				$scope.malePercent = Math.round(($scope.male / ($scope.male + $scope.female) * 100));
				$scope.femalePercent = Math.round(($scope.female / ($scope.male + $scope.female) * 100));
			}

			if ($scope.malePercent > $scope.femalePercent) {
				$scope.maleClass = "green";
				$scope.femaleClass = "red";
			}
			else if ($scope.femalePercent > $scope.malePercent) {
				$scope.maleClass = "red";
				$scope.femaleClass = "green";
			}
			else {
				$scope.maleClass = "black";
				$scope.femaleClass = "black";
			}
		}

		$scope.$apply();
	};
});