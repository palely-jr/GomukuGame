using System;
using System.IO;
using System.Linq;
using static System.Console;
using System.Threading.Tasks;

namespace GomukuGame
{
    class GameIntro 
    {
        
        static void Main()
        {
            OutputEncoding = System.Text.Encoding.Unicode;




            gameIntro();
            gameModes();
        }

        public static void gameIntro()
        {


            WriteLine("\n \n \n ");
            WriteLine("                     ------------------------------------------------------------------");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 Welcome to Gomoku                             *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*    You can play With a mate or you can play aganist the CPU   *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*               Press any key to continue                       *|");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     ------------------------------------------------------------------");
            ReadKey();
        }

        public static void gameModes() 
        {
            int gameMode = 0;

            while(gameMode >=3 || gameMode <= 1)
            {
                WriteLine("\n \n");

                WriteLine("                                        Choose your destiny");
                WriteLine("                                        1=Human Vs Computer");
                WriteLine("                                        2=Human Vs Human");
                WriteLine("                                        3=Hint");
                

                int.TryParse(ReadLine(), out gameMode);

                if (gameMode == 1)
                {
                    WriteLine("                          You have selected Singleplayer\n\n");
                    chooseDifficulty();
                }
                else if (gameMode == 2)
                {
                    WriteLine("                                        you have selected Multiplayer.\n\n");
                    createSetPieces();
                }
                else  if (gameMode == 3)
                {
                    WriteLine("                                        Game Rules.\n\n");
                    hint();
                }
            }
        }
        public static void chooseDifficulty() 
        {

            int difficultySelect =0;

            while (difficultySelect != 1 || difficultySelect != 2)
            {
                WriteLine("                                        please select a Difficulty.\n1=Easy\n2=Hard");
                int.TryParse(ReadLine(), out difficultySelect);

                if (difficultySelect == 1)
                {
                    WriteLine("                                        \nYou have chosen a Easy Game\n");
                    createCpuSetPieces(difficultySelect);
                }
                else if (difficultySelect == 2)
                {
                    WriteLine("                                        \nYou have chosen a Hard Game\n");
                    createCpuSetPieces(difficultySelect);
                }
            }
        }
                public static void hint() 
        {

             WriteLine("1)Divide the XX and OO evenly between both players.  Player One is represented by XX while the other player is represented by OO.");
             WriteLine("2)Start the game by playing a XX, that is player 1. By convention, the player using the XX piece opens the game by placing one of their pieces on the board. Player can place the piece in any column he wants");
             WriteLine("3)Alternate turns between players. During the game, the two players alternate turns, with each player placing one of their pieces on the board during their turn. After the first player plays a XX, the second player will play a OO");
             WriteLine("4)Aim for 5 pieces in a row to win the game. To win, you must be the first player to create an unbroken line of 5 of your stones. The line can go in any direction: horizontally, vertically, or diagonally.");

            WriteLine("Press any key to continue");
            ReadKey();
            gameModes();
        }


