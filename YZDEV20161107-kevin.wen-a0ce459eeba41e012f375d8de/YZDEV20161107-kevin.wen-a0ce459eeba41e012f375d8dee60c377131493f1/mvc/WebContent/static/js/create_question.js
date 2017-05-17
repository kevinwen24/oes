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

    if(!optionA.value){
        optionA.style.border="1px dashed red";
        isSub = false;
    }

    if(!optionB.value){
        optionB.style.border="1px dashed red";
        isSub = false;
    }

    if(!optionC.value){
        optionC.style.border="1px dashed red";
        isSub = false;
    }

    if(!optionD.value){
        optionD.style.border="1px dashed red";
        isSub = false;
    }

    if(isSub){
        formObj.submit();
    }
}