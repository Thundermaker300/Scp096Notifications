using Exiled.API.Features;
using Exiled.Events.EventArgs;

using System.Collections.Generic;

namespace Scp096Notifications
{
    public class EventHandlers
    {
        
        private Plugin plugin;
        public EventHandlers(Plugin plugin) { this.plugin = plugin; }
        public void Scp096AddingTarget(AddingTargetEventArgs ev)
        {
            if (ev.Target.Role.Team == Team.SCP || !ev.IsAllowed) return;
            
            if (plugin.Config.Enable096SeenMessage)
            {
                ShowMessage(ev.Target, plugin.Config.Scp096SeenMessage, plugin.Config.NotifDuration);
            }
            if (plugin.Config.Enable096NewTargetMessage)
            {
                string message = plugin.Config.Scp096NewTargetMessage.Replace("{name}", ev.Target.Nickname).Replace("{class}", $"<color={ev.Target.Role.Color.ToHex()}>{plugin.Config.RoleStrings?[ev.Target.Role] ?? "UNKNOWN"}</color>");
                ShowMessage(ev.Scp096, message, plugin.Config.NotifDuration);
            }
        }

        public void ShowMessage(Player Ply, string Message, ushort Duration = 3)
        {
            if (plugin.Config.UseHints)
                Ply.ShowHint(Message, Duration);
            else
                Ply.Broadcast(Duration, Message, shouldClearPrevious: true);
        }
    }
}
