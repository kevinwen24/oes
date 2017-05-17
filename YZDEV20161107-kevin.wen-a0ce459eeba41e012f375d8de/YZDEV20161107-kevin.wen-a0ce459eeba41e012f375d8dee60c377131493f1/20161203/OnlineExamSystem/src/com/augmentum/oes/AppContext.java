/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes;
/**
 * This class gain the same request's data
 * @author kevin
 * @version 1.0.0
 * @project Online Web Exam System
 *
 */
import java.util.HashMap;
import java.util.Map;

public class AppContext {

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
