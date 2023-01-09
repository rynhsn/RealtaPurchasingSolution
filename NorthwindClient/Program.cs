using Microsoft.Extensions.Configuration;
using NorthwindVbNetApi;
using System;

namespace NorthwindClient // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static IConfigurationRoot? Configuration;
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            BuildConfig();

            INorthwindVbApi _northwindVbApi = new NorthwindVbApi(Configuration.GetConnectionString("NorthwindDS"));
            Console.WriteLine();

            //_northwindVbApi.SayHello();
            Console.WriteLine("---------------------FIND ALL------------------");
            var listRegions = _northwindVbApi.RepositoryManager.Region.FindAllRegion();
            foreach (var item in listRegions)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();

            //Console.WriteLine("-------------------FIND BY ID------------------");
            //var regionById = _northwindVbApi.RepositoryManager.Region.FindRegionById(1);
            //Console.WriteLine($"Found : {regionById}");
            //Console.WriteLine();

            ////create region
            //Console.WriteLine("---------------------CREATE-------------------");
            //var newRegion = _northwindVbApi.RepositoryManager.Region.CreateRegion(new NorthwindVbNetApi.Model.Region
            //{
            //    RegionId = 5,
            //    RegionDescription = "Sentul Limboto",
            //});
            //Console.WriteLine($"New Region : {newRegion}");
            //Console.WriteLine();

            ////update region
            //Console.WriteLine("-----------------UPDATE BY ID-----------------");
            //var updateRegion = _northwindVbApi.RepositoryManager.Region.UpdateRegionById(5, "Warunggunung", true);
            //var regionUpdateResult = _northwindVbApi.RepositoryManager.Region.FindRegionById(5);
            //Console.WriteLine($"{updateRegion}: {regionUpdateResult}");
            //Console.WriteLine();

            ////update region By Sp
            //Console.WriteLine("-----------------UPDATE BY SP------------------");
            //var updateRegionSp = _northwindVbApi.RepositoryManager.Region.UpdateRegionBySp(5, "Sampay Kidul", true);
            //var regionUpdateResultSp = _northwindVbApi.RepositoryManager.Region.FindRegionById(5);
            //Console.WriteLine($"{updateRegionSp}: {regionUpdateResultSp}");
            //Console.WriteLine();

            ////delete region
            //Console.WriteLine("---------------------DELETE--------------------");
            //var deleteRegion = _northwindVbApi.RepositoryManager.Region.DeleteRegion(5);
            //Console.WriteLine($"Deleted Region Row[s] : {deleteRegion}");
            //Console.WriteLine();

            ////_northwindVbApi.SayHello();
            //Console.WriteLine("---------------------ASYNC---------------------");
            //var listRegionsAsync = await _northwindVbApi.RepositoryManager.Region.FindAllRegionAsync();
            //foreach (var item in listRegionsAsync)
            //{
            //    Console.WriteLine($"{item}");
            //}
            //Console.WriteLine();
        }

        static void BuildConfig()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            Console.WriteLine(Configuration.GetConnectionString("NorthwindDS"));
        }
    }
}