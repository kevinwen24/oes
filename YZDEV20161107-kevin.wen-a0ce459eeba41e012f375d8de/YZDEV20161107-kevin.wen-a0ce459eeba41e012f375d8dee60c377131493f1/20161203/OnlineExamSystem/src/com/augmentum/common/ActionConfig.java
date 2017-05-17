/*
 * Copyright (c) 1994, 2017, augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.common;

import java.util.HashMap;
import java.util.Map;
/**
 * This class mapping action.xml element
 * @author kevin
 * @version 1.0.0
 * @project Online Exam System
 *
 */
public class ActionConfig {

    private String className;
    private String method;
    private String[] httpMethod;
    private Map<String, ResultConfig> results = new HashMap<String, ResultConfig>();

    public ActionConfig() {
        super();
    }

    public ActionConfig(String className, String method) {
        super();
        this.className = className;
        this.method = method;
    }

    public String getClassName() {
        return className;
    }

    public void setClassName(String className) {
        this.className = className;
    }

    public String getMethod() {
        return method;
    }

    public void setMethod(String method) {
        this.method = method;
    }

    public String[] getHttpMethod() {
        return httpMethod;
    }

    public void setHttpMethod(String[] httpMethod) {
        this.httpMethod = httpMethod;
    }

    public void addResult(String name, ResultConfig resultConfig) {
        results.put(name, resultConfig);
    }

    public ResultConfig getResult(String name) {
        return results.get(name);
    }
}
