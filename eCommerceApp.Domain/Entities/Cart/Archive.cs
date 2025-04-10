﻿using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Domain.Entities.Cart
{
	public class Archive
	{
		[Key]
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public int Quantity { get; set; }
		public Guid UserId { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
