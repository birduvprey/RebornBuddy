namespace ExBuddy.OrderBotTags.Gather.GatherSpots
{
    using Clio.XmlEngine;
    using ExBuddy.Interfaces;
    using System.Collections;
    using System.Collections.Generic;

    [XmlElement("GatherSpots")]
    public class GatherSpotCollection : IList<IGatherSpot>
    {
        public GatherSpotCollection()
        {
            Locations = new List<IGatherSpot>();
        }

        [XmlElement(XmlEngine.GENERIC_BODY)]
        private List<IGatherSpot> Locations { get; set; }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion IEnumerable Members

        #region IEnumerable<IGatherSpot> Members

        public IEnumerator<IGatherSpot> GetEnumerator()
        {
            return Locations.GetEnumerator();
        }

        #endregion IEnumerable<IGatherSpot> Members

        #region ICollection<IGatherSpot> Members

        public int Count
        {
            get { return Locations.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(IGatherSpot item)
        {
            Locations.Add(item);
        }

        public void Clear()
        {
            Locations.Clear();
        }

        public bool Contains(IGatherSpot item)
        {
            return Locations.Contains(item);
        }

        public void CopyTo(IGatherSpot[] array, int arrayIndex)
        {
            Locations.CopyTo(array, arrayIndex);
        }

        public bool Remove(IGatherSpot item)
        {
            return Locations.Remove(item);
        }

        #endregion ICollection<IGatherSpot> Members

        #region IList<IGatherSpot> Members

        public int IndexOf(IGatherSpot item)
        {
            return Locations.IndexOf(item);
        }

        public void Insert(int index, IGatherSpot item)
        {
            Locations.Insert(index, item);
        }

        public IGatherSpot this[int index]
        {
            get { return Locations[index]; }
            set { Locations[index] = value; }
        }

        public void RemoveAt(int index)
        {
            Locations.RemoveAt(index);
        }

        #endregion IList<IGatherSpot> Members
    }
}