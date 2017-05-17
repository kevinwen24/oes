package com.augmentum.oes.controller;

import java.util.Map;

import com.augmentum.common.ModelAndView;
import com.augmentum.oes.Constants;
import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.User;
import com.augmentum.oes.service.UserService;
import com.augmentum.oes.util.ArrayUtil;
import com.augmentum.oes.util.StringUtil;

public class UserController {

    private UserService userService;

    public void setUserService (UserService userService) {
        this.userService = userService;
    }

    public ModelAndView login(Map<String, String[]> request, Map<String, Object> session) {
        ModelAndView modelAndView = new ModelAndView();
        User user = (User)session.get(Constants.USER);
        if (user != null) {
            modelAndView.setView("/showQuestion.action");
            modelAndView.setRedirct(true);
        } else {
            String go = ArrayUtil.getStringByArray(request.get("go"));
            if (StringUtil.isEmpty(go)) {
                go = "";
            }
            modelAndView.addRequestAttribute("go", go);
            modelAndView.setView(Constants.LOGIN_PATH);
            modelAndView.setRedirct(false);
        }
        return modelAndView;
    }

    public ModelAndView saveLogin (Map<String, String[]> request, Map<String, Object> session) {
        ModelAndView modelAndView = new ModelAndView();
        String userName = ArrayUtil.getStringByArray(request.get("userName"));
        String password = ArrayUtil.getStringByArray(request.get("password"));
        String queryString = ArrayUtil.getStringByArray(request.get("queryString"));
        User user = null;
        try {
            user = userService.login(userName.trim(), password.trim());
            modelAndView.addSessionAttribute(Constants.USER, user);
            String go = ArrayUtil.getStringByArray(request.get("go"));

            if (!StringUtil.isEmpty(queryString)) {
                if (queryString.startsWith("#")) {
                    queryString = queryString.substring(1);
                }
                go = go + "?" + queryString;
            }

            if (!StringUtil.isEmpty(go)) {
                modelAndView.setView("/" + go);
                modelAndView.setRedirct(true);
            } else {
                modelAndView.setView("/showQuestion.action");
                modelAndView.setRedirct(true);
            }
        } catch (ParamterException e) {
            Map<String, String> errorFields = e.getErrorFields();
            modelAndView.addRequestAttribute(Constants.ERRFIELDS, errorFields);
            modelAndView.setView(Constants.LOGIN_PATH);
            modelAndView.setRedirct(false);
        } catch (ServiceException e) {
            modelAndView.addRequestAttribute(Constants.TIP_MESSAGE, e.getMsg());
            modelAndView.setView(Constants.LOGIN_PATH);
            modelAndView.setRedirct(false);
        }
        return modelAndView;
    }

    public ModelAndView logout(Map<String, String[]> request, Map<String, Object> session) {
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.addSessionAttribute(Constants.USER, null);
        modelAndView.setView("/login.action");
        modelAndView.setRedirct(true);
        return modelAndView;
    }
}
