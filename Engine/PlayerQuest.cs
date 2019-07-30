using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class PlayerQuest
    {
        public IQuest Quest { get; set; }
        public bool IsCompleted { get; set; }

        public PlayerQuest (IQuest quest)
        {
            Quest = quest;
            IsCompleted = false;
        }
    }
}
