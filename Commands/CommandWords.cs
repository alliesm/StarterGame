using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class CommandWords
    {
        Dictionary<string, Command> commands;
        private static Command[] commandArray = { new GoCommand(), new InteractCommand(), new QuitCommand(), new ExploreCommand(), new InspectCommand(),
         new PickupCommand(), new BagCommand(), new DropCommand(), new OpenCommand()};

        //this array uses the stack function for when a player is in a certain scenario
        public static Command[] BagCommands = { new CloseBagCommand()};

        public static Command[] SmithCommands = { new InventoryCommand(), new BuyCommand(), new SellCommand(),
            new BagCommand(), new LeaveCommand() };

        public CommandWords() : this(commandArray)
        {
        }

        public CommandWords(Command[] commandList)
        {
            commands = new Dictionary<string, Command>();
            foreach (Command command in commandList)
            {
                commands[command.Name] = command;
            }
            Command help = new HelpCommand(this);
            commands[help.Name] = help;
        }

        public Command Get(string word)
        {
            Command command = null;
            commands.TryGetValue(word, out command);
            return command;
        }

        public string Description()
        {
            string commandNames = "";
            Dictionary<string, Command>.KeyCollection keys = commands.Keys;
            int count = 0;
            foreach (string commandName in keys)
            {
                count++;
                if (keys.Count == count)
                {
                    commandNames += " " + commandName;
                }
                else
                {
                    commandNames += commandName + ", ";
                }
            }
            return commandNames;

        }
    }
}
