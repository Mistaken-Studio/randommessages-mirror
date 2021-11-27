// -----------------------------------------------------------------------
// <copyright file="RandomMessagesHandler.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using Exiled.API.Features;
using MEC;
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

        private readonly List<string> messages = PluginHandler.Instance.Translation.Messages;

        private void Server_RoundStarted()
        {
            this.RunCoroutine(this.SendRandomMessage(PluginHandler.Instance.Config));
        }

        private IEnumerator<float> SendRandomMessage(Config config)
        {
            yield return Timing.WaitForSeconds(UnityEngine.Random.Range(config.MinSec, config.MaxSec));
            while (Round.IsStarted)
            {
                int randomint = UnityEngine.Random.Range(config.MinSec, config.MaxSec);
                string selectedmessage = this.messages[randomint];

                Map.Broadcast(message: selectedmessage, duration: (ushort)PluginHandler.Instance.Config.BroadcastTime);
                this.messages.RemoveAt(randomint);

                yield return Timing.WaitForSeconds(UnityEngine.Random.Range(config.MinSec, config.MaxSec));
            }
        }
    }
}
