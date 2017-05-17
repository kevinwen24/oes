/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.common;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public interface JDBCCallBack<T> {

    public abstract T rsToObject(ResultSet rs) throws SQLException;

    public void setParams(PreparedStatement stmt) throws SQLException;
}
