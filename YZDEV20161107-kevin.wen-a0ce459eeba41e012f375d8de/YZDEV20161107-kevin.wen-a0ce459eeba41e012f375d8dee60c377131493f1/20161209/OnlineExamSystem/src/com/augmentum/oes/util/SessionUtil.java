package com.augmentum.oes.util;

import java.lang.reflect.Method;

import com.augmentum.oes.AppContext;
import com.augmentum.oes.Constants;

public class SessionUtil {

    private static Object getSessionInThread() {
        Object session = AppContext.getAppContext().getObject(Constants.APP_Context_SESSION);
        return session;
    }

    public static void addSession(String key, Object object) {
        Object session = getSessionInThread();
        if (session == null) {
            return;
        }
        try {
            Class<?>[] param = new Class[2];
            param[0] = String.class;
            param[1] = Object.class;

            Method method = session.getClass().getMethod("setAttribute", param);
            Object[] objects = new Object[2];
            objects[0] = key;
            objects[1] = object;

            method.invoke(session, objects);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public static Object getSession(String key) {
        Object session = getSessionInThread();
        if (session == null) {
            return null;
        }
        Object value = null;

        try {
            Method method = session.getClass().getMethod("getAttribute", String.class);
            value = method.invoke(session, key);
        }catch (Exception e) {
            throw new RuntimeException(e);
        }

        return value;
    }

    public static void removeSession(String key) {
        Object session = getSessionInThread();
        if (session == null) {
            return;
        }

        try {
            Method method = session.getClass().getMethod("removeAttribute", String.class);
            method.invoke(session, key);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public static void invalidate() {
        Object session = getSessionInThread();
        if (session == null) {
            return;
        }

        try {
            Method method = session.getClass().getMethod("invalidate");
            method.invoke(session);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
}
