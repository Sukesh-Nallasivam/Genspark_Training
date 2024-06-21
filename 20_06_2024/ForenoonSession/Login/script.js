function login() {
    var username = document.getElementById("username").value;
    var password = document.getElementById("password").value;

    var validCredentials = [
        { username: "admin", password: "admin" },
        { username: "user1", password: "password1" },
        { username: "user2", password: "password2" }
    ];

    var isValid = validCredentials.some(function(credential) {
        return credential.username === username && credential.password === password;
    });

    if (isValid) {
        alert("Login successful");
        window.location = "home.html";
        return false;
    } else {
        alert("Login failed");
    }
}