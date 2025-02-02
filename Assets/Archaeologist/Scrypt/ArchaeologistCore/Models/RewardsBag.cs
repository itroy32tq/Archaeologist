namespace ArchaeologistCore
{
    public sealed class RewardsBag
    {
        public int CurrentCount { get; private set; } = 0;
        public int Capacity { get; private set; }

        public RewardsBag(RewardConfig config)
        {
            Capacity = config.RewardsBugCapacity;
        }

        public void IncRewardCount()
        {
            if (CurrentCount < Capacity)
            {
                CurrentCount++;
            }
            
        }
    }
}
