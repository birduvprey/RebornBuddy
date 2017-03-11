namespace ExBuddy.OrderBotTags.Gather.Rotations
{
    using ExBuddy.Attributes;
    using ExBuddy.Interfaces;
    using System.Threading.Tasks;

    [GatheringRotation("Collect495", 28, 600)]
    public sealed class Collect495GatheringRotation : CollectableGatheringRotation, IGetOverridePriority
    {
        #region IGetOverridePriority Members

        int IGetOverridePriority.GetOverridePriority(ExGatherTag tag)
        {
            // if we have a collectable && the collectable value is greater than or equal to 495: Priority 495
            if (tag.CollectableItem != null && tag.CollectableItem.Value >= 495)
            {
                return 495;
            }

            return -1;
        }

        #endregion IGetOverridePriority Members

        public override async Task<bool> ExecuteRotation(ExGatherTag tag)
        {
            await DiscerningMethodical(tag);
            await Discerning(tag);
            await AppraiseAndRebuff(tag);
            await Methodical(tag);

            await IncreaseChance(tag);

            return true;
        }
    }
}