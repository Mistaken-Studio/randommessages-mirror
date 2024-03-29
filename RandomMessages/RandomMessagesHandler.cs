﻿// -----------------------------------------------------------------------
// <copyright file="RandomMessagesHandler.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Exiled.API.Features;
using MEC;
using Mistaken.API;
using Mistaken.API.Diagnostics;

namespace Mistaken.RandomMessages
{
    internal class RandomMessagesHandler : Module
    {
        public RandomMessagesHandler(PluginHandler plugin)
            : base(plugin)
        {
        }

        public override string Name => "RandomMessages";

        public override void OnEnable()
        {
            Exiled.Events.Handlers.Server.RoundStarted += this.Server_RoundStarted;
        }

        public override void OnDisable()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= this.Server_RoundStarted;
        }

        private List<string> messages;

        private void Server_RoundStarted()
        {
            this.messages = PluginHandler.Instance.Translation.Messages;
            this.RunCoroutine(this.SendRandomMessage(PluginHandler.Instance.Config));
        }

        private IEnumerator<float> SendRandomMessage(Config config)
        {
            yield return Timing.WaitForSeconds(1);
            int rid = RoundPlus.RoundId;
            do
            {
                yield return Timing.WaitForSeconds(UnityEngine.Random.Range(config.MinSec, config.MaxSec));
                if (!(Round.IsStarted && RoundPlus.RoundId == rid && this.messages.Count > 0))
                    break;
                int randomint = UnityEngine.Random.Range(0, this.messages.Count);
                string selectedmessage = this.messages[randomint];

                Map.Broadcast(message: selectedmessage, duration: config.BroadcastTime);
                this.Log.Debug($"Broadcasting {selectedmessage} for {config.BroadcastTime} seconds", config.VerbouseOutput);
                this.messages.RemoveAt(randomint);
            }
            while (Round.IsStarted && RoundPlus.RoundId == rid && this.messages.Count > 0);
        }
    }
}
