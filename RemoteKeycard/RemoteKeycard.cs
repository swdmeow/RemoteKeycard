﻿using System;
using Exiled.API.Features;
using Players = Exiled.Events.Handlers.Player;

namespace RemoteKeycard
{
    /// <summary>
    /// The plugin's core class.
    /// </summary>
    public class RemoteKeycard : Plugin<Config>
    {

        /// <summary>
        /// Gets a static instance of this class.
        /// </summary>
        public static RemoteKeycard Instance { get; private set; }

        /// <inheritdoc/>
        public override string Name => "RemoteKeycard";

        /// <inheritdoc/>
        public override string Prefix => "remotekeycard";

        /// <inheritdoc/>
        public override Version RequiredExiledVersion => new Version(6, 0, 0, 18);

        /// <inheritdoc/>
        public override string Author => "Beryl (Maintained by Parkeymon)";

        /// <inheritdoc/>
        public override Version Version => new Version(3, 1, 5);

        /// <inheritdoc cref="EventsHandler"/>
        private EventsHandler Handler { get; set; }

        /// <summary>
        /// Instance initializer.
        /// </summary>
        public RemoteKeycard() => Instance = this;
        
        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Log.Debug("Initializing events...");
            Handler = new EventsHandler(Config);
            Handler.Start();
            Log.Debug("Events initialized successfully.");

            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            Log.Debug("Stopping events...");
            Handler.Stop();
            Handler = null;
            Log.Debug("Events stopped successfully.");

            base.OnDisabled();
        }
    }
}
