package com.augmentum.oes.util;

import com.augmentum.oes.AppContext;
import com.augmentum.oes.Constants;

public class PathUtil {

    public static String getFullPath(String path) {
        if (path == null) {
            path = "";
        }
        String urlPreFix = Constants.APP_URL_PREFIX;
        if(!StringUtil.isEmpty(urlPreFix)) {
            urlPreFix += "/";
        }
        return AppContext.getContextPath() + "/" + urlPreFix + path;
    }
}
