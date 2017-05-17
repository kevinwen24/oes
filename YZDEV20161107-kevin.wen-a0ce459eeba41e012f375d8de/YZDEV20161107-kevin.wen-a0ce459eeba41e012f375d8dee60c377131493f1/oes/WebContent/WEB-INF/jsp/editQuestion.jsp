<%@page import="com.kevin.oes.Constants"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="com.kevin.oes.model.*" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
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
    <link style="text/css" rel="stylesheet"  href="static/css/edit.css">
    <script type="text/javascript" src="static/js/edit.js"></script>
</head>
<body>

    <%
    Question question = (Question)request.getAttribute("question");
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
          <a href="showQuestion.action" style="a_link_detailQuestion">Question management</a> &gt; Edit question
        </div>
        <div class="content">
          <div class="create_question" id="create_question">
            <form action="editQuestion.action" method="post" id="createQuestion_from">
            <ul id="editQuestion">
                <li class="li_id">
                 <span class="question_span">ID</span>
                 <input type="hidden" value="<%=question.getId() %>" name="questionId"> 
                 <input type="text" value="<%=question.getQuestionId() %>" readonly="readonly" style="width:100px;" >
              </li>
              <li class="li_title">
                 <span class="question">Question</span>
                 <textarea  name="questionTitle" class="question_title" style="margin-left:20px"> <%=question.getTitle() %></textarea> 
              </li>
              <li class="li_answer">
                 <span>Answer</span>
                 <ul class="answer_li" id="answer_id">
                      <li><input type="radio" value="0" name="answer"> <label>A</label> <input type="text" name="optionA" class="option" value=" <%=question.getOptionA() %>"></li>             
                      <li><input type="radio" value="1" name="answer"> <label>B</label> <input type="text" name="optionB" class="option" value=" <%=question.getOptionB() %>"></li>             
                      <li><input type="radio" value="2" name="answer"> <label>C</label> <input type="text" name="optionC" class="option" value=" <%=question.getOptionC() %>"></li>             
                      <li><input type="radio" value="3" name="answer"> <label>D</label> <input type="text" name="optionD" class="option" value=" <%=question.getOptionD() %>"></li>             
                 </ul>
              </li>
              <li>
                 <input type="button" value="Save" class="create" onclick="submitEdit()"> 
                 <input type="reset" value="Reset" class="cancel"> 
              </li>
            </ul>
            </form>
          </div>
        </div>
         <div class="footer">
           Copyright &copy; 2014 Augmentum, Inc,All rights Reserverd.
        </div>
    </div>
    <script type="text/javascript">
    document.getElementById("answer_id").getElementsByTagName("li")[<%=answer%>].getElementsByTagName("input")[0].checked="true";
    document.getElementById("answer_id").getElementsByTagName("li")[<%=answer%>].getElementsByTagName("input")[1].style.background="#ccc";
    </script>
</body>
</html>