/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.dao;

import com.augmentum.oes.model.User;

/**
 * This class is used to user CIUD
 * @author kevin
 * @version 1.0.0
 * @project Online Web Exam System
 *
 */
public interface UserDao {

    User getUserByName(String userName);
}

