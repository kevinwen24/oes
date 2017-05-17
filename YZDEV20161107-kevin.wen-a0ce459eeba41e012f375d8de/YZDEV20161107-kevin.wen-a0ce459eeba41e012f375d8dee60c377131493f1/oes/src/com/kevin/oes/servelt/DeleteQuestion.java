package com.kevin.oes.servelt;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.kevin.oes.Constants;
import com.kevin.oes.service.QuestionService;
import com.kevin.oes.util.StringUtil;
public class DeleteQuestion extends HttpServlet {
    private static final long serialVersionUID = 1L;
    public DeleteQuestion() {
        super();
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        doPost(request, response);
    }
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String[] deleteQuestion = request.getParameterValues("deleteQuestionId");
        String pageSize = request.getParameter("pageSizeInDelete");
        System.out.println(pageSize);
        String currentPage = request.getParameter("currentPage");
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
        QuestionService questionService = new QuestionService();
        int[] questions = new int[deleteQuestion.length];

        for (int i=0; i<deleteQuestion.length; i++) {
            questions[i]= Integer.parseInt(deleteQuestion[i]);
        }

        int records = questionService.deleteQuestionByIds(questions);
        request.getSession().setAttribute(Constants.SUCCESS_SAVEQUESTION, "delete "+records+" record");
        response.sendRedirect(request.getContextPath()+"/showQuestion.action?pageSize="+pageSize+"&currentPage="+currentPage);
    }
}
