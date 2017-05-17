using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OESModel
{
    [DataContract]
    public class Pagination
    {
        private int pageSize;
        private int currentPage;
        private int offset;
        private int totalCount;
        private int pageCount;
        private string otherType;
        private string examName;
        private string startTime;
        private string endTime;
        private string userName;

        [DataMember]
        public string SortName
        {
            set;get;
        }
        [DataMember]
        public string SortDirection
        {
            set; get;
        }

        [DataMember]
        public string OtherType
        {
            set{ otherType = value; }
            get
            {
                if (otherType == null)
                {
                    otherType = "";
                }
                return otherType;
            }
        }
        [DataMember]
        public string ExamName {
            set { examName = value; }
            get
            {
                if (examName == null)
                {
                    examName = "";
                }
                return examName;
            }
        }
        [DataMember]
        public string UserName
        {
            set { userName = value; }
            get
            {
                if (userName == null)
                {
                    userName = "";
                }
                return userName;
            }
        }

        [DataMember]
        public string StartTime
        {
            set { startTime = value; }
            get
            {
                if (startTime == null)
                {
                    startTime = "";
                }
                return startTime;
            }
        }

        [DataMember]
        public string EndTime
        {
            set { endTime = value; }
            get 
            {
                if (endTime == null)
                { 
                    endTime = "";
                }
                return endTime;
            }
        }

        [DataMember]
        public int PageSize
        {
            set { pageSize = value; }
            get {
                if (pageSize == 0)
                {
                    pageSize = 10;
                }
                return pageSize;
            }
        }

        [DataMember]
        public int CurrentPage
        { 
            set { currentPage = value; }
            get {
                if (currentPage < 1 )
                {
                    currentPage = 1;
                }
                return currentPage;
            }
        }

        [DataMember]
        public int Offset
        {
            get
            {
                return offset = (currentPage -1) * pageSize;
            }
            set { offset = value; }
        }

        [DataMember]
        public int TotalCount
        {
            set {
                totalCount = value;
            }
            get {
                return totalCount;
            }
        }

        [DataMember]
        public int PageCount
        {
            get {
                if (totalCount < 1) {
                    return pageCount = 0;
                }
                return (totalCount - 1) / pageSize + 1;
            }
            set { pageCount = value; }
        }

        public bool IsFirstPage()
        { 
            if (currentPage == 1) 
            {
                return true;
            }
            return false;
        }

      
        public bool IsLastPage()
        {
            if (currentPage == pageCount)
            {
                return true;
            }
            return false;
        }
    }
}
