package com.augmentum.oes;

import java.util.HashMap;
import java.util.Map;

import com.augmentum.oes.model.User;

public class AppContext {

    private static String contextPath;

    private static ThreadLocal<AppContext> appContextMap = new ThreadLocal<AppContext>();
    private Map<String, Object> values = new HashMap<String, Object>();

    public static AppContext getAppContext() {
        AppContext appContext = appContextMap.get();
        if (appContext == null) {
            appContext = new AppContext();
            appContextMap.set(appContext);
        }
        return appContext;
    }

    public static void setContextPath(String contextPath) {
        if (AppContext.contextPath == null) {
            AppContext.contextPath = contextPath;
        }
    }

    public static String getContextPath() {
        return contextPath;
    }

    public Object getObject(String key) {
        return values.get(key);
    }

    public Map<String, Object> getValues() {
        return values;
    }

    public void addObjects(String key, Object obj) {
        values.put(key, obj);
    }

    public void clear() {
        values.clear();
    }

    public User getUser() {
        return (User)values.get(Constants.APP_Context_USER);
    }

    public String getUserName() {
        User user = (User)values.get(Constants.APP_Context_USER);
        if (user !=null) {
            return user.getUserName();
        }
        return "";
    }

    public int getUserId() {
        User user = (User)values.get(Constants.APP_Context_USER);
        if (user !=null) {
            return user.getId();
        }
        return 0;
    }
}
