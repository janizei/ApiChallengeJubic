namespace ApiChallenge.Models
{
    public class Licenses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Expiry { get; set; }
        public string Queried { get; set; }
        public string Error { get; set; }

        public Licenses(int Id, string Name, string Expiry, string Queried, string Error)
        {
            this.Id = Id;
            this.Name = Name;
            this.Expiry = Expiry;
            this.Queried = Queried;
            this.Error = Error;
        }
    }
}