package com.augmentum.common;

import java.util.HashMap;
import java.util.Map;

public class ModelAndView {

    private Map<String, Object> sessions = new HashMap<String,Object>();
    private Map<String, Object> requests = new HashMap<String,Object>();
    private String view;
    private boolean isRedirct = false;

    public ModelAndView() {
        super();
    }

    public ModelAndView(String view, boolean isRedirct) {
        super();
        this.view = view;
        this.isRedirct = isRedirct;
    }

    public String getView() {
        return view;
    }

    public void setView(String view) {
        this.view = view;
    }

    public boolean isRedirct() {
        return isRedirct;
    }

    public void setRedirct(boolean isRedirct) {
        this.isRedirct = isRedirct;
    }

    public void addRequestAttribute(String key,Object obj) {
        requests.put(key, obj);
    }

    public void addSessionAttribute(String key, Object object) {
        sessions.put(key, object);
    }

    public Map<String, Object> getSessions() {
        return sessions;
    }

    public Map<String, Object> getRequests() {
        return requests;
    }

    @Override
    public String toString() {
        return "ModelAndView [view=" + view + ", isRedirct=" + isRedirct + "]";
    }
}
