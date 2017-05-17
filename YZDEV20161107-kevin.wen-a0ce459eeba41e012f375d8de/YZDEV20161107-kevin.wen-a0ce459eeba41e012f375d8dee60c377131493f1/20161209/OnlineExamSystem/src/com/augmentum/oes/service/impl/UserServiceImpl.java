package com.augmentum.oes.service.impl;

import org.apache.log4j.Logger;

import com.augmentum.oes.dao.UserDao;
import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.User;
import com.augmentum.oes.service.UserService;
import com.augmentum.oes.util.StringUtil;

public class UserServiceImpl implements UserService{

    private final Logger logger = Logger.getLogger(UserServiceImpl.class);
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
        logger.debug(userName + " login online exam system");
        logger.info(userName + " login online exam system");
        logger.warn(userName + " login online exam system");
        logger.error(userName + " login online exam system");
        user.setPassword(null);
        return user;
    }
}
