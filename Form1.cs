using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //Variables

        //Bot
        public static bool botplayerExists;
        public static bool botplayerTurn;
        //Multiple players

        public static bool igofirst;
        public static string[] xoArray = new string[] { "X", "O" };
        public static int turn = 1;

        //Keeping score on UI and in file
        public string path = @"C:\ProgramData\TicTacToe.txt";
        public static int P1Count = 0;
        public static int DrawCount = 0;
        public static int P2Count = 0;

        //2 because we need to check wether the value has been changed
        //(only possible values in program are 0 or 1)
        //and we don't want to use nullable int because if we do we constantly
        //have to convert back to non nullable int
        public static int selectIndex = 2;

        public Form1()
        {
            //Start of program
            InitializeComponent();

            //Hides the game form while we get info through the other two forms
            this.Hide();

            //Ask who is playing, player + friend/bot
            Form3 Players = new Form3();
            Players.ShowDialog();

            //Ask who is going to take the first turn
            Form2 WhoGoes = new Form2();
            WhoGoes.ShowDialog();

            //Depending on who goes first, set proper label
            label1.Text = (xoArray[selectIndex] + "'S TURN");

            //Check if there are saved scores already
            CheckFile();

            //If the bot is playing and it goes first
            if (botplayerExists == true && igofirst == false)
            {
                ComputerMove();
            }
        }

        //This creates a scoring file at variable path, otherwise it reads the current score into variables
        public void CheckFile()
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("0");
                    sw.WriteLine("0");
                    sw.WriteLine("0");
                }
            }
            else
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    P1Count = int.Parse(sr.ReadLine());
                    DrawCount = int.Parse(sr.ReadLine());
                    P2Count = int.Parse(sr.ReadLine());
                    label2.Text = ("X: " + P1Count.ToString());
                    label3.Text = ("Draw: " + DrawCount.ToString());
                    label4.Text = ("O: " + P2Count.ToString());
                }
            }
        }

        //Restart button, show basic box with application restart if yes
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult restartResult = MessageBox.Show("Restart?", "Restart", MessageBoxButtons.YesNo);
            if (restartResult == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        //Moves
        //These all work the same, check that the button hasn't already been clicked
        //If it hasn't then change its text and then do all the winner logic, turn counter and setting it to other players turn
        //If there is a bot player then allow the bot to take it's turn
        //-------------------------------------------------------------------------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckValue(button2.Text))
            {
                button2.Text = xoArray[selectIndex];
                CheckWinner();
                TurnCounter();
                ChangePlayerIndex(selectIndex);
            }
            if (botplayerExists) { ComputerMove(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CheckValue(button3.Text))
            {
                button3.Text = xoArray[selectIndex];
                CheckWinner();
                TurnCounter();
                ChangePlayerIndex(selectIndex);
            }
            if (botplayerExists) { ComputerMove(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CheckValue(button4.Text))
            {
                button4.Text = xoArray[selectIndex];
                CheckWinner();
                TurnCounter();
                ChangePlayerIndex(selectIndex);
            }
            if (botplayerExists) { ComputerMove(); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (CheckValue(button5.Text))
            {
                button5.Text = xoArray[selectIndex];
                CheckWinner();
                TurnCounter();
                ChangePlayerIndex(selectIndex);
            }
            if (botplayerExists) { ComputerMove(); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (CheckValue(button6.Text))
            {
                button6.Text = xoArray[selectIndex];
                CheckWinner();
                TurnCounter();
                ChangePlayerIndex(selectIndex);
            }
            if (botplayerExists) { ComputerMove(); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (CheckValue(button7.Text))
            {
                button7.Text = xoArray[selectIndex];
                CheckWinner();
                TurnCounter();
                ChangePlayerIndex(selectIndex);
            }
            if (botplayerExists) { ComputerMove(); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (CheckValue(button8.Text))
            {
                button8.Text = xoArray[selectIndex];
                CheckWinner();
                TurnCounter();
                ChangePlayerIndex(selectIndex);
            }
            if (botplayerExists) { ComputerMove(); }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (CheckValue(button9.Text))
            {
                button9.Text = xoArray[selectIndex];
                CheckWinner();
                TurnCounter();
                ChangePlayerIndex(selectIndex);
            }
            if (botplayerExists) { ComputerMove(); }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (CheckValue(button10.Text))
            {
                button10.Text = xoArray[selectIndex];
                CheckWinner();
                TurnCounter();
                ChangePlayerIndex(selectIndex);
            }
            if (botplayerExists) { ComputerMove(); }
        }
        //------------------------------------------------------------------------ END OF MOVES -----------------------------------------------

        //If the button's text IS NOT EMPTY, return false to not run the code
        //Stops us from changing the value of an already clicked button
        public static bool CheckValue(string text)
        {
            if (text != String.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Changes the turn index, so if it was X's turn it is now O's
        public void ChangePlayerIndex(int currentIndex)
        {
            if (currentIndex == 1)
            {
                selectIndex = 0;
            }
            else
            {
                selectIndex = 1;
            }
            label1.Text = (xoArray[selectIndex] + "'S TURN");
        }

        public void TurnCounter()
        {
            //If 9 turns have been taken then we have filled all the spaces
            //If no one has won and all spaces are filled then it's a draw
            if (turn == 9)
            {
                DrawCount += 1;
                EndOfGame("IT'S A DRAW!");
            }
            turn += 1;
        }

        //This Function checks if someone has won the game.
        //The way it does this is by creating a couple loops and then iterating in these through a list of all our buttons
        //In the button list buttons[0] and buttons[10] are nnot related to the game but are for reset and restart
        //For an illustration of the loop logic, check out the winnerLogic.png
        //For a more in depth explaination check the TicTacToeAvailable function's comments
        public void CheckWinner()
        {
            //Works but grabs the buttons in the opposite direction? Like button11 becomes buttons[0] and button1 becomes buttons[10]?
            Button[] buttons = Controls.OfType<Button>().ToArray();

            //We nest all our if statements for readability, hopefully the compiler should deal with performance loss for us :)
            for (int i = 0; i <= 2; i++)
            {
                //Columns
                //Make sure the columns don't have the same text == ""
                if (buttons[(i * 1) + 1].Text != String.Empty)
                {
                    //Check if top and middle button has the same text
                    if (buttons[(i * 1) + 1].Text == buttons[(i * 1) + 4].Text)
                    {
                        //Check if middle and lower button has the same text
                        if (buttons[(i * 1) + 4].Text == buttons[(i * 1) + 7].Text)
                        {
                            //If all 3 buttons in the same column has the same text and not "" then whoever owns one of these buttons wins
                            WinnerByButton(buttons[(i * 1) + 1]);
                        }
                    }
                }

                //Rows
                //Make sure the rows don't have the same text == ""
                if (buttons[(i * 3) + 1].Text != String.Empty)
                {
                    //Check if left and middle button has the same text
                    if (buttons[(i * 3) + 1].Text == buttons[(i * 3) + 2].Text)
                    {
                        //Check if middle and right button has the same text
                        if (buttons[(i * 3) + 2].Text == buttons[(i * 3) + 3].Text)
                        {
                            //If all 3 buttons in the same row has the same text and not "" then whoever owns one of these buttons wins
                            WinnerByButton(buttons[(i * 3) + 1]);
                        }
                    }
                }
            }

            //Diagonals
            //Loop to avoid repeating ourselves too much, use different loop than above since here we only loop 0 to 1
            //rather than 0 to 2
            for (int i = 0; i <= 1; i++)
            {
                //Make sure the diagonal isn't empty
                if (buttons[(i * 2) + 1].Text != String.Empty)
                {
                    //Check if top and middle button has the same text
                    if (buttons[(i * 2) + 1].Text == buttons[5].Text)
                    {
                        //Check if middle and bottom button has the same text
                        if (buttons[5].Text == buttons[9 - (i * 2)].Text)
                        {
                            //If all 3 buttons in the same diagonal has the same text and not "" then whoever owns one of these buttons wins
                            WinnerByButton(buttons[(i * 2) + 1]);
                        }
                    }
                }
            }
        }

        //Common win function to avoid repeating ourselves too much
        //Just takes in a button and it's text changes the outcome
        public void WinnerByButton(Button button)
        {
            if (button.Text == "X")
            {
                P1Count += 1;
                EndOfGame("X Wins!");
            }

            else
            {
                P2Count += 1;
                EndOfGame("O Wins!");
            }
        }

        //Endscreen
        public void EndOfGame(string endOfGameText)
        {
            using (StreamWriter writer = File.CreateText(path))
            {
                writer.WriteLine("{0}", P1Count);
                writer.WriteLine("{0}", DrawCount);
                writer.WriteLine("{0}", P2Count);
            }

            MessageBox.Show(endOfGameText);
            DialogResult restartResult = MessageBox.Show("Restart?", "Restart", MessageBoxButtons.YesNo);
            if (restartResult == DialogResult.Yes)
            {
                Application.Restart();
                Environment.Exit(0);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        //The main BOT function
        public void ComputerMove()
        {
            //Works but grabs the buttons in the opposite direction? Like button11 becomes buttons[0] and button1 becomes buttons[10]?
            Button[] buttons = Controls.OfType<Button>().ToArray();

            //Priorities for the bot when it plays tictactoe
            //1. Get Tic Tac Toe
            //2. Block Tic Tac Toe
            //3. Pick empty space, we're going to go simple and just pick a random spot

            //We put the tictactoe checking in another function and save the return value, with 0 = no one can win
            int someoneCanWin = TicTacToeAvailable(buttons);

            //1 or 2
            //Someone can win so we either want to win ourselves or block the player from winning
            if (someoneCanWin != 0)
            {
                //Get the button where winning is possible and take it
                buttons[someoneCanWin].Text = "O";

                //Change who's turn is next
                ChangePlayerIndex(selectIndex);

                //Check if anyone has won and if not, make it a draw
                CheckWinner();
                TurnCounter();
            }

            //3
            else
            {
                Random random = new Random();
                bool keepGoing = true;

                while (keepGoing)
                {
                    //Pick a random button and if that one hasn't been taken
                    int number = random.Next(1, 9);
                    if (buttons[number].Text == String.Empty)
                    {
                        //Take the button
                        buttons[number].Text = "O";

                        //Stop the loop
                        keepGoing = false;

                        //Same as if player clicked button
                        CheckWinner();
                        TurnCounter();
                        ChangePlayerIndex(selectIndex);
                    }
                }
            }
        }

        //This is for the bot, it checks wether or not a player can get tictactoe
        //Allowing the bot to get tictactoe or stop the human player from getting it
        //This just takes in wether we can tictactoe then returns the button where it is possible
        //If there is none, we return 0
        public int TicTacToeAvailable(Button[] buttons)
        {
            //For visualization of the logic here, check winnerLogic.png

            //Basically the buttons that we can click to place our X or O are in an array with indexes 1 to 9
            //Then we just loop through all tictactoe possibilities

            //  1  2  3
            //  4  5  6
            //  7  8  9

            //First column here is [(i * 1) + 1] == [(i * 1) + 4] == [(i * 1) + 7] and of course != String.Empty, the default value
            //When i = 0:          Button 0 + 1  == Button 0 + 4  == Button 0 + 7, buttons 1, 4, 7
            //When i = 1:          Button 1 + 1  == Button 1 + 4  == Button 1 + 7, buttons 2, 5, 8, the second column
            for (int i = 0; i <= 2; i++)
            {
                //Columns
                //X on Top
                if (buttons[(i * 1) + 1].Text == String.Empty && buttons[(i * 1) + 4].Text == buttons[(i * 1) + 7].Text && buttons[(i * 1) + 7].Text != String.Empty)
                {
                    return (i * 1) + 1;
                }
                //X on Middle
                else if (buttons[(i * 1) + 4].Text == String.Empty && buttons[(i * 1) + 1].Text == buttons[(i * 1) + 7].Text && buttons[(i * 1) + 7].Text != String.Empty)
                {
                    return (i * 1) + 4;
                }
                //X on Bottom
                else if (buttons[(i * 1) + 7].Text == String.Empty && buttons[(i * 1) + 1].Text == buttons[(i * 1) + 4].Text && buttons[(i * 1) + 4].Text != String.Empty)
                {
                    return (i * 1) + 7;
                }

                //Rows
                //X on Left
                if (buttons[(i * 3) + 1].Text == String.Empty && buttons[(i * 3) + 2].Text == buttons[(i * 3) + 3].Text && buttons[(i * 3) + 3].Text != String.Empty)
                {
                    return (i * 3) + 1;
                }
                //X on Middle
                else if (buttons[(i * 3) + 2].Text == String.Empty && buttons[(i * 3) + 1].Text == buttons[(i * 3) + 3].Text && buttons[(i * 3) + 3].Text != String.Empty)
                {
                    return (i * 3) + 2;
                }
                //X on Right
                else if (buttons[(i * 3) + 3].Text == String.Empty && buttons[(i * 3) + 1].Text == buttons[(i * 3) + 2].Text && buttons[(i * 3) + 2].Text != String.Empty)
                {
                    return (i * 3) + 3;
                }
            }

            //Diagonals
            for (int i = 0; i <= 1; i++)
            {
                //X on Top
                if (buttons[(i * 2) + 1].Text == String.Empty && buttons[5].Text == buttons[9 - (i * 2)].Text && buttons[9 - (i * 2)].Text != String.Empty)
                {
                    return (i * 2) + 1;
                }
                //X on Middle
                else if (buttons[5].Text == String.Empty && buttons[(i * 2) + 1].Text == buttons[9 - (i * 2)].Text && buttons[9 - (i * 2)].Text != String.Empty)
                {
                    return 5;
                }
                //X on Bottom
                else if (buttons[(i * 3) + 3].Text == String.Empty && buttons[(i * 2) + 1].Text == buttons[5].Text && buttons[5].Text != String.Empty)
                {
                    return 9 - (i * 2);
                }
            }

            return 0;
        }

        //Reset button, set everything to 0 write it out in our file and on our UI
        private void button11_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("0");
                sw.WriteLine("0");
                sw.WriteLine("0");
            }

            label2.Text = ("X: 0");
            label3.Text = ("Draw: 0");
            label4.Text = ("O: 0");

            P1Count = 0;
            P2Count = 0;
            DrawCount = 0;
        }
    }
}
