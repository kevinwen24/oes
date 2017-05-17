var obj = null;
function submitEdit() {
    var canSub = false;
    var questionTitle = document.getElementsByName("questionTitle")[0];
    var optionA = document.getElementsByName("optionA")[0];
    var optionB = document.getElementsByName("optionB")[0];
    var optionC = document.getElementsByName("optionC")[0];
    var optionD = document.getElementsByName("optionD")[0];
    if (obj) {
        if (obj.title != questionTitle.value.trim()
            || obj.answerA != optionA.value.trim() 
            || obj.answerB != optionB.value.trim()  
            || obj.answerC != optionC.value.trim()  
            || obj.answerD != optionD.value.trim()){
            canSub = true;
            console.log(questionTitle);
        }
    }
    if (!canSub) {
        alertWinSameContent("you do not modify !");
        return;
    }
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

function isModify(obje){
    obj = obje;
}