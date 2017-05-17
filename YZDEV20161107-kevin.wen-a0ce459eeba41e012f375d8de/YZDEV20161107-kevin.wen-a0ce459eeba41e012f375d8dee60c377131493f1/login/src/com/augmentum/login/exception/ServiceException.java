package com.augmentum.login.exception;

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
