/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.common;

import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;
import java.sql.Connection;

import com.augmentum.oes.AppContext;
import com.augmentum.oes.Constants;
import com.augmentum.oes.util.DBUtil;

public class ConnectionDynamicProxy implements InvocationHandler{

    private Object target;

    public void setTarget(Object target ) {
        this.target = target;
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args)
            throws Throwable {
        Object result = null;
        AppContext appContext = AppContext.getAppContext();
        Connection conn = (Connection)appContext.getObject(Constants.APP_Context_CONNECTION);
        boolean needMyClose = false;

        if (conn == null) {
            conn = DBUtil.getConnection();
            DBUtil.setAutoCommit(conn, false);
            appContext.addObjects(Constants.APP_Context_CONNECTION, conn);
            needMyClose = true;
        }

        try {
            result = method.invoke(target, args);
            DBUtil.commit(conn);
        } catch(Exception e) {
            conn.rollback();
            throw e.getCause();
        } finally {
            if (needMyClose) {
                appContext.getObject(Constants.APP_Context_CONNECTION);
                DBUtil.close(conn, null);
                appContext.getGainObject().remove(Constants.APP_Context_CONNECTION);
            }
        }

        return result;
    }
}
