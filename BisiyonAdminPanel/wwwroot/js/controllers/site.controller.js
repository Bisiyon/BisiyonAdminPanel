app.controller("siteController", [
  "$scope",
  "db",
  "$timeout",
  function ($scope, db, $timeout) {
    $scope.title = "Site Başlığı - AngularJS ile";
    $scope.Sites = [];
    $scope.SiteModel = {};
    $scope.SavingSite = false;

    $scope.InitPage = function () {
      $scope.GetSites();
    };

    $scope.GetSites = function () {
      db.get("Site/GetSites")
        .then(function (response) {
          if (response.data) $scope.Sites = response.data;
        })
        .catch(function (error) {
          debugger;
        });
    };

    $scope.NewSite = function () {
      $scope.SiteModel = {};
    };

    $scope.SaveSite = function () {
      if (!$scope.SiteModel.SiteCode) {
        $scope.$parent.ShowToast("Site kodu boş geçilemez!", (isError = true));
        return;
      }
      if (!$scope.SiteModel.SiteName) {
        $scope.$parent.ShowToast("Site adı boş geçilemez!", (isError = true));
        return;
      }
      $scope.SavingSite = true;
      db.post(
        "/Site/SaveSite",
        $scope.SiteModel,
        function (response) {
          $scope.SavingSite = false;
          $("#newSiteModal").modal("hide");
          $scope.$parent.ShowToast("Site eklendi");
          $scope.GetSites();
        },
        function (error) {
          debugger;
          $scope.SavingSite = false;
          $scope.$parent.ShowToast("Hata oluştu!", (isError = true));
        }
      );
    };
  },
]);
