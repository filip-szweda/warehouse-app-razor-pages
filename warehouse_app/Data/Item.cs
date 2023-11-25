namespace warehouse_app.Data
{
    public class Item
    {
        public int Id { get; set; }
        public Collection Collection { get; set; }
        public int CollectionId { get; set; }
    }
}
