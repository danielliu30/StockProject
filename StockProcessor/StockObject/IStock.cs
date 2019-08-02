namespace StockProcessor.StockObject
{
    public interface IStock
    {
        void SaveNewMarketList();

        void AddtoExistingList();

        void RemoveFromExistingList();

        void DeleteMarketList();

    }
}
