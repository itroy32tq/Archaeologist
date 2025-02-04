using SaveModule;

namespace ArchaeologistCore
{
    public sealed class PlayerSaveLoader : SaveLoader<IPlayerPresenter, PlayerData>
    {
        public PlayerSaveLoader(IPlayerPresenter player, IGameRepository gameRepository) : base(player, gameRepository)
        {
        }

        protected override PlayerData ConvertToData(IPlayerPresenter player)
        {
            return new PlayerData() 
            { 
                ShovelCount = player.ShovelCount.Value,
            };
        }

        protected override void SetupData(IPlayerPresenter player, PlayerData data)
        {
            player.LoadData(data);
        }
    }
}
