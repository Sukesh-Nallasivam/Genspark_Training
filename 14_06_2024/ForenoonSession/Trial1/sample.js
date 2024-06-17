function OnSubmit(){
    alert("Form submitted successfully");
    return true;
}


function ValidateForm(){
    var email = document.getElementById("email");
    var password = document.getElementById("password");
    
if (email.value === "") {
        email.classList.add("error");
        email.classList.remove("passed");
    } else {
        email.classList.remove("error");
        email.classList.add("passed");
    }

    if (password.value === "") {
        password.classList.add("error");
        password.classList.remove("passed");
    } else if (password.value.length < 6) {
        password.classList.add("error");
        password.classList.remove("passed");
    } else {
        password.classList.remove("error");
        password.classList.add("passed");
    }
}