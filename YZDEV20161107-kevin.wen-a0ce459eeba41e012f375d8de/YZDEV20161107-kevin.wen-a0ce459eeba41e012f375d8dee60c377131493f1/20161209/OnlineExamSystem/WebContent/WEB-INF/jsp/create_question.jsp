<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
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
    <script type="text/javascript" src="static/js/common.js"></script>
</head>
<body>
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
      <a href="<%=PathUtil.getFullPath("question/index")%>">Question management</a> ＞ Create question
    </div>
    <div class="content">
      <div class="create_question">
        <form action="<%=PathUtil.getFullPath("question/save")%>" method="post" id="createQuestion_from">
           <ul>
              <li>
                <span class="question_span">Question</span>
                <textarea  name="questionTitle" class="question_title" style="margin-left:20px;" maxlength="200"  id="question_title_textarea" > </textarea> 
             </li>
             <li>
               <span>Answer</span>
               <ul class="answer_li">
               <li><input type="radio" value="0" name="answer" checked > <label>A</label> <input type="text" name="optionA" class="option" id="optionA" maxlength="100"></li>             
               <li><input type="radio" value="1" name="answer" > <label>B</label> <input type="text" name="optionB" class="option" id="optionB" maxlength="100"></li>             
               <li><input type="radio" value="2" name="answer"> <label>C</label> <input type="text" name="optionC" class="option" id="optionC" maxlength="100"></li>             
               <li><input type="radio" value="3" name="answer"> <label>D</label> <input type="text" name="optionD" class="option" id="optionD" maxlength="100"></li>             
            </ul>
           </li>
           <li>
             <input type="button" value="Create" class="create" onclick="create_question()"> 
             <input type="reset" value="Reset" class="cancel"> 
          </li>
        </ul>
      </form>
     </div>
    </div>
    <div class="footer">
      Copyright &copy; 2014 Augmentum, Inc, All rights Reserverd.
    </div>
  </div>
 <script type="text/javascript" src="static/js/create_question.js"></script>
</body>
</html>