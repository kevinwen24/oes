package com.kevin.oes.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Date;

import com.kevin.oes.exception.DBException;
import com.kevin.oes.model.User;
import com.kevin.oes.util.DBUtil;

public class UserDao {
    private Connection conn ;
    private User user;
    private PreparedStatement ps ;
    private ResultSet rs;

    public User getUserByName(String userName) {

        conn = DBUtil.getConnection();

        String sql="SELECT * FROM user WHERE user_name = ?";

        try {
            ps = conn.prepareStatement(sql);
            ps.setString(1, userName);
            rs = ps.executeQuery();
            if (rs.next()) {
                user = new User();
                user.setId(rs.getInt("id"));
                user.setUserName(rs.getString("user_name"));
                user.setPassword(rs.getString("password"));
                user.setChineseName(rs.getString("chinese_name"));
                user.setGender(rs.getString("gender"));
                user.setUserEmail(rs.getString("user_email"));
                user.setCreateTime(new Date(rs.getDate("create_time").getTime()));
                user.setUpdateTime(new Date(rs.getDate("update_time").getTime()));
                user.setLastLoginTime(new Date(rs.getDate("last_login_time").getTime()));
                user.setRoleId(Integer.parseInt(rs.getString("role_id")));
                user.setIsAlive(Integer.parseInt(rs.getString("is_alive")));
            }
        }catch (SQLException e) {
            e.printStackTrace();
            throw new DBException();
        } finally {
            DBUtil.close(conn, ps, rs);
        }
        return user;
   }
}

