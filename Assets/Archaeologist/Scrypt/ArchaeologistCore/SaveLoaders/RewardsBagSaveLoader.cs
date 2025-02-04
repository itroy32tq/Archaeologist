using SaveModule;

namespace ArchaeologistCore
{
    public sealed class RewardsBagSaveLoader : SaveLoader<IRewardsBagPresenter, RewardsBagData>
    {
        public RewardsBagSaveLoader(IRewardsBagPresenter bag, IGameRepository gameRepository) : base(bag, gameRepository)
        {
        }

        protected override RewardsBagData ConvertToData(IRewardsBagPresenter bag)
        {
            return new RewardsBagData() 
            { 
                CurrentCount = bag.CurrentCount.Value,
            };
        }

        protected override void SetupData(IRewardsBagPresenter bag, RewardsBagData data)
        {
            bag.LoadData(data);
        }
    }
}
