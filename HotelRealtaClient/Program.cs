using Microsoft.Extensions.Configuration;
using VBPurchasingDbLib;

IConfigurationRoot? Configuration = null;
BuildConfig();
IPurchasingDbLib _purchasingDbLib = new PurchasingDbLib(Configuration.GetConnectionString("HotelRealtaDS"));

//await VendorAsync();
//await StocksAsync();
//await StockPhotoAsync();

void BuildConfig()
{
    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
    Configuration = builder.Build();
}

async Task VendorAsync()
{
    //Console.WriteLine("++++++++++++++++++++++++++++++++++++++++FIND ALL+++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var listVendors = _purchasingDbLib.RepositoryManager.Vendor.FindAll();
    //foreach (var item in listVendors)
    //{
    //    Console.WriteLine($"{item}");
    //}
    //Console.WriteLine();

    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++CREATE++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var addVendor = _purchasingDbLib.RepositoryManager.Vendor.Create(new VBPurchasingDbLib.Model.Vendor
    //{
    //    Name = "MNO",
    //    Active = true,
    //    Priority = false
    //});
    //Console.WriteLine($"{addVendor}");
    //Console.WriteLine();

    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++FIND BY ID++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var findVendor = _purchasingDbLib.RepositoryManager.Vendor.FindById(1);
    //Console.WriteLine($"{findVendor}");
    //Console.WriteLine();

    //Console.WriteLine("-----------------UPDATE BY SP------------------");
    //var updateVendorSp = _purchasingDbLib.RepositoryManager.Vendor.UpdateBySp(11, "ABC", true, true, "www.abc.net");
    //var UpdateResultSp = _purchasingDbLib.RepositoryManager.Vendor.FindById(11);
    //Console.WriteLine($"{updateVendorSp}: {UpdateResultSp}");
    //Console.WriteLine();

    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++DELETE++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var deleteVendor = _purchasingDbLib.RepositoryManager.Vendor.Delete(14);
    //Console.WriteLine($"{deleteVendor} row[s] was deleted");
    //Console.WriteLine();

    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++FIND ALL ASYNC++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var listVendorsAsync = await _purchasingDbLib.RepositoryManager.Vendor.FindAllAsync();
    //foreach (var item in listVendorsAsync)
    //{
    //    Console.WriteLine($"{item}");
    //}
    //Console.WriteLine();
}

async Task StocksAsync()
{
    //Console.WriteLine("++++++++++++++++++++++++++++++++++++++++FIND ALL+++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var list = _purchasingDbLib.RepositoryManager.Stocks.FindAll();
    //foreach (var item in list)
    //{
    //    Console.WriteLine($"{item}");
    //}
    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();

    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++FIND BY ID++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var find = _purchasingDbLib.RepositoryManager.Stocks.FindById(1);
    //Console.WriteLine($"{find}");
    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();

    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++CREATE++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var add = _purchasingDbLib.RepositoryManager.Stocks.Create(new VBPurchasingDbLib.Model.Stocks
    //{
    //    Name = "Nama 11",
    //    Description = "Deskripsi 11",
    //    Size = "Ukuran 11",
    //    Color = "Warna 11"
    //});
    //Console.WriteLine($"{add}");
    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();

    //Console.WriteLine("++++++++++++++++++++++++++++++++++++++UPDATE BY SP+++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var updateSp = _purchasingDbLib.RepositoryManager.Stocks.UpdateBySp(6, "ABC", "ABC", "ABC", "ABC");
    //var UpdateResultSp = _purchasingDbLib.RepositoryManager.Stocks.FindById(6);
    //Console.WriteLine($"{updateSp}: {UpdateResultSp}");
    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();

    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++DELETE++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var delete = _purchasingDbLib.RepositoryManager.Stocks.Delete(7);
    //Console.WriteLine($"{delete} row[s] was deleted");
    //Console.WriteLine();
    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++FIND ALL ASYNC++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var listAsync = await _purchasingDbLib.RepositoryManager.Stocks.FindAllAsync();
    //foreach (var item in listAsync)
    //{
    //    Console.WriteLine($"{item}");
    //}
    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
}

async Task StockPhotoAsync()
{
    Console.WriteLine("++++++++++++++++++++++++++++++++++++++++FIND ALL+++++++++++++++++++++++++++++++++++++++++++++");
    Console.WriteLine();
    var list = _purchasingDbLib.RepositoryManager.StockPhoto.FindAll();
    foreach (var item in list)
    {
        Console.WriteLine($"{item}");
    }
    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    Console.WriteLine();

    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++FIND BY ID++++++++++++++++++++++++++++++++++++++++++++");
    Console.WriteLine();
    var find = _purchasingDbLib.RepositoryManager.StockPhoto.FindById(6);
    Console.WriteLine($"{find}");
    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    Console.WriteLine();

    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++CREATE++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var add = _purchasingDbLib.RepositoryManager.StockPhoto.Create(new VBPurchasingDbLib.Model.StockPhoto()
    //{
    //    Thumbnail = "Link Baru",
    //    Photo = "link Baru",
    //    Primary = false,
    //    Url = "Link Baru",
    //    StockId = 1
    //});
    //Console.WriteLine($"{add}");
    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();

    //Console.WriteLine("++++++++++++++++++++++++++++++++++++++UPDATE BY SP+++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var updateSp = _purchasingDbLib.RepositoryManager.StockPhoto.UpdateBySp(6, "Link Lama", "Link Lama", true, "Link Lama", 1);
    //var UpdateResultSp = _purchasingDbLib.RepositoryManager.StockPhoto.FindById(6);
    //Console.WriteLine($"{updateSp}: {UpdateResultSp}");
    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();

    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++DELETE++++++++++++++++++++++++++++++++++++++++++++++");
    //Console.WriteLine();
    //var delete = _purchasingDbLib.RepositoryManager.StockPhoto.Delete(6);
    //Console.WriteLine($"{delete} row[s] was deleted");
    //Console.WriteLine();
    //Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

    Console.WriteLine("+++++++++++++++++++++++++++++++++++++FIND ALL ASYNC++++++++++++++++++++++++++++++++++++++++++");
    Console.WriteLine();
    var listAsync = await _purchasingDbLib.RepositoryManager.StockPhoto.FindAllAsync();
    foreach (var item in listAsync)
    {
        Console.WriteLine($"{item}");
    }
    Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
    Console.WriteLine();
}