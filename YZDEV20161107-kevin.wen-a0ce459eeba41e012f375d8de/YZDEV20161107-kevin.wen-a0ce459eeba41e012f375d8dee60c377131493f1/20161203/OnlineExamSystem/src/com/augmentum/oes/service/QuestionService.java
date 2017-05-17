/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.service;

import java.util.List;

import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.Question;
import com.augmentum.oes.util.Pagination;

public interface QuestionService {

    void addQuestion(Question question) throws ParamterException;

    List<Question> query(Pagination pagination)  throws ServiceException;

    Question queryQuestionById(String id) throws ServiceException;

    void deleteQuestionById(int id);

    int deleteQuestionByIds (int[] ids);

    void updateIsAliveById(int id);
}
