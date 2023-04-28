using PlayerAPI = Exiled.API.Features.Player;
using Exiled.Events.EventArgs.Player;
using KillFeed.Extensions;
using System.Linq;
using PlayerRoles;

namespace KillFeed.Events.Internal
{
    public class Player
    {

        public void OnPlayerDying(DyingEventArgs args)
        {
            if (args.Attacker is null) return;

            Plugin.SenderFeed.AddHint($"Игрок {args.Player.GetInfo()} Был убит Игроком {args.Attacker.GetInfo()}");
        }
    }
}
