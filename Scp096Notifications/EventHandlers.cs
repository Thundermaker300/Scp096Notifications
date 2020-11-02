using Exiled.API.Features;
using Exiled.Events.EventArgs;

using System.Collections.Generic;

namespace Scp096Notifications
{
    class EventHandlers
    {
        public void Scp096AddingTarget(AddingTargetEventArgs ev)
        {
            if (ev.Target.Team == Team.SCP) return;
            Config Settings = Scp096Notifications.Singleton.Config;
            if (Settings.Enable096SeenMessage)
            {
                ShowMessage(ev.Target, Settings.Scp096SeenMessage, 5f);
            }
            if (Settings.Enable096NewTargetMessage)
            {
                string message = Settings.Scp096NewTargetMessage.Replace("{name}", ev.Target.Nickname).Replace("{class}", $"<color={ev.Target.RoleColor.ToHex()}>{Scp096Notifications.Singleton.Config.RoleStrings[ev.Target.Role]}</color>");
                ShowMessage(ev.Scp096, message, 5f);
            }
        }

        public void ShowMessage(Player Ply, string Message, float Duration = 3)
        {
            Ply.ShowHint(Message, Duration);
        }
    }
}
