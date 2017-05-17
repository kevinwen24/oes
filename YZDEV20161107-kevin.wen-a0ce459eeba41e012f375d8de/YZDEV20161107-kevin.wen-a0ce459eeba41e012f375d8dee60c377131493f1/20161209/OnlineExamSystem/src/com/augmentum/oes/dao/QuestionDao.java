/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.dao;

import java.util.List;

import com.augmentum.oes.model.Question;
import com.augmentum.oes.util.Pagination;

/**
 * This class is used to question CIUD
 * @author kevin
 * @version 1.0.0
 * @project Online Web Exam System
 *
 */
 public interface QuestionDao {

    int addQuestion(final Question question);

    int getCountQuestion(String keywords);

    List<Question> findAllQuestion(Pagination pagination);

    int deleteQuestionById (int id);

    int deleteQuestionByIds (int[] ids);

    Question queryQuestionById (int id);

    String insertQuestionIdById(int id);
}
