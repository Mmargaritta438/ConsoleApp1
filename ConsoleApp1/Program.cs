using ProduceInventory;
using ProduceInventory.View;

Startup storageManager = new Startup("..\\..\\..\\Data");
try
{
    Menu menu = new Menu(storageManager);
    menu.Start();
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}