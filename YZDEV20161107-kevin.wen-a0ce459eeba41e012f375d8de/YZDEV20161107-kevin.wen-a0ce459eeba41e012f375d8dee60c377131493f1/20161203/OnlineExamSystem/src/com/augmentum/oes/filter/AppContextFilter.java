/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.filter;

import java.io.IOException;
import java.sql.Connection;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletRequest;

import com.augmentum.oes.AppContext;
import com.augmentum.oes.Constants;
import com.augmentum.oes.util.DBUtil;

public class AppContextFilter implements Filter {

    public AppContextFilter() {
    }

    @Override
    public void destroy() {
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
        HttpServletRequest req = (HttpServletRequest) request;
        AppContext appContext = AppContext.getAppContext();
        appContext.addObjects(Constants.APP_Context_REQUEST, req);
        appContext.addObjects(Constants.APP_Context_RESPONSE, req);
        Connection conn = (Connection)appContext.getObject(Constants.APP_Context_CONNECTION);
        boolean needMyClose = false;

        if (conn == null) {
            conn = DBUtil.getConnection();
            appContext.addObjects(Constants.APP_Context_CONNECTION, conn);
            needMyClose = true;
        }

        try {
            chain.doFilter(request, response);
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            appContext.clear();
            if (needMyClose) {
                DBUtil.close(conn, null);
            }
        }
    }

    @Override
    public void init(FilterConfig fConfig) throws ServletException {

    }
}
