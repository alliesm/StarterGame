using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    public class HelpCommand : Command
    {
        CommandWords words;

        public HelpCommand() : this(new CommandWords())
        {
        }

        public HelpCommand(CommandWords commands) : base()
        {
            words = commands;
            this.Name = "help";
        }

        override
        public bool Execute(Player player)
        {
            if (QWords.Count > 0)
            {
                player.OutputMessage("\nI cannot help you with " + QWords);
            }
            else
            {
                player.OutputMessage("\nYou're goal is to defeat the ...beast?... and rescue the princess, stay focused. \n\nYour available commands are " + words.Description());
            }
            return false;
        }
    }
}
