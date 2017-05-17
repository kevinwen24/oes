function submitEdit() {
    var createQuestion_from = document.getElementById("createQuestion_from");
    createQuestion_from.submit();
}

function Cancel(pageSize, currentPage) {
    var showModalDialog = document.getElementById("showModalDialog");
    var popScreen = document.getElementById("popScreen");
    var confirmDiv = document.getElementById("confirmDiv");

    showModalDialog.style.display = "block";
    popScreen.style.display = "block";
    var isclickYes = false;
    confirmDiv.onclick = function() {
        isclickYes = true;
        showModalDialog.style.display = "none";
        popScreen.style.display = "none";
        if(isclickYes){
          location.href="showQuestion.action?pageSize="+pageSize+"&currentPage="+currentPage;
        }
    }
    
}

function closePopWin() {
    var showModalDialog = document.getElementById("showModalDialog");
    var popScreen = document.getElementById("popScreen");
    showModalDialog.style.display = "none";
    popScreen.style.display = "none";
}