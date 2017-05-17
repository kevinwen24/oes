package com.kevin.oes.util;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import com.kevin.oes.exception.DBException;

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

    public static Connection getConnection()  {
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

    public static void close(Connection conn, Statement stmt) {
        try {
            close( conn,  stmt, null);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static void close(Connection conn, Statement stmt, ResultSet rs) {
        try {
            if(conn != null){
                conn.close();
            }
            if(stmt != null){
                stmt.close();
            }
            if(rs != null){
                rs.close();
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

}
