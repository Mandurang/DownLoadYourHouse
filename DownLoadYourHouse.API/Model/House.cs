using System.ComponentModel.DataAnnotations;

namespace DownLoadYourHouse.API.Model
{
    public class House
    {
        [Key]
        public int Id { get; set; }
        public string Reference { get; set; }
        public decimal GPSLatitude { get; set; }
        public decimal GPSLongitude { get; set;}
        public string Country { get; set; }
        public string State { get; set; }
        public string Town { get; set; }
        public string Neighborhood { get; set; }
        public string Zone { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public decimal Price { get; set; }
        public BusinessType BusinessType { get; set; }
        public Availability Availability { get; set; }
        public Status Status { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public int IdOwner { get; set; }
        public string Owner { get; set; }
        public int IdAgent { get; set; }
        public string Agent { get; set; }
    }

    public enum BusinessType
    {

    }

    public enum Availability
    {
        
    }

    public enum Status
    {

    }
}