        public static void createCpuSetPieces(int difficultySelect) {

            string playerOneName = null;
            string playerTwoName = "CPU";
            string playerOnePiece = "XX";
            string playerTwoPiece = "OO";
            int playerOneScore = 0;
            int playerTwoScore = 0;

            WriteLine("                                        Enter the name for player 1");
            playerOneName = ReadLine();
            WriteLine("                                        Your piece is {0}", playerOnePiece);
            WriteLine("                                        Press any key to load the game");
            ReadKey();
           

          
            startCpuGame(playerOneName, playerTwoName,playerOnePiece, playerTwoScore, playerOneScore, playerTwoPiece,difficultySelect);
            
                    }


 
    public static void startCpuGame(string playerOneName, string playerTwoName, string playerOnePiece, int playerTwoScore, int playerOneScore, string playerTwoPiece,int difficultySelect) {
            Clear();
            gameBoard();
            string[] cpuMoves={ "01","02" , "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13","14","15","16","17", "18", "19", "20", "21","22", "23", "24", "25","26"};
            if (difficultySelect == 1) { 
               WriteLine("                                        Easy Game Staring...");
                string[] easyGameMoves={ "01","02" , "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13","14","15","16","17", "18", "19", "20", "21","22", "23", "24", "25","26"};
             cpuMoves = easyGameMoves;
            }
            else { 
                WriteLine("                                        Hard Game Staring...");
                string[] hardGameMoves= { "01","04" , "03", "07", "05", "06", "02", "08", "24", "15", "11", "12", "13","14","18","16","17", "19", "10", "20", "21","26", "23", "09", "22","25"};
             cpuMoves = hardGameMoves;
                }

            //saveFile(hardGameMoves);

            String selectedNum =null;
            string playerName=playerOneName;
            string setPiece=playerOnePiece;
            bool validInput=true;
            int playerNum=1;
            string[] turnResults=null;
            int numCheck=0;
            int drawCheck=0;
            int count= 25;
             
   
            do {



                if (count == 0) { 
                
                count=25;
                
                }

               

               winCheck( playerOneName, playerTwoName, playerOnePiece,  playerTwoScore,  playerOneScore,  playerTwoPiece);

                if (drawCheck == 25) {
                
                drawGame();
                
                }
      

                while (validInput) { 
              if (playerNum == 1) { 
                          Write("                                        Numbers 1 to 9 enter with a zero in prefix as shown in the table\n");
            WriteLine("                                        {0} Choose a number from the board",playerName);
                    }
                    else { 
                    
             WriteLine("                                        {0} will play now",playerName);       
                    }
                    if (playerNum == 1) {
                    selectedNum=Console.ReadLine();
                    }
                    else { 
                    selectedNum=cpuMoves[count];
                        count--;
                    }
                    int checkVal=0;
             bool check= Int32.TryParse(selectedNum, out numCheck);
             if(!String.IsNullOrEmpty(selectedNum)) {

                         if(check && numCheck<26) {

                           
 
                    if (gamePlatform.Contains(selectedNum)) { 
                            
                        
                      
                                checkVal=Int32.Parse(selectedNum)-1;
 
                       

                        drawCheck++;
                        gamePlatform[checkVal]=setPiece;

                                if (playerNum == 2) { 
                                validInput=false;
                                }

                      
                       



                     int optionNext= 0;


                                if (playerNum == 1){ 

                                    gameBoard();


         while (optionNext != 1 || optionNext != 2)
            {
                                                                    WriteLine("                                        Choose From the Following Option :");
                                WriteLine("                                        1=Undo");
                                WriteLine("                                        2=Next");
                
                int.TryParse(ReadLine(), out optionNext);

                if (optionNext == 1)
                {
                    WriteLine("                                        \nYou have chosen to undo the last move\n");
                    gamePlatform[checkVal]=selectedNum;
                                        gameBoard();
                                        break;
                }
                else if (optionNext == 2)
                {
                    WriteLine("                                        \nTurn Change\n");
                    validInput=false;
                    break;
                }
            }
         }





                    }
                    else { 
                    
                    if (playerNum == 1) {
                    WriteLine("                                        Invalid entry, try again");
                    }
                    }

                        }
                        else
                        {
                                                                    
                             if (playerNum == 1) {
                    WriteLine("                                        Invalid entry, try again");
                    }


                        }
                         }
                    else { 

                         if (playerNum == 1) {
                    WriteLine("                                        Invalid entry, try again");
                    }
                    
                    }


              }
            turnResults=decideTurns(selectedNum,playerOnePiece,playerTwoPiece,playerNum,playerName,playerOneName,playerTwoName,setPiece);

                playerName=turnResults[0];
                setPiece=turnResults[1];
                playerNum=Int32.Parse(turnResults[2]);


            gameBoard();
                validInput=true;

               }while(true);
        
        
        }


       




