package com.augmentum.oes.model;

import java.util.Date;

public class Question {
    private Integer id;
    private String questionId;
    private String title;
    private String optionA;
    private String optionB;
    private String optionC;
    private String optionD;
    private Integer answer;
    private Date createTime;
    private Date updateTime;
    private int isAlive;

    public Question() {
        super();
    }

    public Question(Integer id, String questionId, String title,
            String optionA, String optionB, String optionC, String optionD,
            Integer answer, Date createTime, Date updateTime, int isAlive) {
        super();
        this.id = id;
        this.questionId = questionId;
        this.title = title;
        this.optionA = optionA;
        this.optionB = optionB;
        this.optionC = optionC;
        this.optionD = optionD;
        this.answer = answer;
        this.createTime = createTime;
        this.updateTime = updateTime;
        this.isAlive = isAlive;
    }


    public String getQuestionId() {
        return questionId;
    }


    public void setQuestionId(String questionId) {
        this.questionId = questionId;
    }


    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getOptionA() {
        return optionA;
    }

    public void setOptionA(String optionA) {
        this.optionA = optionA;
    }

    public String getOptionB() {
        return optionB;
    }

    public void setOptionB(String optionB) {
        this.optionB = optionB;
    }

    public String getOptionC() {
        return optionC;
    }

    public void setOptionC(String optionC) {
        this.optionC = optionC;
    }

    public String getOptionD() {
        return optionD;
    }

    public void setOptionD(String optionD) {
        this.optionD = optionD;
    }

    public Integer getAnswer() {
        return answer;
    }

    public void setAnswer(Integer answer) {
        this.answer = answer;
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

    public int getIsAlive() {
        return isAlive;
    }

    public void setIsAlive(int isAlive) {
        this.isAlive = isAlive;
    }

    @Override
    public String toString() {
        return "Question [id=" + id + ", questionId=" + questionId + ", title="
                + title + ", optionA=" + optionA + ", optionB=" + optionB
                + ", optionC=" + optionC + ", optionD=" + optionD + ", answer="
                + answer + ", createTime=" + createTime + ", updateTime="
                + updateTime + ", isAlive=" + isAlive + "]";
    }



}
