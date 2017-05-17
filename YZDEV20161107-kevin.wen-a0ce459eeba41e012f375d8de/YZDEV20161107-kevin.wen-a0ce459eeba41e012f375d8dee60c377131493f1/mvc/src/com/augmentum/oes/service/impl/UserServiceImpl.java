package com.augmentum.oes.service.impl;

import java.sql.Connection;

import com.augmentum.oes.AppContext;
import com.augmentum.oes.Constants;
import com.augmentum.oes.dao.UserDao;
import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.User;
import com.augmentum.oes.service.UserService;
import com.augmentum.oes.util.DBUtil;
import com.augmentum.oes.util.StringUtil;

public class UserServiceImpl implements UserService{

    private UserDao userDao;
    public void setUserDao(UserDao userDao) {
        this.userDao = userDao;
    }

    @Override
    public User login(String userName,String password) throws ParamterException,ServiceException {
        ParamterException paramterException = new ParamterException();
        AppContext appContext = AppContext.getAppContext();
        Connection conn = (Connection)appContext.getObject(Constants.APP_Context_CONNECTION);
        boolean needMyClose = false;
        if (conn == null) {
            conn = DBUtil.getConnection();
            appContext.addObjects(Constants.APP_Context_CONNECTION, conn);
            needMyClose = true;
        }

        if (StringUtil.isEmpty(userName)) {
            paramterException.addErrorField("userName", "User name is required");
        }

        if (StringUtil.isEmpty(password)) {
            paramterException.addErrorField("password", "Password is required");
        }

        if (paramterException.isErrorField()) {
            throw paramterException;
        }

        User user = null;
        try {
            user = userDao.getUserByName(userName);
        } finally {
            if (needMyClose) {
                DBUtil.close(conn, null);
            }
        }
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
