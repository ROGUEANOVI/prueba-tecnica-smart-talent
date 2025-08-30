using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs
{
    public class CreateUpdateProductDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(255, ErrorMessage = "La descripción no puede tener más de 255 caracteres.")]
        public string? Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Price { get; set; }
    }
}
