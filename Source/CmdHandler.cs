﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Skynet {
    public class CommandHandler : ModuleBase<SocketCommandContext> {
        private DiscordSocketClient DiscordClient;
        private CommandService CmdService;

        public CommandHandler (DiscordSocketClient client) {
            DiscordClient = client;
            CmdService = new CommandService (new CommandServiceConfig {
                LogLevel = LogSeverity.Verbose, // Tell the logger to give Verbose debug information
                    DefaultRunMode = RunMode.Async, // Force all commands to run async by default
                    CaseSensitiveCommands = false // Ignore letter case when executing commands
            });

            CmdService.AddModulesAsync (Assembly.GetEntryAssembly ());
            DiscordClient.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync (SocketMessage SocketMsg) {
            SocketUserMessage UserMsg = (SocketUserMessage) SocketMsg;
            int ArgPos = 0;
            SocketCommandContext Context = new SocketCommandContext (DiscordClient, UserMsg);

            if (UserMsg == null) return;

            if (UserMsg.HasCharPrefix ('/', ref ArgPos)) {
                var Result = await CmdService.ExecuteAsync (Context, ArgPos);
                if (!Result.IsSuccess && Result.Error != CommandError.UnknownCommand) {
                    await Context.Message.DeleteAsync ();

                    //await Context.Channel.SendMessageAsync(Result.ErrorReason);

                    string ErrorMessage = "ERROR: The command requested was invalid or syntax was the incorrect";

                    await Helper.LoggingAsync (new LogMessage (LogSeverity.Verbose, "Bot", ErrorMessage));
                    //await this.Context.Channel.SendMessageAsync(ErrorMessage);
                }
            }
        }
    }
}