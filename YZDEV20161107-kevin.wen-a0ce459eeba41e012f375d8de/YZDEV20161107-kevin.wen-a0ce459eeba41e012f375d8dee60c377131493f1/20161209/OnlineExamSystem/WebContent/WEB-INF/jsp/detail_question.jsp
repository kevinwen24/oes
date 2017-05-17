<%@ page import="com.augmentum.oes.Constants"%>
<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="com.augmentum.oes.model.*" %>
<%@ page import="com.augmentum.oes.util.*" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <% String path= request.getContextPath();
       String basePath = request.getScheme()+"://" + request.getServerName() + ":" + request.getServerPort()+path+"/";
    %>
    <base href="<%=basePath %>">
    <title>Online Exam System</title>
    <link style="text/css" rel="stylesheet"  href="static/css/reset.css">
    <link style="text/css" rel="stylesheet"  href="static/css/header.css">
    <link style="text/css" rel="stylesheet"  href="static/css/style.css">
    <link style="text/css" rel="stylesheet"  href="static/css/detail.css">
    <script type="text/javascript" src="static/js/common.js"></script>
</head>
<body>
    <div id="showModalDialog"></div>
      <div id="popScreen">
        <div class="tilte" id="titleTip">Are you sure delete the selected options?</div>
        <div class="close" onclick="closePopWin()"><img src="static/images/BTN_Close_16x16.png"></div>
        <div class="confirm_div" id="confirmDiv">Yes</div>
        <div class="cancel_div" id="cancelDiv"  onclick="closePopWin()">No</div>
    </div>
    <%
    Question question = (Question)request.getAttribute("question");
    int pageSize = (Integer)request.getAttribute("pageSize");
    int currentPage = (Integer)request.getAttribute("currentPage");
    int answer = question.getAnswer();
    %>
    <div id="main">
        <jsp:include page="header.jsp"></jsp:include>
        <div class="navigation">
          <ul>
            <li class="default">Question Management</li>
            <li>Exam Management</li>
          </ul>
        </div>
        <div class="address" >
          <a href="<%=PathUtil.getFullPath("question/index?currentPage=" + currentPage + "&pageSize=" + pageSize)%>" >Question management</a> ＞ Detail question＞ <%=question.getQuestionId() %>
        </div>
        <div class="content">
          <div class="create_question">
             <div class="left_detail">
               <div class="question_id">
                 Question ID
               </div>
               <div class="question">
                 Question
               </div>
               <div class="answer">
                 Answer 
               </div>
             </div> 
             
             <div class="right_detail">
                 <div class="question_id">
                     <%=question.getQuestionId()%>
                 </div>
                 <div class="question">
                    <%=StringUtil.htmlEncode(question.getTitle())%>
                 </div>
                 <div class="answer">
                    <ul id="answer_select">
                       <li>A&nbsp;<%=StringUtil.htmlEncode(question.getOptionA()) %></li>
                        <li>B&nbsp;<%=StringUtil.htmlEncode(question.getOptionB()) %></li>
                       <li>C&nbsp;<%=StringUtil.htmlEncode(question.getOptionC()) %></li>
                         <li>D&nbsp;<%=StringUtil.htmlEncode(question.getOptionD())%></li>
                    </ul>
                 </div>
                 <div class="btn">
                    <a href="<%=PathUtil.getFullPath("question/edit/" + question.getId() + "?pageSize=" + pageSize + "&currentPage=" + currentPage)%>" class="edit">Edit</a>
                    <span class="delete"  onclick="deleteSubmit()">delete</span>
                 </div>  
             </div>
                       
          </div>
        </div>
         <div class="footer">
           Copyright &copy; 2014 Augmentum, Inc,All rights Reserverd.
        </div>
    </div>
    <script type="text/javascript">
    var answer = document.getElementById("answer_select").getElementsByTagName("li")[<%=question.getAnswer()%>];
    answer.style.background="#D2dae3";
    
    function deleteSubmit() {
        var deleteuqestionForm = document.getElementById("deleteuqestionForm");
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
              location.href = "<%=PathUtil.getFullPath("question/delete?deleteQuestionId=" + question.getId() + "&pageSize= " + pageSize+ "&currentPage=" + currentPage)%>";
            }
        }
    }
    </script>
    <script type="text/javascript" src="static/js/edit.js"></script>
</body>
</html>