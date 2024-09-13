namespace AgricultureProject.Models
{
    public class ContactModel
    {
        //Mesaj raporlarını dinamik olarak almak için bu classı ekledik.
        public int ContactID { get; set; }
        public string? ContactName { get; set; }
        public string? ContactMail { get; set; }
        public string? ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }

    }
}
