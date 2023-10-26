using ProduceInventory.View.Command;
using ProduceInventory.View.Interfaces;

namespace ProduceInventory.View
{
    internal class Menu
    {
        public readonly Startup _storageManager;

        public Menu(Startup storageManager)
        {
            _storageManager = storageManager;
        }



        public void Start()
        {
            List<IExecutor> executorList = new()
            {
                new LookAllStorage(_storageManager),
                new MakeNewStorage(_storageManager),
                new DeleteStartup(_storageManager),
                new ChangeComplete()
            };

            do
            {


                for (int i = 0; i < executorList.Count; i++)
                {
                    Console.Write(i + 1 + ") ");
                    Console.WriteLine(executorList[i].Description);
                }
                Console.Write("=> ");
                if (int.TryParse(Console.ReadLine(), out int chois))
                {
                    switch (chois)
                    {
                        case 1:
                            executorList[0].Execute();
                            break;
                        case 2:
                            executorList[1].Execute();
                            break;
                        case 3:
                            executorList[2].Execute();
                            break;
                        case 4:
                            do
                            {
                                Console.Write("Ыещкфпу number => ");
                                if (int.TryParse(Console.ReadLine(), out var warehouseIndex))
                                {
                                    if (_storageManager.FindStorage((uint)warehouseIndex) != null)
                                    {
                                        ChangeInStock((uint)warehouseIndex);
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("This srorage does not exist");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid value");
                                }
                            } while (true);
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("There is no such option");
                            break;
                    }


                }
                else
                {
                    Console.WriteLine("Invalid value");
                }

            } while (true);
        }

        public void ChangeInStock(uint storageIndex)
        {
            List<IExecutor> executorList = new()
            {
                new MakeAllProduces(_storageManager, storageIndex),
                new ProducteAdd(_storageManager, storageIndex),
                new UninstallProduce(_storageManager, storageIndex)
            };


            do
            {
                for (int i = 0; i < executorList.Count; i++)
                {
                    Console.Write(i + 1 + ") ");
                    Console.WriteLine(executorList[i].Description);
                }

                Console.Write("=> ");
                if (int.TryParse(Console.ReadLine(), out int chois))
                {
                    switch (chois)
                    {
                        case 1:
                            executorList[0].Execute();
                            break;
                        case 2:
                            executorList[1].Execute();
                            break;
                        case 3:
                            executorList[0].Execute();
                            executorList[2].Execute();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("There is no such option");
                            break;
                    }
                }

            } while (true);
        }
    }
}