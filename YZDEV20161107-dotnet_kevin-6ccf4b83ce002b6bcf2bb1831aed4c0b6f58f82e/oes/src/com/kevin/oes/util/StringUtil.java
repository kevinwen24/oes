package com.kevin.oes.util;

public class StringUtil {
    public static boolean isEmpty(String str) {
        if (str == null || str.equals("")) {
            return true;
        }

        return false;
    }
}
