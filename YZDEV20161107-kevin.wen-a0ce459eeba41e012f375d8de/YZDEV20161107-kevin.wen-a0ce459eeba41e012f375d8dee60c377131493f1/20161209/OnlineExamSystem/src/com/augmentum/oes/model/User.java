package com.augmentum.oes.model;

import java.util.Date;

public class User {
    private Integer id;
    private String userName;
    private String chineseName;
    private String gender;
    private String userEmail;
    private String password;
    private Date createTime;
    private Date updateTime;
    private Date lastLoginTime;
    private int roleId;
    private int isAlive;

    public User() {
        super();
    }

    public User(Integer id, String userName, String chineseName, String gender,
            String userEmail, String password, Date createTime,
            Date updateTime, Date lastLoginTime, int roleId, int isAlive) {
        super();
        this.id = id;
        this.userName = userName;
        this.chineseName = chineseName;
        this.gender = gender;
        this.userEmail = userEmail;
        this.password = password;
        this.createTime = createTime;
        this.updateTime = updateTime;
        this.lastLoginTime = lastLoginTime;
        this.roleId = roleId;
        this.isAlive = isAlive;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getChineseName() {
        return chineseName;
    }

    public void setChineseName(String chineseName) {
        this.chineseName = chineseName;
    }

    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }

    public String getUserEmail() {
        return userEmail;
    }

    public void setUserEmail(String userEmail) {
        this.userEmail = userEmail;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Date getCreateTime() {
        return createTime;
    }

    public void setCreateTime(Date createTime) {
        this.createTime = createTime;
    }

    public Date getUpdateTime() {
        return updateTime;
    }

    public void setUpdateTime(Date updateTime) {
        this.updateTime = updateTime;
    }

    public Date getLastLoginTime() {
        return lastLoginTime;
    }

    public void setLastLoginTime(Date lastLoginTime) {
        this.lastLoginTime = lastLoginTime;
    }

    public int getRoleId() {
        return roleId;
    }

    public void setRoleId(int roleId) {
        this.roleId = roleId;
    }

    public int getIsAlive() {
        return isAlive;
    }

    public void setIsAlive(int isAlive) {
        this.isAlive = isAlive;
    }

    @Override
    public String toString() {
        return "User [id=" + id + ", userName=" + userName + ", chineseName="
                + chineseName + ", gender=" + gender + ", userEmail="
                + userEmail + ", password=" + password + ", createTime="
                + createTime + ", updateTime=" + updateTime
                + ", lastLoginTime=" + lastLoginTime + ", roleId=" + roleId
                + ", isAlive=" + isAlive + "]";
    }




}
