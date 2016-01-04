 
namespace TaskRelease.Model
{
    public class Question
    { 
        public string Id { get; set; }
        public string Content { get; set; }
        public string Asker { get; set; }
        public int AuditState { get; set; }
        public string CreateDate { get; set; }
    }
}
