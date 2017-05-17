<%@ page import="com.augmentum.oes.util.Pagination"%>
<%@ page import="com.augmentum.oes.Constants"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ page import="java.util.*" %>
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
  <script type="text/javascript" src="<%=PropertyUtil.getStaticUrl() %>js/common.js"></script>
  <script type="text/javascript" src="<%=PropertyUtil.getStaticUrl() %>js/index.js"></script>
</head>
<body>
  <div id="showModalDialog"></div>
  <div id="popScreen">
    <div class="tilte" id="titleTip">Are you sure delete the selected options?</div>
    <div class="close" onclick="closePopWin()"><img src="<%=PropertyUtil.getStaticUrl() %>images/BTN_Close_16x16.png"></div>
    <div class="confirm_div" id="confirmDiv">Yes</div>
    <div class="cancel_div" id="cancelDiv"  onclick="closePopWin()">No</div>
  </div>
    <% 
        String successSaveQuestion = (String)session.getAttribute(Constants.SUCCESS_SAVEQUESTION);
        Pagination pagination = (Pagination)request.getAttribute("pagination");
        session.removeAttribute(Constants.SUCCESS_SAVEQUESTION);
        String showmsg = successSaveQuestion == null ? "":successSaveQuestion;
        String isDisplayFlashMessage ="";

        String failQueryQuestion = (String)session.getAttribute(Constants.FAIL_QUERYQUESTION);
        session.removeAttribute(Constants.FAIL_QUERYQUESTION);

        if("".equals(showmsg)){
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
              <li class="active"><a href="<%=PathUtil.getFullPath("question/index")%>">Question List</a></li>
              <li><a href="<%=PathUtil.getFullPath("question/save")%>">Create Question</a></li>
            </ul>
          </div>
          <div class="right_content">
            <div class="search_form">
              <div class="display">
                <form action="<%=PathUtil.getFullPath("question/index")%>" method="post" name="searchForm">
                  <input type="text" name="search" id="input_search" placeholder="Please input the keyword" value="<%if(!pagination.getSearch().equals("")){out.print(pagination.getSearch());} %>"/>
                  <input type="hidden" name="pageSize"  value="<%=pagination.getPageSize() %>" />
                  <input type="hidden" name="currentPage" value="<%=pagination.getCurrentPage() %>"/>
                </form>
                <div class="img">
                  <img src="<%=PropertyUtil.getStaticUrl() %>images/ICN_Search_15x20.png" onclick="searchQuestion()"/>
                </div>
              </div>
            </div>
            <div class="list_date" id="container">
            
              <div class="date_header">
                <ul>
                  <li class="li_num"> </li>
                  <li class="li_id"><span style="padding-left:20px;"></span>ID&nbsp;
                    <%if (pagination.getSearch().equals("DESC")) {%>
                    <img id="sortQuestionImg" src="<%=PropertyUtil.getStaticUrl() %>images/ICN_Decrese_10x15.png" width="10" style="cursor:pointer;" onclick="sortQuestion('<%=request.getContextPath() %>', this,'<%=pagination.getCurrentPage() %>','<%=pagination.getPageSize()%>','<%=pagination.getSearch() %>','<%=pagination.getSort() %>')">
                    <%} else { %>
                    <img id="sortQuestionImg" src="<%=PropertyUtil.getStaticUrl() %>images/ICN_Increase_10x15.png" width="10" style="cursor:pointer;" onclick="sortQuestion('<%=request.getContextPath() %>', this,'<%=pagination.getCurrentPage() %>','<%=pagination.getPageSize()%>','<%=pagination.getSearch() %>','<%=pagination.getSort() %>')">
                    <% }  %>
                  </li>
                  <li class="li_description li_description_word">Description</li>
                  <li class="li_edit">Edit</li>
                  <li class="li_select" ><input type="checkbox" onclick="checkAll(this)" id="checkAllSelect"></li>
                </ul>
              </div>
              <div class="date_content" id="date_content">
              <!-- data content start -->
              <form action="<%=PathUtil.getFullPath("question/delete")%>" method="post" id="deleteuqestionForm">
              <ul class="question_line_ul">
                
               <%
              @SuppressWarnings("unchecked")
              List<Question> questions = (List<Question>)request.getAttribute("questions");
              int index = 1;
              for(Question question: questions){
              %>
                   <li>
                     <ul>
                         <li class="li_num" ><%=index %></li>
                         <li class="li_id"><%=question.getQuestionId() %></li>
                         <li class="li_description li_description_date" title="<%=question.getTitle() %>">
                            <a href="<%=PathUtil.getFullPath("question/detail/" + question.getId() +"?currentPage="+ pagination.getCurrentPage() +"&pageSize=" +pagination.getPageSize())%>">
                                 <%=StringUtil.htmlEncode(question.getTitle()) %>
                            </a>
                         </li>
                         <li class="li_edit"><a href="<%=PathUtil.getFullPath("question/edit/" + question.getId() +"?currentPage="+ pagination.getCurrentPage() +"&pageSize=" +pagination.getPageSize())%>"><img src="<%=PropertyUtil.getStaticUrl() %>images/ICN_Edit_15x15.png"/></a></li>
                         <li class="li_select"  id="checkbox_i"><input class="question_check" type="checkbox"  onclick="selectCheckBox(this)" name="deleteQuestionId" value="<%=question.getId()%>"></li>
                     </ul>
                   </li>
              <% 
                 index++;
               }
              %> 
              </ul>
                 <input type="hidden" name="pageSize"  value="<%=pagination.getPageSize() %>" />
                 <input type="hidden" name="currentPage" value="<%=pagination.getCurrentPage() %>"/>
               
              </form>
              <!-- data content end -->
              </div>
              <div class="date_footer" >
                  <div class="page">
                  <% if(pagination.isFirstPage()) {%>
                    <span><img src="<%=PropertyUtil.getStaticUrl() %>images/BTN_PageLeft_20x15.png" style="opacity:0.3;"></span>
                   <% } else {
                        if (pagination.getSearch() == ""){
                            %>  
                           <span>
                             <a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getCurrentPage() - 1) + "&pageSize=" + pagination.getPageSize())%>">
                               <img src="<%=PropertyUtil.getStaticUrl() %>images/BTN_PageLeft_20x15.png">
                             </a>
                           </span>
                            <%
                        } else {
                            %>  
                            <span>
                              <a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getCurrentPage() - 1) + "&pageSize=" + pagination.getPageSize() + "&search=" + pagination.getSearch())%>">
                                <img src="<%=PropertyUtil.getStaticUrl() %>images/BTN_PageLeft_20x15.png">
                              </a>
                            </span>
                            <%
                        }
                   }%> 
                   <!--页码开始  -->
                   <ul class="pagination" id="pagination">
                   <%if (pagination.getPageCount() <= 4) {
                       for (int i = 1;i <= pagination.getPageCount();i++) {
                   %>
                         <li <%if(i == pagination.getCurrentPage()) {%> class="active" <%}%> >
                          <a href="<%=PathUtil.getFullPath("question/index?currentPage=" + i + "&pageSize=" + pagination.getPageSize()) %>"><%=i %></a>
                         </li>
                       
                   <%     }
                     } else if (pagination.getPageCount() - pagination.getCurrentPage() <= 3){ 
                  %>
                           <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getPageCount() - 3) + "&pageSize=" + pagination.getPageSize()) %>"> <%=pagination.getPageCount() - 3 %></a></li>
                           <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getPageCount() - 2) + "&pageSize=" + pagination.getPageSize()) %>"><%=pagination.getPageCount() - 2 %></a></li>
                           <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getPageCount() - 1) + "&pageSize=" + pagination.getPageSize()) %>"><%=pagination.getPageCount() - 1 %></a></li>
                           <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getPageCount() ) + "&pageSize=" + pagination.getPageSize()) %>"><%=pagination.getPageCount()  %></a></li>
                  <%
                      } else if (pagination.getPageCount() - pagination.getCurrentPage() > 3 && (pagination.getCurrentPage() != 1)) {
                   %>
                           <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getCurrentPage() - 1) + "&pageSize=" + pagination.getPageSize()) %>"><%=pagination.getCurrentPage() - 1 %></a></li>
                           <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + pagination.getCurrentPage() + "&pageSize=" + pagination.getPageSize()) %>"><%=pagination.getCurrentPage() %></a></li>
                           <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getCurrentPage() + 1) + "&pageSize=" + pagination.getPageSize()) %>"><%=pagination.getCurrentPage() + 1 %></a></li>
                           <li>...</li>
                           <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getPageCount()) + "&pageSize=" + pagination.getPageSize()) %>"><%=pagination.getPageCount()%></a></li>
                   <%  
                      } else if (pagination.getPageCount() - pagination.getCurrentPage() > 3 && (pagination.getCurrentPage() == 1)) {
                          %>
                            <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + pagination.getCurrentPage() + "&pageSize=" + pagination.getPageSize()) %>"><%=pagination.getCurrentPage()%></a></li>
                            <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getCurrentPage() + 1) + "&pageSize=" + pagination.getPageSize()) %>"><%=pagination.getCurrentPage() + 1  %></a></li>
                            <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getCurrentPage() + 2) + "&pageSize=" + pagination.getPageSize()) %>"><%=pagination.getCurrentPage() + 2 %></a></li>
                            <li>...</li>
                            <li><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getPageCount()) + "&pageSize=" + pagination.getPageSize()) %>"><%=pagination.getPageCount()%></a></li>
                          <% 
                              }
                  %>
                  </ul>
                    <!--页码结束  -->
                    <% if(pagination.isLastPage()) {%>
                    <span><img src="<%=PropertyUtil.getStaticUrl() %>images/BTN_PageRight_20x15.png" style="opacity:0.3;"></span>
                    <% }else{
                       if (pagination.getSearch() == ""){
                            %>  
                            <span><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getCurrentPage() + 1) + "&pageSize=" + pagination.getPageSize())%>">
                              <img src="<%=PropertyUtil.getStaticUrl() %>images/BTN_PageRight_20x15.png"></a>
                            </span>
                            <% 
                       } else {
                           %>  
                           <span><a href="<%=PathUtil.getFullPath("question/index?currentPage=" + (pagination.getCurrentPage() + 1) + "&pageSize=" + pagination.getPageSize() + "&search=" + pagination.getSearch())%>">
                             <img src="<%=PropertyUtil.getStaticUrl() %>images/BTN_PageRight_20x15.png"></a>
                           </span>
                           <% 
                       }
                    }
                   %> 
                     <select name="paseSize" onchange="changeSelect('<%=request.getContextPath() %>','<%=pagination.getCurrentPage()%>','<%=pagination.getSearch() %>')" id="select_id">
                       <option value="5" <% if (pagination.getPageSize()== 5){out.print("selected='true'");}%>>5</option>
                       <option value="10" <% if (pagination.getPageSize()== 10){out.print("selected='true'");}%>>10</option>
                     </select>
                     <input type="hidden" name="currentPage" value="<%=pagination.getCurrentPage() %>"/>
                     <input type="text" class="skip_page" id="skipVal" value="<%=pagination.getCurrentPage() %>" />
                     <input type="button" class="go" value="Go" onclick="skipGo('<%=request.getContextPath() %>', '<%=pagination.getSearch() %>', '<%=pagination.getPageSize() %>')" />
                  </div>
                  <div class="delete">
                      <input type="button" value="Delete" id="deleteBtn" onclick="deleteSubmit(this)"/>
                      <input type="hidden" name="pageSizeInDelete"  value="<%=pagination.getPageSize() %>" />
                      <input type="hidden" name="currentPage" value="<%=pagination.getCurrentPage() %>"/>
                  </div>
              </div>
              <!-- datefooter end -->
            </div>
          </div>
        </div>
         <div class="footer">
           Copyright &copy; 2014 Augmentum, Inc, All rights Reserverd.
        </div>
    </div>
</body>
<script type="text/javascript">
    showSortImg("<%=request.getContextPath()%>","<%=pagination.getSort()%>");
    showCurrentPage("<%=pagination.getCurrentPage()%>");
</script>
</html>