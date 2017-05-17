package com.kevin.oes.service;

import com.kevin.oes.dao.UserDao;
import com.kevin.oes.exception.ParamterException;
import com.kevin.oes.exception.ServiceException;
import com.kevin.oes.model.User;
import com.kevin.oes.util.StringUtil;

public class UserService {
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

        UserDao userDao = new UserDao();
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
