using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WProject.Classes
{
    public class DashBoardColumnsCollectionSize
    {
        private int _maxSize;
        public int ToDoWidth { get; set; }
        public int InProgressWitdh { get; set; }
        public int DoneWidth { get; set; }

        public int MaxSize
        {
            get
            {
                return _maxSize;
            }
            set
            {
                _maxSize = value;

                if(_maxSize <= 0)
                    return;

                while (ToDoWidth + InProgressWitdh + DoneWidth > _maxSize)
                {
                    ToDoWidth--;
                    InProgressWitdh--;
                    DoneWidth--;
                }
            }
        }

        [JsonIgnore]
        public int Sum => ToDoWidth + InProgressWitdh + DoneWidth;

        public DashBoardColumnsCollectionSize()
            : this(0, 0, 0, 0)
        {
        }

        public DashBoardColumnsCollectionSize(int toDoWidth, int inProgressWitdh, int doneWidth)
            : this(toDoWidth, inProgressWitdh, doneWidth, 0)
        {

        }

        public DashBoardColumnsCollectionSize(int toDoWidth, int inProgressWitdh, int doneWidth, int maxSize)
        {
            ToDoWidth = toDoWidth;
            InProgressWitdh = inProgressWitdh;
            DoneWidth = doneWidth;
            MaxSize = maxSize;
        }

        public static DashBoardColumnsCollectionSize Create(int toDoWidth,
                                                            int inProgressWitdh,
                                                            int doneWidth,
                                                            int maxSize = 0)
        {
            return new DashBoardColumnsCollectionSize(toDoWidth, inProgressWitdh, doneWidth, maxSize);
        }

        public int ToDoLeft(int relativeTo)
        {
            return relativeTo - ToDoWidth - InProgressWitdh - DoneWidth;
        }

        public int InProgressLeft(int relativeTo)
        {
            return relativeTo - InProgressWitdh - DoneWidth;
        }

        public int DoneLeft(int relativeTo)
        {
            return relativeTo - DoneWidth;
        }
    }
}
