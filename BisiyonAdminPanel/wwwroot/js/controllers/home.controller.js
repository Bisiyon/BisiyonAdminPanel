// wwwroot/js/layout.controller.js
app.controller("homeController", [
  "$scope",
  "db",
  function ($scope, db) {
    $scope.title = "Home Başlığı - AngularJS ile";
  },
]);
