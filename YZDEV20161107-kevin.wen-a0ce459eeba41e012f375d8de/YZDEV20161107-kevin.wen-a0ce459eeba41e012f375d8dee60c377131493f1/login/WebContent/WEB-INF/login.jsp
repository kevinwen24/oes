<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
<%@ page import="com.augmentum.login.*" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Login</title>
    <style type="text/css">
        #msg{
            color: red;
        }
        .errorMessage{
            color: red;
            padding-left: 6px;
        }
    </style>
  </head>
  <script type="text/javascript">
  function login(){
      /* var userVal = document.getElementById("userName").value;
      var passVal = document.getElementById("password").value;
      var formIsSub = true;
      if (!userVal) {
    	  document.getElementById("tipUserName").innerHTML = "user name is required";
    	  formIsSub = false;
      }
      
      if (!passVal) {
    	  document.getElementById("tipPassword").innerHTML = "password is required";
    	  formIsSub = false;
      }
      if (formIsSub) { */
          var formObj = document.getElementById("loginForm");
          formObj.submit();
      /* } */
  }
  </script>
  <body>  
    <% String msg = (String)request.getAttribute(Constants.TIP_MESSAGE);
       Map<String,String> errorFields = (Map<String,String>)request.getAttribute(Constants.ERRFIELDS);
       if (msg != null) {
          out.print("<p id='msg'>"+msg+"</p>");
        }
       
       if (errorFields == null) {
           errorFields= new HashMap<String,String>();
       }
        %>
    <form action="login" method="post" name="loginForm" id="loginForm">
       userName <input type="text" name="userName" id="userName" />
                <span id="tipUserName" class="errorMessage">
                  <% String userName = errorFields.get("userName") == null ? "" : errorFields.get("userName");
                     out.print(userName);
                  %>
                </span><br/>
       password <input type="password" name="password" id="password" />
                <span id="tipPassword" class="errorMessage">
                <% String password = errorFields.get("password") == null ? "" : errorFields.get("password");
                   out.print(password);
                %>
                </span><br/>
       <input type="button" value="Login" onclick="login()" />
    </form>
  </body>
</html>