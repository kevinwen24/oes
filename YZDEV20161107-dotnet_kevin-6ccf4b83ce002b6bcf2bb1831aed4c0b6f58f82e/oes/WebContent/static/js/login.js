function login(){
    /*var formIsSub = true;
    var userName = document.getElementsByName("userName")[0].value;
    var password = document.getElementsByName("password")[0].value;
    var errorUserName = document.getElementById("error_userName");
    var errorPassword = document.getElementById("error_password");
    var tip_message = document.getElementById("tip_message");
    tip_message.style.visibility="visible";
    
    if(!userName.trim() && !password.trim()) {
        formIsSub = false;
        tip_message.style.visibility="visible";
        tip_message.innerHTML = "User name and Password is required";
        return;
    }
    if(!userName.trim()){
        errorUserName.style.display="block";
        tip_message.style.visibility="visible";
        tip_message.innerHTML = "User name is required";
        formIsSub = false;
        return;
    }
    if(!password.trim()){
        errorPassword.style.display="block";
        tip_message.style.visibility="visible";
        tip_message.innerHTML = "Password is required";
        formIsSub = false;
        return;
    }
    if(formIsSub){*/
        var form = document.forms.loginForm;
        form.submit();
//    }
}
window.onload = function(){
    var userName = document.getElementsByName("userName")[0];
    var password = document.getElementsByName("password")[0];
    var errorUserName = document.getElementById("error_userName");
    var errorPassword = document.getElementById("error_password");
    var tip_message = document.getElementById("tip_message");
    userName.onfocus = function(){
        errorUserName.style.display="none";
        tip_message.style.visibility="hidden";
    }
    
    password.onfocus = function(){
        errorPassword.style.display="none";
         tip_message.style.visibility="hidden";
    }
}
