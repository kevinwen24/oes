using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESDal;
using OESModel;

namespace OESLogic
{
    public class ExamManager
    {
        public List<Exam> FindAllExam(string sortName, string sortDirection, int userId)
        {
            ExamDal examDAl = new ExamDal();
            return examDAl.FindAllExam(sortName, sortDirection, userId);
        }
    }
}
