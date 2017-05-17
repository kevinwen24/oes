package com.augmentum.login.util;

public class StringUtil {
    public static boolean isEmpty(String str) {
        if (str == null || str.equals("")) {
            return true;
        }

        return false;
    }
}
