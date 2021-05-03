using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public abstract class Command
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        private string _secondWord;
        public string secondWord { get { return _secondWord; } set { _secondWord = value; } }
        private string thirdWord;
        public string ThirdWord { get { return thirdWord; } set { thirdWord = value; } }

        //Queues allow for an unlimited amount of words in commands
        private Queue<string> qWords;
        public Queue<string> QWords { get { return qWords; } set { qWords = value; } }

        public Command()
        {
            this.Name = "";
            this.secondWord = null;
            this.thirdWord = null;
            this.qWords = null;
            
        }

        public bool hasSecondWord()
        {
            return this.secondWord != null;
        }

        public bool hasThirdWord()
        {
            return this.thirdWord != null;
        }

        public abstract bool Execute(Player player);
    }
}
