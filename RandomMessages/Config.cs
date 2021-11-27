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

        /// <summary>
        /// Gets or sets the minimal value to broadcast a message.
        /// </summary>
        [Description("Minimum time to broadcast a random message")]
        public int MinSec { get; set; } = 10;

        /// <summary>
        /// Gets or sets the maximal value to broadcast a message.
        /// </summary>
        [Description("Maximum time to broadcast a random message")]
        public int MaxSec { get; set; } = 20;

        /// <summary>
        /// Gets or sets a value of how long the message should be displayed on the screen.
        /// </summary>
        [Description("How long should the message be on the screen")]
        public int BroadcastTime { get; set; } = 5;
    }
}
