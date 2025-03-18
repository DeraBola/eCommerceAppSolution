using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;

namespace eCommerceApp.Application.DTOs.Category
{
	public class UpdateCategory : CategoryBase
    {
        [Required]
        public Guid Id { get; set; }
    }
}
