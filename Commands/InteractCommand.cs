using System;
using System.Collections.Generic;
using System.Text;

namespace StarterGame
{
    class InteractCommand : Command
    {

        public InteractCommand()
        {
            this.Name = "interact";
        }

        public override bool Execute(Player player)
        {
            string notify = "Talk_";
            string name = "";
            if (this.QWords.Count == 0)
            {
                player.OutputMessage("\nTalk to who?");
                return false;
            }
            else
            {
                while (this.QWords.Count != 0)
                {
                    name += this.QWords.Dequeue() + " ";
                }

                name = name.TrimEnd();
                notify += name;
                ILivingCreature npc = player.CurrentRoom.GetNpc(name);
                if (npc != null)
                {
                    NotificationCenter.Instance.PostNotification(new Notification(notify, player));
                    player.OutputMessage("\nType 'leave' to end the interaction");
                }
                else
                {
                    player.OutputMessage("\nThat person is not in this room?\n");
                    player.OutputMessage(player.CurrentRoom.Description());
                }
            }
            return false;
        }
    }
}
