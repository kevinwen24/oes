/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.service.impl;

import com.augmentum.oes.dao.UserDao;
import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.User;
import com.augmentum.oes.service.UserService;
import com.augmentum.oes.util.StringUtil;

public class UserServiceImpl implements UserService{

    private UserDao userDao;

    public void setUserDao(UserDao userDao) {
        this.userDao = userDao;
    }

    @Override
    public User login(String userName,String password) throws ParamterException,ServiceException {
        ParamterException paramterException = new ParamterException();

        if (StringUtil.isEmpty(userName)) {
            paramterException.addErrorField("userName", "User name is required");
        }

        if (StringUtil.isEmpty(password)) {
            paramterException.addErrorField("password", "Password is required");
        }

        if (paramterException.isErrorField()) {
            throw paramterException;
        }

        User user = userDao.getUserByName(userName);
        if(user == null) {
           throw new ServiceException(1000, "User is not exist");
        }

        if (!password.equals(user.getPassword())) {
            throw new ServiceException(1001, "Password is error");
        }
        user.setPassword(null);
        return user;
    }
}
