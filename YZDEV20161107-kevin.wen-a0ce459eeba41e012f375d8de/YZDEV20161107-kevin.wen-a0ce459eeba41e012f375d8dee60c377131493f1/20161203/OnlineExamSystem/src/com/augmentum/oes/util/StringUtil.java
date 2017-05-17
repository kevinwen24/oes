/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.util;
/**
 * This class is a tool class
 * @author kevin
 * @version 1.0.0
 * @project Online Web Exam System
 *
 */
public class StringUtil {

    public static boolean isEmpty(String str) {
        if (str == null || "".equals(str)) {
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
