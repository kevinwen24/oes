package com.kevin.oes.util;

import java.util.List;

public class Page<T> {
    private int pageSize;
    private int currentPage;
    private int totalRecord;
    private int totalPage;
    private List<T> dataList;

    public Page(int pageSize, int currentPage, int totalRecord, int totalPage,
            List<T> dataList) {
        super();
        this.pageSize = pageSize;
        this.currentPage = currentPage;
        this.totalRecord = totalRecord;
        this.totalPage = totalPage;
        this.dataList = dataList;
    }

    public int getPageSize() {
        return pageSize;
    }

    public void setPageSize(int pageSize) {
        this.pageSize = pageSize;
    }

    public int getCurrentPage() {
        return currentPage;
    }

    public void setCurrentPage(int currentPage) {
        this.currentPage = currentPage;
    }

    public int getTotalRecord() {
        return totalRecord;
    }

    public void setTotalRecord(int totalRecord) {
        this.totalRecord = totalRecord;
    }

    public int getTotalPage() {
        return totalPage;
    }

    public void setTotalPage(int totalPage) {
        this.totalPage = totalPage;
    }

    public List<T> getDataList() {
        return dataList;
    }

    public void setDataList(List<T> dataList) {
        this.dataList = dataList;
    }

    @Override
    public String toString() {
        return "Page [pageSize=" + pageSize + ", currentPage=" + currentPage
                + ", totalRecord=" + totalRecord + ", totalPage=" + totalPage
                + ", dataList=" + dataList + "]";
    }


}
