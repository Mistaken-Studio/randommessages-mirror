// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using Mistaken.Updater.Config;

namespace Mistaken.RandomMessages
{
    /// <inheritdoc/>
    public class Config : IAutoUpdatableConfig
    {
        /// <inheritdoc/>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether debug should be displayed.
        /// </summary>
        [Description("If true then debug will be displayed")]
        public bool VerbouseOutput { get; set; }

        /// <inheritdoc/>
        [Description("Auto Update Settings")]
        public Dictionary<string, string> AutoUpdateConfig { get; set; }

        [Description("Minimum time to broadcast a random message")]
        public int MinSec { get; set; } = 10;

        [Description("Maximum time to broadcast a random message")]
        public int MaxSec { get; set; } = 20;

        [Description("How long should the message on the screen")]
        public int BroadcastTime { get; set; } = 5;
    }
}
