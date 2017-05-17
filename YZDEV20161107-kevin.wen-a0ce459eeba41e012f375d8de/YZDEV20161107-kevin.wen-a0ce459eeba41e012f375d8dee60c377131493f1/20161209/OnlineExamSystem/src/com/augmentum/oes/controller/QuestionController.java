/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;

import com.augmentum.oes.Constants;
import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.Question;
import com.augmentum.oes.service.QuestionService;
import com.augmentum.oes.util.Pagination;
import com.augmentum.oes.util.StringUtil;
/**
 * This class use to deal with request parameter about question and return request or session data
 * @author kevin
 * @version 1.0.0
 * @project Online Web Exam System
 *
 */
@Controller
@RequestMapping(Constants.APP_URL_QUESTION_PREFIX)
public class QuestionController extends BaseController{

    private static final String OES_CREATE_JSP = "create_question";
    private static final String OES_DETAIL_JSP = "detail_question";
    private static final String OES_EDIT_JSP = "edit_question";
    private static final String OES_show_JSP = "index";
    private static final String OES_SHOWQUESTION_PAGE = "question/index";

    @Autowired
    private QuestionService questionService;

    @RequestMapping(value = "/save", method = {RequestMethod.GET, RequestMethod.POST})
    public ModelAndView save(
                             @RequestParam(value = "questionId", defaultValue = "") String questionId,
                             @RequestParam(value = "questionTitle", defaultValue = "") String title,
                             @RequestParam(value = "answer", defaultValue = "") String answer,
                             @RequestParam(value = "optionA", defaultValue = "") String optionA,
                             @RequestParam(value = "optionB", defaultValue = "") String optionB,
                             @RequestParam(value = "optionC", defaultValue = "") String optionC,
                             @RequestParam(value = "optionD", defaultValue = "") String optionD
                             ) {
        Question question = new Question();
        ModelAndView modelAndView = new ModelAndView();

        question.setTitle(title.trim());

        if (!"".equals(answer) && answer.matches("[0-9]*")) {
            question.setAnswer(Integer.parseInt(answer));
        }

        question.setOptionA(optionA.trim());
        question.setOptionB(optionB.trim());
        question.setOptionC(optionC.trim());
        question.setOptionD(optionD.trim());

        try {
            questionService.addQuestion(question);
            if ("".equals(questionId) && !"".equals(title)) {
                this.addSession(Constants.SUCCESS_SAVEQUESTION, "Add the question successfully!");
            } else if (!"".equals(questionId)){
                questionService.deleteQuestionById(Integer.parseInt(questionId));
                this.addSession(Constants.SUCCESS_SAVEQUESTION, "Modify the question successfully!");
            }
        } catch (ParamterException e) {
            modelAndView.setViewName(OES_CREATE_JSP);
            return modelAndView;
        }
        modelAndView.setView(this.getRedirectView(OES_SHOWQUESTION_PAGE));
        return modelAndView;
    }

    @RequestMapping(value = "delete", method = {RequestMethod.GET, RequestMethod.POST})
    public ModelAndView delete(
                               @RequestParam(value = "deleteQuestionId", defaultValue = "") String[] deleteQuestion,
                               @RequestParam(value = "pageSize", defaultValue = "") String pageSize,
                               @RequestParam(value = "currentPage", defaultValue = "") String currentPage
                               ) {
        ModelAndView modelAndView = new ModelAndView();

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

        int[] questions = new int[deleteQuestion.length];

        for (int i=0; i<deleteQuestion.length; i++) {
            questions[i]= Integer.parseInt(deleteQuestion[i]);
        }

        int records = questionService.deleteQuestionByIds(questions);
        this.addSession(Constants.SUCCESS_SAVEQUESTION, "delete " + records + " record");
        modelAndView.setView(this.getRedirectView(OES_SHOWQUESTION_PAGE + "?currentPage=" + currentPage.trim() + "&pageSize=" + pageSize.trim()));
        return modelAndView;
    }

