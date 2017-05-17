package com.augmentum.oes.controller;

import java.util.List;
import java.util.Map;

import com.augmentum.common.ModelAndView;
import com.augmentum.oes.Constants;
import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.Question;
import com.augmentum.oes.service.QuestionService;
import com.augmentum.oes.util.ArrayUtil;
import com.augmentum.oes.util.Pagination;
import com.augmentum.oes.util.StringUtil;

public class QuestionController {

    private QuestionService questionService;

    public void setQuestionService (QuestionService questionService) {
        this.questionService = questionService;
    }

    public ModelAndView save(Map<String, String[]> request, Map<String, Object> session) {
        Question question = new Question();
        ModelAndView modelAndView = new ModelAndView();

        String questionId = ArrayUtil.getStringByArray(request.get("questionId"));
        String title = ArrayUtil.getStringByArray(request.get("questionTitle"));
        String answer = ArrayUtil.getStringByArray(request.get("answer"));
        String optionA = ArrayUtil.getStringByArray(request.get("optionA"));
        String optionB = ArrayUtil.getStringByArray(request.get("optionB"));
        String optionC = ArrayUtil.getStringByArray(request.get("optionC"));
        String optionD = ArrayUtil.getStringByArray(request.get("optionD"));

        question.setTitle(title.trim());

        if (answer != "" && answer.matches("[0-9]*")) {
            question.setAnswer(Integer.parseInt(answer));
        }
        question.setOptionA(optionA.trim());
        question.setOptionB(optionB.trim());
        question.setOptionC(optionC.trim());
        question.setOptionD(optionD.trim());

        try {
            questionService.addQuestion(question);
            if (questionId.equals("") && !title.equals("")) {
                modelAndView.addSessionAttribute(Constants.SUCCESS_SAVEQUESTION, "Add the question successfully!");
            } else if (!questionId.equals("")){
                questionService.deleteQuestionById(Integer.parseInt(questionId));
                modelAndView.addSessionAttribute(Constants.SUCCESS_SAVEQUESTION, "Modify the question successfully!");
            }
        } catch (ParamterException e) {
            modelAndView.setView(Constants.CREATEQUESTION_PATH);
            modelAndView.setRedirct(false);
            return modelAndView;
        }

        modelAndView.setView("/showQuestion.action");
        modelAndView.setRedirct(true);

        return modelAndView;
    }

    public ModelAndView delete(Map<String, String[]> request, Map<String, Object> session) {
        ModelAndView modelAndView = new ModelAndView();
        String[] deleteQuestion = request.get("deleteQuestionId");
        String pageSize = ArrayUtil.getStringByArray(request.get("pageSizeInDelete"));
        String currentPage = ArrayUtil.getStringByArray(request.get("currentPage"));

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
        modelAndView.addSessionAttribute(Constants.SUCCESS_SAVEQUESTION, "delete "+records+" record");
        modelAndView.setView("/showQuestion.action?pageSize="+pageSize+"&currentPage="+currentPage);
        modelAndView.setRedirct(true);
        return modelAndView;
    }

    public ModelAndView edit(Map<String, String[]> request, Map<String, Object> session) {
        ModelAndView modelAndView = new ModelAndView();
        String questionId = ArrayUtil.getStringByArray(request.get("questionId"));
        String currentPage = ArrayUtil.getStringByArray(request.get("currentPage"));
        String pageSize = ArrayUtil.getStringByArray(request.get("pageSize"));

        Question question = null;
        try {
            question = questionService.queryQuestionById(questionId);
        } catch (ServiceException e) {
            modelAndView.addSessionAttribute(Constants.FAIL_QUERYQUESTION, e.getMsg());
            modelAndView.setView("/showQuestion.action");
            modelAndView.setRedirct(true);
            return modelAndView;
        }
        if (!currentPage.matches("[0-9]*") || !pageSize.matches("[0-9]*") ) {
            modelAndView.addSessionAttribute(Constants.FAIL_QUERYQUESTION, "Illegal data format!");
            modelAndView.setView("/showQuestion.action");
            modelAndView.setRedirct(true);
            return modelAndView;
        }

        modelAndView.addRequestAttribute("question", question);
        modelAndView.addRequestAttribute("pageSize", Integer.parseInt(pageSize));
        modelAndView.addRequestAttribute("currentPage", Integer.parseInt(currentPage));
        modelAndView.setView(Constants.EDITQUESTION_PATH);
        modelAndView.setRedirct(false);
        return modelAndView;
    }

    public ModelAndView show(Map<String, String[]> request, Map<String, Object> session) {
        ModelAndView modelAndView = new ModelAndView();
        String currentPage = ArrayUtil.getStringByArray(request.get("currentPage"));
        String pageSize = ArrayUtil.getStringByArray(request.get("pageSize"));
        String search = ArrayUtil.getStringByArray(request.get("search"));
        String sort = ArrayUtil.getStringByArray(request.get("sort"));

        if (StringUtil.isEmpty(currentPage) || currentPage.equals("null")) {
            currentPage = "1";
        }

        if (StringUtil.isEmpty(pageSize) || pageSize.equals("null")) {
            pageSize = "10";
        }

        if (StringUtil.isEmpty(search)) {
            search = "";
        }

        if (!currentPage.matches("[0-9]*") || !pageSize.matches("[0-9]*") ) {
            modelAndView.addSessionAttribute(Constants.FAIL_QUERYQUESTION, "Illegal data format!");
            modelAndView.setView("/showQuestion.action");
            modelAndView.setRedirct(true);
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
            modelAndView.addSessionAttribute(Constants.FAIL_QUERYQUESTION, "Illegal data format!");
            modelAndView.setView("/showQuestion.action");
            modelAndView.setRedirct(true);
            return modelAndView;
        }
        modelAndView.addRequestAttribute("questions", questions);
        modelAndView.addRequestAttribute("pagination", pagination);
        modelAndView.setView(Constants.SHOWQUESTION_PATH);
        modelAndView.setRedirct(false);
        return modelAndView;
    }

    public ModelAndView detail(Map<String, String[]> request, Map<String, Object> session) {

        ModelAndView modelAndView = new ModelAndView();
        String questionId = ArrayUtil.getStringByArray(request.get("questionId"));
        String currentPage = ArrayUtil.getStringByArray(request.get("currentPage"));
        String pageSize = ArrayUtil.getStringByArray(request.get("pageSize"));

        Question question = null;
        try {
            question = questionService.queryQuestionById(questionId);
        } catch (ServiceException e) {
            modelAndView.addSessionAttribute(Constants.FAIL_QUERYQUESTION, e.getMsg());
            modelAndView.setView("/showQuestion.action");
            modelAndView.setRedirct(true);
            return modelAndView;
        }
        if (!currentPage.matches("[0-9]*") || !pageSize.matches("[0-9]*") ) {
            modelAndView.addSessionAttribute(Constants.FAIL_QUERYQUESTION, "Illegal data format!");
            modelAndView.setView("/showQuestion.action");
            modelAndView.setRedirct(true);
            return modelAndView;
        }

        modelAndView.addRequestAttribute("question", question);
        modelAndView.addRequestAttribute("pageSize", Integer.parseInt(pageSize));
        modelAndView.addRequestAttribute("currentPage", Integer.parseInt(currentPage));
        modelAndView.setView(Constants.DETAILQUESTION_PATH);
        modelAndView.setRedirct(false);
        return modelAndView;
    }
}
