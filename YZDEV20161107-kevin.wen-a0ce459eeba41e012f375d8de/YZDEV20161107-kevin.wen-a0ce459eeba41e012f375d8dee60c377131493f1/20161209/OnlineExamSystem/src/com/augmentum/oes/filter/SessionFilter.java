package com.augmentum.oes.filter;

import java.io.IOException;

import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.augmentum.oes.Constants;
import com.augmentum.oes.model.User;
import com.augmentum.oes.util.PathUtil;
import com.augmentum.oes.util.StringUtil;

public class SessionFilter implements Filter {

    private String notNeedLoginPage="";

    public SessionFilter() {
    }

    @Override
    public void destroy() {
    }

    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain) throws IOException, ServletException {
        HttpServletRequest req = (HttpServletRequest) request;
        HttpServletResponse rep = (HttpServletResponse) response;
        String uri = req.getRequestURI();
        String requestionUri = uri.substring(req.getContextPath().length()+1);

        boolean isAllow = false;
        String[] pages = notNeedLoginPage.split(",");
        for (String page : pages) {
            if (page.equals(requestionUri)) {
                isAllow = true;
                break;
            }
        }
        if (isAllow) {
            chain.doFilter(request, response);
        } else {
            HttpSession session = req.getSession();
            User user = (User)session.getAttribute(Constants.USER);
            if (user == null  ) {
                if (req.getMethod().toLowerCase().equals("get")) {
                    String queryString = req.getQueryString();
                    String go = requestionUri;
                    if (!StringUtil.isEmpty(queryString)) {
                        go = go + "#" +queryString;
                    }

                    rep.sendRedirect(PathUtil.getFullPath("user/login?go=" + go));
                } else {
                    rep.sendRedirect(PathUtil.getFullPath("user/login"));
                }
            } else {
                chain.doFilter(request, response);
            }
        }
    }

    @Override
    public void init(FilterConfig fConfig) throws ServletException {
        notNeedLoginPage  = fConfig.getInitParameter("notNeedLoginPage");
    }
}
