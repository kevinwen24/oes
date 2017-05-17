/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.controller;

import java.util.Map;

import org.apache.log4j.Logger;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import com.augmentum.oes.AppContext;
import com.augmentum.oes.Constants;
import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.User;
import com.augmentum.oes.service.UserService;
import com.augmentum.oes.util.StringUtil;
/**
 * This class use to deal with request parameter about user and return request or session data
 * @author kevin
 * @version 1.0.0
 * @project Online Web Exam System
 *
 */
@Controller
@RequestMapping(Constants.APP_URL_USER_PREFIX)
public class UserController extends BaseController{

    private static final String LOGIN_PATH = "login";
    private static final String OES_SHOWQUESTION_PAGE = "question/index";

    private Logger logger = Logger.getLogger(UserController.class);

    @Autowired
    private UserService userService;

    @RequestMapping(value="/login", method = RequestMethod.GET)
    public ModelAndView login(@RequestParam(value = "go", defaultValue = "") String go) {
        ModelAndView modelAndView = new ModelAndView();
        User user = (User)AppContext.getAppContext().getObject(Constants.APP_Context_USER);
        if (user != null) {
            modelAndView.setView(this.getRedirectView(OES_SHOWQUESTION_PAGE));
        } else {
            modelAndView.addObject("go", go);
            modelAndView.setViewName(LOGIN_PATH);
        }
        return modelAndView;
    }

    @RequestMapping(value = "/login", method = RequestMethod.POST)
    public ModelAndView saveLogin (
                                   @RequestParam(value = "userName", defaultValue = "") String userName,
                                   @RequestParam(value = "password", defaultValue = "") String password,
                                   @RequestParam(value = "queryString", defaultValue = "") String queryString,
                                   @RequestParam(value = "go", defaultValue = "") String go
                                   ) {
        ModelAndView modelAndView = new ModelAndView();
        try {
            User user = null;
            user = userService.login(userName.trim(), password.trim());
            this.addSession(Constants.USER, user);

            if (!StringUtil.isEmpty(queryString)) {
                if (queryString.startsWith("#")) {
                    queryString = queryString.substring(1);
                }
                go = go + "?" + queryString;
            }
            RedirectView redirectView = StringUtil.isEmpty(go) ? this.getRedirectView(OES_SHOWQUESTION_PAGE)
                                                               : new RedirectView(AppContext.getContextPath() + "/" + go);
            modelAndView.setView(redirectView);
        } catch (ParamterException e) {
            Map<String, String> errorFields = e.getErrorFields();
            modelAndView.addObject(Constants.ERRFIELDS, errorFields);
            modelAndView.setViewName(LOGIN_PATH);
            logger.info("user input null date in login", e);
        } catch (ServiceException e) {
            modelAndView.addObject(Constants.TIP_MESSAGE, e.getMsg());
            modelAndView.setViewName(LOGIN_PATH);
            logger.warn("userName or password is not find", e);
        }
        return modelAndView;
    }

    @RequestMapping(value = "/logout", method = RequestMethod.GET)
    public ModelAndView logout() {
        this.removeSession(Constants.USER);
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setView(this.getRedirectView("user/login"));
        return modelAndView;
    }
}
