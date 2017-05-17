package com.augmentum.login.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.augmentum.login.exception.DBException;
import com.augmentum.login.model.User;
import com.augmentum.login.util.DBUtil;

public class UserDao {
    public User getUserByName(String userName) {
        Connection conn = null;
        User user = null;
        conn = DBUtil.getConnection();
        PreparedStatement ps = null;
        ResultSet rs = null;

        String sql="SELECT * FROM user WHERE user_name = ?";

        try {
            ps = conn.prepareStatement(sql);
            ps.setString(1, userName);
            rs = ps.executeQuery();
            if (rs.next()) {
                user = new User();
                user.setId(rs.getInt(1));
                user.setUserName(rs.getString(2));
                user.setPassword(rs.getString(3));
            }

        }catch (SQLException e) {
            e.printStackTrace();
            throw new DBException();
        } finally {
            try {
                DBUtil.close(conn, ps, rs);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
        return user;
   }
}

