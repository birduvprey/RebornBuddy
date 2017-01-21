using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ff14bot;
using ff14bot.Helpers;
using Newtonsoft.Json;

namespace CrystalHunter.Settings
{
    public class CrystalHunterSettings : JsonSettings
    {
        [JsonIgnore]
        private static	CrystalHunterSettings _instance;
		private bool	_verboseLogging;
		private int 	_crystalCount;
		List<string> 	_crystalInventory;
		private bool 	_idyllshireAetheryteUnlocked;
		private bool 	_noduleCheck;

		private bool 	_jobSetChange;
		private int 	_coerthasJobSet;
		private int 	_dravanianForelandsJobSet;
		private int 	_dravanianHinterlandsJobSet;
		private int 	_churningMistsJobSet;
		private int 	_seaOfCloudsJobSet;
		private int 	_azysLlaJobSet;

        public static CrystalHunterSettings instance { get { return _instance ?? (_instance = new CrystalHunterSettings("CrystalHunterSettings")); } }
        
		public CrystalHunterSettings(string filename) : base(Path.Combine(CharacterSettingsDirectory, "CrystalHunter.json"))
		{ 
			_crystalInventory = GetCrystalInventory();
		}

		[Setting]
        [Category("Misc")]
        [DefaultValue(false)]
        [DisplayName("Verbose Logging")]
		[Description("Add debug output to the log.")]
		public bool VerboseLogging
		{
			get
			{
				return _verboseLogging;
			}
			set
			{
				_verboseLogging = value;
				Save();
			}
		}

        [Setting]
        [Category("Crystal")]
        [DefaultValue(3)]
        [DisplayName("Crystal Count")]
		[Description("Number of crystals required before moving zone.")]
        public int CrystalCount
		{
			get
			{
				return _crystalCount;
			}
			set
			{
				_crystalCount = value;
				Save();
			}
		}
		
        [Category("Crystal")]
		[Description("Current Crystal Inventory")]
        [Editor(@"System.Windows.Forms.Design.StringCollectionEditor,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",typeof(System.Drawing.Design.UITypeEditor))]
		public List<String> Crystals
		{ 
			get
			{
				return _crystalInventory;
			}
		}
		
		private List<String> GetCrystalInventory()
		{
			CrystalHunter crystalHunter = new CrystalHunter();
			//return crystalHunter.InventoryScan();
			List<String> inventory = new List<String>();
			return inventory;
		}
		
		[Setting]
        [Category("Misc")]
        [DefaultValue(true)]
        [DisplayName("Idyllshire Aetheryte Unlocked")]
		[Description("Have you unlocked all of the Aetheryte locations in Idyllshire?")]
		public bool IdyllshireAetheryteUnlocked
		{
			get
			{
				return _idyllshireAetheryteUnlocked;
			}
			set
			{
				_idyllshireAetheryteUnlocked = value;
				Save();
			}
		}
		
		[Setting]
        [Category("Crystal")]
        [DefaultValue(true)]
        [DisplayName("Nodule Check")]
		[Description("Will scan inventory for Umbral / Astral nodules and if found ignore the crystals required. \n Umbral nodule = Ice, Earth, Water, Astral = Fire, Wind, Lightning.")]
		public bool NoduleCheck
		{
			get
			{
				return _noduleCheck;
			}
			set
			{
				_noduleCheck = value;
				Save();
			}
		}

		[Setting]
        [Category("Job Set")]
        [DefaultValue(false)]
        [DisplayName("_Enable Job Change")]
		[Description("Allow CrystalHunter to change jobs?\nThis can be an issue if you have multiple combat routines.")]
		public bool JobSetChange
		{
			get
			{
				return _jobSetChange;
			}
			set
			{
				_jobSetChange = value;
				Save();
			}
		}

		[Setting]
        [Category("Job Set")]
        [DefaultValue(0)]
        [DisplayName("Coerthas")]
		[Description("Set the gear list number for the job you would like to use in Coerthas Western Highlands.")]
		public int CoerthasJobSet
		{
			get
			{
				return _coerthasJobSet;
			}
			set
			{
				_coerthasJobSet = value;
				Save();
			}
		}

		[Setting]
        [Category("Job Set")]
        [DefaultValue(0)]
        [DisplayName("Dravanian Forelands")]
		[Description("Set the gear list number for the job you would like to use in Dravanian Forelands.")]
		public int DravanianForelandsJobSet
		{
			get
			{
				return _dravanianForelandsJobSet;
			}
			set
			{
				_dravanianForelandsJobSet = value;
				Save();
			}
		}

		[Setting]
        [Category("Job Set")]
        [DefaultValue(0)]
        [DisplayName("Dravanian Hinterlands")]
		[Description("Set the gear list number for the job you would like to use in Dravanian Hinterlands.")]
		public int DravanianHinterlandsJobSet
		{
			get
			{
				return _dravanianHinterlandsJobSet;
			}
			set
			{
				_dravanianHinterlandsJobSet = value;
				Save();
			}
		}

		[Setting]
        [Category("Job Set")]
        [DefaultValue(0)]
        [DisplayName("Churning Mists")]
		[Description("Set the gear list number for the job you would like to use in Churning Mists.")]
		public int ChurningMistsJobSet
		{
			get
			{
				return _churningMistsJobSet;
			}
			set
			{
				_churningMistsJobSet = value;
				Save();
			}
		}

		[Setting]
        [Category("Job Set")]
        [DefaultValue(0)]
        [DisplayName("Sea Of Clouds")]
		[Description("Set the gear list number for the job you would like to use in Sea Of Clouds.")]
		public int SeaOfCloudsJobSet
		{
			get
			{
				return _seaOfCloudsJobSet;
			}
			set
			{
				_seaOfCloudsJobSet = value;
				Save();
			}
		}

		[Setting]
        [Category("Job Set")]
        [DefaultValue(0)]
        [DisplayName("Azys Lla")]
		[Description("Set the gear list number for the job you would like to use in Azys Lla.")]
		public int AzysLlaJobSet
		{
			get
			{
				return _azysLlaJobSet;
			}
			set
			{
				_azysLlaJobSet = value;
				Save();
			}
		}
    }
}