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

public class SaveQuestionServlet extends HttpServlet {
   private static final long serialVersionUID = 1L;

    public SaveQuestionServlet() {
        super();
    }

   @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
       request.getRequestDispatcher(Constants.CREATEQUESTION_PATH).forward(request, response);
   }

   @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
       Question question = new Question();
       QuestionService questionService = new QuestionService();
       HttpSession session = request.getSession();

       String title = request.getParameter("questionTitle");
       String answer = request.getParameter("answer");
       String optionA = request.getParameter("optionA");
       String optionB = request.getParameter("optionB");
       String optionC = request.getParameter("optionC");
       String optionD = request.getParameter("optionD");

       if(StringUtil.isEmpty(answer)){
           System.out.println(Constants.CREATEQUESTION_PATH);
           request.getRequestDispatcher(Constants.CREATEQUESTION_PATH).forward(request, response);
            return;
        }

       question.setTitle(title.trim());
       question.setAnswer(Integer.parseInt(answer));
       question.setOptionA(optionA.trim());
       question.setOptionB(optionB.trim());
       question.setOptionC(optionC.trim());
       question.setOptionD(optionD.trim());

       System.out.println(question);
       try {
            questionService.addQuestion(question);
            session.setAttribute(Constants.SUCCESS_SAVEQUESTION, "添加问题成功!");
            response.sendRedirect(request.getContextPath()+"/showQuestion");
        } catch (ParamterException e ) {
            request.getRequestDispatcher("").forward(request, response);
            e.printStackTrace();
        }

   }

}
