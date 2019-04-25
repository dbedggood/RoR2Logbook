namespace RoR2Logbook.Models
{
    public class SurvivorComment
    {
        public int ID { get; set; }
        public string SurvivorID { get; set; }
        public string Date { get; set; }
        public string Commenter { get; set; }
        public string Text { get; set; }
    }
}
