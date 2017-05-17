package com.augmentum.common;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

public interface JDBCCallBack<T> {

    public abstract T rsToObject(ResultSet rs) throws SQLException;

    public void setParams(PreparedStatement stmt) throws SQLException;
}
