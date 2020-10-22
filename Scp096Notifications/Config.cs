using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scp096Notifications
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Determines whether or not people who view SCP-096's face will be notified.")]
        public bool Enable096SeenMessage { get; set; } = true;
        [Description("Determines whether or not SCP-096 will be notified everytime somebody views his face.")]
        public bool Enable096NewTargetMessage { get; set; } = true;
        [Description("The message to show users who become a target of SCP-096.")]
        public string Scp096SeenMessage { get; set; } = "You are a target of SCP-096!";
        [Description("The message to show SCP-096 when he gains a new target.")]
        public string Scp096NewTargetMessage { get; set; } = "<b>{name}</b> has viewed your face! They are a <b>{class}</b>.";
    }
}
