package com.augmentum.common;

import java.util.ArrayList;
import java.util.List;

public class ResultConfig {

    private String name;
    private String view;
    private boolean redirect;
    private List<ViewParameterConfig> viewParameterConfigs = new ArrayList<ViewParameterConfig>();

    public ResultConfig() {
        super();
    }

    public ResultConfig(String name, String view, boolean redirect) {
        super();
        this.name = name;
        this.view = view;
        this.redirect = redirect;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getView() {
        return view;
    }

    public void setView(String view) {
        this.view = view;
    }

    public boolean isRedirect() {
        return redirect;
    }

    public void setRedirect(boolean redirect) {
        this.redirect = redirect;
    }

    public void addViewParameterConfig(ViewParameterConfig viewParameterConfig) {
        viewParameterConfigs.add(viewParameterConfig);
    }

    public List<ViewParameterConfig> getViewParameterConfigs() {
        return viewParameterConfigs;
    }
}
