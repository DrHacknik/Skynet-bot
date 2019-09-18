using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace Skynet {
    public class About : ModuleBase<SocketCommandContext> {
        private string cd = System.IO.Directory.GetCurrentDirectory ();

        private string time = DateTime.Now.ToString ();

        [Command ("About")]
        public async Task SendAbout () {
            EmbedBuilder Embed = new EmbedBuilder ();
            Embed.WithTitle ("About Skynet [Beta]:");
            Embed.WithColor (new Color (236, 183, 4));
            Embed.WithImageUrl ("https://github.com/DrHacknik/Skynet/blob/master/Splash_256.png?raw=true");
            Embed.WithDescription (
                "**" + Config.BotName + "** for Discord" + Environment.NewLine +
                "**by Dr.Hacknik**" + Environment.NewLine +
                "**Version:** " + Config.Version + Environment.NewLine +
                "**Bot name:** " + Config.BotName + Environment.NewLine +
                "**Bot revision:** " + Config.BuildDate + Environment.NewLine +
                "**Bot Type:** DotNet Core | Web-socket-based" + Environment.NewLine +
                "**Bot Platform:** " + Config.OS + Environment.NewLine +
                "Dedicated Website: https://dochacknik.keybase.pub/index/Skynet");
            Embed.WithTimestamp (DateTime.UtcNow);
            await Context.Channel.SendMessageAsync (String.Empty, false, Embed.Build ());

            await Context.Message.DeleteAsync ();

            await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Bot", ""));
        }
    }
}