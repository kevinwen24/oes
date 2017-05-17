window.onload = function(){
    var date_content = getObjById("date_content");
    var select = date_content.getElementsByTagName("input");
    var isShow =true; 
    for (var i = 0; i<select.length;i++) {
        if (!select[i].checked ) {
            isShow = false; 
            break;
         }
    }  
    if(!isShow) {
        var deleteBtn = getObjById("deleteBtn");
        deleteBtn.style.cursor="auto";
    }
    var isDelete = deleteSubmit();
    
}

function skipGo(contextPath, search, pageSize) {
    var skip_num = getObjById("skipVal").value;
    if(isNaN(skip_num)||skip_num.trim()==""){
        var errorFlashMessage = getObjById("errorFlashMessage");
        errorFlashMessage.style.display="block";
        errorFlashMessage.innerHTML ="Illegal data format!";
        setTimeout(function(){
            errorFlashMessage.style.display="none";
        },2500);
    } else {
         if (search == "") {
                location.href = contextPath + "/page/question/index?currentPage=" + skip_num+"&pageSize=" + pageSize;
            } else {
                location.href = contextPath + "/page/question/index?currentPage=" + skip_num+"&pageSize=" + pageSize+"&search="+search;
        }
    }
}

function changeSelect(contextPath, currentPage, search) {
    var option1 = document.getElementsByTagName("option")[0];
    var option2 = document.getElementsByTagName("option")[1];
    if (option1.selected) {
        pageSize = option1.value;
    } else if (option2.selected) {
        pageSize = option2.value;
    }
    if (search == "") {
        location.href=contextPath+"/page/question/index?currentPage="+currentPage+"&pageSize="+pageSize;
    } else {
        location.href=contextPath+"/page/question/index?currentPage="+currentPage+"&pageSize="+pageSize+"&search="+search;
    }
}

function checkAll(obj) {
    var date_content = getObjById("date_content");
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
    var checkAll = getObjById("checkAllSelect");
    var date_content = getObjById("date_content");
    var select = date_content.getElementsByTagName("input");
    var num = 0;
    if(!ele.checked) {
        checkAll.checked = ele.checked;
    }
    isSelectAll();
}

function closePopWin() {
    var showModalDialog = getObjById("showModalDialog");
    var popScreen = getObjById("popScreen");
    showModalDialog.style.display = "none";
    popScreen.style.display = "none";
}

function isSelectAll() {
    var checkAll = getObjById("checkAllSelect");
    var date_content = getObjById("date_content");
    var select = date_content.getElementsByTagName("input");
    var num = 0;
    for (var i=0; i<select.length;i++) {
        if (select[i].checked ){
            num++;
        }
    }
    if (num > 0){
        deleteBtn.style.background="#FE9901";
    } else {
        deleteBtn.style.background="#ccc";
    }
     
    if (num == select.length) {
        checkAll.checked = true;
        return true;
    }
    return false;
}
function deleteSubmit(ele) {
    var date_content = getObjById("date_content");
    var deleteBtn = getObjById("deleteBtn");
    var deleteuqestionForm = getObjById("deleteuqestionForm");
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
        var showModalDialog = getObjById("showModalDialog");
        var popScreen = getObjById("popScreen");
        showModalDialog.style.display = "block";
        popScreen.style.display = "block";
        var confirmDiv = getObjById("confirmDiv");
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
    var input_search = getObjById("input_search");
    if(input_search.value.trim() == "") {
        var errorFlashMessage = getObjById("errorFlashMessage");
        errorFlashMessage.style.display="block";
        errorFlashMessage.innerHTML ="please input the keyword!";
        setTimeout(function(){
            errorFlashMessage.style.display="none";
        },2500);
        return;
    }
    searchForm.submit();
}

function showSortImg(contextPath, sort) {
    var ele = getObjById("sortQuestionImg");
    if (sort == "DESC" || sort =="") {
        ele.src = contextPath + "/static/images/ICN_Decrese_10x15.png";
    } else {
        ele.src = contextPath + "/static/images/ICN_Increase_10x15.png";
    }
}

function sortQuestion(contextPath, ele, currentPage, pageSize, search, sort) {
    if(sort == "DESC") {
        sort = "ASC";
    } else if (sort == "ASC"){
        sort = "DESC";
    }
   var ele = getObjById("sortQuestionImg");
    if (search == "") {
          location.href = contextPath + "/page/question/index?currentPage=" + currentPage + "&pageSize=" + pageSize + "&sort=" + sort;
    } else {
          location.href = contextPath + "/page/question/index?currentPage=" + currentPage + "&pageSize="+pageSize+"&search=" + search + "&sort=" + sort;
    }
}

function showErrorMsg(msg) {
    if (msg == "") {
       return;
    }
     var errorFlashMessage = getObjById("errorFlashMessage");
     errorFlashMessage.style.display = "block";
     errorFlashMessage.innerHTML = msg;
     setTimeout(function(){
         errorFlashMessage.style.display="none";
     },2500);
}

function showCurrentPage(currentPage) {
    var paginationUlNode = getObjById("pagination");
    var liNodes = paginationUlNode.getElementsByTagName("li");
    for (var i = 0; i<liNodes.length ;i++) {
        var aNode = liNodes[i].getElementsByTagName("a")[0];
        if (aNode.innerHTML.trim() == currentPage) {
            aNode.style.color = "#FE9901";
            break;
        }
    }
}
