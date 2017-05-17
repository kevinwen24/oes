window.onload = function(){
    var date_content = document.getElementById("date_content");
    var select = date_content.getElementsByTagName("input");
    var isShow =true; 
    for (var i = 0; i<select.length;i++) {
        if (!select[i].checked ) {
            isShow = false; 
            break;
         }
    }  
    if(!isShow) {
        var deleteBtn = document.getElementById("deleteBtn");
        deleteBtn.style.cursor="auto";
    }
    var isDelete = deleteSubmit();
}

function skipGo(search,pageSize) {
    var skip_num = document.getElementById("skipVal").value;
    if(isNaN(skip_num)||skip_num.trim()==""){
        var errorFlashMessage = document.getElementById("errorFlashMessage");
        errorFlashMessage.style.display="block";
        errorFlashMessage.innerHTML ="Illegal data format!";
        setTimeout(function(){
            errorFlashMessage.style.display="none";
        },2500);
    } else {
         if (search == "") {
                location.href="showQuestion.action?currentPage="+skip_num+"&pageSize="+pageSize;
            } else {
                location.href="showQuestion.action?currentPage="+skip_num+"&pageSize="+pageSize+"&search="+search;
        }
    }
}

function changeSelect(currentPage,search) {
    var option1 = document.getElementsByTagName("option")[0];
    var option2 = document.getElementsByTagName("option")[1];
    if (option1.selected) {
        pageSize = option1.value;
    } else if (option2.selected) {
        pageSize = option2.value;
    }
    if (search == "") {
        location.href="showQuestion.action?currentPage="+currentPage+"&pageSize="+pageSize;
    } else {
        location.href="showQuestion.action?currentPage="+currentPage+"&pageSize="+pageSize+"&search="+search;
    }
}

function checkAll(obj) {
    var date_content = document.getElementById("date_content");
    var select = date_content.getElementsByTagName("input");
    for (var i=0; i<select.length;i++) {
        select[i].checked = obj.checked;
    }
    if(deleteSubmit()) {
      deleteBtn.style.background="#FE9901";
   } else {
      deleteBtn.style.background="#ccc";
   }
}

function selectCheckBox(ele) {
    var checkAll = document.getElementById("checkAllSelect");
    var date_content = document.getElementById("date_content");
    var select = date_content.getElementsByTagName("input");
    var num = 0;
    if(!ele.checked) {
        checkAll.checked = ele.checked;
    }

    if(deleteSubmit()) {
       deleteBtn.style.background="#FE9901";
    } else {
       deleteBtn.style.background="#ccc";
    }

    for (var i=0; i<select.length;i++) {
        if (select[i].checked ){
            num++;
        }
    }
    if (num == select.length) {
        checkAll.checked = "checked";
    }
}

function closePopWin() {
    var showModalDialog = document.getElementById("showModalDialog");
    var popScreen = document.getElementById("popScreen");
    showModalDialog.style.display = "none";
    popScreen.style.display = "none";
}

function deleteSubmit(ele) {
    var date_content = document.getElementById("date_content");
    var deleteBtn = document.getElementById("deleteBtn");
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
       deleteBtn.style.background="#ccc";
       return false;
    }
    deleteBtn.style.background="#FE9901";
    deleteBtn.style.cursor="pointer";
    if(ele) {
        var showModalDialog = document.getElementById("showModalDialog");
        var popScreen = document.getElementById("popScreen");
        showModalDialog.style.display = "block";
        popScreen.style.display = "block";
        var confirmDiv = document.getElementById("confirmDiv");
        var isclickYes = false;
        confirmDiv.onclick = function() {
            isclickYes = true;
            showModalDialog.style.display = "none";
            popScreen.style.display = "none";
            if(isclickYes){
                deleteuqestionForm.submit();
            }
        }
     }
     return true;
}

function searchQuestion() {
    var searchForm = document.forms.searchForm;
    var input_search = document.getElementById("input_search");
    if(input_search.value.trim() == "") {
        var errorFlashMessage = document.getElementById("errorFlashMessage");
        errorFlashMessage.style.display="block";
        errorFlashMessage.innerHTML ="please input the keyword!";
        setTimeout(function(){
            errorFlashMessage.style.display="none";
        },2500);
        return;
    }
    searchForm.submit();
}

function showSortImg(sort) {
    var ele = document.getElementById("sortQuestionImg");
    if (sort == "DESC" || sort =="") {
        ele.src = "static/images/ICN_Decrese_10x15.png";
    } else {
        ele.src = "static/images/ICN_Increase_10x15.png";
    }
}

function sortQuestion(ele,currentPage, pageSize, search, sort) {
    if(sort == "DESC") {
        sort = "ASC";
    } else {
        sort = "DESC";
    }
   var ele = document.getElementById("sortQuestionImg");
    if (search == "") {
        location.href = "showQuestion.action?currentPage=" + currentPage + "&pageSize=" + pageSize + "&sort=" + sort;
    } else {
        location.href = "showQuestion.action?currentPage=" + currentPage + "&pageSize="+pageSize+"&search=" + search + "&search=" + sort;
    }
}

function showErrorMsg(msg) {
    if (msg == "") {
       return;
    }
     var errorFlashMessage = document.getElementById("errorFlashMessage");
     errorFlashMessage.style.display = "block";
     errorFlashMessage.innerHTML = msg;
     setTimeout(function() {
         errorFlashMessage.style.display="none";
     },2500);
}

function showCurrentPage(currentPage) {
    var paginationUlNode = document.getElementById("pagination");
    var liNodes = paginationUlNode.getElementsByTagName("li");
    for (var i = 0; i<liNodes.length ;i++) {
        var aNode = liNodes[i].getElementsByTagName("a")[0];
        if (aNode.innerHTML == currentPage) {
            aNode.style.color = "#FE9901";
            break;
        }
    }
}
