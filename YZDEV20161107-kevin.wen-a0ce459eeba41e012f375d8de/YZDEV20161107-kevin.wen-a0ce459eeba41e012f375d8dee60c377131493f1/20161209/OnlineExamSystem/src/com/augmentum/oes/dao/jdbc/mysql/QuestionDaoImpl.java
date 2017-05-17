package com.augmentum.oes.dao.jdbc.mysql;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Date;
import java.util.List;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.core.PreparedStatementCreator;
import org.springframework.jdbc.core.RowMapper;
import org.springframework.jdbc.support.GeneratedKeyHolder;
import org.springframework.jdbc.support.KeyHolder;

import com.augmentum.oes.dao.QuestionDao;
import com.augmentum.oes.model.Question;
import com.augmentum.oes.util.Pagination;

public class QuestionDaoImpl implements QuestionDao{

    private JdbcTemplate jdbcTemplate;

    public void setJdbcTemplate(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate= jdbcTemplate;
    }

    @Override
    public int addQuestion(final Question question){
        KeyHolder keyHolder = new GeneratedKeyHolder();
        jdbcTemplate.update(new PreparedStatementCreator() {

            @Override
            public PreparedStatement createPreparedStatement(Connection conn)
                    throws SQLException {
                String sql = "INSERT INTO question(title,option_a,option_b,option_c,option_d,answer,create_time) VALUES(?,?,?,?,?,?,NOW())";
                PreparedStatement ps =conn.prepareStatement(sql, Statement.RETURN_GENERATED_KEYS);
                ps.setString(1, question.getTitle());
                ps.setString(2, question.getOptionA());
                ps.setString(3, question.getOptionB());
                ps.setString(4, question.getOptionC());
                ps.setString(5, question.getOptionD());
                ps.setInt(6, question.getAnswer());
                return ps;
            }
        }, keyHolder);
        question.setId(keyHolder.getKey().intValue());
        return keyHolder.getKey().intValue();
    }

    @Override
    public int getCountQuestion(String keywords){
        if (keywords == null ) {
            keywords = "";
        }
        String sql = "SELECT count(*) totalCount FROM question WHERE is_alive=0  AND title like '%"+ keywords +"%'";

        return jdbcTemplate.queryForInt(sql);
    }

    @Override
    public List<Question> findAllQuestion(Pagination pagination){
        pagination.setTotalCount(this.getCountQuestion(pagination.getSearch()));
        if (pagination.getCurrentPage() > pagination.getPageCount()) {
            pagination.setCurrentPage(pagination.getPageCount());
        }

        String sql = "SELECT * FROM question WHERE is_alive=0 and title like '%" + pagination.getSearch() + "%' ORDER BY id " + pagination.getSort() + " LIMIT "+pagination.getOffset()+"," + pagination.getPageSize();
        RowMapper<Question> rowMapper = new RowMapper<Question>() {

            @Override
            public Question mapRow(ResultSet rs, int arg1)
                    throws SQLException {
                return rsToQuestion(rs);
            }
        };

        return jdbcTemplate.query(sql,rowMapper);
    }

    @Override
    public int deleteQuestionById (int id){
        String sql = "update question SET is_alive = -1, update_time=NOW()  where id=" + id;
        return jdbcTemplate.update(sql);
    }

    @Override
    public String insertQuestionIdById(int id) {
        String questionId = String.format("Q%06d", id);
        String sql = "UPDATE question SET question_id='" + questionId+"' where id=" + id;
        jdbcTemplate.update(sql);
        return questionId;
    }

    @Override
    public int deleteQuestionByIds (int[] ids) {
        StringBuffer sb = new StringBuffer();
        for (int i = 0; i < ids.length; i++) {
            sb.append(ids[i]+",");
        }

        String deleteQuestionId = sb.toString().substring(0,sb.length() - 1);
        String sql = "UPDATE question SET  is_alive=-1,update_time=NOW() WHERE id in (" + deleteQuestionId + ")";
        jdbcTemplate.update(sql);
        return ids.length;
    }

    @Override
    public Question queryQuestionById (int id) {
        String sql = "SELECT * FROM question WHERE id = " + id;
        RowMapper<Question> rowMapper = new RowMapper<Question>() {

            @Override
            public Question mapRow(ResultSet rs, int arg1)
                    throws SQLException {
                return rsToQuestion(rs);
            }
        };
        List<Question> questions = jdbcTemplate.query(sql, rowMapper);
        if (questions.isEmpty()) {
            return null;
        } else {
            return questions.get(0);
        }
    }

    private Question rsToQuestion(ResultSet rs) throws SQLException {
        Question question= new Question();
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
        return question;
    }

}
