/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.common;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import com.augmentum.oes.AppContext;
import com.augmentum.oes.Constants;
import com.augmentum.oes.exception.DBException;
import com.augmentum.oes.util.DBUtil;

public class JDBCTemplate<T> {

    private Connection conn;
    private PreparedStatement ps;
    private ResultSet rs;

    public List<T> query(String sql, JDBCCallBack<T> jdbcCallback) {
        List<T> data = new ArrayList<T>();
        conn = (Connection)AppContext.getAppContext().getObject(Constants.APP_Context_CONNECTION);
        boolean needMyClose = false;
        if (conn == null) {
            conn = DBUtil.getConnection();
            needMyClose = true;
        }
        DBUtil.setAutoCommit(conn, false);
        try {
            ps = conn.prepareStatement(sql);
            jdbcCallback.setParams(ps);
            rs = ps.executeQuery();
            while (rs.next()) {
                T object = jdbcCallback.rsToObject(rs);
                data.add(object);
            }
            DBUtil.commit(conn);
        } catch (SQLException e) {
            DBUtil.rollback(conn);
            e.printStackTrace();
        } finally {
            DBUtil.close(null, ps, rs);
            if (needMyClose) {
                DBUtil.close(conn, null, null);
            }
        }

        return data;
    }

    public T queryOne(String sql, JDBCCallBack<T> jdbcCallback) {
        List<T> data = query(sql, jdbcCallback);
        if (data != null && !data.isEmpty()) {
            return data.get(0);
        }

        return null;
    }

    public int update(String sql, JDBCCallBack<T> jdbcCallBack) {
        conn = (Connection)AppContext.getAppContext().getObject(Constants.APP_Context_CONNECTION);
        DBUtil.setAutoCommit(conn, false);
        int count = 0;
        boolean needMyClose = false;
        try {
            if (conn == null) {
                conn = DBUtil.getConnection();
                needMyClose = true;
            }

            ps = conn.prepareStatement(sql);
            jdbcCallBack.setParams(ps);
            count = ps.executeUpdate();

        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException();
        } finally {
            DBUtil.close(null, ps);
            if (needMyClose) {
                DBUtil.close(conn, null, null);
            }
        }
        return count;
    }

    public int insert(String sql, JDBCCallBack<T> jdbcCallback) {
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        int id = 0;
        boolean needMyClose = false;
        conn = (Connection)AppContext.getAppContext().getObject(Constants.APP_Context_CONNECTION);
        try {
            if (conn == null) {
                conn = DBUtil.getConnection();
                needMyClose = true;
            }
            stmt = conn.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);
            jdbcCallback.setParams(stmt);

            stmt.executeUpdate();

            rs = stmt.getGeneratedKeys();
            if (rs.next()) {
               id = rs.getInt(1);
            }

        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException();
        } finally {
            DBUtil.close(null, stmt, rs);
            if (needMyClose) {
                DBUtil.close(conn, null, null);
            }
        }

        return id;
    }


    public int getCount(String sql, JDBCCallBack<T> jdbcCallback) {
        Connection conn = null;
        PreparedStatement stmt = null;
        ResultSet rs = null;
        int count = 0;
        boolean needMyClose = false;
        conn = (Connection)AppContext.getAppContext().getObject(Constants.APP_Context_CONNECTION);
        try {
            if (conn == null) {
                conn = DBUtil.getConnection();
                needMyClose = true;
            }
            stmt = conn.prepareStatement(sql);
            rs = stmt.executeQuery();
            if (rs.next()) {
                count = rs.getInt(1);
            }
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException();
        } finally {
            DBUtil.close(null, stmt, rs);
            if (needMyClose) {
                DBUtil.close(conn, null, null);
            }
        }

        return count;
    }

    public int getCount(String sql) {
        return this.getCount(sql, new JDBCAbstractCallBack<T>() {});
    }
}
