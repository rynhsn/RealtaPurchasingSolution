using Microsoft.Extensions.Configuration;
using VBPurchasingDbLib;

IConfigurationRoot? Configuration = null;
BuildConfig();
IPurchasingDbLib _purchasingDbLib = new PurchasingDbLib(Configuration.GetConnectionString("HotelRealtaDS"));

//Console.WriteLine("++++++++++++++++++++++++++++++++++++++++FIND ALL+++++++++++++++++++++++++++++++++++++++++++++");
//Console.WriteLine();
//var listVendors = _purchasingDbLib.RepositoryManager.Vendor.FindAll();
//foreach (var item in listVendors)
//{
//    Console.WriteLine($"{item}");
//}
//Console.WriteLine();

//Console.WriteLine("+++++++++++++++++++++++++++++++++++++++FIND BY ID++++++++++++++++++++++++++++++++++++++++++++");
//Console.WriteLine();
//var findVendor = _purchasingDbLib.RepositoryManager.Vendor.FindById(1);
//Console.WriteLine($"{findVendor}");
//Console.WriteLine();

//Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++CREATE++++++++++++++++++++++++++++++++++++++++++++++");
//Console.WriteLine();
//var addVendor = _purchasingDbLib.RepositoryManager.Vendor.Create(new VBPurchasingDbLib.Model.Vendor
//{
//    Name = "XYZ",
//    Active = true,
//    Priority = false,
//    WebUrl = ""
//});
//Console.WriteLine($"{addVendor}");
//Console.WriteLine();

Console.WriteLine("-----------------UPDATE BY SP------------------");
var updateVendorSp = _purchasingDbLib.RepositoryManager.Vendor.UpdateBySp(11, "ABC", true, true, "www.abc.net");
var UpdateResultSp = _purchasingDbLib.RepositoryManager.Vendor.FindById(11);
Console.WriteLine($"{updateVendorSp}: {UpdateResultSp}");
Console.WriteLine();

//Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++DELETE++++++++++++++++++++++++++++++++++++++++++++++");
//Console.WriteLine();
//var deleteVendor = _purchasingDbLib.RepositoryManager.Vendor.Delete(14);
//Console.WriteLine($"{deleteVendor} row[s] was deleted");
//Console.WriteLine();

Console.WriteLine("+++++++++++++++++++++++++++++++++++++FIND ALL ASYNC++++++++++++++++++++++++++++++++++++++++++");
Console.WriteLine();
var listVendors = await _purchasingDbLib.RepositoryManager.Vendor.FindAllAsync();
foreach (var item in listVendors)
{
    Console.WriteLine($"{item}");
}
Console.WriteLine();

void BuildConfig()
{
    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);

    Configuration = builder.Build();

    //Console.WriteLine(Configuration.GetConnectionString("HotelRealtaDS"));
}
