<%@ page import="com.augmentum.oes.Constants"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="com.augmentum.oes.model.*" %>
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
          <a href="showQuestion.action" >Question management</a> &gt; Detail question
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
                    <xmp ><%=question.getTitle()%></xmp>
                 </div>
                 <div class="answer">
                    <ul id="answer_select">
                       <li>A&nbsp;<xmp> <%=question.getOptionA() %></xmp></li>
                        <li>B&nbsp; <xmp><%=question.getOptionB() %></xmp></li>
                       <li>C&nbsp;<xmp> <%=question.getOptionC() %></xmp></li>
                         <li>D&nbsp;<xmp> <%=question.getOptionD() %></xmp></li>
                    </ul>
                 </div>
                 <div class="btn">
                    <a href="editQuestion.action?questionId=<%=question.getId() %>&pageSize=<%=pageSize%>&currentPage=<%=currentPage%>" class="edit">Edit</a>
                    <span class="delete"  onclick="deleteSubmit('<%=question.getId() %>')">delete</span>
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
    
    function deleteSubmit(id) {
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
              location.href="deleteQuestion.action?deleteQuestionId="+id+"&pageSize=<%=pageSize%>&currentPage=<%=currentPage%>";
            }
        }
    }
    
    function closePopWin() {
        var showModalDialog = document.getElementById("showModalDialog");
        var popScreen = document.getElementById("popScreen");
        showModalDialog.style.display = "none";
        popScreen.style.display = "none";
    }
    </script>
</body>
</html>