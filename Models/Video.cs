using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WadoRyu.Models
{
	public class Video
	{
		public int ID { get; set; }

		[StringLength(20, ErrorMessage = "Video title cannot exceed 20 characters")]
		public string Name { get; set; }

		[DisplayName("YouTube URL")]
		[Required(ErrorMessage = "URL is required.")]
		public string Url { get; set; }

		public string Category { get; set; }

		[DisplayName("Date added")]
		public DateTime DateAdded { get; set; }
	}
}
