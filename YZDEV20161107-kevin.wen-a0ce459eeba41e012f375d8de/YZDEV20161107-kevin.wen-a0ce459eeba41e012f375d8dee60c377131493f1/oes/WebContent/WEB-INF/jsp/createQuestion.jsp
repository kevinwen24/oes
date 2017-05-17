<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
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
</head>
<body>
    <div id="main">
        <jsp:include page="header.jsp"></jsp:include>
        <div class="navigation">
          <ul>
            <li class="default">Question Management</li>
            <li>Exam Management</li>
          </ul>
        </div>
        <div class="address" >
          <a href="showQuestion.action" style="a_link_detailQuestion">Question management</a>  &gt; Create question
        </div>
        <div class="content">
          <div class="create_question">
            <form action="saveQuestion.action" method="post" id="createQuestion_from">
            <ul>
              <li>
                 <span class="question_span">Question</span>
                 <textarea  name="questionTitle" class="question_title" style="margin-left:20px;"  id="question_title_textarea" > </textarea> 
              </li>
              <li>
                 <span>Answer</span>
                 <ul class="answer_li">
                      <li><input type="radio" value="0" name="answer" checked > <label>A</label> <input type="text" name="optionA" class="option" id="optionA"></li>             
                      <li><input type="radio" value="1" name="answer"> <label>B</label> <input type="text" name="optionB" class="option" id="optionB"></li>             
                      <li><input type="radio" value="2" name="answer"> <label>C</label> <input type="text" name="optionC" class="option" id="optionC"></li>             
                      <li><input type="radio" value="3" name="answer"> <label>D</label> <input type="text" name="optionD" class="option" id="optionD"></li>             
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
           Copyright &copy; 2014 Augmentum, Inc,All rights Reserverd.
        </div>
    </div>
</body>
</html>
 <script type="text/javascript" src="static/js/create_question.js"></script>