using Microsoft.EntityFrameworkCore;
using System;

namespace WadoRyu.Models
{
	public class NewsArticle
	{
		public int ID { get; set; }
		string Title { get; set; }
		string Content { get; set; }
		DateTime DatePublished { get; set; }

		//ApplicationUser Author { get; set; }
	}

	public class EmpDBContext : DbContext
	{
		public DbSet<NewsArticle> NewsArticles { get; set; }
	}
}
