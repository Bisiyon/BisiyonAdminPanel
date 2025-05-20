// wwwroot/js/layout.controller.js
app.controller("layoutController", [
  "$scope",
  "db",
  function ($scope, db) {
    $scope.title = "Layout Başlığı - AngularJS ile";
    $scope.ToastSuccessMessage = "";
    $scope.ToastErrorMessage = "";
    $scope.ToastIsError = false;
    const toastPlacementExample = document.querySelector(".toast-placement-ex");
    let selectedType,
      selectedPlacement = "top-0 start-50 translate-middle-x".split(" "),
      toastPlacement;

    $scope.ShowToast = function (message, isError = false) {
      if (toastPlacement) {
        $scope.DisposeToast(toastPlacement);
      }
      let selectedType = "";
      $scope.ToastIsError = isError;
      $scope.ToastMessage = message;
      if (isError) {
        selectedType = "bg-danger";
      } else {
        selectedType = "bg-success";
      }

      toastPlacementExample.classList.add(selectedType);
      DOMTokenList.prototype.add.apply(
        toastPlacementExample.classList,
        selectedPlacement
      );
      toastPlacement = new bootstrap.Toast(toastPlacementExample);
      toastPlacement.show();
    };

    $scope.DisposeToast = function (toast) {
      if (toast && toast._element !== null) {
        if (toastPlacementExample) {
          toastPlacementExample.classList.remove(selectedType);
          DOMTokenList.prototype.remove.apply(
            toastPlacementExample.classList,
            selectedPlacement
          );
        }
        toast.dispose();
      }
    };
  },
]);
