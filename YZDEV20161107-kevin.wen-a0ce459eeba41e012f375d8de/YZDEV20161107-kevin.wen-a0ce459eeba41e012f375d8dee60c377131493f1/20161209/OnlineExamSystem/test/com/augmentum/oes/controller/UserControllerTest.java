package com.augmentum.oes.controller;


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
import com.augmentum.oes.util.PathUtil;
import com.augmentum.oes.util.SessionUtil;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:applicationContext.xml", "classpath:oes-mvc.xml"})
public class UserControllerTest extends AbstractTransactionalJUnit4SpringContextTests{

    @Before
    public void setUp()  throws Exception {
        AppContext.setContextPath("/springmvc");
        AppContext appContext = AppContext.getAppContext();
        appContext.addObjects(Constants.APP_Context_SESSION, new MockHttpSession());
    }

    @After
    public void tearDown() throws Exception {
        AppContext appContext = AppContext.getAppContext();
        appContext.clear();
    }

    @Test
    public void testSaveLogin() {
        UserController userController = (UserController)this.applicationContext.getBean("userController");
        ModelAndView modelAndView = userController.saveLogin("kevin", "1234", "", "");
        RedirectView redirectView = (RedirectView)modelAndView.getView();
        Assert.assertEquals(PathUtil.getFullPath("question/index"), redirectView.getUrl());
        Assert.assertNotNull(SessionUtil.getSession(Constants.USER));
    }
}
