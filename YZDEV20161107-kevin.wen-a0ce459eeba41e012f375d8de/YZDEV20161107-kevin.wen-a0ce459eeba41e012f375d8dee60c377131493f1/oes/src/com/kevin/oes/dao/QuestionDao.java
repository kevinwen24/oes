package com.kevin.oes.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import com.kevin.oes.exception.DBException;
import com.kevin.oes.model.Question;
import com.kevin.oes.util.DBUtil;
import com.kevin.oes.util.Pagination;

public class QuestionDao {
    private Connection conn;
    private PreparedStatement ps;
    private ResultSet rs;

    public int addQuestion(Question question){
        conn = DBUtil.getConnection();
        try {
        ps = conn.prepareStatement("INSERT INTO question(title,option_a,option_b,option_c,option_d,answer,create_time) VALUES(?,?,?,?,?,?,NOW())"
                                , Statement.RETURN_GENERATED_KEYS);
        ps.setString(1, question.getTitle());
        ps.setString(2, question.getOptionA());
        ps.setString(3, question.getOptionB());
        ps.setString(4, question.getOptionC());
        ps.setString(5, question.getOptionD());
        ps.setInt(6, question.getAnswer());

        ps.executeUpdate();
        rs = ps.getGeneratedKeys();

        if(rs.next()){
            int id = rs.getInt(1);
            question.setId(id);
            question.setQuestionId(insertQuestionIdById(id));
        }
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException();
        }finally{
            DBUtil.close(conn, ps, rs);
        }
        return question.getId();
    }

    public int getCountQuestion(){
        int totalCount = 0;

        conn = DBUtil.getConnection();
        try {
            ps = conn.prepareStatement("SELECT count(*) totalCount FROM question WHERE is_alive=0");
            rs = ps.executeQuery();
            if(rs.next()){
                totalCount= rs.getInt("totalCount");
            }
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException();
        }finally{
            DBUtil.close(conn, ps, rs);
        }
        return totalCount;
    }
    public List<Question> findAllQuestion(Pagination pagination){
        Question question =null;
        List<Question> questions = new ArrayList<Question>();

        pagination.setTotalCount(this.getCountQuestion());
        if(pagination.getCurrentPage()>pagination.getPageCount()) {
            pagination.setCurrentPage(pagination.getPageCount());
        }
        conn = DBUtil.getConnection();
        try {
           ps = conn.prepareStatement("SELECT * FROM question where is_alive=0  LIMIT  "+pagination.getOffset()+","+pagination.getPageSize());
           rs = ps.executeQuery();
           while(rs.next()) {
               question = new Question();
               question.setId(rs.getInt("id"));
               question.setQuestionId(rs.getString("question_id"));
               question.setTitle(rs.getString("title"));
               question.setOptionA(rs.getString("option_a"));
               question.setOptionB(rs.getString("option_b"));
               question.setOptionC(rs.getString("option_c"));
               question.setOptionD(rs.getString("option_d"));
               question.setAnswer(rs.getInt("answer"));
               question.setCreateTime(new Date(rs.getDate("create_time").getTime()));
               question.setIsAlive(rs.getInt("is_alive"));
               questions.add(question);
           }
        } catch (SQLException e) {
            e.printStackTrace();
        }finally{
            DBUtil.close(conn, ps, rs);
        }
        return questions;
    }

    public Question queryQuestionById (int id) {
        Question question =null;

        conn = DBUtil.getConnection();
        try {
        ps = conn.prepareStatement("SELECT * FROM question WHERE id ="+id);
        rs = ps.executeQuery();
        if(rs.next()){
            question = new Question();
            question.setId(rs.getInt("id"));
            question.setQuestionId(rs.getString("question_id"));
            question.setTitle(rs.getString("title"));
            question.setOptionA(rs.getString("option_a"));
            question.setOptionB(rs.getString("option_b"));
            question.setOptionC(rs.getString("option_c"));
            question.setOptionD(rs.getString("option_d"));
            question.setAnswer(rs.getInt("answer"));
            question.setCreateTime(new Date(rs.getDate("create_time").getTime()));
            question.setIsAlive(rs.getInt("is_alive"));
        }
        } catch (SQLException e) {
            e.printStackTrace();
        }finally{
            DBUtil.close(conn, ps, rs);
        }
        return question;
    }

    public int deleteQuestionById (int id){
        int num =0;
        conn = DBUtil.getConnection();
        try {
        ps = conn.prepareStatement("update question SET is_alive = -1,update_time=NOW()  where id="+id);
        num = ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
        }finally{
            DBUtil.close(conn, ps);
        }
        return num;
    }

    private String insertQuestionIdById(int id) {
        conn =  DBUtil.getConnection();
        String questionId = String.format("Q%06d", id);
        try {
        ps = conn.prepareStatement("UPDATE question SET question_id='"+questionId+"' where id="+id);
        ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException();
        }finally{
            DBUtil.close(conn, ps);
        }
        return questionId;
    }

    public int deleteQuestionByIds (int[] ids) {
        conn = DBUtil.getConnection();
        try {
            ps = conn.prepareStatement("UPDATE question SET  is_alive=-1,update_time=NOW()  WHERE id = ?");
            for (int i=0; i<ids.length; i++) {
                ps.setInt(1, ids[i]);
                ps.addBatch();
                if(i%10==0) {
                    ps.executeUpdate();
                }
            }
            ps.executeUpdate();
        } catch (SQLException e) {
            e.printStackTrace();
            throw new DBException();
        }finally{
            DBUtil.close(conn, ps);
        }
        return ids.length;
    }
}
