namespace ArchaeologistCore
{
    public sealed class Player
    {
        public int ShovelCount { get; private set; }

        public Player(int count)
        {
            ShovelCount = count;
        }

        public void Excavate()
        { 
            ShovelCount--;
        }

    }
}
