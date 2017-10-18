using System.ComponentModel.DataAnnotations;

namespace EFCore.Data {
    public class People {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
