using Exiled.API.Features;
using MEC;
using System.Collections.Generic;

namespace KillFeed.Features
{
    public class SenderFeed
    {
        private readonly Queue<string> killHint = new Queue<string>();

        private bool IsShowing = false;

        public void AddHint(string hint)
        {
            killHint.Enqueue(hint);

            if (IsShowing) return;

            ShowHint();
        }

        private void ShowHint()
        {
            if (killHint.TryDequeue(out var message))
            {
                Map.ShowHint($"<size=20><color=#AABBCC>{message}</color></size>");

                IsShowing = true;

                Timing.CallDelayed(3f, () =>
                {
                    IsShowing = false;
                    ShowHint();
                });
            }
        }
    }
}