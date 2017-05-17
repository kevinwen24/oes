/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.util;
/**
 * This class as a String tool class
 * @author kevin
 * @version 1.0.0
 * @project Online Web Exam System
 *
 */
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

    public static String htmlEncode(String txt) {
        if (txt != null) {
            txt = txt.replaceAll("&", "&amp;");
            txt = txt.replaceAll("&amp;amp;", "&amp;");
            txt = txt.replaceAll("&amp;quot;", "&quot;");
            txt = txt.replaceAll("\"", "&quot;");
            txt = txt.replaceAll("&amp;lt;", "&lt;");
            txt = txt.replaceAll("<", "&lt;");
            txt = txt.replaceAll("&amp;gt;", "&gt;");
            txt = txt.replaceAll(">", "&gt;");
            txt = txt.replaceAll("&amp;nbsp;", "&nbsp;");
        }
        return txt;
    }
}
