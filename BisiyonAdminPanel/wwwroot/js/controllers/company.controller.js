app.controller("companyController", [
  "$scope",
  "db",
  "$timeout",
  function ($scope, db, $timeout) {
    $scope.Companies = [];
    $scope.CompanyModel = {};
    $scope.SavingCompany = false;
    $scope.Provinces = [];
    $scope.Districts = [];

    $scope.InitPage = function () {
      $scope.GetCompanies();
    };

    $scope.GetCompanies = function () {
      db.get("Company/GetCompanies")
        .then(function (response) {
          if (response.data) $scope.Companies = response.data;
        })
        .catch(function (error) {});
    };

    $scope.NewCompany = function () {
      $scope.CompanyModel = {};
      $scope.InitProvince();
    };

    $scope.InitProvince = function () {
      if ($scope.Provinces.length === 0) {
        db.get("/Province/GetProvinces").then(function (response) {
          $scope.Provinces = response.data;
          $scope.CreateProvinceComponent();
        });
      } else {
        $scope.CreateProvinceComponent();
      }
    };

    $scope.CreateProvinceComponent = function () {
      $("#provinceExLarge").select2({
        matcher: matchCustom,
        dropdownParent: "#newCompanyModal",
        language: {
          noResults: function () {
            return "Veri yok";
          },
        },
      });
      $("#provinceExLarge").on("select2:select", function (e) {
        $scope.InitDistrict(Number(e.params.data.id));
      });
    };

    $scope.InitDistrict = function (id) {
      db.get("/District/GetDistricts/" + id).then(function (response) {
        $scope.Districts = response.data;
        $scope.CreateDistrictComponent();
      });
    };

    $scope.CreateDistrictComponent = function () {
      $("#districtExLarge").select2({
        width: "100%",
        matcher: matchCustom,
        dropdownParent: "#newCompanyModal",
        language: {
          noResults: function () {
            return "İl seçiniz";
          },
        },
      });
    };

    $scope.SaveCompany = function () {
      if (!$scope.CompanyModel.Name) {
        $scope.$parent.ShowToast("Firma adı boş geçilemez!", (isError = true));
        return;
      }
      debugger;
      try {
        $scope.CompanyModel.ProvinceId = Number($("#provinceExLarge").val());
      } catch (e) {}
      try {
        $scope.CompanyModel.DistrictId = Number($("#districtExLarge").val());
      } catch (e) {}
      $scope.SavingCompany = true;
      db.post(
        "/Company/SaveCompany",
        $scope.CompanyModel,
        function (response) {
          $scope.SavingCompany = false;
          $("#newCompanyModal").modal("hide");
          $scope.$parent.ShowToast("Firma eklendi");
          $scope.GetCompanies();
          try {
            $("#provinceExLarge").select2("destroy");
          } catch (e) {}
          try {
            $("#districtExLarge").select2("destroy");
          } catch (e) {}
        },
        function (error) {
          debugger;
          $scope.SavingCompany = false;
          $scope.$parent.ShowToast("Hata oluştu!", (isError = true));
        }
      );
    };
  },
]);

function matchCustom(params, data) {
  if ($.trim(params.term) === "") {
    return data;
  }
  if (typeof data.text === "undefined") {
    return null;
  }
  if (data.text.toLowerCase().indexOf(params.term.toLowerCase()) > -1) {
    var modifiedData = $.extend({}, data, true);
    return modifiedData;
  }
  return null;
}
