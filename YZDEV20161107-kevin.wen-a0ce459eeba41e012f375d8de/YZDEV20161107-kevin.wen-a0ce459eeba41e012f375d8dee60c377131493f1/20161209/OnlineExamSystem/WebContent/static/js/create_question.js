function create_question() {
    var formObj = getObjById("createQuestion_from");
    var questionTitle = getObjById("question_title_textarea");
    var optionA = getObjById("optionA");
    var optionB = getObjById("optionB");
    var optionC = getObjById("optionC");
    var optionD = getObjById("optionD");
    var isSub = true;

    if(!questionTitle.value.trim()){
        setEleBorder(questionTitle, "1px dashed red");
        isSub = false;
    }

    if(!optionA.value.trim()){
        setEleBorder(optionA, "1px dashed red");
        isSub = false;
    }

    if(!optionB.value.trim()){
        setEleBorder(optionB, "1px dashed red");
        optionB.style.border="1px dashed red";
        isSub = false;
    }

    if(!optionC.value.trim()){
        setEleBorder(optionC, "1px dashed red");
        isSub = false;
    }

    if(!optionD.value.trim()){
        setEleBorder(optionD, "1px dashed red");
        isSub = false;
    }

    if (isSub) {
        if (inputValueTrim(optionA) == inputValueTrim(optionB)
            || inputValueTrim(optionA) == inputValueTrim(optionC)
            || inputValueTrim(optionA) == inputValueTrim(optionD)
            || inputValueTrim(optionB) == inputValueTrim(optionC)
            || inputValueTrim(optionB) == inputValueTrim(optionD)
            || inputValueTrim(optionC) == inputValueTrim(optionD)
            ) {
            alertWinSameContent("please input different answer");
            return;
        }
    }

    if(isSub){
        formObj.submit();
    }

}

function alertWinSameContent(content) {
    var errorFlashMessage = getObjById("errorFlashMessage");
    errorFlashMessage.style.display = "block";
    errorFlashMessage.innerHTML = content;
    setTimeout(function(){
        errorFlashMessage.style.display="none";
    },2500);
}