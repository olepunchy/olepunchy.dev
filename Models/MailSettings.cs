namespace olepunchy.Models {
    public class MailSettings {
        public string ToAddress { get; set; } = "olepunchy@gmail.com";
        public string FromAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string MailServer { get; } = "smtp.gmail.com";
        public int MailPort { get; } = 587;
        public string MailPassword { get; } = "naiybfivefnkymyi";

    }
}