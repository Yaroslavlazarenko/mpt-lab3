internal class Program
{
    private static void Main(string[] args)
    {
        int choice; 

        do
        {
            Console.WriteLine("\nВыберите задачу для выполнения:\n1. Task 952\n2. Task 959\n3. Task 978\n4. Task 1015\n0. Выйти\n");
            choice = getIntFromUser();
            switch (choice)
            {
                case 1:
                    task952();
                    break;
                case 2:
                    task959();
                    break;
                case 3:
                    task978();
                    break;
                case 4:
                    task1015();
                    break;
                case 0:
                    Console.WriteLine("Выход из программы.");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        } while (choice != 0);
    }

    /// <summary>
    /// Выполняет приобразование строки в целое значение. Если не удается просит пользователя заново ввести целое числовое значение.
    /// </summary>
    /// <returns>Целое числовое значение</returns>
    static int getIntFromUser()
    {
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            return choice;
        }
        else
        {
            Console.WriteLine("Пожалуйста, введите целое числовое значение.");
            return getIntFromUser();
        }
    }

    /// <summary>
    /// 952. Составить программу, которая проводит замену всех элементов:
    /// а) некоторой строки Двумерного массива заданным числом;
    /// б) некоторого столбца Двумерного массива заданным числом.
    /// </summary>
    static void task952()
    {
        const byte ROW_QUANTITI = 5;
        const byte COLUMN_QUANTITI = 10;
        Random random = new();

        int[,] matrix = new int[ROW_QUANTITI, COLUMN_QUANTITI];

        Console.WriteLine("Ваша матрица: ");
        for (int i = 0; i < ROW_QUANTITI; i++)
        {
            for (int j = 0; j < COLUMN_QUANTITI; j++)
            {
                matrix[i, j] = random.Next(0,9);
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Выберите: \n1 - заменить строку \n2 - заменить столбец\nдругое - завершить");
        int choice = getIntFromUser();
     
        if (choice == 1 || choice == 2)
        {
            Console.WriteLine($"Выберите {(choice == 1 ? "строку" : "столбец")} от 0 до {(choice == 1 ? ROW_QUANTITI - 1 : COLUMN_QUANTITI-1)}");
            int choiceNumber = getIntFromUser();

            if (choiceNumber > (choice == 1 ? ROW_QUANTITI - 1 : COLUMN_QUANTITI-1))
            {
                Console.WriteLine($"Введённое число больше {(choice == 1 ? ROW_QUANTITI - 1 : COLUMN_QUANTITI - 1)}, поэтому значение уменьшено до {(choice == 1 ? ROW_QUANTITI - 1 : COLUMN_QUANTITI-1)}");
                choiceNumber = choice == 1 ? ROW_QUANTITI - 1 : COLUMN_QUANTITI - 1;
            }
            else if (choiceNumber < 0)
            {
                Console.WriteLine($"Введённое число меньше 0, поэтому значение увеличенно до 0");
                choiceNumber = 0;
            }

            Console.WriteLine($"Введите значение, на которое будет заменено каждое значение {choiceNumber} строки:");
            int replacementNumber = getIntFromUser();

            Console.WriteLine("Итоговый вид матрицы: ");
            for (int i = 0; i < ROW_QUANTITI; i++)
            {
                for (int j = 0; j < COLUMN_QUANTITI; j++)
                {
                    if (choice == 1)
                    {
                        matrix[choiceNumber, j] = replacementNumber;
                    }
                    else
                    {
                        matrix[i, choiceNumber] = replacementNumber;
                    }

                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }

    /// <summary>
    /// В Двумерном массиве хранится информация о количестве учеников в каждом классе каждого потока школы с первого по одиннадцатый 
    /// (в первой строке — информация о первых классах, во второй — о вторых классах и т. д.). В каждом потоке школы имеются четыре класса. 
    /// Определить общее число учеников 5-х классов.
    /// </summary>
    static void task959()
    {
        const byte ROW_QUANTITI = 11;
        const byte COLUMN_QUANTITI = 4;
        Random random = new();

        int[,] matrix = new int[ROW_QUANTITI, COLUMN_QUANTITI];

        Console.WriteLine("Количество учеников в классах:");
        for (int i = 0; i < ROW_QUANTITI; i++)
        {
            Console.Write($"{i+1} классы: ");
            for (int j = 0; j < COLUMN_QUANTITI; j++)
            {
                matrix[i, j]= random.Next(21, 32);
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }

        int numberOfFifthGraders = 0;
        for (int j = 0; j < COLUMN_QUANTITI; j++)
        {
            numberOfFifthGraders += matrix[4, j];
        }

        Console.WriteLine($"Количество пятиклассников: {numberOfFifthGraders}");
    }


    /// <summary>
    /// Дана вещественная квадратная матрица порядка 2n. Получить новую матрицу, переставляя ее блоки размера n × n крест-накрест.
    /// </summary>
    static void task978()
    {
        const byte N = 2;
        Random random = new();
        int[,] matrix = new int[N<<1, N<<1];

        Console.WriteLine("\nИзначальный вид матрицы: ");
        for (int i = 0; i < N << 1; i++)
        {
            for (int j = 0; j < N << 1; j++)
            {
                matrix[i, j] = random.Next(10, 99);
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }

        int temp;
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                temp = matrix[i, j];
                matrix[i, j] = matrix[N+i, N+j];
                matrix[N + i, N + j] = temp;
            }
        }

        for (int i = N; i < N<<1; i++)
        {
            for (int j = 0; j < N; j++)
            {
                temp = matrix[i, j];
                matrix[i, j] = matrix[i - N, N+j];
                matrix[i - N, N + j] = temp;
            }
        }

        Console.WriteLine("\nИтоговый вид матрицы: ");
        for (int i = 0; i < N << 1; i++)
        {
            for (int j = 0; j < N << 1; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Определить, является ли заданная матрица ортонормированной, то есть равно ли скалярное произведение каждой пары разных строк (столбцов) нулю.
    /// </summary>
    static void task1015()
    {
        const byte ROW_QUANTITI = 2;
        const byte COLUMN_QUANTITI = 4;
        Random random = new();

        int[,] matrix = new int[ROW_QUANTITI, COLUMN_QUANTITI];

        Console.WriteLine("\nИзначальный вид матрицы: ");
        for (int i = 0; i < ROW_QUANTITI; i++)
        {
            for (int j = 0; j < COLUMN_QUANTITI; j++)
            {
                matrix[i, j] = random.Next(0, 2);
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }


        int rowMultplicationNumber;
        bool matrixIsOrtonormalized = true;

        for (int i = 0; i < ROW_QUANTITI; i++)
        {
            if (matrixIsOrtonormalized)
            {
                for (int j = i + 1; j < ROW_QUANTITI; j++)
                {
                    rowMultplicationNumber = 0;
                    for (int k = 0; k < COLUMN_QUANTITI; k++)
                    {
                        rowMultplicationNumber += matrix[i, k] * matrix[j, k];
                    }
                    if (rowMultplicationNumber != 0)
                    {
                        matrixIsOrtonormalized = false;
                        break;
                    }
                }
            }
            else
            {
                break;
            }
        }

        if (matrixIsOrtonormalized)
        {
            Console.WriteLine("Матрица ортонормированная");
        }
        else
        {
            Console.WriteLine("Матрица не ортонормированная");
        }
    }
}