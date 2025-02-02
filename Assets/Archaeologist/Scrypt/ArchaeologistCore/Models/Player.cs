namespace ArchaeologistCore
{
    public sealed class Player
    {
        public int ShovelCount { get; private set; }

        public Player(PlayerConfig config)
        {
            ShovelCount = config.ShovelCount;
        }

        public void Excavate()
        { 
            ShovelCount--;
        }

    }
}
