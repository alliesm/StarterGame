using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    public class QuitCommand : Command
    {

        public QuitCommand() : base()
        {
            this.Name = "quit";
        }

        override
        public bool Execute(Player player)
        {
            bool answer = true;
            if (QWords.Count > 0)
            {
                player.OutputMessage("\nI cannot quit " + QWords);
                answer = false;
            }
            return answer;
        }
    }
}
