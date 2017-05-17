function create_question() {
    var formObj = document.getElementById("createQuestion_from");
    var questionTitle = document.getElementsByTagName("textarea")[0];
    var optionA = document.getElementById("optionA");
    var optionB = document.getElementById("optionB");
    var optionC = document.getElementById("optionC");
    var optionD = document.getElementById("optionD");
    var isSub = true;
    alert(questionTitle.innerHTML.trim());
    if(!questionTitle.innerHTML ==""){
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