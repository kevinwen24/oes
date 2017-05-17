package com.kevin.oes.servelt;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.kevin.oes.Constants;
import com.kevin.oes.model.Question;
import com.kevin.oes.service.QuestionService;

public class QueryServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

    public QueryServlet() {
        super();
    }
	@Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
	    doPost(request, response);
	}

	@Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
	    String questionId = request.getParameter("questionId");
	    QuestionService questionService = new QuestionService();
	    Question question = questionService.queryQuestionById(Integer.parseInt(questionId));
	    request.setAttribute("question",question );
	    request.getRequestDispatcher(Constants.EDITQUESTION_PATH).forward(request, response);
	}

}
