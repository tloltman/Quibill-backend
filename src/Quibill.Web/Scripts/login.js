function LoginPage() {
    var self = this;

    var tokenKey = 'accessToken';

    function appendError(errorString) {
        $('#errors-container').show();
        $('#errors-container ul').append("<li>" + errorString + "</li>");
    }

    function clearErrors() {
        $('#errors-container ul').empty();
    }

    function showError(jqXHR) {
        clearErrors();
        var response = jqXHR.responseJSON;
        if (response) {
            if (response.error_description) {
                appendError(response.error_description);
            }
            if (response.ModelState) {
                var modelState = response.ModelState;
                for (var errorProp in modelState) {
                    if (modelState.hasOwnProperty(errorProp)) {
                        var errorArray = modelState[errorProp];
                        if (errorArray.length) {
                            for (var i = 0; i < errorArray.length; ++i) {
                                appendError(errorArray[i]);
                            }
                        }
                    }
                }
            }
        }
    }

    self.getValues = function () {
        var token = sessionStorage.getItem(tokenKey);
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }


        $.ajax({
            type: 'GET',
            url: '/api/values/1',
            headers: headers
        }).done(function (data) {
            $('#values').append("<li>" + data + "</li>");
        }).fail(showError);
    }

    self.register = function() {
        var registerData = {
            Email: $('#registerEmail').val(),
            Password: $('#registerPassword').val(),
            ConfirmPassword: $('#registerConfirmPassword').val()
        }

        $.ajax({
            type: 'POST',
            url: '/api/Account/Register',
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            data: registerData
        }).done(function(data) {
            alert("Successfully registered!");
        }).fail(showError);
    };

    self.login = function() {
        var loginData = {
            grant_type: 'password',
            username: $('#loginUserName').val(),
            password: $('#loginPassword').val()
        }

        $.ajax({
            type: 'POST',
            url: '/Token',
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            data: loginData
        }).done(function(data) {
            window.location.replace('/Home/Index');
            sessionStorage.setItem(tokenKey, data.access_token);
        }).fail(showError);
    };

    self.logout = function () {
        var token = sessionStorage.getItem(tokenKey);
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            type: 'POST',
            url: '/api/Account/Logout',
            headers: headers
        }).done(function (data) {
            window.location.replace('/Home/Index');
            sessionStorage.removeItem(tokenKey);
        }).fail(showError);
    }
}

$(function() {
    var loginPage = new LoginPage();

    $('#registerButton').click(loginPage.register);
    $('#loginButton').click(loginPage.login);
    $('#logoutButton').click(loginPage.logout);
    $('#getValuesButton').click(loginPage.getValues);
});
