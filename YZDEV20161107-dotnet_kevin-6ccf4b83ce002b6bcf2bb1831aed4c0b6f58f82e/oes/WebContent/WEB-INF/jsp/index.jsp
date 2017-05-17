<%@page import="com.kevin.oes.util.Pagination"%>
<%@page import="com.kevin.oes.Constants"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
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
</head>
<body>
    <% 
    String successSaveQuestion = (String)session.getAttribute(Constants.SUCCESS_SAVEQUESTION);
    session.removeAttribute(Constants.SUCCESS_SAVEQUESTION);
    String showmsg = successSaveQuestion == null ? "":successSaveQuestion;
    String isDisplayFlashMessage ="";
    if(showmsg.equals("")){
        isDisplayFlashMessage = "style='display:none;'"; 
    }
    %>
    <div id="successFlashMessage" <%=isDisplayFlashMessage%>>
        <%
        out.print(showmsg);
        if(!showmsg.equals("")){
        %>
        <script type="text/javascript">
        setTimeout(function(){
            document.getElementById("successFlashMessage").style.display="none";
        },3000);
        </script>
        <%
          }
        %>
    </div>
    <div id="main">
        <jsp:include page="header.jsp"></jsp:include>
        <div class="navigation">
          <ul>
            <li class="default">Question Management</li>
            <li>Exam Management</li>
          </ul>
        </div>
        <div class="content">
          <div class="left_content">
            <ul>
              <li class="active">Question List</li>
              <li ><a href="SaveQuestion">Create Question</a></li>
            </ul>
          </div>
          <div class="right_content">
            <div class="search_form">
              <div class="display">
                <form action="#" method="post">
                  <input type="text" name="search" id="input_search" placeholder="Please input the keyword">
                </form>
                <div class="img">
                  <img src="static/images/ICN_Search_15x20.png"/>
                </div>
              </div>
            </div>
            <div class="list_date">
            
              <div class="date_header">
                <ul>
                  <li class="li_num"> </li>
                  <li class="li_id"><span style="padding-left:20px;"></span>ID&nbsp;<img src="static/images/ICN_Increase_10x15.png" width="10" style="cursor:pointer;"></li>
                  <li class="li_description">Description</li>
                  <li class="li_edit">Edit</li>
                  <li class="li_select"><input type="checkbox" ></li>
                </ul>
              </div>
              <div class="date_content">
              <!-- datecontent start -->
               <%
              List<Question> questions = (List<Question>)request.getAttribute("questions");
              int index = 1;
              Pagination pagination = (Pagination)request.getAttribute("pagination");
              for(Question question: questions){
              %>
              <ul class="question_line_ul">
                   <li>
                     <ul>
                         <li class="li_num" ><%=index %></li>
                         <li class="li_id"><%=question.getQuestionId() %></li>
                         <li class="li_description li_description_date" title="<%=question.getTitle() %>">
                            <a href="queryQuestion?questionId=<%=question.getId() %>">
                                 <xmp><%=question.getTitle() %></xmp>
                            </a>
                         </li>
                         <li class="li_edit"><a href="queryQuestion?questionId=<%=question.getId() %>"><img src="static/images/ICN_Edit_15x15.png"/></a></li>
                         <li class="li_select"><input type="checkbox" ></li>
                     </ul>
                   </li>
              </ul>
              <% 
                 index++;
               }
              %> 
              <!-- datecontent end -->
              </div>
              <div class="date_footer">
                  <div class="page">
                  <% if(pagination.isFirstPage()) {%>
                    <span><img src="static/images/BTN_PageLeft_20x15.png" style="opacity:0.3;"></span>
                   <% }else{%>  
                   <span><a href="showQuestion?currentPage=<%=pagination.getCurrentPage()-1%>"><img src="static/images/BTN_PageLeft_20x15.png"></a></span>
                   <% }%> 
                    <ul>
                       <li><%=pagination.getCurrentPage() %></li>
                    </ul>
                   <% if(pagination.isLastPage()) {%>
                    <span><img src="static/images/BTN_PageRight_20x15.png" style="opacity:0.3;"></span>
                   <% }else{%>  
                   <span><a href="showQuestion?currentPage=<%=pagination.getCurrentPage()+1%>"><img src="static/images/BTN_PageRight_20x15.png"></a></span>
                   <% }%> 
                   <form action="showQuestion" method="post">
                     <select name="paseSize" onchange="change_select()" id="select_id">
                       <option value="5">5</option>
                       <option value="10">10</option>
                     </select>
                     <input type="text" class="skip_page" id="skip_val">
                     <input type="button" class="go" value="Go" onclick="skip_go()" >
                   </form>
                  </div>
                  <div class="delete">
                    <form action="" method="post">
                      <input type="button" value="Delete">
                    </form>
                  </div>
              </div>
              <!-- datefooter end -->
            </div>
          </div>
        </div>
         <div class="footer">
           Copyright &copy; 2014 Augmentum, Inc,All rights Reserverd.
        </div>
    </div>
    <script type="text/javascript">
    function skip_go() {
        var skip_num = document.getElementById("skip_val").value;
        location.href="showQuestion?currentPage="+skip_num;
    }
    function change_select() {
        alert(1111);
        var option = document.getElementById("select_id").getElementsByTagName("option");
        
        alert(option.length);
        for(var i=0;i<option.length;i++) {
            alert(option[i].selected);
            if(option[i].selected){
                alert(option[i].value);
                location.href="showQuestion?paseSize="+option[i].value + "";
                break;
            }
        }
        
//         location.href="showQuestion?currentPage="+skip_num;
    }
    </script>
</body>
</html>