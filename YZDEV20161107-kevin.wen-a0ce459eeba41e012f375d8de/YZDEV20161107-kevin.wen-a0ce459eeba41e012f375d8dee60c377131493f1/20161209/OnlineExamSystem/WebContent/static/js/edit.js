var obj = null;
function submitEdit() {
    var canSub = false;
    var questionTitle = getObjIndexFirstByName("questionTitle");
    
    var optionA = getObjIndexFirstByName("optionA");
    var optionB = getObjIndexFirstByName("optionB");
    var optionC = getObjIndexFirstByName("optionC");
    var optionD = getObjIndexFirstByName("optionD");
    console.log($("input[type='radio']:checked").val());
    
    if (!$("input[type='radio']:checked").val()) {
    	$("input[type='radio']:checked").val(4);
    }
    if (obj) {
        if (obj.title != inputValueTrim(questionTitle)
            || obj.answer !=  $("input[type='radio']:checked").val()
            || obj.answerA != inputValueTrim(optionA) 
            || obj.answerB != inputValueTrim(optionB)  
            || obj.answerC != inputValueTrim(optionC)  
            || obj.answerD != inputValueTrim(optionD)) {
            canSub = true;
            console.log(questionTitle);
        }
    }
    if (!canSub) {
        alertWinSameContent("you do not modify !");
        return;
    }
    var createQuestion_from = getObjById("createQuestion_from");
    createQuestion_from.submit();
}

function Cancel(contextPath,pageSize, currentPage) {
    var showModalDialog = getObjById("showModalDialog");
    var popScreen = getObjById("popScreen");
    var confirmDiv = getObjById("confirmDiv");

    showModalDialog.style.display = "block";
    popScreen.style.display = "block";
    var isclickYes = false;
    confirmDiv.onclick = function() {
        isclickYes = true;
        showModalDialog.style.display = "none";
        popScreen.style.display = "none";
        if(isclickYes){
          location.href=contextPath + "/page/question/index?pageSize="+pageSize+"&currentPage="+currentPage;
        }
    }
    
}

function closePopWin() {
    var showModalDialog = getObjById("showModalDialog");
    var popScreen = getObjById("popScreen");
    showModalDialog.style.display = "none";
    popScreen.style.display = "none";
}

function isModify(obje){
    obj = obje;
}