    @RequestMapping(value = "/edit/{questionId}", method = RequestMethod.GET)
    public ModelAndView edit(
                             @PathVariable int questionId,
                             @RequestParam(value = "currentPage", defaultValue = "") String currentPage,
                             @RequestParam(value = "pageSize", defaultValue = "") String pageSize
                             ) {
        ModelAndView modelAndView = new ModelAndView();

        Question question = null;
        try {
            question = questionService.queryQuestionById(questionId + "");
        } catch (ServiceException e) {
            this.addSession(Constants.FAIL_QUERYQUESTION, e.getMsg());
            modelAndView.setView(this.getRedirectView(OES_SHOWQUESTION_PAGE));
            return modelAndView;
        }
        if (!currentPage.matches("[0-9]*") || !pageSize.matches("[0-9]*") ) {
            this.addSession(Constants.FAIL_QUERYQUESTION, "Illegal data format!");
            modelAndView.setView(this.getRedirectView(OES_SHOWQUESTION_PAGE));
            return modelAndView;
        }
        modelAndView.addObject("question", question);
        modelAndView.addObject("pageSize", Integer.parseInt(pageSize));
        modelAndView.addObject("currentPage", Integer.parseInt(currentPage));

        modelAndView.setViewName(OES_EDIT_JSP);
        return modelAndView;
    }

    @RequestMapping(value = "/index", method = {RequestMethod.GET, RequestMethod.POST})
    public ModelAndView show(
                             @RequestParam(value = "currentPage", defaultValue = "") String currentPage,
                             @RequestParam(value = "pageSize", defaultValue = "") String pageSize,
                             @RequestParam(value = "search", defaultValue = "") String search,
                             @RequestParam(value = "sort", defaultValue = "") String sort
                             ) {
        ModelAndView modelAndView = new ModelAndView();

        if (StringUtil.isEmpty(currentPage) || currentPage.equals("null")) {
            currentPage = "1";
        }

        if (StringUtil.isEmpty(pageSize) || pageSize.equals("null")) {
            pageSize = "10";
        }

        if (!currentPage.matches("[0-9]*") || !pageSize.matches("[0-9]*") ) {
            this.addSession(Constants.FAIL_QUERYQUESTION, "Illegal data format!");
            modelAndView.setView(this.getRedirectView(OES_SHOWQUESTION_PAGE));
            return modelAndView;
        }
        String s = StringUtil.transferString(search);
        Pagination pagination = new Pagination();
        pagination.setCurrentPage(Integer.parseInt(currentPage));
        pagination.setPageSize(Integer.parseInt(pageSize));
        pagination.setSearch(s);
        pagination.setSort(sort);
        if(pagination.getPageSize() > 10) {
            pagination.setPageSize(10);
        }

        List<Question> questions = null;
        try {
            questions = questionService.query(pagination);
        } catch (ServiceException e) {
            this.addSession(Constants.FAIL_QUERYQUESTION, "Illegal data format!");
            modelAndView.setView(this.getRedirectView(OES_SHOWQUESTION_PAGE));
            return modelAndView;
        }
        pagination.setSearch(search);
        modelAndView.addObject("questions", questions);
        modelAndView.addObject("pagination", pagination);
        modelAndView.setViewName(OES_show_JSP);
        return modelAndView;
    }

    @RequestMapping(value = "/detail/{questionId}",method = RequestMethod.GET)
    public ModelAndView detail(
                               @PathVariable int questionId,
                               @RequestParam(value = "currentPage", defaultValue = "") String currentPage,
                               @RequestParam(value = "pageSize", defaultValue = "") String pageSize
                               ) {
        ModelAndView modelAndView = new ModelAndView();

        Question question = null;
        try {
            question = questionService.queryQuestionById(questionId + "");
        } catch (ServiceException e) {
            this.addSession(Constants.FAIL_QUERYQUESTION, e.getMsg());
            modelAndView.setView(this.getRedirectView(OES_SHOWQUESTION_PAGE));
            return modelAndView;
        }
        if (!currentPage.matches("[0-9]*") || !pageSize.matches("[0-9]*") ) {
            this.addSession(Constants.FAIL_QUERYQUESTION, "Illegal data format!");
            modelAndView.setView(this.getRedirectView(OES_SHOWQUESTION_PAGE));
            return modelAndView;
        }

        modelAndView.addObject("question", question);
        modelAndView.addObject("pageSize", Integer.parseInt(pageSize));
        modelAndView.addObject("currentPage", Integer.parseInt(currentPage));
        modelAndView.setViewName(OES_DETAIL_JSP);
        return modelAndView;
    }
}
