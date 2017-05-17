<%@ page import="com.augmentum.oes.Constants"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="com.augmentum.oes.model.*" %>
<%@ page import="com.augmentum.oes.util.*" %>
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Online Exam System</title>
    <link style="text/css" rel="stylesheet"  href="<%=PropertyUtil.getStaticUrl() %>css/reset.css">
    <link style="text/css" rel="stylesheet"  href="<%=PropertyUtil.getStaticUrl() %>css/header.css">
    <link style="text/css" rel="stylesheet"  href="<%=PropertyUtil.getStaticUrl() %>css/style.css">
    <link style="text/css" rel="stylesheet"  href="<%=PropertyUtil.getStaticUrl() %>css/edit.css">
    <script type="text/javascript" src="<%=PropertyUtil.getStaticUrl() %>js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="<%=PropertyUtil.getStaticUrl() %>js/create_question.js"></script>
    <script type="text/javascript" src="<%=PropertyUtil.getStaticUrl() %>js/common.js"></script>
    <script type="text/javascript" src="<%=PropertyUtil.getStaticUrl() %>js/edit.js"></script>
</head>
<body>
 <div id="showModalDialog"></div>
      <div id="popScreen">
        <div class="tilte" id="titleTip">Are you sure cancel edit question?</div>
        <div class="close" onclick="closePopWin()"><img src="<%=PropertyUtil.getStaticUrl() %>images/BTN_Close_16x16.png"></div>
        <div class="confirm_div" id="confirmDiv">Yes</div>
        <div class="cancel_div" id="cancelDiv"  onclick="closePopWin()">No</div>
    </div>
    <%
    Question question = (Question)request.getAttribute("question");
    int pageSize = (Integer)request.getAttribute("pageSize");
    int currentPage = (Integer)request.getAttribute("currentPage");
    int answer = question.getAnswer();
    %>
    <div id="errorFlashMessage"></div>
    <div id="main">
        <jsp:include page="header.jsp"></jsp:include>
        <div class="navigation">
          <ul>
            <li class="default">Question Management</li>
            <li>Exam Management</li>
          </ul>
        </div>
        <div class="address" >
          <a href="<%=PathUtil.getFullPath("question/index?currentPage=" + currentPage + "&pageSize=" + pageSize)%>">Question management</a> ＞ Edit question
        </div>
        <div class="content">
          <div class="create_question" id="create_question">
            <form action="<%=PathUtil.getFullPath("question/save")%>" method="post" id="createQuestion_from" name="saveQuestionForm">
            <ul id="editQuestion">
                <li class="li_id">
                 <span class="question_span">ID</span>
                 <input type="hidden" value="<%=question.getId() %>" name="questionId"/> 
                 <input type="text" value="<%=question.getQuestionId() %>" readonly="readonly" style="width:100px;" />
              </li>
              <li class="li_title">
                 <span class="question">Question</span>
                 <textarea  name="questionTitle" class="question_title" style="margin-left:20px" > <%=question.getTitle() %></textarea> 
              </li>
              <li class="li_answer">
                 <span>Answer</span>
                 <ul class="answer_li" id="answer_id">
                      <li><input type="radio" value="0" name="answer"/> <label>A</label> <input type="text" name="optionA" class="option" value=" <%=question.getOptionA() %>" maxlength="100"/></li>
                      <li><input type="radio" value="1" name="answer"/> <label>B</label> <input type="text" name="optionB" class="option" value=" <%=question.getOptionB() %>" maxlength="100"/></li>
                      <li><input type="radio" value="2" name="answer"/> <label>C</label> <input type="text" name="optionC" class="option" value=" <%=question.getOptionC() %>" maxlength="100"/></li>
                      <li><input type="radio" value="3" name="answer"/> <label>D</label> <input type="text" name="optionD" class="option" value=" <%=question.getOptionD() %>" maxlength="100"/></li>
                 </ul>
              </li>
              <li>
                 <input type="button" value="Save" class="create" onclick="submitEdit()"/> 
                 <input type="button" value="Cancel" class="cancel" onclick="Cancel('<%=request.getContextPath() %>', '<%=pageSize %>', '<%=currentPage %>')" />
              </li>
            </ul>
            </form>
          </div>
        </div>
         <div class="footer">
           Copyright &copy; 2014 Augmentum, Inc, All rights Reserverd.
        </div>
    </div>
    <script type="text/javascript">
        document.getElementById("answer_id").getElementsByTagName("li")[<%=answer%>].getElementsByTagName("input")[0].checked="true";
        document.getElementById("answer_id").getElementsByTagName("li")[<%=answer%>].getElementsByTagName("input")[1].style.background="#ccc";
        var obj = new Object();
        obj.title = "<%=question.getTitle()%>";
        obj.answer = "<%=question.getAnswer()%>";
        obj.answerA = "<%=question.getOptionA()%>";
        obj.answerB = "<%=question.getOptionB()%>";
        obj.answerC = "<%=question.getOptionC()%>";
        obj.answerD = "<%=question.getOptionD()%>";
        isModify(obj);
    </script>
</body>
</html>