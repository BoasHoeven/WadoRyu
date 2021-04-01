using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WadoRyu.Models
{
	public class ViewModelTest
	{

		[StringLength(20, ErrorMessage = "Video title cannot exceed 20 characters")]
		public string Name { get; set; }

		[DisplayName("YouTube URL")]
		[Required(ErrorMessage = "URL is required.")]
		public string Url { get; set; }

		[DisplayName("Date added")]
		public DateTime DateAdded { get; set; }

		[Display(Name = "Select a video category")]
		public string SelectedValue { get; set; }

		public IEnumerable<SelectListItem> VideoCategories { get; set; }
	}
}
