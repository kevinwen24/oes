using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESModel
{
    public class Question
    {
        public int Id { set; get; }

        public string QuestionId { set; get; }

        public string Title { set; get; }

        public string OptionA { set; get; }

        public string OptionB { set; get; }

        public string OptionC { set; get; }

        public string OptionD { set; get; }

        public int Answer { set; get; }

        public string CreateTime { set; get; }

        public string UpdateTime { set; get; }

        public int IsActive { set; get; }

    }
}
