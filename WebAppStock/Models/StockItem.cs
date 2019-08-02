using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebAppStock
{
    public class StockItem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string TodaysDate { get; set; }

        public float OpeningValue { get; set; }

        public float HighValue { get; set; }

        public float LowValue { get; set; }

        public float CloseValue { get; set; }

        public float AdjClose { get; set; }

        public float Volume { get; set; }

    }
}
