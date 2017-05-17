package com.augmentum.oes.service.impl;

import org.aopalliance.intercept.MethodInterceptor;
import org.aopalliance.intercept.MethodInvocation;
import org.apache.log4j.Logger;

import com.augmentum.oes.AppContext;

public class LogMethhodTime implements MethodInterceptor {

    private final Logger logger = Logger.getLogger(UserServiceImpl.class);
    @Override
    public Object invoke(MethodInvocation invocation) throws Throwable {
        long startTime = System.currentTimeMillis();

        Object returnVlaue = invocation.proceed();

        String methodName = invocation.getMethod().getName();
        long endTime = System.currentTimeMillis();
        StringBuilder sb = new StringBuilder();
        sb.append(AppContext.getAppContext().getUserName());
        sb.append(" : ");
        sb.append(invocation.getMethod().getDeclaringClass().getSimpleName());
        sb.append(" : ");
        sb.append(methodName);
        sb.append(" : ");
        sb.append(endTime - startTime);

        logger.info(sb.toString());
        return returnVlaue;
    }

}
