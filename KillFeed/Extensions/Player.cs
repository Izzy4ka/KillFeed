using PlayerAPI = Exiled.API.Features.Player;

namespace KillFeed.Extensions
{
    public static class Player
    {
        public static string GetInfo(this PlayerAPI player)
        {
            return $"{player.Id} - {player.Nickname}({player.UserId})[{player.RoleManager.CurrentRole.RoleName}]";
        }
    }
}
