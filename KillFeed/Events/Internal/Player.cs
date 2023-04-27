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
            if (args.Attacker is null)
            {
                if (args.Player.CurrentRoom.TeslaGate is null) return;

                var target = PlayerAPI.List.Where(player => player.Role.Type == RoleTypeId.Scp079);

                if(target is null) return;

                Plugin.SenderFeed.AddHint($"Игрок {args.Player.GetInfo()} был убит Игроком {target.FirstOrDefault().GetInfo()}");
            }

            Plugin.SenderFeed.AddHint($"Игрок {args.Player.GetInfo()} Был убит Игроком {args.Attacker.GetInfo()}");
        }
    }
}
