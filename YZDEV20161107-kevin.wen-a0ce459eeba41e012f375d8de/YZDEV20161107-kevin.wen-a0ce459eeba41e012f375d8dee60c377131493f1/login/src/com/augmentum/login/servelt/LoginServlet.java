package com.augmentum.login.servelt;

import java.io.IOException;
import java.util.Map;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.augmentum.login.Constants;
import com.augmentum.login.exception.ParamterException;
import com.augmentum.login.exception.ServiceException;
import com.augmentum.login.model.User;
import com.augmentum.login.service.UserService;

public class LoginServlet extends HttpServlet {
    private static final long serialVersionUID = 1L;

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        request.getRequestDispatcher("/WEB-INF/login.jsp").forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String userName = request.getParameter("userName");
        String password = request.getParameter("password");
        UserService uService = new UserService();
        User user = null;
        try {
            user = uService.login(userName, password);
            HttpSession session = request.getSession();
            session.setAttribute(Constants.USER, user);
            response.sendRedirect(request.getContextPath()+"/dashboard");
        } catch (ParamterException e) {
            Map<String, String> errorFields = e.getErrorFields();
            request.setAttribute(Constants.ERRFIELDS, errorFields);
            request.getRequestDispatcher("/WEB-INF/login.jsp").forward(request, response);
            return;
        } catch (ServiceException e) {
            request.setAttribute(Constants.TIP_MESSAGE, e.getMsg());
            request. getRequestDispatcher("/WEB-INF/login.jsp").forward(request, response);
        }
    }

}
