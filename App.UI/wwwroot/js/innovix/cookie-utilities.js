
// Get the value of a cookie by its name
function getCookie(name) {
    const nameEquals = name + '=';
    const cookieArray = document.cookie.split(';');

    for (cookie of cookieArray) {
        while (cookie.charAt(0) == ' ') {
            cookie = cookie.slice(1, cookie.length);
        }

        if (cookie.indexOf(nameEquals) == 0)
            return decodeURIComponent(
                cookie.slice(nameEquals.length, cookie.length),
            );
    }

    return null;
}

// Set a cookie with a given name, value, and optional expiration (in days)
function setCookie(name, value, days) {
    var expires = "";
    if (days) {
        var expiryDate = new Date();
        expiryDate.setTime(expiryDate.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + expiryDate.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}