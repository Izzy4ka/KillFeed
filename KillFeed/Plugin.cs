using Exiled.API.Features;
using KillFeed.Features;
using System;
using PlayerApi = Exiled.Events.Handlers.Player;
using MapAPI = Exiled.Events.Handlers.Map;
using WarheadAPI = Exiled.Events.Handlers.Warhead;

namespace KillFeed
{
    public class Plugin : Plugin<Config>
    {
        private static readonly Lazy<SenderFeed> LazeSender = new Lazy<SenderFeed>(() => new SenderFeed()); 

        public static SenderFeed SenderFeed => LazeSender.Value;

        private Events.Internal.Player player;

        private Events.Internal.Server server;

        public override void OnEnabled()
        {
            InitData();
            RegisterEvents();
            base.OnEnabled();
        }

        private void RegisterEvents()
        {
            MapAPI.Decontaminating += server.OnDecontaminatingZone;
            MapAPI.GeneratorActivated += server.OnGeneratorActivated;

            WarheadAPI.Starting += server.OnWarheadStarting;
            WarheadAPI.Stopping += server.OnWarheadStopping;
            WarheadAPI.ChangingLeverStatus += server.OnWarheadAction;
            WarheadAPI.Detonating += server.OnWarheadDetonating;

            PlayerApi.Dying += player.OnPlayerDying;
        }

        private void UnRegisterEvents()
        {
            MapAPI.Decontaminating -= server.OnDecontaminatingZone;

            WarheadAPI.Starting -= server.OnWarheadStarting;
            WarheadAPI.Stopping -= server.OnWarheadStopping;
            WarheadAPI.ChangingLeverStatus -= server.OnWarheadAction;
            WarheadAPI.Detonating -= server.OnWarheadDetonating;

            PlayerApi.Dying -= player.OnPlayerDying;
        }

        private void InitData()
        {
            player = new Events.Internal.Player();
            server = new Events.Internal.Server();
        }

        public override void OnDisabled()
        {
            DeleteData();
            UnRegisterEvents();
            base.OnDisabled();
        }

        private void DeleteData()
        {
            player = null;
            server = null;
        }
    }
}