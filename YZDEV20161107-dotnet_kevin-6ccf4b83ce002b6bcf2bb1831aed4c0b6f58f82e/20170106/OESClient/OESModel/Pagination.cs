using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESModel
{
    public class Pagination
    {
        private int pageSize;
        private int currentPage;
        private int offest;
        private int pageCount;
        private int totalCount;
        private string otherType;

        public string SortName
        {
            set;
            get;
        }

        public string SortDirection
        {
            set;
            get;
        }

        public string OtherType
        {
            set
            {
                otherType = value;
            }
            get
            {
                if (otherType == null)
                {
                    otherType = "";
                }
                return otherType;
            }
        }

        public int PageSize
        {
            set { pageSize = value; }
            get
            {
                if (pageSize == 0)
                {
                    pageSize = 10;
                }
                return pageSize;
            }
        }

        public int CurrentPage
        {
            set { currentPage = value; }
            get
            {
                if (currentPage < 1)
                {
                    currentPage = 1;
                }
                return currentPage;
            }
        }

        public int Offset
        {
            get
            {
                return offest = (currentPage - 1) * pageSize;
            }
        }

        public int TotalCount
        {
            set;
            get;
        }

        public int PageCount
        {
            get
            {
                if (totalCount < 1)
                {
                    return pageCount = 0;
                }
                return pageCount = (totalCount - 1) / pageSize + 1;
            }
        }
    }
}
