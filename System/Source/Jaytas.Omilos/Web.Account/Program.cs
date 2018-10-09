using Jaytas.Omilos.Web.HostConfigurations;
using Microsoft.AspNetCore.Hosting;

namespace Jaytas.Omilos.Web.Account
{
	public class Program : KestrelHostBuilderConfiguration
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder<Startup>(args).Build().Run();
		}
	}
}
