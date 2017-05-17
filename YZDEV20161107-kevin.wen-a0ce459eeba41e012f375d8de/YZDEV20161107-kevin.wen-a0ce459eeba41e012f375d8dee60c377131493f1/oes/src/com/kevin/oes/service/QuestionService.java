package com.kevin.oes.service;

import java.util.List;

import com.kevin.oes.dao.QuestionDao;
import com.kevin.oes.exception.ParamterException;
import com.kevin.oes.model.Question;
import com.kevin.oes.util.Pagination;
import com.kevin.oes.util.StringUtil;

public class QuestionService {
    private QuestionDao dao;

    public void addQuestion(Question question) throws ParamterException{
        ParamterException ParamterException =new ParamterException();
        if(StringUtil.isEmpty(question.getTitle())){
            ParamterException.addErrorField("title", "title is required");
        }
        if(StringUtil.isEmpty(question.getOptionA())){
            ParamterException.addErrorField("option_a", "option_a is required");
        }
        if(StringUtil.isEmpty(question.getOptionB())){
            ParamterException.addErrorField("option_b", "option_b is required");
        }
        if(StringUtil.isEmpty(question.getOptionB())){
            ParamterException.addErrorField("option_c", "option_c is required");
        }
        if(StringUtil.isEmpty(question.getOptionB())){
            ParamterException.addErrorField("option_d", "option_d is required");
        }
        if(StringUtil.isEmpty(question.getOptionB())){
            ParamterException.addErrorField("answer", "answer is required");
        }
        if(ParamterException.isErrorField()){
            throw ParamterException;
        }

        dao = new QuestionDao();
        int qId = dao.addQuestion(question);
        System.out.println(qId);
    }

    public List<Question> query(Pagination pagination) {
        dao = new QuestionDao();
        return  dao.findAllQuestion(pagination);
    }

    public Question queryQuestionById(int id) {
        dao = new QuestionDao();
        return dao.queryQuestionById(id);
    }

    public void deleteQuestionById(int id) {
        dao = new QuestionDao();
        int num = dao.deleteQuestionById(id);
    }
    public int deleteQuestionByIds (int[] ids) {
        dao = new QuestionDao();
        return dao.deleteQuestionByIds(ids);
    }
    public void updateIsAliveById(int id) {
        dao = new QuestionDao();
        dao.deleteQuestionById(id);
    }
}
