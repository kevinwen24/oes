package com.kevin.oes.servelt;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.kevin.oes.Constants;
import com.kevin.oes.model.Question;
import com.kevin.oes.service.QuestionService;
import com.kevin.oes.util.StringUtil;
public class DetailQuestion extends HttpServlet {
    private static final long serialVersionUID = 1L;
    public DetailQuestion() {
        super();
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String questionId = request.getParameter("questionId");
        if (StringUtil.isEmpty(questionId)) {
            return;
        }

        if(!StringUtil.isEmpty(questionId)) {
            if (!questionId.matches("[0-9]*")) {
                request.setAttribute("", "Illegal parameters");
                return ;
            }else {
                if(questionId.length()>6){
                    return;
                }
            }
        }
        QuestionService questionService = new QuestionService();
        Question question = questionService.queryQuestionById(Integer.parseInt(questionId));
        request.setAttribute("question",question );
        request.getRequestDispatcher(Constants.DETAILQUESTION_PATH).forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    }

}
