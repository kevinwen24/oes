/*
 * Copyright (c) 1994, 2017, augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.servelt;

import java.io.IOException;
import java.io.InputStream;
import java.lang.reflect.Method;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;

import com.augmentum.common.ActionConfig;
import com.augmentum.common.BeanFactory;
import com.augmentum.common.ModelAndView;
import com.augmentum.common.ResultConfig;
import com.augmentum.common.ViewParameterConfig;
import com.augmentum.oes.util.StringUtil;
/**
 * This class is used to deal with request and
 * @author kevin
 * @version 1.0.0
 * @project Online Exam System
 *
 */
public class DispatcherServlet extends HttpServlet {

    private static final long serialVersionUID = 1L;
    private String suffix = ".action";

    Map<String, ActionConfig> actionConfigs = new HashMap<String, ActionConfig>();

    public DispatcherServlet() {

    }

    @Override
    public void init(ServletConfig config) throws ServletException {
        super.init(config);
        String suffixFromConf = config.getInitParameter("suffix");
        if (!StringUtil.isEmpty(suffixFromConf)) {
            suffix = suffixFromConf;
        }
        InputStream is = null;
        is = DispatcherServlet.class.getClassLoader().getResourceAsStream("action.xml");
        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        try {
            DocumentBuilder builder = factory.newDocumentBuilder();
            Document document = builder.parse(is);
            Element element = document.getDocumentElement();
            NodeList actionNodes = element.getElementsByTagName("action");
            if (actionNodes == null) {
                return;
            }
            for (int i = 0; i < actionNodes.getLength(); i++) {
                Element actionElement = (Element)actionNodes.item(i);

                String name = actionElement.getAttribute("name");
                String className = actionElement.getAttribute("class");
                String method = actionElement.getAttribute("method");
                String httpMethod = actionElement.getAttribute("httpMethod");
                if (StringUtil.isEmpty(httpMethod)) {
                    httpMethod = "GET";
                }

                ActionConfig actionConfig = new ActionConfig();
                actionConfig.setClassName(className);
                actionConfig.setMethod(method);
                String[] httpMethodAddr = httpMethod.split(",");
                actionConfig.setHttpMethod(httpMethodAddr);
                for (String httpMethodItem : httpMethodAddr) {
                    actionConfigs.put(name + suffix + "#" + httpMethodItem.toUpperCase() , actionConfig);
                }

                //parse results
                NodeList resultNodes = actionElement.getElementsByTagName("result");
                if (resultNodes != null) {
                    for (int j = 0; j < resultNodes.getLength();j++) {
                        ResultConfig resultConfig = new ResultConfig();
                        Element resultElement = (Element)resultNodes.item(j);
                        String resultName = resultElement.getAttribute("name");
                        String view = resultElement.getAttribute("view");
                        String redirect = resultElement.getAttribute("redirect");
                        String viewParameter = resultElement.getAttribute("viewParameter");
                        if (StringUtil.isEmpty(redirect)) {
                            redirect = "false";
                        }

                        //parse viewParameter
                        if (!StringUtil.isEmpty(viewParameter)) {
                            String[] viewParameterAttr = viewParameter.split(",");
                            for (String viewParameterItem : viewParameterAttr) {
                                String[] viewParameterItemAttr = viewParameterItem.split(":");
                                String key = viewParameterItemAttr[0].trim();
                                String from = "attribute";
                                if (viewParameterItemAttr.length == 2) {
                                    from = viewParameterItemAttr[1].trim();
                                }
                                ViewParameterConfig viewParameterConfig = new ViewParameterConfig();
                                viewParameterConfig.setName(key);
                                viewParameterConfig.setFrom(from);
                                resultConfig.addViewParameterConfig(viewParameterConfig);
                            }
                        }
                        resultConfig.setName(resultName);
                        resultConfig.setView(view);
                        resultConfig.setRedirect(Boolean.parseBoolean(redirect));
                        actionConfig.addResult(resultName, resultConfig);
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (is != null) {
                try {
                    is.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    @Override
    protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String uri = request.getRequestURI();
        String requestUri = uri.substring(request.getContextPath().length()+1);
        if (requestUri == null || requestUri.equals("")) {
            requestUri = "login" + suffix;
        }
        String httpMethod = request.getMethod();

        ActionConfig actionConfig = actionConfigs.get(requestUri + "#" + httpMethod.toUpperCase());
        HttpSession session = request.getSession();
        if ( actionConfig != null ) {

            Class<?>[] params = new Class[2];
            params[0] = Map.class;
            params[1] = Map.class;

            try {
                //Class<?> clazz = Class.forName(actionConfig.getClassName());
                //Object obj = clazz.newInstance();
                Object obj =BeanFactory.getInstance().getBean(actionConfig.getClassName());
                Method method = obj.getClass().getMethod(actionConfig.getMethod(), params);


                Map<String, Object> sessionMap = new HashMap<String,Object>();
                Enumeration<String> toSessionkeys = session.getAttributeNames();
                while (toSessionkeys.hasMoreElements()) {
                    String toKey = toSessionkeys.nextElement();
                    sessionMap.put(toKey, session.getAttribute(toKey));
                }

                Map<String, String[]> parameterMap = new HashMap<String,String[]>();
                Enumeration<String> toRequestKeys = request.getParameterNames();
                while (toRequestKeys.hasMoreElements()) {
                    String toKey = toRequestKeys.nextElement();
                    parameterMap.put(toKey, request.getParameterValues(toKey));
                }

                Object[] object = new Object[2];
                object[0] = parameterMap;
                object[1] = sessionMap;

                ModelAndView modelAndView = (ModelAndView)method.invoke(obj, object);

                Map<String, Object> fromControllerSession = modelAndView.getSessions();
                Set<String> keys = fromControllerSession.keySet();
                for (String key : keys) {
                    session.setAttribute(key, fromControllerSession.get(key));
                }

                Map<String, Object> fromControllerRequest = modelAndView.getRequests();
                Set<String> keyRequests = fromControllerRequest.keySet();
                for (String key: keyRequests) {
                    request.setAttribute(key, fromControllerRequest.get(key));
                }

                String view = modelAndView.getView();
                ResultConfig resultConfig = actionConfig.getResult(view);
                if (resultConfig == null) {
                    if (modelAndView.isRedirct()) {
                        response.sendRedirect(request.getContextPath() + view);
                    } else {
                        request.getRequestDispatcher(view).forward(request, response);
                    }
                } else {
                    String resultView = request.getContextPath()+view;
                    if (resultConfig.isRedirect()) {
                        response.sendRedirect(resultView);
                        List<ViewParameterConfig> viewParameterConfigs = resultConfig.getViewParameterConfigs();
                        if (viewParameterConfigs == null || viewParameterConfigs.isEmpty()) {
                            response.sendRedirect(resultView);
                        } else {
                            StringBuilder sb = new StringBuilder();
                            for (ViewParameterConfig viewParameterConfig: viewParameterConfigs) {
                                String name = viewParameterConfig.getName();
                                String from = viewParameterConfig.getFrom();
                                String value = "";
                                if ("attribute".equals(from)) {
                                    value = (String) request.getAttribute(name);
                                } else if ("parameter".equals(from)) {
                                    value = request.getParameter(name);
                                } else if ("session".equals(from)) {
                                    value = (String) request.getSession().getAttribute(from);
                                } else {
                                    value = (String) request.getAttribute(name);
                                }
                                if (StringUtil.isEmpty(value)) {
                                    sb.append(name + "=" + value + "&");
                                }
                            }
                            String paramsAndValue = sb.toString().substring(0, sb.length()-1);
                            if (resultView.indexOf("&") != -1) {
                                resultView = resultView + "&" + paramsAndValue;
                            } else {
                                resultView = resultView + "?" + paramsAndValue;
                            }
                            response.sendRedirect(resultView);
                        }
                    }
                }
            } catch (Exception e) {
                e.printStackTrace();
                response.sendError(500);
            }
        } else {
            response.sendError(404);
        }
    }
}
