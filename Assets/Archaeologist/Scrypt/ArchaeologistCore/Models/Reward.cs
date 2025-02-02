using System;

namespace ArchaeologistCore
{
    public sealed class Reward
    {
        public bool IsCollected { get; private set; } = false;
        public int X { get; private set; }
        public int Y { get; private set; }

        public Reward(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal void SetCollectedStatus(bool value)
        {
            IsCollected = value;
        }
    }
}
