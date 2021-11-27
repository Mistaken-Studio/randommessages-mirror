// -----------------------------------------------------------------------
// <copyright file="Translation.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Mistaken.RandomMessages
{
    /// <inheritdoc/>
    public class Translation : ITranslation
    {
        /// <summary>
        /// Gets or sets a list of messages that will be displayed during the game.
        /// </summary>
        [Description("List of messages that will be displayed during the game")]
        public List<string> Messages { get; set; } = new List<string>()
        {
            "Default Message 1",
            "Default Message 2",
            "Default Message 3",
        };
    }
}
