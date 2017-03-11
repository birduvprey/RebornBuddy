namespace ExBuddy.OrderBotTags.Gather.Rotations
{
    using ExBuddy.Attributes;
    using ExBuddy.Interfaces;
    using System.Threading.Tasks;

    [GatheringRotation("Collect570", 31, 600)]
    public sealed class Collect570GatheringRotation : CollectableGatheringRotation, IGetOverridePriority
    {
        #region IGetOverridePriority Members

        int IGetOverridePriority.GetOverridePriority(ExGatherTag tag)
        {
            // if we have a collectable && the collectable value is greater than or equal to 570: Priority 570
            if (tag.CollectableItem != null && tag.CollectableItem.Value >= 570)
            {
                return 570;
            }

            return -1;
        }

        #endregion IGetOverridePriority Members

        public override async Task<bool> ExecuteRotation(ExGatherTag tag)
        {
            await UtmostMethodical(tag);
            await UtmostMethodical(tag);
            await DiscerningMethodical(tag);
            await DiscerningMethodical(tag);

            await IncreaseChance(tag);

            return true;
        }
    }
}