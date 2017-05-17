package com.augmentum.oes.dao;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Date;

import com.augmentum.common.JDBCCallBack;
import com.augmentum.common.JDBCTemplate;
import com.augmentum.oes.model.User;

public class UserDao {

    private JDBCTemplate<User> jdbcTemplate;

    public void setJdbcTemplate(JDBCTemplate<User> jdbcTemplate) {
        this.jdbcTemplate= jdbcTemplate;
    }

    public User getUserByName(final String userName) {
        String sql="SELECT * FROM user WHERE user_name = ?";
        return jdbcTemplate.queryOne(sql, new JDBCCallBack<User>() {
            @Override
            public User rsToObject(ResultSet rs) throws SQLException {
                User user = new User();
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
                return user;
            }

            @Override
            public void setParams(PreparedStatement stmt) throws SQLException {
                stmt.setString(1, userName);
            }
        });
   }
}

