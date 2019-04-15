namespace CarParkApp
{
    public class Customer
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string LicencePlate { get; set; }

        public Customer(string name, string phonenumber, string licenceplate)
        {
            this.Name = name;
            this.PhoneNumber = phonenumber;
            this.LicencePlate = licenceplate;
        }
    }
}
