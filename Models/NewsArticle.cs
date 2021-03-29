using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JokesWebApp.Models
{
	public class NewsArticle
	{
		public int ID { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		[StringLength(30, ErrorMessage = "Title length cannot be more than 30 characters.")]
		public string Title { get; set; }

		[StringLength(2000, ErrorMessage = "Content length cannot be more than 2000 characters long.")]
		public string Content { get; set; }

		[DisplayName("Date")]
		public DateTime DatePublished { get; set; }

		public NewsArticle()
		{
		}
	}
}
