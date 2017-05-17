/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.service.impl;

import java.util.List;

import com.augmentum.oes.dao.QuestionDao;
import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.Question;
import com.augmentum.oes.service.QuestionService;
import com.augmentum.oes.util.Pagination;
import com.augmentum.oes.util.StringUtil;

public class QuestionServiceImpl implements QuestionService{

    private QuestionDao dao;

    public void setQuestionDao(QuestionDao dao) {
        this.dao = dao;
    }

    @Override
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

        dao.addQuestion(question);

    }

    @Override
    public List<Question> query(Pagination pagination)  throws ServiceException{
        List<Question> questions = null;
        if (!(pagination.getCurrentPage() + "").matches("[0-9]*") || !(pagination.getPageSize() + "").matches("[0-9]*")) {
            throw new ServiceException("Illegal data format!");
        }

        if (StringUtil.isEmpty(pagination.getSort())) {
            pagination.setSort("");
        }

        boolean isSortFlag =false;
        String[] StringSort= new String[]{"DESC","ASC"};
        for (int i = 0; i < StringSort.length ; i++) {
            if (StringSort[i].equals(pagination.getSort())) {
                isSortFlag = true;
                break;
            }
        }

        if (!isSortFlag) {
            pagination.setSort("DESC");
        }
        if (pagination.getSort().equals("")) {
            try {
                questions = dao.findAllQuestion(pagination);
            } catch (RuntimeException re) {
               re.printStackTrace();
            }
        } else {
            try {
                questions = dao.sortQuestion(pagination);
            } catch (RuntimeException re) {
               re.printStackTrace();
            }
        }
        return questions;
    }

    @Override
    public Question queryQuestionById(String id) throws ServiceException{
        if (StringUtil.isEmpty(id)) {
            throw new ServiceException("Illegal data format!");
        }

        if(!StringUtil.isEmpty(id)) {
            if (!id.matches("[0-9]*")) {
                throw new ServiceException("Illegal data format!");
            } else {
                if (id.length() > 6){
                    throw new ServiceException("Illegal data format!");
                }
            }
        }
        return dao.queryQuestionById(Integer.parseInt(id));
    }

    @Override
    public void deleteQuestionById(int id) {
        dao.deleteQuestionById(id);
    }

    @Override
    public int deleteQuestionByIds (int[] ids) {
        return dao.deleteQuestionByIds(ids);
    }

    @Override
    public void updateIsAliveById(int id) {
        dao.deleteQuestionById(id);
    }
}
