/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.common;

import java.io.IOException;
import java.io.InputStream;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;

public class BeanFactory {

    private static Map<String, BeanConfig> beans = new HashMap<String, BeanConfig>();
    private static Map<String, Object> objects = new HashMap<String, Object>();
    private static BeanFactory beanFactory;

    public static BeanFactory getInstance() {
        if (beanFactory == null) {
            beanFactory = new BeanFactory();
            beanFactory.init();
        }
        return beanFactory;
    }

    private void init() {
        InputStream is = null;

        try {
            is = BeanFactory.class.getClassLoader().getResourceAsStream("bean.xml");
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            DocumentBuilder builder = factory.newDocumentBuilder();
            Document document = builder.parse(is);
            NodeList beanNodes = document.getElementsByTagName("bean");
            if (beanNodes == null) {
                return;
            }

            for (int i = 0; i < beanNodes.getLength(); i++) {
                Element beanElement = (Element) beanNodes.item(i);
                String id = beanElement.getAttribute("id");
                String className = beanElement.getAttribute("class");
                String scope = beanElement.getAttribute("scope");
                BeanConfig beanConfig = new BeanConfig();
                beanConfig.setId(id);
                beanConfig.setClassName(className);
                beanConfig.setScope(scope);
                beans.put(id, beanConfig);

                // parse property element
                NodeList propertyNodes = beanElement
                        .getElementsByTagName("property");
                if (propertyNodes != null) {
                    for (int j = 0; j < propertyNodes.getLength(); j++) {
                        BeanProperty beanProperty = new BeanProperty();
                        Element beanPropertyElement = (Element) propertyNodes
                                .item(j);
                        beanProperty.setName(beanPropertyElement
                                .getAttribute("name"));
                        beanProperty.setValue(beanPropertyElement
                                .getAttribute("value"));
                        beanProperty.setRef(beanPropertyElement
                                .getAttribute("ref"));
                        beanConfig.addBeanProperty(beanProperty);
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

    public Object getBean(String id) {
        if (beans.containsKey(id)) {
            BeanConfig beanConfig = beans.get(id);
            String scope = beanConfig.getScope();
            if (scope == null || scope.equals("")) {
                scope = "singleton";
            }

            if (scope.equalsIgnoreCase("singleton")) {
                if (objects.containsKey(id)) {
                    return objects.get(id);
                }
            }

            String className = beanConfig.getClassName();
            Class<?> clazz = null;
            try {
                clazz = Class.forName(className);
                Object object = clazz.newInstance();
                if (scope.equalsIgnoreCase("singleton")) {
                    objects.put(id, object);
                }
                // DI
                List<BeanProperty> beanPropertyList = beanConfig
                        .getBeanPropertys();
                if (beanPropertyList != null && !beanPropertyList.isEmpty()) {
                    for (BeanProperty beanProperty : beanPropertyList) {
                        String name = beanProperty.getName();
                        String methodName = "set"
                                + name.substring(0, 1).toUpperCase()
                                + name.substring(1);

                        Method method = null;
                        Method[] methods = clazz.getMethods();
                        for (Method methodInClass : methods) {
                            String methodNameInClass = methodInClass.getName();
                            if (methodNameInClass.equals(methodName)) {
                                method = methodInClass;
                                break;
                            }
                        }
                        String ref = beanProperty.getRef();
                        String value = beanProperty.getValue();
                        if (!ref.trim().equals("") && ref != null) {
                            Object refObject = this.getBean(ref);
                            method.invoke(object, refObject);
                        } else if (!value.trim().equals("") && value != null) {
                            Class<?>[] parameterTypes = method
                                    .getParameterTypes();
                            if (parameterTypes[0] == String.class) {
                                method.invoke(object, value);
                            }
                            if (parameterTypes[0] == Integer.class) {
                                method.invoke(object, Integer.parseInt(value));
                            }
                            if (parameterTypes[0] == Boolean.class) {
                                method.invoke(object,
                                        Boolean.parseBoolean(value));
                            }
                        }
                    }
                }
                if (object.getClass().getPackage().getName()
                        .equals("com.kevin.oes.service.impl")) {
                    ConnectionDynamicProxy connectionDynamicProxy = new ConnectionDynamicProxy();
                    connectionDynamicProxy.setTarget(object);
                    Object proxyObject = Proxy.newProxyInstance(object
                            .getClass().getClassLoader(), object.getClass()
                            .getInterfaces(), connectionDynamicProxy);
                    return proxyObject;
                }
                return object;
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return null;
    }
}
