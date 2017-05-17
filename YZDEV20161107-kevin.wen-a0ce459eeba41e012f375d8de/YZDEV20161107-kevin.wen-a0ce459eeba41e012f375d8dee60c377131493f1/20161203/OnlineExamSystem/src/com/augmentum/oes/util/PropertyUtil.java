/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.util;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

public class PropertyUtil {

    private static Properties pro;

    static {
        InputStream is = PropertyUtil.class.getClassLoader().getResourceAsStream("app.properties");
        pro = new Properties();
        try {
            pro.load(is);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public static String getProperties(String name) {
        return pro.getProperty(name);
    }
}
