package com.augmentum.oes.dao.jdbc.mysql;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Date;
import java.util.List;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.RowMapper;

import com.augmentum.oes.dao.UserDao;
import com.augmentum.oes.model.User;

public class UserDaoImpl implements UserDao{

    private JdbcTemplate jdbcTemplate;

    public void setJdbcTemplate(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }

    public User getUserByName(String userName) {
        if (userName == null || userName == "") {
            return null;
        }

        String sql="SELECT * FROM user WHERE user_name = ?";
        Object[] args = new Object[]{userName};
        RowMapper<User> rowMapper = new RowMapper<User>() {
            @Override
            public User mapRow(ResultSet rs, int row) throws SQLException {
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
        };
        List<User> users = jdbcTemplate.query(sql, args, rowMapper);
        if (users.isEmpty()) {
            return null;
        } else {
            return users.get(0);
        }
   }
}
