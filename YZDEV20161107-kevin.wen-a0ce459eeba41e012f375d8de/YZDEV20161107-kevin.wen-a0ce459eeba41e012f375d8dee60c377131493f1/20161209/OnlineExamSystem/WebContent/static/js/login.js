function login(){
    //test server validation
   /* var formIsSub = true;
    var userName = getObjIndexFirstByName("userName").value;
    var password = getObjIndexFirstByName("password").value;
    var errorUserName = getObjById("error_userName");
    var errorPassword = getObjById("error_password");
    var tip_message = getObjById("tip_message");

    if(!userName.trim() && !password.trim()) {
        formIsSub = false;
        tip_message.style.visibility="visible";
        tip_message.innerHTML = "User name and Password is required";
        return;
    }

    if(!userName.trim()){
        setEleStyleDiaplay(errorUserName,"block");
        setEleStylevisibility(tip_message, "visible");
        tip_message.innerHTML = "User name is required";
        formIsSub = false;
        return;
    }

    if(!password.trim()){
        setEleStyleDiaplay(errorPassword,"block");
        setEleStylevisibility(tip_message, "visible");
        tip_message.innerHTML = "Password is required";
        formIsSub = false;
        return;
    }

    if(formIsSub){*/
        var form = document.forms.loginForm;
        form.submit();
    /*}*/
}
window.onload = function(){
    var userName = getObjIndexFirstByName("userName");
    var password = getObjIndexFirstByName("password");
    var errorUserName = getObjById("error_userName");
    var errorPassword = getObjById("error_password");
    var tip_message = getObjById("tip_message");
    userName.onfocus = function(){
        setEleStyleDiaplay(errorUserName,"none");
        setEleStylevisibility(tip_message, "hidden");
    }
    
    password.onfocus = function(){
        setEleStyleDiaplay(errorPassword,"none");
        setEleStylevisibility(tip_message, "hidden");
    }
}
