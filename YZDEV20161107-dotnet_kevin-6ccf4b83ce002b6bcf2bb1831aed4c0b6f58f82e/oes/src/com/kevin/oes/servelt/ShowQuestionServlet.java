package com.kevin.oes.servelt;

import java.io.IOException;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

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
//	    String paseSize = request.getParameter("paseSize");

	    doPost(request, response);
	    request.getRequestDispatcher(Constants.SHOWQUESTION_PATH).forward(request,response);
	}

	@Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
	    QuestionService questionService = new QuestionService();
        String currentPage = request.getParameter("currentPage");
        String paseSize = request.getParameter("paseSize");
        if(StringUtil.isEmpty(currentPage)) {
            currentPage = "1";
        }
        if(StringUtil.isEmpty(paseSize)) {
            paseSize = "0";
        }
        Pagination pagination = new Pagination();
        pagination.setCurrentPage(Integer.parseInt(currentPage));
        pagination.setPageSize(Integer.parseInt(paseSize));
        List<Question> questions = questionService.query(pagination);
        request.setAttribute("questions", questions);
        request.setAttribute("pagination", pagination);
	}

}
