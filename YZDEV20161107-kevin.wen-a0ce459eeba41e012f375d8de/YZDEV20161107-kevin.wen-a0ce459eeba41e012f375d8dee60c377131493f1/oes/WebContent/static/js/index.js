window.onload=function(){
    var date_content = document.getElementById("date_content");
    var select = date_content.getElementsByTagName("input");
    var isShow =true; 
    for (var i=0; i<select.length;i++) {
        if (!select[i].checked ) {
            isShow = false; 
            break;
         }
    }  
    if(!isShow) {
        var delete_btn = document.getElementById("delete_btn");
        delete_btn.style.cursor="auto";
    }
    var isDelete = deleteSubmit();
}


function skipGo() {
    var skip_num = document.getElementById("skip_val").value;
    if(isNaN(skip_num)||skip_num.trim()==""){
        var errorFlashMessage = document.getElementById("errorFlashMessage");
        errorFlashMessage.style.display="block";
        errorFlashMessage.innerHTML ="Illegal data format!";
        setTimeout(function(){
            errorFlashMessage.style.display="none";
        },2500);
    }else{
        location.href="showQuestion.action?currentPage="+skip_num;
    }
    }
function changeSelect(currentPage) {
    var option1 = document.getElementsByTagName("option")[0];
    var option2 = document.getElementsByTagName("option")[1];
    if (option1.selected) {
        pageSize = option1.value;
    } else if (option2.selected) {
        pageSize = option2.value;
    }
    location.href="showQuestion.action?currentPage="+currentPage+"&pageSize="+pageSize;
}
function checkAll(obj) {
    var date_content = document.getElementById("date_content");
    var select = date_content.getElementsByTagName("input");
    for (var i=0; i<select.length;i++) {
        select[i].checked = obj.checked;
    }
    if(deleteSubmit()) {
      delete_btn.style.background="#FE9901";
   }else{
      delete_btn.style.background="#ccc";
   }
}
function selectCheckBox(ele) {
    var checkAll = document.getElementById("checkAll");
    if(!ele.checked) {
        checkAll.checked=ele.checked;
    }
    if(deleteSubmit()) {
       delete_btn.style.background="#FE9901";
    }else{
       delete_btn.style.background="#ccc";
    }
}

function closePopWin() {
    var disabled_screen = document.getElementById("disabled_screen");
    var pop_screen = document.getElementById("pop_screen");
    disabled_screen.style.display = "none";
    pop_screen.style.display = "none";
}
function deleteSubmit(ele) {
   var date_content = document.getElementById("date_content");
   var delete_btn = document.getElementById("delete_btn");
   var deleteuqestionForm = document.getElementById("deleteuqestionForm");
   var select = date_content.getElementsByTagName("input");
   
   var isClick =true;
   var num = 0;
     for (var i=0; i<select.length;i++) {
      if (select[i].checked ){
        num++;
      }
  }
     if( num == 0) {
       delete_btn.style.background="#ccc";
       return false;
     }
     delete_btn.style.background="#FE9901";
     delete_btn.style.cursor="pointer";
     if(ele) {
        var disabled_screen = document.getElementById("disabled_screen");
        var pop_screen = document.getElementById("pop_screen");
        disabled_screen.style.display = "block";
        pop_screen.style.display = "block";
        var confrim_div = document.getElementById("confrim_div");
        var isclickYes = false;
        confrim_div.onclick = function() {
            isclickYes = true;
            disabled_screen.style.display = "none";
            pop_screen.style.display = "none";
            if(isclickYes){
                deleteuqestionForm.submit();
            }
        }
         
     }
     return true;
}
