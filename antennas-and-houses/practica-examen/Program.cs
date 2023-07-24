using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_examen
{
    internal class Program
    {
        /*Descripcion:
           Antenas y casas:
                 Dado un mapa poblado de antenas, casas y espacios vacios, cada uno de estos objetos 
                 ocupar unicamente un espacio en el mapa. Las antenas tienen diferentes intensidades
                 de senal que forman un patron en forma de cruz. La intensidad de senal varia desde 
                 1 a 3.
             De acuerdo a las especificaciones anteriores, escriba un algoritmo capaz de contar el total
             de las casas que se quedan sin senal. El algoritmo debe funcionar en un mapa de tamano N*M.
         */
        public static bool MainAxis(int[,] signalArray, int staticDirection, int houseCoordinate) //x
        {
            //staticDirection is the coordinate that will not change in iterations
            //houseCoordinate is the exact index in that static coordinate

            int currentElement = 0;

            //Match counters
            int lowAntennaMatch = 0;
            int midAntennaMatch = 0;
            int highAntennaMatch = 0;

            //Intensity toggles
            bool lowIntensityAntenna = false;//1 spaces
            bool midIntensityAntenna = false;//2 spaces
            bool highIntensityAntenna = false;//3 spaces
           
            for (int iteratorDirection = 0; iteratorDirection <= 8; iteratorDirection++)
            {
                  currentElement = signalArray[staticDirection, iteratorDirection];
                  //space between 2 spots (any type of antenna and house)
                  int rangeOfConnection = Math.Abs(iteratorDirection - houseCoordinate);//absolute value
                  //If antenna is type 1
               
                  if (currentElement == 2)//antenna with intensity: 1
                  {
                      if (rangeOfConnection <= 1)
                      {
                          lowAntennaMatch++;
                          lowIntensityAntenna = true;
                      }
                  }
                  //If antenna is type 2
                  if (currentElement == 3)//antenna with intensity: 2
                  {
                      if (rangeOfConnection <= 2)
                      {
                          midAntennaMatch++;
                          midIntensityAntenna = true;
                      }
                  }
                  //If antenna is type 3
                  if (currentElement == 4)//antenna with intensity: 3
                  {
                      if (rangeOfConnection <= 3)
                      {
                          highAntennaMatch++;
                          highIntensityAntenna = true;
                      }
                  }
            }
            
            //Console.WriteLine("New house spotted");
            //Console.WriteLine("Low antenna match count: " + lowAntennaMatch);
            //Console.WriteLine("Mid antenna match count: " + midAntennaMatch);
            //Console.WriteLine("High antenna match count: " + highAntennaMatch);

            //final test of matches
            if (lowIntensityAntenna == true || midIntensityAntenna == true || highIntensityAntenna == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AcrossAxis(int[,] signalArray, int col, int houseCoordinate) //y
        {
            //staticDirection is the coordinate that will not change in iterations
            //houseCoordinate is the exact index in that static coordinate

            int currentElement = 0;

            //Match counters
            int lowAntennaMatch = 0;
            int midAntennaMatch = 0;
            int highAntennaMatch = 0;

            //Intensity toggles
            bool lowIntensityAntenna = false;//1 spaces
            bool midIntensityAntenna = false;//2 spaces
            bool highIntensityAntenna = false;//3 spaces
            
            for (int iteratorDirection = 0; iteratorDirection <= 8; iteratorDirection++)
            {
                currentElement = signalArray[iteratorDirection, col];//rows cols
                //space between 2 spots (any type of antenna and house)
                int rangeOfConnection = Math.Abs(iteratorDirection - houseCoordinate);//absolute value
                //If antenna is type 1
                if (currentElement == 2)//antenna with intensity: 1
                {
                    if (rangeOfConnection <= 1)
                    {
                        lowAntennaMatch++;
                        lowIntensityAntenna = true;
                    }
                }
                //If antenna is type 2
                if (currentElement == 3)//antenna with intensity: 2
                {
                    if (rangeOfConnection <= 2)
                    {
                        midAntennaMatch++;
                        midIntensityAntenna = true;
                    }
                }
                //If antenna is type 3
                if (currentElement == 4)//antenna with intensity: 3
                {
                    if (rangeOfConnection <= 3)
                    {
                        highAntennaMatch++;
                        highIntensityAntenna = true;
                    }
                }
            }
            
             /*Console.WriteLine("New house spotted");
             Console.WriteLine("Low antenna match count: " + lowAntennaMatch);
             Console.WriteLine("Mid antenna match count: " + midAntennaMatch);
             Console.WriteLine("High antenna match count: " + highAntennaMatch);*/
             
            //final test of matches
            if (lowIntensityAntenna == true || midIntensityAntenna == true || highIntensityAntenna == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int DetectSignal(int[,] signalArray) //funcion principal
        {
            int housesWithNoSignal = 0;
            int currentElement = 0;
            int mainAxisHouseWhithoutMatch = 0; //This counts the number houses whithout match in x
            int mainAxisHouseWhithMatch = 0; //This counts the number of matches in x
            int acrossAxisHouseWhithoutMatch = 0; //This counts the number houses whithout match in y
            int acrossAxisHouseWhithMatch = 0; //This counts the number of matches in y

            for (int row = 0; row <= 8; row++)
            {
                for (int col = 0; col <= 8; col++)
                {
                    currentElement = signalArray[row, col];
                    if (currentElement == 1)//is a house
                    {
                        //Main axis 
                        if (MainAxis(signalArray, row, col))//returns the ammount of houses with matches in x
                        {
                            mainAxisHouseWhithMatch++;//Matches in x
                        }else
                        {
                            mainAxisHouseWhithoutMatch++;//No matches in x
                            //in case we don't have match in main axis, let's try across axis
                            if (AcrossAxis(signalArray, col, row))
                            {
                                acrossAxisHouseWhithMatch++;//Matches in y
                            }
                            else
                            {
                                housesWithNoSignal++; //No match in x and y
                                acrossAxisHouseWhithoutMatch++;//No matches in y
                            }
                            
                        }

                    }
                }
            }
            return housesWithNoSignal;
        }
        static void Main(string[] args)
        {
            int[,] signalArray = {

                    {0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0, 0, 0, 0, 0},
                    {0, 0, 1, 2, 1, 0, 0, 1, 0},
                    {0, 0, 1, 1, 0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 2, 1, 1, 0, 0, 0, 0, 0},
                    {0, 1, 0, 0, 1, 2, 1, 0, 0},
                    {0, 3, 1, 0, 0, 1, 0, 0, 0},
                    {0, 1, 0, 0, 1, 0, 0, 0, 1}
            };
            Console.WriteLine(DetectSignal(signalArray));

            Console.ReadLine();
        }
    }
}
