package com.kevin.oes.servelt;

import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.kevin.oes.Constants;
import com.kevin.oes.exception.ParamterException;
import com.kevin.oes.model.Question;
import com.kevin.oes.service.QuestionService;
import com.kevin.oes.util.StringUtil;

public class EditQuestion extends HttpServlet {
	private static final long serialVersionUID = 1L;

    public EditQuestion() {
        super();
    }
	@Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

	}

	@Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
	    Question question = null;
        HttpSession session = request.getSession();
        String questionId = request.getParameter("questionId");
        String title = request.getParameter("questionTitle");
        String answer = request.getParameter("answer");
        String optionA = request.getParameter("optionA");
        String optionB = request.getParameter("optionB");
        String optionC = request.getParameter("optionC");
        String optionD = request.getParameter("optionD");
        QuestionService questionService = new QuestionService();
        if(StringUtil.isEmpty(answer)){
            System.out.println(Constants.CREATEQUESTION_PATH);
            request.getRequestDispatcher(Constants.CREATEQUESTION_PATH).forward(request, response);
            return;
        }

        question = new Question();
        question.setTitle(title);
        question.setAnswer(Integer.parseInt(answer));
        question.setOptionA(optionA);
        question.setOptionB(optionB);
        question.setOptionC(optionC);
        question.setOptionD(optionD);

        try {
         //   questionService.deleteQuestionById(Integer.parseInt(questionId));
            questionService.addQuestion(question);
            session.setAttribute(Constants.SUCCESS_SAVEQUESTION, "修改问题成功!");
            response.sendRedirect(request.getContextPath()+"/showQuestion");
        } catch (ParamterException e) {
            e.printStackTrace();
        }
	}
}
