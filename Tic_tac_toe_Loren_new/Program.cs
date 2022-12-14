namespace TicTacToeNew
{
    internal class Program
    {
        static Player p1, p2;

        class Player
        {
            public string name;
            public char sign;
            public Player(string name, char sign)
            {
                this.name = name;
                this.sign = sign;
            }
        }
        static void Main(string[] args)
        {
            GameWelcomeAndInstructions();

            participantsNameAndChoice(); 

            char[,] board = new char[3, 3];
      
            initializingBoard(board);

            GameEngine(board);
            
        }

        //Functions
        static void GameWelcomeAndInstructions()
        {
            Console.WriteLine("Welcome to the Tic Tac Toe game!");
            Console.WriteLine("");
            Console.WriteLine("choose a number of row & column to place your choice on the board:");
            Console.WriteLine("");
        }

        static void participantsNameAndChoice()
        {
            char flag;
            while (true)
            {
                Console.WriteLine("Enter first name:");
                string name1 = Console.ReadLine();

                Console.WriteLine("Do you want to be X or O ?");
                char choice = Console.ReadLine()[0];

             
                Console.WriteLine("Enter second name:");
                string name2 = Console.ReadLine();

                if (choice == 'X' || choice == 'x')
                {
                    flag = 'X';
                    Console.WriteLine("");
                    Console.WriteLine($"{name1} = {flag}");
                    Console.WriteLine($"{name2} = O");

                     p1 = new Player(name1, flag);
                     p2 = new Player(name2, 'O');
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to start the game.");
                    Console.ReadLine();
                    break;

                }
                else if (choice == 'O' || choice == 'o' || choice == '0')
                {
                    flag = 'O';
                    Console.WriteLine("");
                    Console.WriteLine($"{name1} = {flag}");
                    Console.WriteLine($"{name2} = X");
                    Console.WriteLine("");
                    p1 = new Player(name1, flag);
                    p2 = new Player(name2, 'X');
                    Console.WriteLine("Press any key to start the game.");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("XXX Worng choise! try again XXX");
                    Console.WriteLine("");
                    continue;
                }
            }
        }

        static void initializingBoard(char[,] board)
        {
            //הוספת רווח שווה בין התאים- המצב ההתחלתי גם אם אין נתונים בלוח
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }

        static void PrintGameBoard(char[,] board)
        {
            //הדפסת לוח המשחק
            Console.WriteLine("  | 0 | 1 | 2 |" + "\n"); //מספור העמודות למשתמש
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + " | "); //מספור השורות למשתמש
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col]);
                    Console.Write(" | ");
                }
                Console.WriteLine("\n");
            }
        }

        static void GameEngine(char[,] board)
        {
            char player = 'X';
            int movePlayed = 0;

            while (true)
            {
                Console.Clear();
                PrintGameBoard(board);


                Console.Write($"{player} choose a row:");
                //int row = Convert.ToInt32(Console.ReadLine());
                int.TryParse(Console.ReadLine(), out int row);

                Console.Write($"{player} choose a column:");
                // int col = Convert.ToInt32(Console.ReadLine());
                int.TryParse(Console.ReadLine(), out int col);


                while (row<0||col<0 ||  row > 2 || col > 2 ||  board[row, col] != ' ')
                {
                    Console.WriteLine("Please Choose another spot!");
                    Console.Write($"{player} choose a row:");
                    //row = Convert.ToInt32(Console.ReadLine());
                    int.TryParse(Console.ReadLine(), out row);

                    Console.Write($"{player} choose a column:");
                    //col = Convert.ToInt32(Console.ReadLine());
                    int.TryParse(Console.ReadLine(), out col);

                }
                board[row, col] = player;


                //בדיקת תנאים לניצחון
                if (// שורות
                 player == board[0, 0] && player == board[0, 1] && player == board[0, 2] ||
                 player == board[1, 0] && player == board[1, 1] && player == board[1, 2] ||
                 player == board[2, 0] && player == board[2, 1] && player == board[2, 2] ||
                   // עמודות
                 player == board[0, 0] && player == board[1, 0] && player == board[2, 0] ||
                 player == board[0, 1] && player == board[1, 1] && player == board[2, 1] ||
                 player == board[0, 2] && player == board[1, 2] && player == board[2, 2] ||
                  //אלכסונים
                 player == board[0, 0] && player == board[1, 1] && player == board[2, 2] ||
                 player == board[0, 2] && player == board[1, 1] && player == board[2, 0])
                {
                    Console.WriteLine();
                    Console.Clear();
                    PrintGameBoard(board);
                    Console.WriteLine($"{(p1.sign.Equals(player) ? p1.name : p2.name)} won the game!");
                    break;
                }

                //רק אחרי שבודקים אם מישהו ניצח, בודקים אם תיקו
                movePlayed = movePlayed + 1;

                if (movePlayed == 9)
                {
                    Console.WriteLine("");
                    Console.Clear();
                    PrintGameBoard(board); ;
                    Console.WriteLine("Draw!");
                    break;
                }

                //אחרי שהשחקן הנוכחי שיחק- מחליפים שחקן
                player = SwitchPlayers(player);
            }
        }

        static char SwitchPlayers(char player)
        {
            if (player == 'X')
            {
                return 'O';
            }
            else
            {
                return 'X';
            }
        }
    }
}

//הערות

// - משום שרציתי להשתמש בשם השחקנים, לא הצלחתי להשתמש ב
//try Parse
//לכן, לקחתי בחשבון ששם השחקן יכול להיות גם סטרינג, אותיות או ספרות מיוחדות.





