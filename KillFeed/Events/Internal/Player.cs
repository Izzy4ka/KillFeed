using Exiled.Events.EventArgs.Player;
using KillFeed.Extensions;

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
