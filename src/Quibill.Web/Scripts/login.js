function LoginPage() {
    var self = this;

    var tokenKey = 'accessToken';

    function showError(jqXHR) {

        console.log(jqXHR.status + ': ' + jqXHR.statusText);

        console.log(jqXHR.responseJSON);
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
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(registerData)
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
            data: JSON.stringify(loginData)
        }).done(function(data) {
            alert("User: " + data.username + "successfully logged in!");
        }).fail(showError);
    };

    self.logout = function() {
        $.ajax({
            type: 'POST',
            url: '/api/Account/Logout'
        }).done(function(data) {
            alert("Successfully logged out!");
        }).fail(showError);
    }
}

var loginPage = new LoginPage();