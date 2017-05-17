using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESModel;

namespace OESUtil
{
    public class PaginationUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public static List<string> GetPagingIndexString(Pagination pagination) 
        {
            List<string> strList = new List<string>();

            if (pagination.PageCount <= 5)
            {   
                for (int i = 1; i <= pagination.PageCount; i++ )
                {
                    strList.Add(i + "");
                }
            } 
            else 
            {
                if (pagination.CurrentPage <= 4 && (pagination.PageCount - pagination.CurrentPage) >= 2)
                {
                    for (int i = 1; i <= pagination.CurrentPage + 2; i++ )
                    {
                        strList.Add(i + "");
                    }

                    if (pagination.PageCount - pagination.CurrentPage > 3)
                    {
                        strList.Add("...");
                    }

                    strList.Add(pagination.PageCount + ""); 
                }
                else if((pagination.PageCount - pagination.CurrentPage) <= 3)
                {
                    strList.Add("1");
                    strList.Add("...");
                    for (int i = pagination.CurrentPage - 2; i <= pagination.PageCount; i++ )
                    {
                        strList.Add(i + "");
                    }
                }
                else if ((pagination.CurrentPage - 2) > 2 && ( (pagination.PageCount - pagination.CurrentPage) > 3) )
                {
                    strList.Add("1");
                    strList.Add("...");
                    for (int i = pagination.CurrentPage - 2; i <= pagination.CurrentPage + 2; i++ )
                    {
                        strList.Add(i + "");
                    }
                    strList.Add("...");
                    strList.Add(pagination.PageCount + "");
                }
            }
            return strList;
        }
    }
}
