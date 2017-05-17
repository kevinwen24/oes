/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.exception;
/**
 * This class use to deal with sevice Exception
 * @author kevin
 * @version 1.0.0
 * @project Online Web Exam System
 *
 */
public class ServiceException extends Exception{
    private static final long serialVersionUID = -8063960611811622798L;
    private int code;
    private String msg;

    public ServiceException(String msg) {
        super();
        this.msg = msg;
    }

    public ServiceException(int code, String msg) {
        super();
        this.code = code;
        this.msg = msg;
    }

    public int getCode() {
        return code;
    }

    public void setCode(int code) {
        this.code = code;
    }

    public String getMsg() {
        return msg;
    }

    public void setMsg(String msg) {
        this.msg = msg;
    }

}
