namespace ExBuddy.OrderBotTags.Gather.Rotations
{
    using ExBuddy.Attributes;
    using ExBuddy.Interfaces;
    using System.Threading.Tasks;

    [GatheringRotation("Collect115", 24)]
    public sealed class Collect115GatheringRotation : CollectableGatheringRotation, IGetOverridePriority
    {
        #region IGetOverridePriority Members

        int IGetOverridePriority.GetOverridePriority(ExGatherTag tag)
        {
            // if we have a collectable && the collectable value is greater than or equal to 115: Priority 115
            if (tag.CollectableItem != null && tag.CollectableItem.Value >= 115)
            {
                return 115;
            }

            return -1;
        }

        #endregion IGetOverridePriority Members

        public override async Task<bool> ExecuteRotation(ExGatherTag tag)
        {
            await Methodical(tag);

            await IncreaseChance(tag);

            return true;
        }
    }
}