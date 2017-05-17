package com.augmentum.oes.controller;

import javax.servlet.http.HttpSession;

import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.mock.web.MockHttpSession;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.AbstractTransactionalJUnit4SpringContextTests;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import com.augmentum.oes.AppContext;
import com.augmentum.oes.Constants;
import com.augmentum.oes.model.User;
import com.augmentum.oes.util.PathUtil;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:applicationContext.xml", "classpath:oes-mvc.xml"})
public class QuestionControllerTest extends AbstractTransactionalJUnit4SpringContextTests{


    @Before
    public void setUp()  throws Exception {
        AppContext.setContextPath("/springmvc");
        AppContext appContext = AppContext.getAppContext();
        User user = new User();
        user.setId(1);
        user.setUserName("kevin");
        user.setPassword("1234");
        HttpSession session = new MockHttpSession();
        session.setAttribute(Constants.APP_Context_USER, user);
        appContext.addObjects(Constants.APP_Context_SESSION, session);

        appContext.addObjects(Constants.APP_Context_USER, user);
    }

    @After
    public void tearDown() throws Exception {
        AppContext appContext = AppContext.getAppContext();
        appContext.clear();
    }

    @Test
    public void testSave() {
        QuestionController questionController = (QuestionController)this.applicationContext.getBean("questionController");
        ModelAndView modelAndView = questionController.save("", "Spring HttpInvoke的实现(远程接口调用),以及效率提升!解决Rea",
                                                            "0", "Spring HttpInvoke的实现(远程接口",
                                                            "及效率提升!解决Rea", "实现(远程接口调用),以及效率提升!解决Read ...",
                                                            "Spring HttpInvoke的实现e");
        RedirectView redirectView = (RedirectView)modelAndView.getView();
        Assert.assertEquals(redirectView.getUrl(), PathUtil.getFullPath("question/index"));
    }
}
