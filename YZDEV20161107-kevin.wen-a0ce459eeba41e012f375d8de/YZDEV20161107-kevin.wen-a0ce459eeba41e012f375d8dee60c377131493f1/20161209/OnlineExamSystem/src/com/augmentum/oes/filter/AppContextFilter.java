/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.filter;

import java.io.IOException;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletRequest;

import com.augmentum.oes.AppContext;
import com.augmentum.oes.Constants;

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
        AppContext.setContextPath(req.getContextPath());
        appContext.addObjects(Constants.APP_Context_USER, req.getSession().getAttribute(Constants.USER));
        appContext.addObjects(Constants.APP_Context_SESSION, req.getSession());

        try {
            chain.doFilter(request, response);
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            appContext.clear();
        }
    }

    @Override
    public void init(FilterConfig fConfig) throws ServletException {

    }

}
