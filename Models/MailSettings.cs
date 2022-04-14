namespace olepunchy.Models {
    public class MailSettings {
        public string ToAddress { get; set; }
        public string FromAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string MailServer { get; }
        public int MailPort { get; }
        public string MailPassword { get; }

    }
}