   public static void createSetPieces() {

            string playerOneName = null;
            string playerTwoName = null;
            string playerOnePiece = "XX";
            string playerTwoPiece = "OO";
            int playerOneScore = 0;
            int playerTwoScore = 0;

            WriteLine("                                        Enter the name for player 1");
            playerOneName = ReadLine();
            WriteLine("                                        Your piece is {0}", playerOnePiece);
            WriteLine("                                        Enter the name for player 2");
            playerTwoName = ReadLine();
            WriteLine("                                        Your piece is {0}", playerTwoPiece);
            WriteLine("                                        Press any key to load the game");
            ReadKey();
            startGame(playerOneName, playerTwoName,playerOnePiece, playerTwoScore, playerOneScore, playerTwoPiece);

                    }






        public static void startGame(string playerOneName, string playerTwoName, string playerOnePiece, int playerTwoScore, int playerOneScore, string playerTwoPiece) {
            Clear();
            gameBoard();

            String selectedNum =null;
            string playerName=playerOneName;
            string setPiece=playerOnePiece;
            bool validInput=true;
            int playerNum=1;
            string[] turnResults=null;
            int numCheck=0;
            int drawCheck=0;
             
   
            do { 

               winCheck( playerOneName, playerTwoName, playerOnePiece,  playerTwoScore,  playerOneScore,  playerTwoPiece);

                if (drawCheck == 25) {
                
                drawGame();
                
                }
      

                while (validInput) { 
                    Write("                                        Numbers 1 to 9 enter with a zero in prefix as shown in the table\n");
            WriteLine("                                        {0} Choose a number from the board ",playerName);
                    selectedNum=Console.ReadLine();
                    int checkVal=0;
             bool check= Int32.TryParse(selectedNum, out numCheck);
             if(!String.IsNullOrEmpty(selectedNum)) {

                         if(check && numCheck<26) {

                           
 
                    if (gamePlatform.Contains(selectedNum)) { 
                            
                        
                      
                                checkVal=Int32.Parse(selectedNum)-1;
 
                         

                        drawCheck++;
                        gamePlatform[checkVal]=setPiece;
                      
                                  int optionNext= 0;




                                    gameBoard();


         while (optionNext != 1 || optionNext != 2)
            {
                                                                    WriteLine("                                        Choose From the Following Option :");
                                WriteLine("                                        1=Undo");
                                WriteLine("                                        2=Next");
                
                int.TryParse(ReadLine(), out optionNext);

                if (optionNext == 1)
                {
                    WriteLine("                                        \nYou have chosen to undo the last move\n");
                    gamePlatform[checkVal]=selectedNum;
                                        gameBoard();
                                        break;
                }
                else if (optionNext == 2)
                {
                    WriteLine("                                        \nTurn Change\n");
                    validInput=false;
                    break;
                }
            }
         


                    }
                    else { 
                    
                    WriteLine("                                        Invalid entry, try again");
                    }

                        }
                        else
                        {
                                                                    
                            WriteLine("                                        Invalid entry, try again");


                        }
                         }
                    else { 

                        WriteLine("                                        Invalid entry, try again");
                    
                    }


              }
            turnResults=decideTurns(selectedNum,playerOnePiece,playerTwoPiece,playerNum,playerName,playerOneName,playerTwoName,setPiece);

                playerName=turnResults[0];
                setPiece=turnResults[1];
                playerNum=Int32.Parse(turnResults[2]);


            gameBoard();
                validInput=true;

               }while(true);
        
        
        }

