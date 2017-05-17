package com.augmentum.oes;

import java.util.HashMap;
import java.util.Map;

public class AppContext {
    //private  Map<Thread, AppContext> appContextMap;

    private static ThreadLocal<AppContext> appContextMap = new ThreadLocal<AppContext>();
    private Map<String, Object> gainObject = new HashMap<String, Object>();

    public static AppContext getAppContext() {
        AppContext appContext = appContextMap.get();
        if (appContext == null) {
            appContext = new AppContext();
            appContextMap.set(appContext);
        }
        return appContext;
    }

    public Object getObject(String key) {
        return gainObject.get(key);
    }

    public Map<String, Object> getGainObject() {
        return gainObject;
    }

    public void addObjects(String key, Object obj) {
        gainObject.put(key, obj);
    }

    public void clear() {
        gainObject.clear();
    }


}
