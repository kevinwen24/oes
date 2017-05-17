function create_question() {
    var formObj = document.getElementById("createQuestion_from");
    var questionTitle = document.getElementById("question_title_textarea");
    var optionA = document.getElementById("optionA");
    var optionB = document.getElementById("optionB");
    var optionC = document.getElementById("optionC");
    var optionD = document.getElementById("optionD");
    var isSub = true;

    if(!questionTitle.value.trim()){
        questionTitle.style.border="1px dashed red";
        isSub = false;
    }

    if(!optionA.value.trim()){
        optionA.style.border="1px dashed red";
        isSub = false;
    }

    if(!optionB.value.trim()){
        optionB.style.border="1px dashed red";
        isSub = false;
    }

    if(!optionC.value.trim()){
        optionC.style.border="1px dashed red";
        isSub = false;
    }

    if(!optionD.value.trim()){
        optionD.style.border="1px dashed red";
        isSub = false;
    }

    if (isSub) {
        if (optionA.value.trim() == optionB.value.trim()
            || optionA.value.trim() == optionC.value.trim()
            || optionA.value.trim() == optionD.value.trim()
            || optionB.value.trim() == optionC.value.trim()
            || optionB.value.trim() == optionD.value.trim() 
            || optionC.value.trim() == optionD.value.trim()) {
            alertWinSameContent("please input different answer");
            return;
        }
    }
    if(isSub){
        formObj.submit();
    }

}

function alertWinSameContent(content) {
    var errorFlashMessage = document.getElementById("errorFlashMessage");
    errorFlashMessage.style.display = "block";
    errorFlashMessage.innerHTML = content;
    setTimeout(function(){
        errorFlashMessage.style.display="none";
    },2500);
}