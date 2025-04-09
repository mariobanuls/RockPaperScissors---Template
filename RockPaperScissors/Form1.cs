using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

/// <summary>
/// A rock, paper, scissors game that utilizes basic methods
/// for repetitive tasks.
/// </summary>

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        string playerChoice, cpuChoice;

        int wins = 0;
        int losses = 0;
        int ties = 0;
        int choicePause = 1000;
        int outcomePause = 3000;

        Random randGen = new Random();

        SoundPlayer jabPlayer = new SoundPlayer(Properties.Resources.jabSound);
        SoundPlayer gongPlayer = new SoundPlayer(Properties.Resources.gong);

        Image rockImage = Properties.Resources.rock168x280;
        Image paperImage = Properties.Resources.paper168x280;
        Image scissorImage = Properties.Resources.scissors168x280;
        Image winImage = Properties.Resources.winTrans;
        Image loseImage = Properties.Resources.loseTrans;
        Image tieImage = Properties.Resources.tieTrans;

        public Form1()
        {
            InitializeComponent();
            
        }


        //makes the players choice be rock and runs the rest methods
        //it also sets the image to rock
        private void rockButton_Click(object sender, EventArgs e)
        {
            playerChoice = "rock";
            playerImage.BackgroundImage = rockImage;
            CpuTurn();
            CalculateResult();
            gongPlayer.Play();
            DelayDelete();
        }


        //makes the players choice be paper and runs the rest methods
        //it also sets the image to paper
        private void paperButton_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            playerImage.BackgroundImage = paperImage;
            CpuTurn();
            CalculateResult();
            gongPlayer.Play();
            DelayDelete();
        }


        //makes the players choice be scissors and runs the rest methods
        //it also sets the image to scissor
        private void scissorsButton_Click(object sender, EventArgs e)
        {
            playerChoice = "scissor";
            playerImage.BackgroundImage = scissorImage;
            CpuTurn();
            CalculateResult();
            Refresh();
            DelayDelete();
        }


        //generates a random decision that will be the cpu's choice
        private void CpuTurn()
        {
            int randValue = randGen.Next(1, 4);
            if (randValue == 1)
            {
                cpuImage.BackgroundImage = rockImage;
                cpuChoice = "rock";
            }
            else if (randValue == 2)
            {
                cpuImage.BackgroundImage = paperImage;
                cpuChoice = "paper";
            }
            else
            {
                cpuImage.BackgroundImage = scissorImage;
                cpuChoice = "scissor";
            }
        }


        //decides the winner depending on the player's and cpu's choices. 
        //changes the images and updates the scoreboard
        private void CalculateResult()
        {

            if  (((cpuChoice == "rock") && (playerChoice == "paper")) || ((cpuChoice == "paper") && (playerChoice == "scissor")) || ((cpuChoice == "scissor") && (playerChoice == "rock")))
            {
                wins++;
                resultImage.BackgroundImage = winImage;
                winsLabel.Text = $"Wins: {wins}";
            }
            else if (cpuChoice == playerChoice)
            {
                ties++;
                resultImage.BackgroundImage = tieImage;
                tiesLabel.Text = $"Ties: {ties}";
            }
            else 
            {
                losses++;
                resultImage.BackgroundImage = loseImage;
                lossesLabel.Text = $"Losses: {losses}";
            }
            
        }


        //waits for a while and resets the images
        private void DelayDelete()
        {
            Refresh();
            Thread.Sleep(outcomePause);
            resultImage.BackgroundImage = null;
            cpuImage.BackgroundImage = null;
            playerImage.BackgroundImage = null;
        }
        




    }
}