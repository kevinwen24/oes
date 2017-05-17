/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.exception;

import java.util.HashMap;
import java.util.Map;
/**
 * This class use to deal with paramException
 * @author kevin
 * @version 1.0.0
 * @project Online Web Exam System
 *
 */
public class ParamterException extends Exception {

    private static final long serialVersionUID = 7747458901806166220L;

    Map<String,String> errorFields = new HashMap<String,String>();

    public Map<String, String> getErrorFields() {
        return errorFields;
    }

    public void setErrorFields(Map<String, String> errorFields) {
        this.errorFields = errorFields;
    }

    public void addErrorField(String fieldName, String message) {
        errorFields.put(fieldName, message);
    }

    public boolean isErrorField() {
        return !errorFields.isEmpty();
    }

}
