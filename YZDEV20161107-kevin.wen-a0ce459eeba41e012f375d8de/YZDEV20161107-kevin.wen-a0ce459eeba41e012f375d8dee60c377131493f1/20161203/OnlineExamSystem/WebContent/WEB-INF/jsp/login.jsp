<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
<%@ page import="com.augmentum.oes.*" %>
<% String path= request.getContextPath();
   String basePath = request.getScheme()+"://" + request.getServerName() + ":" + request.getServerPort()+path+"/";
%>
<%
    String visibility = "hidden";
    String msg = null;
    if(request.getAttribute(Constants.TIP_MESSAGE) != null) {
    msg = (String)request.getAttribute(Constants.TIP_MESSAGE);

    if( msg!=null && !msg.equals("")){
        visibility = "visible";
      }
    }
%>
<!DOCTYPE html>
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <base href="<%=basePath %>">
    <title>Login</title>
    <link rel="stylesheet" href="static/css/reset.css" style="text/css">
    <link rel="stylesheet" href="static/css/login.css" style="text/css">
    <script type="text/javascript" src="static/js/login.js"></script>
  </head>
  <body>
    <div class="container">
      <div class="logo">
             <img alt="logo" src="static/images/LOGO_Web_Login_90x180.png">
             <p> Online Exam Web System</p>
    </div>
    <div class="form_div">
       <div class="welcome">Welcome to login!</div>
       <div class="form_container">
         <div class="empty"></div>
         <p id="tip_message" style="visibility:<%=visibility %>">
         <%=msg %>
         </p>
         <form action="saveLogin.action" method="post" id="loginForm" name="loginForm">
           <div class="input_line  input_line_userName">
             <input type="text" name="userName" class="input_userName" placeholder="User name"/>
               <span id="error_userName"></span>
               <input type="hidden" name="go" value="<%= (String)request.getAttribute("go") == null?"":(String)request.getAttribute("go")%>"/>
               <input type="hidden" name="queryString" id="queryString"/> 
               <img src="static/images/ICN_Usename_20x20.png"/>
             </div>
             <div class="input_line">
               <input type="password" name="password" class="input_password" placeholder="Password"/><span id="error_password"></span><br/>
             </div>
             <div>
               <input type="button" value="Login" class="input_submit" onclick="login()"/>
             </div>  
             <div class="input_line input_checkbox_line">
               <input type="checkbox" class="input_checkbox">
               <span class="word_msg word_msg">Remember me</span>
               <span class="forget_password word_msg">Forgot password?</span>
             </div>    
           </form>
         </div>
      </div>
  </div>
  <div class="footer">
    Copyright &copy; 2014 Augmentum, Inc, All rights Reserverd.
  </div>
  <% if(request.getAttribute(Constants.TIP_MESSAGE) != null) {
     String msg2 = (String)request.getAttribute(Constants.TIP_MESSAGE);
     System.out.println(msg2);
  %>
      <script type="text/javascript">
          var tip_message = document.getElementById("tip_message");
          tip_message.style.visibility="visible";
          tip_message.innerHTML = "<%=msg2%>";
      </script>
  <%} %>
   <%
   
     if(request.getAttribute(Constants.ERRFIELDS) == null)  {
         Map<String, String> map = new HashMap<String, String>();
     } 
     if(request.getAttribute(Constants.ERRFIELDS) != null) {
         @SuppressWarnings("unchecked")
         Map<String, String> map = (Map<String, String>)request.getAttribute(Constants.ERRFIELDS);
     if(map.size() == 2){
  %>
      <script type="text/javascript">
          var errorUserName = document.getElementById("error_userName");
          var errorPassword = document.getElementById("error_password");
          errorUserName.style.display="block";
          errorPassword.style.display="block";
          tip_message.style.visibility="visible";
          tip_message.innerHTML = "User name and Password is required";
      </script>
  <%
     } 
  %>
  <% 
      if(map.containsKey("userName") && !map.containsKey("password")){
  %>
      <script type="text/javascript">
      var errorUserName = document.getElementById("error_userName");
      errorUserName.style.display="block";
      tip_message.style.visibility="visible";
      tip_message.innerHTML = "User name  is required";
     </script>
  <%
  }
      if(map.containsKey("password") && !map.containsKey("userName")){
      %>
      <script type="text/javascript">
      var errorPassword = document.getElementById("error_password");
      errorPassword.style.display="block";
      tip_message.style.visibility="visible";
      tip_message.innerHTML = "Password is required";
     </script>
      <%
    }
   }
  %>
  <script type="text/javascript">
      var queryString = location.hash;
      document.getElementById("queryString").value = queryString;
      console.log(queryString);
  </script>
  </body>
</html>