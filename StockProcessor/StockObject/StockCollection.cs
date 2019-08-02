using System;
using System.Collections.Generic;

namespace StockProcessor.StockObject
{
    public class StockCollection : IStock
    {
        private static List<StockCollection> DailySnPCollection = null;

        public StockCollection()
        {
        }

        public List<StockCollection> CollectionOfStock
        {
            get
            {
                if (DailySnPCollection == null)
                {
                    return CreateCollection();
                }

                return DailySnPCollection;
            }
            set
            {
                DailySnPCollection = value;
            }
        }


        public void AddtoExistingList()
        {
            throw new NotImplementedException();
        }

        public void DeleteMarketList()
        {
            throw new NotImplementedException();
        }

        public void RemoveFromExistingList()
        {
            throw new NotImplementedException();
        }

        public void SaveNewMarketList()
        {
            throw new NotImplementedException();
        }

        private List<StockCollection> CreateCollection()
        {
            throw new NotImplementedException();
        }
    }
}
