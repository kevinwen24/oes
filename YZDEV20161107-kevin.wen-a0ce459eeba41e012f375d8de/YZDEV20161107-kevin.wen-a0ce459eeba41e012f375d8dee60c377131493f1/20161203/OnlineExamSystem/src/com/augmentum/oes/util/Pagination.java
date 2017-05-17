/*
 * Copyright (c) 1994, 2017, Augmentum and/or its affiliates. All rights reserved.
 * AUGMENTUM PROPRIETARY/CONFIDENTIAL. Use is subject to license terms.
 */
package com.augmentum.oes.util;

public class Pagination {

    private static final String KEY_PAGE_SIZE = "pagination.pageSize";

    private int pageSize;
    private int pageCount;
    private int totalCount;
    private int currentPage;

    private int offset;
    private String search;
    private String sort = "DESC";

    public String getSearch() {
        return search;
    }

    public void setSearch(String search) {
        this.search = search;
    }


    public String getSort() {
        return sort;
    }

    public void setSort(String sort) {
        this.sort = sort;
    }

    public int getPageSize() {
        if(pageSize == 0){
            String size = PropertyUtil.getProperties(KEY_PAGE_SIZE);
            pageSize = Integer.parseInt(size);
        }
        return pageSize;
    }

    public void setPageSize(int pageSize) {
        this.pageSize = pageSize;
    }

    public int getPageCount() {
        if(totalCount <1) {
            pageCount = 0;
            return pageCount;
        }

        pageCount = (totalCount-1)/getPageSize()+1;
        return pageCount;
    }

    public void setPageCount(int pageCount) {
        this.pageCount = pageCount;
    }

    public int getTotalCount() {
        return totalCount;
    }

    public void setTotalCount(int totalCount) {
        this.totalCount = totalCount;
    }

    public int getCurrentPage() {
        if(currentPage <1) {
            currentPage = 1;
        }
        return currentPage;
    }

    public void setCurrentPage(int currentPage) {
        this.currentPage = currentPage;
    }

    public int getOffset() {
        offset = (getCurrentPage() -1 )* getPageSize();
        return offset;
    }

    public boolean isFirstPage() {
        if(this.getCurrentPage()<=1){
            return true;
        }
        return false;
    }

    public boolean isLastPage() {
        if(this.getCurrentPage()>=this.getPageCount()){
            return true;
        }
        return false;
    }
}
