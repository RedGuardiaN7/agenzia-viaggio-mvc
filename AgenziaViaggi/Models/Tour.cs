using System.ComponentModel.DataAnnotations.Schema;

namespace AgenziaViaggi.Models
{
    public class Tour
    {

        public int Id { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string Title { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [Column(TypeName = "varchar(350)")]
        public string Image { get; set; }
        [Column(TypeName = "int")]
        public int Price { get; set; }
        [Column(TypeName = "text")]
        public string Destinations { get; set; }
        [Column(TypeName = "smallint")]
        public int Days { get; set; }

        public Tour()
        {

        }
        
        public Tour(int id, string title, string descriprion, string image, int price, string destinations, int days)
        {
            Id = id;
            Title = title;
            Description = descriprion;
            Image = image;
            Price = price;
            Destinations = destinations;
            Days = days;
        }
    }
}
