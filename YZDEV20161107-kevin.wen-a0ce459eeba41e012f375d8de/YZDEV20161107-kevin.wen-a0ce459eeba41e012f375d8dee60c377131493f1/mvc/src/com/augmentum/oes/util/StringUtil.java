package com.augmentum.oes.util;

public class StringUtil {
    public static boolean isEmpty(String str) {
        if (str == null || str.equals("")) {
            return true;
        }
        return false;
    }

    public static String transferString(String str) {

        return str.replaceAll("%", "\\\\%")
                  .replaceAll("_", "\\\\_")
                  .replaceAll("'", "\\\\'");
    }
}
