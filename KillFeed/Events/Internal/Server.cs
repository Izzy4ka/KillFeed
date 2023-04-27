using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Warhead;
using KillFeed.Extensions;

namespace KillFeed.Events.Internal
{
    public class Server
    {

        public void OnWarheadStarting(StartingEventArgs args)
        {
            Plugin.SenderFeed.AddHint($"Игрок {args.Player.GetInfo()} Запустил БГ");
        }

        public void OnWarheadStopping(StoppingEventArgs args)
        {
            Plugin.SenderFeed.AddHint($"Игрок {args.Player.GetInfo()} Деактивировал БГ");
        }

        public void OnWarheadDetonating(DetonatingEventArgs args)
        {
            Plugin.SenderFeed.AddHint("Боеголовка взорвана");
        }

        public void OnWarheadAction(ChangingLeverStatusEventArgs args)
        {
            Plugin.SenderFeed.AddHint($"Игрок {args.Player.GetInfo()} {(args.CurrentState ? " Отключил" : " Активировал")} БГ");
        }
        
        public void OnDecontaminatingZone(DecontaminatingEventArgs args) {
            Plugin.SenderFeed.AddHint("Деконтаминация ЛКЗ");
        }

        public void OnGeneratorActivated(GeneratorActivatedEventArgs args)
        {
            Plugin.SenderFeed.AddHint($"Генератор {args.Generator.Base.name} был активирован Игроком {args.Generator.LastActivator.GetInfo()}") ;
        }
    }
}
