﻿using System;
using System.Threading;

namespace big_sister_base
{
    class Program
    {
        static void Main(string[] args)
        {
            LittleGuy littleGuy = new LittleGuy();
            Market market = new Market();
            BigSister bigSister = new BigSister();
            
            bool continueCycle = true;
            bigSister.ProductCheck += littleGuy.OnProductCheck;
            bigSister.CheckSL += littleGuy.OnCheckSL;
            while (continueCycle)
            {
                Console.Clear();
                Console.WriteLine("¿Que quieres hacer?\n");
                Console.WriteLine("\t1. Ver Receta");
                Console.WriteLine("\t2. Comprar");
                Console.WriteLine("\t3. Ver carrito");
                Console.WriteLine("\t4. Pagar");
                Console.WriteLine("\t5. Salir");
                String answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        littleGuy.ViewRecipe();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("¿Que deseas comprar? (-1 para cancelar)\n\n");

                        for (int i = 0; i < market.Storage.Count; i++)
                        {
                            Console.WriteLine($"[{i}] " + market.Storage[i].ToString() + $"\t Stock:{market.Storage[i].Stock}");
                        }
                        int index = Convert.ToInt32(Console.ReadLine());
                        if (index != -1)
                        {
                            if (market.Storage[index].Stock > 0)
                            {

                                /*Console.WriteLine(littleGuy.ToString());*/

                                if (bigSister.CheckP(littleGuy.ShopList[index], littleGuy))
                                {
                                    littleGuy.AddProduct(market.Storage[index]);
                                    littleGuy.ShopList[index].Stock = 0;
                                    market.removeStorage(index);
                                }
                               
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Product sin stock");
                            }
                        }
                        
                        break;
                    case "3":
                        Console.Clear();
                        littleGuy.ViewCart();
                        //Console.WriteLine(littleGuy.ToString());//
                        Console.WriteLine("\n\nPresiona ENTER para volver al supermercado...");
                        ConsoleKeyInfo response = Console.ReadKey(true);
                        while (response.Key != ConsoleKey.Enter)
                        {
                            response = Console.ReadKey(true);
                        }
                        break;
                    case "4":
                        Console.Clear();
                        if (bigSister.CheckS(littleGuy.ShopList,littleGuy))
                        {
                            littleGuy.Pay();
                            littleGuy.SaveData();
                            market.SaveStorage();
                            continueCycle = false;
                        }
                      
                        break;
                    case "5":
                        Console.Clear();
                        littleGuy.SaveData();
                        market.SaveStorage();
                        continueCycle = false;
                        break;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
        }
    }
}
