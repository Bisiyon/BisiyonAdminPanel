// wwwroot/js/app.js
var app = angular.module("bisiyonApp", []);

app.service("db", [
  "$http",
  function ($http) {
    // GET isteği (url parametresi zorunlu)
    this.get = function (url, config) {
      return $http.get(url, config);
    };

    // POST isteği (url ve data zorunlu)
    this.post = function (url, data, config) {
      return $http.post(url, data, config);
    };
  },
]);
