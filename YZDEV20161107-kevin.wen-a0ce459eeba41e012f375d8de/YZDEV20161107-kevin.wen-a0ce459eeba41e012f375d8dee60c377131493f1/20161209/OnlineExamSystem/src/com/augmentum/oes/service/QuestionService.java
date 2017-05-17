package com.augmentum.oes.service;

import java.util.List;

import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.Question;
import com.augmentum.oes.util.Pagination;

public interface QuestionService {


    public void addQuestion(Question question) throws ParamterException;

    public List<Question> query(Pagination pagination)  throws ServiceException;

    public Question queryQuestionById(String id) throws ServiceException;

    public void deleteQuestionById(int id);

    public int deleteQuestionByIds (int[] ids);

    public void updateIsAliveById(int id);
}
