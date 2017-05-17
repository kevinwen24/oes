package com.augmentum.oes.dao;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Date;
import java.util.List;

import com.augmentum.common.JDBCAbstractCallBack;
import com.augmentum.common.JDBCCallBack;
import com.augmentum.common.JDBCTemplate;
import com.augmentum.oes.model.Question;
import com.augmentum.oes.util.Pagination;

/**
 * This class is used to question CIUD
 * @author kevin
 * @version 1.0.0
 * @project Online Web Exam System
 *
 */
public class QuestionDao {

    private JDBCTemplate<Question> jdbcTemplate;

    public void setJdbcTemplate(JDBCTemplate<Question> jdbcTemplate) {
        this.jdbcTemplate= jdbcTemplate;
    }

    public int addQuestion(final Question question){
        String sql = "INSERT INTO question(title,option_a,option_b,option_c,option_d,answer,create_time) VALUES(?,?,?,?,?,?,NOW())";
        int id = jdbcTemplate.insert(sql, new JDBCCallBack<Question>() {

            @Override
            public void setParams(PreparedStatement ps) throws SQLException {
                ps.setString(1, question.getTitle());
                ps.setString(2, question.getOptionA());
                ps.setString(3, question.getOptionB());
                ps.setString(4, question.getOptionC());
                ps.setString(5, question.getOptionD());
                ps.setInt(6, question.getAnswer());
            }

            @Override
            public Question rsToObject(ResultSet rs) throws SQLException {
                return null;
            }
        });
        question.setId(id);
        question.setQuestionId(insertQuestionIdById(id));
        return question.getId();
    }

    public int getCountQuestion(final String keywords){
        String sql = "";
        if (keywords == null ) {
            sql = "SELECT count(*) totalCount FROM question WHERE is_alive=0";
            return jdbcTemplate.getCount(sql);
        } else {
            sql = "SELECT count(*) totalCount FROM question WHERE is_alive=0  and title like '%"+keywords+"%'";
            return jdbcTemplate.getCount(sql, new JDBCAbstractCallBack<Question>() {
                @Override
                public void setParams(PreparedStatement ps)
                        throws SQLException {
                }
            });
        }
    }

    public List<Question> findAllQuestion(final Pagination pagination){
        String sql = "";
        if (pagination.getSearch().equals("") || pagination.getSearch() == null) {
            pagination.setTotalCount(this.getCountQuestion(null));
            if (pagination.getCurrentPage() > pagination.getPageCount()) {
                pagination.setCurrentPage(pagination.getPageCount());
            }
            sql = "SELECT * FROM question WHERE is_alive=0  LIMIT  ?,?";
            return jdbcTemplate.query(sql, new JDBCCallBack<Question>() {
                @Override
                public void setParams(PreparedStatement ps)
                        throws SQLException {
                    ps.setInt(1, pagination.getOffset());
                    ps.setInt(2, pagination.getPageSize());
                }

                @Override
                public Question rsToObject(ResultSet rs) throws SQLException {
                    return rsToQuestion(rs);
                }
            });
        } else {
            pagination.setTotalCount(this.getCountQuestion(pagination.getSearch()));
            if(pagination.getCurrentPage() > pagination.getPageCount()) {
                pagination.setCurrentPage(pagination.getPageCount());
            }
            sql = "SELECT * FROM question WHERE is_alive = 0 AND title like ? LIMIT ?,?";
            return jdbcTemplate.query(sql, new JDBCCallBack<Question>() {
                @Override
                public void setParams(PreparedStatement ps)
                        throws SQLException {
                    ps.setString(1, "%" + pagination.getSearch() + "%");
                    ps.setInt(2, pagination.getOffset());
                    ps.setInt(3, pagination.getPageSize());
                }
                @Override
                public Question rsToObject(ResultSet rs) throws SQLException {
                    return rsToQuestion(rs);
                }
            });
        }
    }

    public Question queryQuestionById (final int id) {
        String sql = "SELECT * FROM question WHERE id = ?";
        return jdbcTemplate.queryOne(sql, new JDBCCallBack<Question>() {

            @Override
            public void setParams(PreparedStatement ps) throws SQLException {
                ps.setInt(1, id);
            }

            @Override
            public Question rsToObject(ResultSet rs) throws SQLException {
                return rsToQuestion(rs);
            }
        });
    }

    public int deleteQuestionByIds (int[] ids) {
        StringBuffer sb = new StringBuffer();
        for (int i = 0; i < ids.length; i++) {
            sb.append(ids[i]+",");
        }

        final String deleteQuestionId = sb.toString().substring(0,sb.length()-1);
        String sql = "UPDATE question SET  is_alive=-1,update_time=NOW() WHERE id in (" + deleteQuestionId + ")";
        jdbcTemplate.update(sql, new JDBCAbstractCallBack<Question>() {
           @Override
            public void setParams(PreparedStatement ps) throws SQLException {
            }
        });
        return ids.length;
    }

    public List<Question> sortQuestion(final Pagination pagination){
        String sql = "";
        if (pagination.getSearch().equals("") || pagination.getSearch() == null) {
            pagination.setTotalCount(this.getCountQuestion(null));
            if (pagination.getCurrentPage() > pagination.getPageCount()) {
                pagination.setCurrentPage(pagination.getPageCount());
            }
            sql = "SELECT * FROM question WHERE is_alive=0 ORDER BY id " + pagination.getSort() +" LIMIT ?,?";
            return jdbcTemplate.query(sql, new JDBCCallBack<Question>() {
                @Override
                public void setParams(PreparedStatement ps)
                        throws SQLException {
                    ps.setInt(1, pagination.getOffset());
                    ps.setInt(2, pagination.getPageSize());
                }
                @Override
                public Question rsToObject(ResultSet rs) throws SQLException {
                    return rsToQuestion(rs);
                }
            });
        } else {
            pagination.setTotalCount(this.getCountQuestion(pagination.getSearch()));
            if(pagination.getCurrentPage() > pagination.getPageCount()) {
                pagination.setCurrentPage(pagination.getPageCount());
            }
            sql = "SELECT * FROM question WHERE is_alive=0 AND title LIKE '%"+pagination.getSearch()+"%' ORDER BY id " + pagination.getSort() + " LIMIT ?,?";
            return jdbcTemplate.query(sql, new JDBCCallBack<Question>() {
                @Override
                public void setParams(PreparedStatement ps)
                        throws SQLException {
                    ps.setInt(1, pagination.getOffset());
                    ps.setInt(2, pagination.getPageSize());
                }
                @Override
                public Question rsToObject(ResultSet rs) throws SQLException {
                    return rsToQuestion(rs);
                }
            });
        }
    }

    public int deleteQuestionById (final int id){
        String sql = "update question SET is_alive = -1,update_time=NOW()  where id = ?";
        return jdbcTemplate.update(sql, new JDBCAbstractCallBack<Question>() {
            @Override
            public void setParams(PreparedStatement ps) throws SQLException {
                ps.setInt(1, id);
            }
        });
    }

    private String insertQuestionIdById(final int id) {
        final String questionId = String.format("Q%06d", id);
        String sql = "UPDATE question SET question_id = ? where id = ?";
        jdbcTemplate.update(sql, new JDBCAbstractCallBack<Question>() {
            @Override
            public void setParams(PreparedStatement ps) throws SQLException {
                ps.setString(1, questionId);
                ps.setInt(2, id);
            }
        });
        return questionId;
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
