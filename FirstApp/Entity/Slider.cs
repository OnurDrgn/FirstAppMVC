using System.ComponentModel.DataAnnotations;

namespace FirstApp.Entity
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
    }
}
