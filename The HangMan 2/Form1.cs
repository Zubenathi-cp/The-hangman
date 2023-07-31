//Author : Zubenathi Mateza
//File Name : The Hangman
//Module Name : Basic c# programming
//Project Number : 1
//Date : 29 March 2023
//Descriotion : This is a game called 'The Hangman', a player is asked to enter letters in order to correctly guess the given word!



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_HangMan_2
{

    public partial class Form1 : Form
    {
        //These are fields that will be needed in the code below
        int score = 0;
        string word = "";
        List<Label> labels = new List<Label>();
        int tries = 0;

       

        public void LabelsChar()
        {
             word = randoWord();


            // Array for the characters
            char[] chars = word.ToCharArray();
            int spaceBetween = 330 / chars.Length;
            for (int i = 0; i < chars.Length; i++)
            {
                labels.Add(new Label()); // intialisation
                labels[i].Location = new Point((i * spaceBetween) + 10, 80); //The space between each underscore is always 40 on the same y-axis of 80. 
                labels[i].Text = "___"; // Displays the underscore where the input will be displayed
                labels[i].Parent = groupBox1; //Declaring where the above will be located
                labels[i].BringToFront();
                labels[i].CreateControl();
            }
            // The Word Length counter
            lblWordLength.Text = "Word Length : " + (chars.Length).ToString() + " " + "letters";




        }


        string randoWord()
        {

            // Below here are the word the will be used in the game

            string[] wordList = new string[10];

            wordList[0] = "red";
            wordList[1] = "blue";
            wordList[2] = "black";
            wordList[3] = "white";
            wordList[4] = "orange";
            wordList[5] = "gray";
            wordList[6] = "coral";
            wordList[7] = "teal";
            wordList[8] = "tan";
            wordList[9] = "violet";


            //random class 

            Random ran = new Random();
            return wordList[ran.Next(0, wordList.Length)];
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LabelsChar();
        }

        public void resetHangman()
        {
            randoWord();
            LabelsChar();
            lblIncorrectGuesses.Text = "Missed: ";
           // lblPlayerScore.Text = "The Score: ";



        }

        
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //The code below will allow the user to use keypresses when enter a letter
            char guessedLetter = char.ToLower(e.KeyChar);
            lblOutput.Text = guessedLetter.ToString();
            

            

            //This code the computer to returns an error messsage when the user enters something thats not a letter
            if (!char.IsLetter(guessedLetter))
            {
                MessageBox.Show("THIS TEXTBOX ONLY ACCEPTS LETTERS!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //The code that checks whether the guessed letter is found in chosen word
            if (word.Contains(guessedLetter))
            {
                char[] guessedletters = word.ToCharArray();
                for (int i = 0; i < guessedletters.Length; i++)
                {
                    if (guessedletters[i] == guessedLetter)
                    {
                        labels[i].Text = guessedLetter.ToString();

                        // The score of the player is added
                        score++;
                        lblPlayerScore.Text = "Your current score: " + score.ToString();// Display the score to the label
                        


                        // The foreach loop checks the unscore place holderss if they are 
                        foreach (Label b in labels)
                            if (b.Text == "___") return;
                        MessageBox.Show("Congratulations you have WON!", "WINNER!!!!!!");
                        ;

                        //After the user has guessed the word, the game to a new game 
                        resetHangman();
                        

                        //This adds the score(s) of the the player with a timeStamp in Hours:Minutes:Seconds  
                        DateTime timeStamp = DateTime.Now;
                        string timeStampString = timeStamp.ToString("HH:mm:ss");
                        string item1 = lblPlayerScore.Text;
                        string formattedString = $"{timeStampString}:  {item1}";
                        listBox1.Items.Add(formattedString);

                    }





                }
            }
            else
            {
                //The condition if you get the character entered incorrect 
                MessageBox.Show("SORRY!! Wrong letter", "Try again!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//Message for the incorrect word entered
                lblIncorrectGuesses.Text += " " + guessedLetter.ToString() + ",";
                tries++;


                // if statement for when the number of guesses entred when playing [the maximum number of attempts is 10 for every word]
                if (tries == 10)
                {
                    MessageBox.Show("Sorry man you have used all your attempts" + "\n" + "\n" + "The word was acctually: " + word + "\n" + "\n" + "Try again in the next game", "Game Over!!!!");
                    resetHangman();

                }

            }

           

           
        }


        

    

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            
            resetHangman();
            
        }

        private void lblPlayerScore_Click(object sender, EventArgs e)
        {

        }

        

        private void lblOutput_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          