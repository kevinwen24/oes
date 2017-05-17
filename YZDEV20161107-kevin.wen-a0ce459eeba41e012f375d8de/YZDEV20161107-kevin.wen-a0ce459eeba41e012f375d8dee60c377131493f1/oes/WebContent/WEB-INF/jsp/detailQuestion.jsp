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
    <link style="text/css" rel="stylesheet"  href="static/css/detail.css">
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
          <a href="showQuestion.action" style="a_link_detailQuestion">Question management</a> &gt; Detail question
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
                     <%=question.getQuestionId() %>
                 </div>
                 <div class="question">
                    <xmp class="question"> <%=question.getTitle() %></xmp>
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
	                <a href="queryQuestion.action?questionId=<%=question.getId() %>" class="edit">Edit</a>
	                <a href="deleteQuestion.action?deleteQuestionId=<%=question.getId() %>" class="delete">delete</a>
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
    </script>
</body>
</html>