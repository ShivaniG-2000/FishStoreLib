using FishStoreLib;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;

namespace FishStoreConsole
{
    class Program
    {
      public  static void Main(string[] args)
        {   
            
            Console.WriteLine("-------------------------------------     WELCOME TO OUR FISH STORE.    ---------------------------------------");
            Console.Write("1.Create account\n2.Shop now\nChoose one option :   ");
            int chooseoption = int.Parse(Console.ReadLine());

            switch (chooseoption)
            {
                case 1: break;
                case 2: ChoseItem(); break;

            }

            

        }
         static void ChoseItem()
        {
            string[] F_types = { "Goldfish", "Angelfish", "African Leaf Fish", "Oscar", "Tiger barb", "Rummy nose tetra", "Neotetra" };
            decimal[] F_price = { 100.00m, 150.00m, 200.00m, 250.00m, 300.00m, 350.00m, 400.00m };
            string[] F_food = { "Flake Food", "Pellets", "Freeze-Dried", "Frozen", "Spirulina/Dried Seaweed" };
            string[] F_tank = { "Coldwater Aquarium", "Freshwater Tropical Aquarium", "Marine (Saltwater) Aquarium", "Brackish Aquarium", "Betta Fish Tank", "Breeder Tank", "Large Tank", "Kids' Tank" };
            int choose_Item;
            Fish fishobj = new Fish();

            string Temp = "y";
            do
            {
                
            Console.Write("1.Buy pet fish\n2.Buy pet food\n3. Buy fish tank.\nChoose one option :   ");
                choose_Item = int.Parse(Console.ReadLine());

                switch (choose_Item)
                {
                    case 1:
                            fishobj.fishName=  Choosefish(F_types);
                        for (int i = 0; i < F_types.Length; i++)
                            if (fishobj.fishName == F_types[i])
                               fishobj.Price = F_price[i];                            
                            break;
                    case 2:  fishobj.fishFood =  choosefood(F_food); break;
                    case 3: fishobj.fishTank =  choosetank(F_tank); break;

                }

                Console.Write("Do you want to continue shopping?(Choon 'y' if yes.)\t");
                Temp = Console.ReadLine();

            } while(Temp == "y");

            string strJson = JsonConvert.SerializeObject(fishobj);
            File.WriteAllText(@"FishDetails.json", strJson);
            Console.WriteLine("Data Saved successfull!!\n");


            strJson = String.Empty;
            strJson = File.ReadAllText(@"FishDetails.json");
            Fish result = JsonConvert.DeserializeObject<Fish>(strJson);

            Console.WriteLine(result.ToString());

        }  
    
        public static string Choosefish(string[] a)
        {
            
            string name = "";
            Console.Write("\nChoose your pet fish :\n");
            for (int i=0;i< a.Length; i++)
            Console.WriteLine(@$"{i+1}. {a[i]}");

            int item = int.Parse(Console.ReadLine());
            for (int i = 0; i < a.Length; i++)
             if ((i+1) == item)
                {
                    name = a[i];
                    
                }

            return name;

            
        }

        static string choosefood(string[] c)
        {
            string food = "";
            Console.Write("\nChoose the fish food :\n");
            for (int i = 0; i < c.Length; i++)
            {
                Console.WriteLine(@$"{i + 1}. {c[i]}");
            }

            int item = int.Parse(Console.ReadLine());
            for (int i = 0; i < c.Length; i++)
                if ((i + 1) == item)
                {
                    food = c[i];

                }

            return food;


        }

        static string choosetank(string[] d)
        {
            string tank = "";
            Console.Write("\nChoose the fish tank :\n");
            for (int i = 0; i < d.Length; i++)
            {
                Console.WriteLine(@$"{i + 1}. {d[i]}");
            }

            int item = int.Parse(Console.ReadLine());
            for (int i = 0; i < d.Length; i++)
                if ((i + 1) == item)
                {
                    tank = d[i];

                }

            return tank;

        }



    }
}
