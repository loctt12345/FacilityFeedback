function checkSignUpError() {
    var loginError = document.getElementById('loginError');
    if (loginError.textContent != "") {
        return;
    }
    var errorExisted = document.getElementsByClassName('error-signup');
    for (var i = 0; i < errorExisted.length; i++) {
        if (errorExisted[i].textContent != "") {
            form_container.classList.toggle('left-right');
            break;
        }
    }
}