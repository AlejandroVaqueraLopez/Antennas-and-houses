using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antennas_and_houses_v2_project
{
    internal class Program
    {
        const int N = 9;
        const int M = 9;

        static int[,] originalMatrix = new int[N, M]//original matrix
        {      
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


        static int[,] copyMatrix = new int[N, M];//original matrix

        //fill the copy matrix
        public static void copyMatrixFill()
        {
            int currentValue = 0;
            for(int stCont = 0; stCont < N; stCont++)
            {
                for(int ndCont = 0; ndCont < M; ndCont++)
                {
                    currentValue = originalMatrix[stCont, ndCont];
                    if(currentValue == 1)//there is a house
                    {
                        copyMatrix[stCont, ndCont] = 1;
                    }
                    else
                    {
                        copyMatrix[stCont, ndCont] = 0;
                    }
                }
            }
        }



           //antennaSignal is to delete houses with signal

        public static void AntennaSignal(int row, int col, int type)
        {
            int range = type - 1;//range of signal
            int counter = 1;
            int auxRow = 0;
            int auxCol = 0;

            do
            {
                //Up
                auxRow = row - counter;
                if (auxRow >= 0 && originalMatrix[auxRow, col] == 1) //if is house?
                {
                    copyMatrix[auxRow, col] = 0;
                }

                //upRight
                auxRow = row - counter;
                auxCol = col + counter;
                if (auxRow >= 0 && auxCol < M && originalMatrix[auxRow, auxCol] == 1) //if is house?
                {
                    copyMatrix[auxRow, auxCol] = 0;
                }

                //Right
                auxCol = col + counter;
                if (auxCol < M && originalMatrix[row, auxCol] == 1) //if is house?
                {
                    copyMatrix[row, auxCol] = 0;
                }

                //RightDown
                auxRow = row + counter;
                auxCol = col + counter;
                if (auxRow < N && auxCol < M && originalMatrix[auxRow, auxCol] == 1) //if is house?
                {
                    copyMatrix[auxRow, auxCol] = 0;
                }


                //Down
                auxRow = row + counter;
                if (auxRow < N && originalMatrix[auxRow, col] == 1) //if is house?
                {
                    copyMatrix[auxRow, col] = 0;
                }

                //LeftDown
                auxRow = row + counter;
                auxCol = col - counter;
                if (auxRow < N && auxCol >= 0 && originalMatrix[auxRow, auxCol] == 1) //if is house?
                {
                    copyMatrix[auxRow, auxCol] = 0;
                }


                //Left
                auxCol = col - counter;
                if (auxCol >= 0 && originalMatrix[row, auxCol] == 1) //if is house?
                {
                    copyMatrix[row, auxCol] = 0;
                }

                //LeftUp
                auxRow = row - counter;
                auxCol = col - counter;
                if (auxRow >=0 && auxCol >= 0 && originalMatrix[auxRow, auxCol] == 1) //if is house?
                {
                    copyMatrix[auxRow, auxCol] = 0;
                }

                counter++;
            } while (counter <= range);
        }


        static void Main(string[] args)
        {
            copyMatrixFill();
            int currentValue = 0;

            for(int row = 0; row < N; row++)
            {
                for(int col = 0; col < M; col++)
                {
                    currentValue = originalMatrix[row, col];
                    switch (currentValue)
                    {
                        case 2: //antenna type 2;
                            AntennaSignal(row, col, 2);
                            break;
                        case 3: //antenna type 2;
                            AntennaSignal(row, col, 3);
                            break;
                        case 4: //antenna type 2;
                            AntennaSignal(row, col, 4);
                            break;
                    }
                }
            }

            int hws = 0;

            for(int row = 0; row < N; row++)
            {
                for(int col = 0; col < M; col++)
                {
                    if (copyMatrix[row, col] == 1)
                    {
                        hws++;
                    }
                }
            }

            Console.WriteLine("The number of houses whithout signal are: " + hws);
            Console.ReadLine();


        }
    }
}
