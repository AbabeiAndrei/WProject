using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WProject.DataAccess;

namespace WProject.TestLibrary
{
	class Program
	{
		static void Main()
		{
			string mdss = String.Format("Server={0};Database={1};User ID={2};Password={3};Connection Timeout=60;",
									   "localhost",
									   "wproject",
									   "wproject",
									   "wPr0j3cT");
			wpContext mctx = new wpContext(mdss);
			var mi = mctx.Groups.ToList();
			Console.Write("heheh");
			Console.ReadKey();
		}
	}
}
