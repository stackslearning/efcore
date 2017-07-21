﻿using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Samurai.Data;

using SamuraiDomain = Samurai.Domain.Samurai;

namespace Samurai.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			InsertSamurai();
		}

		private static void InsertSamurai()
		{
			var sam1 = new SamuraiDomain { Name = "Sam1" };
			using (var db = new SamuraiContext())
			{
				db.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());

				db.Samurais.Add(sam1);
				db.SaveChanges();
			}
		}
	}
}