        public static void drawGame() { 

      Clear();
         WriteLine("\n \n \n ");
            WriteLine("                     ------------------------------------------------------------------");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 The Game Has Been Drawn                       *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*               Press any key to continue                       *|");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     ------------------------------------------------------------------");
        
        
                        ReadKey();
                        clearBoard();
                        gameModes();
        
        
        
        }


          public static void winCheck(string playerOneName,string playerTwoName,string playerOnePiece, int playerTwoScore, int playerOneScore, string playerTwoPiece) {


               string[] playerIdentifiers = { playerOnePiece, playerTwoPiece };

                            foreach (string setPiece in playerIdentifiers)

                {

               
                //horizontal
                    if (((gamePlatform[0] == setPiece) && (gamePlatform[1] == setPiece) && (gamePlatform[2] == setPiece) && (gamePlatform[3] == setPiece) && (gamePlatform[4] == setPiece))
                        || ((gamePlatform[5] == setPiece) && (gamePlatform[6] == setPiece) && (gamePlatform[7] == setPiece) && (gamePlatform[8] == setPiece) && (gamePlatform[9] == setPiece))
                        || ((gamePlatform[10] == setPiece) && (gamePlatform[11] == setPiece) && (gamePlatform[12] == setPiece) && (gamePlatform[13] == setPiece) && (gamePlatform[14] == setPiece))
                        || ((gamePlatform[15] == setPiece) && (gamePlatform[16] == setPiece) && (gamePlatform[17] == setPiece) && (gamePlatform[18] == setPiece) && (gamePlatform[19] == setPiece))
                        || ((gamePlatform[20] == setPiece) && (gamePlatform[21] == setPiece) && (gamePlatform[22] == setPiece) && (gamePlatform[23] == setPiece) && (gamePlatform[24] == setPiece)))
                    {
                     
                        Clear ();

                        if (setPiece == playerOnePiece)
                        {
                            ++playerOneScore;
                               WriteLine("\n \n \n ");
            WriteLine("                     ------------------------------------------------------------------");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 {0} is the champion                           *|",playerOneName);
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                   Horizontal Vitory                           *|");
            WriteLine("                     |*                 Your Score is {0}                             *|",playerOneScore);
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*               Press any key to continue                       *|");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     ------------------------------------------------------------------");
        
                        }
                        else if (setPiece == playerTwoPiece)
                        {
                            ++playerTwoScore;
                            WriteLine("\n \n \n ");
            WriteLine("                     ------------------------------------------------------------------");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 {0} is the champion                           *|",playerTwoName);
            WriteLine("                     |*                 Horizontal Vitory                             *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 Your Score is {0}                             *|",playerTwoScore);
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*               Press any key to continue                       *|");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     ------------------------------------------------------------------");
        
        

                        }
 
                        ReadKey();
                        clearBoard();
                        gameModes();

                        break;

                    }
                
                
                
                if (((gamePlatform[0] == setPiece) && (gamePlatform[5] == setPiece) && (gamePlatform[10] == setPiece) && (gamePlatform[15] == setPiece) && (gamePlatform[20] == setPiece))
                        || ((gamePlatform[1] == setPiece) && (gamePlatform[6] == setPiece) && (gamePlatform[11] == setPiece) && (gamePlatform[16] == setPiece) && (gamePlatform[21] == setPiece))
                        || ((gamePlatform[2] == setPiece) && (gamePlatform[7] == setPiece) && (gamePlatform[12] == setPiece) && (gamePlatform[17] == setPiece) && (gamePlatform[22] == setPiece))
                        || ((gamePlatform[3] == setPiece) && (gamePlatform[8] == setPiece) && (gamePlatform[13] == setPiece) && (gamePlatform[18] == setPiece) && (gamePlatform[23] == setPiece))
                        || ((gamePlatform[4] == setPiece) && (gamePlatform[9] == setPiece) && (gamePlatform[14] == setPiece) && (gamePlatform[19] == setPiece) && (gamePlatform[24] == setPiece)))
                    {
                        Clear();

                  

                        if (setPiece == playerOnePiece)
                        {
                            ++playerOneScore;

                        WriteLine("\n \n \n ");
            WriteLine("                     ------------------------------------------------------------------");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 {0} is the champion                           *|",playerOneName);
            WriteLine("                     |*                  Vertical Vitory                              *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 Your Score is {0}                             *|",playerOneScore);
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*               Press any key to continue                       *|");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     ------------------------------------------------------------------");
        
        




                           
                        }
                        else if (setPiece == playerTwoPiece)
                        {
                            ++playerTwoScore;
                           
                        WriteLine("\n \n \n ");
            WriteLine("                     ------------------------------------------------------------------");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 {0} is the champion                           *|",playerTwoName);
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 Vertical Vitory                               *|");
            WriteLine("                     |*                 Your Score is {0}                             *|",playerTwoScore);
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*               Press any key to continue                       *|");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     ------------------------------------------------------------------");
        
        

                        }
                        
                        ReadKey();
                        clearBoard();
                        gameModes();

                        break;
                    } if (((gamePlatform[0] == setPiece) && (gamePlatform[6] == setPiece) && (gamePlatform[12] == setPiece) && (gamePlatform[18] == setPiece) && (gamePlatform[24] == setPiece))
                        || ((gamePlatform[4] == setPiece) && (gamePlatform[8] == setPiece) && (gamePlatform[12] == setPiece) && (gamePlatform[16] == setPiece) && (gamePlatform[20] == setPiece)))
                    {
                        Clear();
                       if (setPiece == playerOnePiece)
                        {
                            ++playerOneScore;
                       
                        WriteLine("\n \n \n ");
            WriteLine("                     ------------------------------------------------------------------");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 {0} is the champion                           *|",playerOneName);
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                  Diagonal Vitory                              *|");
            WriteLine("                     |*                 Your Score is {0}                             *|",playerOneScore);
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*               Press any key to continue                       *|");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     ------------------------------------------------------------------");
        
        
                        }
                        else if (setPiece == playerTwoPiece)
                        {
                            ++playerTwoScore;
                                                   WriteLine("\n \n \n ");
            WriteLine("                     ------------------------------------------------------------------");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 {0} is the champion                           *|",playerTwoName);
            WriteLine("                     |*                   Diagonal Vitory                             *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                 Your Score is {0}                             *|",playerTwoScore);
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*                                                               *|");
            WriteLine("                     |*               Press any key to continue                       *|");
            WriteLine("                     |*****************************************************************|");
            WriteLine("                     ------------------------------------------------------------------");
        
        
                        }
                        WriteLine("\nPress any key to reset the game");
                        ReadKey();
                        clearBoard();
                        gameModes();

                        break;
                    }
                }

           



        }


                public static void clearBoard()
        {
            string[] newBoard = { "01","02" , "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13","14","15","16","17", "18", "19", "20", "21","22", "23", "24", "25","26" };
            gamePlatform = newBoard;

        }




  public static string[] decideTurns(string selectedNum,string playerOnePiece,string playerTwoPiece,int playerNum,string playerName,string playerOneName,string  playerTwoName,string setPiece) {


            if (playerNum == 1) {
                       playerName=playerTwoName;
            setPiece=playerTwoPiece;
            playerNum=2;    
          
            } else {
 
              playerName=playerOneName;
            setPiece=playerOnePiece;
            playerNum=1;
            
            
            }

            string[] turnResults = {playerName,setPiece,playerNum.ToString()};

            return turnResults;



        }

        public static string[] gamePlatform = { "01","02" , "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13","14","15","16","17", "18", "19", "20", "21","22", "23", "24", "25","26" };


        public static void gameBoard() {


            WriteLine("                                        ---------------------------------------");
            WriteLine("                                        | {0}   |  {1}   |  {2}   |  {3}   |  {4}  |", gamePlatform[0], gamePlatform[1], gamePlatform[2], gamePlatform[3], gamePlatform[4]);
            WriteLine("                                        ---------------------------------------");
            WriteLine("                                        | {0}   |  {1}   |  {2}   |  {3}   |  {4}  |", gamePlatform[5], gamePlatform[6], gamePlatform[7], gamePlatform[8], gamePlatform[9]);
            WriteLine("                                        ---------------------------------------");
            WriteLine("                                        | {0}   |  {1}   |  {2}   |  {3}   |  {4}  |", gamePlatform[10], gamePlatform[11], gamePlatform[12], gamePlatform[13], gamePlatform[14]);
            WriteLine("                                        ---------------------------------------");
            WriteLine("                                        | {0}   |  {1}   |  {2}   |  {3}   |  {4}  |", gamePlatform[15], gamePlatform[16], gamePlatform[17], gamePlatform[18], gamePlatform[19]);
            WriteLine("                                        ---------------------------------------");
            WriteLine("                                        | {0}   |  {1}   |  {2}   |  {3}   |  {4}  |", gamePlatform[20], gamePlatform[21], gamePlatform[22], gamePlatform[23], gamePlatform[24]);
            WriteLine("                                        |______|_______|_______|_______|______|");


        }





    }

}

