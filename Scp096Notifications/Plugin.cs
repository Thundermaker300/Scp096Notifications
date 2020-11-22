using Exiled.API.Enums;
using Exiled.API.Features;
using System;

using Events = Exiled.Events.Handlers;

namespace Scp096Notifications
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "Scp096Notifications";

        public override string Author { get; } = "Thundermaker300";

        public override Version Version { get; } = new Version(1, 0, 4);

        public override Version RequiredExiledVersion { get; } = new Version(2, 1, 18);

        public override PluginPriority Priority => PluginPriority.Low;

        public static Plugin Singleton;
        private static EventHandlers Handler;

        public override void OnEnabled()
        {

            if (!Config.IsEnabled) return;
            Singleton = new Plugin();
            Handler = new EventHandlers(this);
            base.OnEnabled();

            // Events
            Events.Scp096.AddingTarget += Handler.Scp096AddingTarget;
        }

        public override void OnDisabled()
        {

            if (!Config.IsEnabled) return;
            Singleton = null;
            Handler = null;
            base.OnDisabled();

            // Events
            Events.Scp096.AddingTarget -= Handler.Scp096AddingTarget;
        }
    }
}
