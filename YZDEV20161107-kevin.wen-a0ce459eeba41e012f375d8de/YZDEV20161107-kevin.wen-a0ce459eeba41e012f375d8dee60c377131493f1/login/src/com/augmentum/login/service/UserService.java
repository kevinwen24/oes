package com.augmentum.login.service;

import com.augmentum.login.dao.UserDao;
import com.augmentum.login.exception.ParamterException;
import com.augmentum.login.exception.ServiceException;
import com.augmentum.login.model.User;
import com.augmentum.login.util.StringUtil;

public class UserService {
    public User login(String userName,String password) throws ParamterException,ServiceException {
        ParamterException paramterException = new ParamterException();
        if (StringUtil.isEmpty(userName)) {
            paramterException.addErrorField("userName", "user name is required");
        }

        if (StringUtil.isEmpty(password)) {
            paramterException.addErrorField("password", "password is required");
        }

        if (paramterException.isErrorField()) {
            throw paramterException;
        }

        UserDao userDao = new UserDao();
        User user = userDao.getUserByName(userName);
        if(user == null) {
           throw new ServiceException(1000, "用户名不存在");
        }

        if (!password.equals(user.getPassword())) {
            throw new ServiceException(1001, "密码不正确");
        }
        user.setPassword(null);
        return user;

    }
}
