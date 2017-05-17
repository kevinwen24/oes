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
    <script type="text/javascript" src="static/js/index.js"></script>
</head>
<body>

    <div id="disabled_screen"></div>
    <div id="pop_screen">
        <div class="tilte" id="title_tip">Are you sure delete the selected options?</div>
        <div class="close" onclick="closePopWin()"><img src="static/images/BTN_Close_16x16.png"></div>
        <div class="confrim_div" id="confrim_div">Yes</div>
        <div class="cancel_div" id="cancel_div"  onclick="closePopWin()">No</div>
    </div>
    <% 
    String successSaveQuestion = (String)session.getAttribute(Constants.SUCCESS_SAVEQUESTION);
    session.removeAttribute(Constants.SUCCESS_SAVEQUESTION);
    String showmsg = successSaveQuestion == null ? "":successSaveQuestion;
    String isDisplayFlashMessage ="";
    if(showmsg.equals("")){
        isDisplayFlashMessage = "style='display:none;'"; 
    }
    %>
    <div id="successFlashMessage" <%=isDisplayFlashMessage%> >
    
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
    <div id="errorFlashMessage"></div>
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
              <li ><a href="saveQuestion.action">Create Question</a></li>
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
            <div class="list_date" id="container">
            
              <div class="date_header">
                <ul>
                  <li class="li_num"> </li>
                  <li class="li_id"><span style="padding-left:20px;"></span>ID&nbsp;<img src="static/images/ICN_Increase_10x15.png" width="10" style="cursor:pointer;"></li>
                  <li class="li_description">Description</li>
                  <li class="li_edit">Edit</li>
                  <li class="li_select" ><input type="checkbox" onclick="checkAll(this)" id="check_all"></li>
                </ul>
              </div>
              <div class="date_content" id="date_content">
              <!-- datecontent start -->
              <ul class="question_line_ul">
              <form action="deleteQuestion.action" method="post" id="deleteuqestionForm">
               <%
              List<Question> questions = (List<Question>)request.getAttribute("questions");
              int index = 1;
              Pagination pagination = (Pagination)request.getAttribute("pagination");
              for(Question question: questions){
              %>
                   <li>
                     <ul>
                         <li class="li_num" ><%=index %></li>
                         <li class="li_id"><%=question.getQuestionId() %></li>
                         <li class="li_description li_description_date" title="<%=question.getTitle() %>">
                            <a href="detailQuestion.action?questionId=<%=question.getId() %>">
                                 <xmp><%=question.getTitle() %></xmp>
                            </a>
                         </li>
                         <li class="li_edit"><a href="queryQuestion.action?questionId=<%=question.getId() %>"><img src="static/images/ICN_Edit_15x15.png"/></a></li>
                         <li class="li_select"  id="checkbox_i"><input type="checkbox"  onclick="selectCheckBox(this)" name="deleteQuestionId" value="<%=question.getId()%>"></li>
                     </ul>
                   </li>
              <% 
                 index++;
               }
              %> 
              </ul>
              <!-- datecontent end -->
              </div>
              <div class="date_footer">
                  <div class="page">
                  <% if(pagination.isFirstPage()) {%>
                    <span><img src="static/images/BTN_PageLeft_20x15.png" style="opacity:0.3;"></span>
                   <% }else{%>  
                   <span><a href="showQuestion.action?currentPage=<%=pagination.getCurrentPage()-1%>&pageSize=<%=pagination.getPageSize()%>"><img src="static/images/BTN_PageLeft_20x15.png"></a></span>
                   <% }%> 
                    <ul>
                       <li style="padding-left:6px;padding-right:6px;"><%=pagination.getCurrentPage()%></li>
                    </ul>
                   <% if(pagination.isLastPage()) {%>
                    <span><img src="static/images/BTN_PageRight_20x15.png" style="opacity:0.3;"></span>
                   <% }else{%>  
                   <span><a href="showQuestion.action?currentPage=<%=pagination.getCurrentPage()+1%>&pageSize=<%=pagination.getPageSize() %>"><img src="static/images/BTN_PageRight_20x15.png"></a></span>
                   <% }%> 
                     <select name="paseSize" onchange="changeSelect('<%=pagination.getCurrentPage()%>')" id="select_id">
                       <option value="5" <% if (pagination.getPageSize()==5){out.print("selected='true'");}%>>5</option>
                       <option value="10" <% if (pagination.getPageSize()==10){out.print("selected='true'");}%>>10</option>
                     </select>
                     <input type="hidden" name="currentPage" value="<%=pagination.getCurrentPage() %>">
                     <input type="text" class="skip_page" id="skip_val">
                     <input type="button" class="go" value="Go" onclick="skipGo()" >
                  </div>
                  <div class="delete">
                      <input type="button" value="Delete" id="delete_btn" onclick="deleteSubmit(this)">
                      <input type="hidden" name="pageSizeInDelete"  value="<%=pagination.getPageSize() %>" >
                      <input type="hidden" name="currentPage" value="<%=pagination.getCurrentPage() %>">
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
</body>
</html>