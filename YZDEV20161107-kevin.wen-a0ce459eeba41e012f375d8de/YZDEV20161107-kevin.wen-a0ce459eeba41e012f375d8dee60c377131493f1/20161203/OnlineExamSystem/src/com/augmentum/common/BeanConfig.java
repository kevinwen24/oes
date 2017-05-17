/*
 * Copyright (c) 1994, 2017, augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.common;

import java.util.ArrayList;
import java.util.List;
/**
 * This class mapping bean.xml element
 * @author kevin
 * @version 1.0.0
 * @project Online Exam System
 *
 */
public class BeanConfig {

    private String id;
    private String className;
    private String scope;
    private List<BeanProperty> beanPropertys = new ArrayList<BeanProperty>();

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getClassName() {
        return className;
    }

    public void setClassName(String className) {
        this.className = className;
    }

    public String getScope() {
        return scope;
    }

    public void setScope(String scope) {
        this.scope = scope;
    }

    public void addBeanProperty(BeanProperty beanProperty) {
        beanPropertys.add(beanProperty);
    }

    public List<BeanProperty> getBeanPropertys() {
        return beanPropertys;
    }
    @Override
    public String toString() {
        return "BeanConfig [id=" + id + ", className=" + className + ", scope="
                + scope + "]";
    }
}
