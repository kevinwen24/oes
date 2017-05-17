package com.kevin.oes.servelt;

import java.io.IOException;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.kevin.oes.Constants;
import com.kevin.oes.model.Question;
import com.kevin.oes.service.QuestionService;
import com.kevin.oes.util.Pagination;
import com.kevin.oes.util.StringUtil;
public class ShowQuestionServlet extends HttpServlet {
    private static final long serialVersionUID = 1L;

    public ShowQuestionServlet() {
        super();
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        QuestionService questionService = new QuestionService();
        String currentPage = request.getParameter("currentPage");
        String pageSize = request.getParameter("pageSize");

        if(StringUtil.isEmpty(currentPage)) {
            currentPage = "1";
        }

        if(StringUtil.isEmpty(pageSize)) {
            pageSize = "10";
        }
        if(currentPage.equals("null")) {
            currentPage = "1";
        }
        if(pageSize.equals("null")) {
            pageSize = "10";
        }
        Pagination pagination = new Pagination();
        pagination.setCurrentPage(Integer.parseInt(currentPage));
        pagination.setPageSize(Integer.parseInt(pageSize));
        if(pagination.getPageSize()>10) {
            pagination.setPageSize(10);
        }
        List<Question> questions = questionService.query(pagination);
        request.setAttribute("questions", questions);
        request.setAttribute("pagination", pagination);
        HttpSession session = request.getSession();
        session.setAttribute("pagination", pagination);
        request.getRequestDispatcher(Constants.SHOWQUESTION_PATH).forward(request,response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }

}
