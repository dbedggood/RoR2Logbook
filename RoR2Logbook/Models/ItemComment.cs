namespace RoR2Logbook.Models
{
    public class ItemComment
    {
        public int ID { get; set; }
        public string ItemID { get; set; }
        public string Date { get; set; }
        public string Commenter { get; set; }
        public string Text { get; set; }
    }
}
