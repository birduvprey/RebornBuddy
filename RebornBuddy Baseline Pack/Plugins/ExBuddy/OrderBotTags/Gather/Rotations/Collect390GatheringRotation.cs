namespace ExBuddy.OrderBotTags.Gather.Rotations
{
	using System.Threading.Tasks;
	using Attributes;
	using Interfaces;
	using ff14bot;

	[GatheringRotation("Collect390", 30, 600)]
	public sealed class Collect390GatheringRotation : CollectableGatheringRotation, IGetOverridePriority
	{
		#region IGetOverridePriority Members
		int IGetOverridePriority.GetOverridePriority(ExGatherTag tag)
		{
			// if we have a collectable && the collectable value is greater than or equal to 402: Priority 402
			if (tag.CollectableItem != null && tag.CollectableItem.Value >= 390)
			{
				return 390;
			}
			return -1;
		}
		#endregion
		public override async Task<bool> ExecuteRotation(ExGatherTag tag)
		{
			await SingleMindMethodical(tag);
			await SingleMindAppraiseAndRebuff(tag);
			await Methodical(tag);
			
			return true;
		}
	}
}