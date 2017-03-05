function LoginPage() {
    var self = this;

    var tokenKey = 'accessToken';

    function showError(jqXHR) {

        console.log(jqXHR.status + ': ' + jqXHR.statusText);

        console.log(jqXHR.responseJSON);
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
            alert("Got value: " + data);
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
            username: $('#loginEmail').val(),
            password: $('#loginPassword').val()
        }

        $.ajax({
            type: 'POST',
            url: '/Token',
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            data: loginData
        }).done(function(data) {
            alert("User: " + data.userName + " successfully logged in!");
            sessionStorage.setItem(tokenKey, data.access_token);
        }).fail(showError);
    };

    self.logout = function() {
        sessionStorage.removeItem(tokenKey);
        alert("Successfully logged out!")
    }
}

var loginPage = new LoginPage();