package com.augmentum.oes.dao.mybatis;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.mybatis.spring.support.SqlSessionDaoSupport;

import com.augmentum.oes.dao.QuestionDao;
import com.augmentum.oes.model.Question;
import com.augmentum.oes.util.Pagination;

public class QuestionDaoImpl extends SqlSessionDaoSupport implements QuestionDao{

    private static final String CLASS_NAME = Question.class.getName();
    private static final String SQL_ID_ADD = ".add";
    private static final String SQL_ID_UPDATE_QUESTIONID = ".updateQuestionId";
    private static final String SQL_ID_FIND_QUESTION_BY_ID = ".findQuestionById";
    private static final String SQL_ID_FIND_ALL_QUESTION = ".findAllQuestion";
    private static final String SQL_ID_DELETE_QUESTION_BY_ID = ".deleteQuestionByIds";
    private static final String SQL_ID_COUNT = ".countQuestion";

    @Override
    public int addQuestion(Question question) {
        return getSqlSession().insert(CLASS_NAME + SQL_ID_ADD, question);
    }

    @Override
    public int getCountQuestion(String keywords) {
        return getSqlSession().selectOne(CLASS_NAME + SQL_ID_COUNT, keywords);
    }

    @Override
    public List<Question> findAllQuestion(Pagination pagination) {
        pagination.setTotalCount(this.getCountQuestion(pagination.getSearch()));
        if (pagination.getCurrentPage() > pagination.getPageCount()) {
            pagination.setCurrentPage(pagination.getPageCount());
        }
        Map<String,Object> params = new HashMap<String,Object>();
        params.put("search", pagination.getSearch());
        params.put("sort", pagination.getSort());
        params.put("offset", pagination.getOffset());
        params.put("pageSize", pagination.getPageSize());
        return getSqlSession().selectList(CLASS_NAME + SQL_ID_FIND_ALL_QUESTION,params);
    }

    @Override
    public int deleteQuestionById(int id) {
        int[] ids = new int[1];
        ids[0] = id;
        return deleteQuestionByIds(ids);
    }

    @Override
    public int deleteQuestionByIds(int[] ids) {
        for (int i = 0; i<ids.length; i++) {
            getSqlSession().delete(CLASS_NAME + SQL_ID_DELETE_QUESTION_BY_ID, ids[i]);
        }
        return ids.length;
    }

    @Override
    public Question queryQuestionById(int id) {
        return getSqlSession().selectOne(CLASS_NAME + SQL_ID_FIND_QUESTION_BY_ID, id);
    }

    @Override
    public String insertQuestionIdById(int id) {
        Map<String,Object> params = new HashMap<String,Object>();
        String questionId = String.format("Q%06d", id);
        params.put("questionId", questionId);
        params.put("id", id);
        getSqlSession().update(CLASS_NAME + SQL_ID_UPDATE_QUESTIONID, params);
        return questionId;
    }

}
