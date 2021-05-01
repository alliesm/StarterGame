using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public abstract class Command
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }

        //Queues allow for an unlimited amount of words in commands
        private Queue<string> qWords;
        public Queue<string> QWords { get { return qWords; } set { qWords = value; } }

        public Command()
        {
            this.Name = "";
            this.qWords = null;
            
        }

        public abstract bool Execute(Player player);
    }
}
