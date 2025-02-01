namespace ArchaeologistCore
{
    public sealed class RewardsBag
    {
        public int CurrentCount { get; private set; } = 0;
        public int NeedCount { get; private set; }
        public RewardsBag(int needCount)
        {
            NeedCount = needCount;
        }
    }
}
