package com.augmentum.oes.service;

import com.augmentum.oes.exception.ParamterException;
import com.augmentum.oes.exception.ServiceException;
import com.augmentum.oes.model.User;

public interface UserService {

    public User login(String userName,String password) throws ParamterException,ServiceException;

}
