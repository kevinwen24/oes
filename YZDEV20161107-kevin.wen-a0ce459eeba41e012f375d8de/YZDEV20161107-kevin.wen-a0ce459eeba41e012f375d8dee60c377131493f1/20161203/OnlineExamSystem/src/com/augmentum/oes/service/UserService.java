/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.service;

import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.User;

public interface UserService {

    User login(String userName,String password) throws ParamterException,ServiceException;
}
