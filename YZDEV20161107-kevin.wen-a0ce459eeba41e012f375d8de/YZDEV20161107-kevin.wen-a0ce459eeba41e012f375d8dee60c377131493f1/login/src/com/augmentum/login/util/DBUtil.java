package com.augmentum.login.util;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import com.augmentum.login.exception.DBException;

public class DBUtil {
    private static String driver;
    private static String url;
    private static String user;
    private static String password;
    private static Connection conn;
    static {
            driver = PropertyUtil.getProperties("jdbc.driver");
            url = PropertyUtil.getProperties("jdbc.url");
            user = PropertyUtil.getProperties("jdbc.user");
            password = PropertyUtil.getProperties("jdbc.password");
    }
    public static Connection getConnection() throws DBException {
        try {
            Class.forName(driver);
            } catch (ClassNotFoundException e) {
                e.printStackTrace();
            }
            try {
                conn = DriverManager.getConnection(url, user, password);
            } catch (SQLException e) {
                e.printStackTrace();
                throw new DBException();
            }
        return conn;
    }
    public static void close(Connection conn, Statement stmt) throws DBException {
        try {
            close( conn,  stmt, null);
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException();
        }
    }
    public static void close(Connection conn, Statement stmt, ResultSet rs)throws SQLException {
        if(rs != null){
            rs.close();
        }
        if(stmt != null){
            rs.close();
        }
        if(conn != null){
            rs.close();
        }
    }

}
