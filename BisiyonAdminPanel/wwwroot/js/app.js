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
    this.post = function (
      url,
      data,
      thenFunction,
      catchFunction,
      contentType = undefined,
      generateFormData = true,
      unAuthorizeFunc = undefined
    ) {
      var header = {
        IsAjax: true,
        "Content-Type": contentType,
      };
      var request = $http({
        method: "post",
        url: url,
        data: data,
        headers: header,
        transformRequest: function (data) {
          if (generateFormData) return jsonToFormData(data);
          return JSON.stringify(data);
        },
      })
        .then(function onSuccess(response) {
          responseControl(
            response,
            function () {
              if (thenFunction) thenFunction(response.data);
              return response.data;
            },
            unAuthorizeFunc,
            true
          );
        })
        .catch(function onError(response) {
          responseControl(
            response,
            function () {
              if (catchFunction) catchFunction(response);
            },
            unAuthorizeFunc,
            true
          );
        });
    };
  },
]);

function buildFormData(formData, data, parentKey) {
  if (
    data &&
    typeof data === "object" &&
    !(data instanceof Date) &&
    !(data instanceof File)
  ) {
    if (parentKey && parentKey.split("[").length < formDataMaximumFieldLength) {
      try {
        Object.keys(data).forEach((key) => {
          if (
            parentKey &&
            parentKey.split("[").length < formDataMaximumFieldLength
          ) {
            buildFormData(
              formData,
              data[key],
              parentKey ? `${parentKey}[${key}]` : key
            );
          } else if (parentKey == null || parentKey == undefined) {
            buildFormData(
              formData,
              data[key],
              parentKey ? `${parentKey}[${key}]` : key
            );
          } else {
            //
            throw BreakException;
          }
        });
      } catch (e) {}
    } else if (parentKey == null || parentKey == undefined) {
      try {
        Object.keys(data).forEach((key) => {
          if (
            parentKey &&
            parentKey.split("[").length < formDataMaximumFieldLength
          ) {
            buildFormData(
              formData,
              data[key],
              parentKey ? `${parentKey}[${key}]` : key
            );
          } else if (parentKey == null || parentKey == undefined) {
            buildFormData(
              formData,
              data[key],
              parentKey ? `${parentKey}[${key}]` : key
            );
          } else {
            throw BreakException;
          }
        });
      } catch (e) {}
    }
  } else {
    let newValueFormDataField = data == null ? "" : data;
    if (newValueFormDataField instanceof Date) {
      newValueFormDataField = moment(newValueFormDataField).format(
        "YYYY-MM-DDTHH:mm:ss.SSS"
      );
    }
    formData.append(parentKey, newValueFormDataField);
  }
}

function jsonToFormData(data) {
  const formData = new FormData();
  buildFormData(formData, data, null, 0);
  return formData;
}

function responseControl(response, fn, unAuthorizeFunc, isPost) {
  if (response.status === 401) {
    if (isPost) {
      hideSpinner();
    }
    if (unAuthorizeFunc) unAuthorizeFunc(response);
    else {
      Swal.fire({
        title: GetResourceValue("Error"),
        text: GetResourceValue("UnauthorizedProcess"),
        icon: "error",
      });
    }
  } else if (response.status === 403) {
    let timerInterval;
    hideSpinner();
    Swal.fire({
      title: GetResourceValue("SessionTimeOut"),
      html: GetResourceValue("RedirectToLogin") + "<b></b>",
      timer: 5000,
      timerProgressBar: true,
      didOpen: () => {
        Swal.showLoading();
        timerInterval = setInterval(() => {
          const content = Swal.getContent();
          if (content) {
            const b = content.querySelector("b");
            if (b) {
              b.textContent = Swal.getTimerLeft();
            }
          }
        }, 100);
      },
      willClose: () => {
        clearInterval(timerInterval);
      },
    }).then((result) => {
      /* Read more about handling dismissals below */
      if (result.dismiss === Swal.DismissReason.timer) {
        window.location = "/Account/Login";
      }
    });
  } else {
    if (fn) fn();
  }
}
