package com.kevin.oes.servelt;

import java.io.IOException;
import java.util.Map;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.kevin.oes.Constants;
import com.kevin.oes.exception.ParamterException;
import com.kevin.oes.exception.ServiceException;
import com.kevin.oes.model.User;
import com.kevin.oes.service.UserService;

public class LoginServlet extends HttpServlet {
    private static final long serialVersionUID = 1L;

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.getRequestDispatcher(Constants.LOGIN_PATH).forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String userName = request.getParameter("userName");
        String password = request.getParameter("password");
        UserService uService = new UserService();
        User user = null;
        try {
            user = uService.login(userName.trim(), password.trim());
            HttpSession session = request.getSession();
            session.setAttribute(Constants.USER, user);
            response.sendRedirect(request.getContextPath()+"/showQuestion");
        } catch (ParamterException e) {
            Map<String, String> errorFields = e.getErrorFields();
            request.setAttribute(Constants.ERRFIELDS, errorFields);
            request.getRequestDispatcher(Constants.LOGIN_PATH).forward(request, response);
        } catch (ServiceException e) {
            request.setAttribute(Constants.TIP_MESSAGE, e.getMsg());
            request.getRequestDispatcher(Constants.LOGIN_PATH).forward(request, response);
        }
    }

}
