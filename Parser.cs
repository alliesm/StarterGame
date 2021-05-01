using System.Collections;
using System.Collections.Generic;
using System;

namespace StarterGame
{
    public class Parser
    {
        private CommandWords _commands;

        public Parser() : this(new CommandWords())
        {

        }

        public Parser(CommandWords newCommands)
        {
            _commands = newCommands;
        }

        public Command ParseCommand(string commandString)
        {
            Command command = null;
            Queue<string> words = new Queue<string>(commandString.Split(" "));
            if (words.Count > 0)
            {
                string nameOfCommand = "";
                command = returnCommand(words);
                if (command != null)
                {
                    if (command != null)
                    {
                        command.QWords = new Queue<string>(words);
                    }
                }
                else
                {
                    Console.WriteLine(">>>Did not find the command " + nameOfCommand);
                }
            }
            else
            {
                Console.WriteLine("No words parsed!");
            }
            return command;
        }

        public Command returnCommand(Queue<string> words)
        {
            Command command = null;
            string commandName = "";
            Queue<string> newWords = words;
            while (newWords.Count > 0 && command == null)
            {
                commandName += newWords.Dequeue().Trim();
                command = _commands.Get(commandName);
                if (command == null)
                {
                    commandName += " ";
                }
            }
            return command;
        }

        public string Description()
        {
            return _commands.Description();
        }
    }
}
