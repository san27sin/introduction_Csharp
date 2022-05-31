using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5
{
    class ToDo
    {
        bool isDone;
        string title;

        public bool IsDone
        {
            get => isDone;
            set
            {
                isDone = value;
            }
        }

        public string Title
        {
            get => title;
            set { title = value; }
        }
    }
}
