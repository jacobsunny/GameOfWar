/*
 * Author: Jacob Sunny
 * War game 
 * 1/23/2019
 * 
 */



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WARGame.Properties;

namespace WARGame
{

    public partial class Game : Form
    {



        Random rnd = new Random();
        int card = 0;
        int card2 = 0;
        int warCard1 = 0;
        int warCard2 = 0;
        bool isWar = false;


        // setting facedown to picture of a card face down
        Image facedown = Resources.facedown;


        // a List of images with images values
        List<Image> image = new List<Image>{ Resources._0, Resources._1,Resources._2,Resources._3,Resources._4,
                Resources._5,Resources._6,Resources._7, Resources._8,Resources._9,Resources._10,Resources._11,
                Resources._12,Resources._13,Resources._14, Resources._15,Resources._16,Resources._17,Resources._18,
                Resources._19,Resources._20,Resources._21, Resources._22,Resources._23,Resources._24,Resources._25,
                Resources._26,Resources._27,Resources._28, Resources._29,Resources._30,Resources._31,Resources._32,
                Resources._33,Resources._34,Resources._35, Resources._36,Resources._37,Resources._38,Resources._39,
                Resources._40,Resources._41,Resources._42,Resources._43, Resources._44,Resources._45,Resources._46,Resources._47,
                Resources._48,Resources._49,Resources._50, Resources._51
            };
        //declaring two list images 
        List<Image> player1 = new List<Image> { };
           List<Image> player2 = new List<Image> { };

       
        public Game()
        {
            InitializeComponent();
         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // button event handler for draw button
        private void button1_Click(object sender, EventArgs e)
        {
            // Setting random values to variables
            card = rnd.Next(player1.Count);
            card2 = rnd.Next(player2.Count);
            //pictureBox2.Image = Resources._0;
           
            // assigning a picture to a picture box
            pictureBox3.Image = player1[card];
            pictureBox2.Image = player2[card2];

            // Removing current picture from list because its been drawn
            player1.Remove(pictureBox3.Image);
            player2.Remove(pictureBox2.Image);

            //UI Changes
            BtnTakeCardP1.Visible = true;
            btnTakeCardP2.Visible = true;
            btnDraw.Visible = false;
          
            // Returns the count for each string.
            label1.Text = player1.Count.ToString();
            label2.Text = player2.Count.ToString();
            isWar = false;

            btnWar.Visible = true;

        }

        private void Game_Load(object sender, EventArgs e)
        {

            isWar = false;
            // UI Changes
            BtnTakeCardP1.Visible = false;
            btnTakeCardP2.Visible = false;
            btnDrawWar.Visible = false;
            btnWar.Visible = false;

            // Randomly ordering the image List
            image = image.OrderBy(i => rnd.Next()).ToList();

            // dividing 52 cards in the Image list to two other lists
            player1 = image.Take(image.Count/ 2).ToList();
            player2 = image.Skip(image.Count / 2).ToList();

            //player1 = image.Take(26).ToList();
            //player2 = image.Skip(26).Take(26).ToList();

            // Returns the count for each list
            label1.Text = player1.Count.ToString();
            label2.Text = player2.Count.ToString();

            //UI Changes
            pictureBox1.Image = facedown;
            pictureBox2.Image = facedown;
            pictureBox3.Image = facedown;
            pictureBox4.Image = facedown;    
        }

        // Button event handle for player2 to take cards
        private void btnTakeCardP2_Click(object sender, EventArgs e)
        {

            btnDraw.Visible = true;

            if (isWar == true)
            {
                //Removing the picture from the list
                player1.Remove(pictureP1War1.Image);
                player2.Remove(pictureP2War1.Image);

                //Adding pictures items to player 2 
                player2.Add(pictureP2War1.Image);
                player2.Add(pictureP2War2.Image);

                player2.Add(pictureP1War1.Image);
                player2.Add(pictureP1War2.Image);

                player2.Add(pictureBox3.Image);
                player2.Add(pictureBox2.Image);
             
                // returns the count of each list
                label1.Text = player1.Count.ToString();
                label2.Text = player2.Count.ToString();
                //Checks to see if there is a winner
                Winner();
                // UI changes
                pictureP1War1.Visible = false;
                pictureP1War2.Visible = false;
                pictureP2War1.Visible = false;
                pictureP2War2.Visible = false;
                BtnTakeCardP1.Visible = false;
                btnTakeCardP2.Visible = false;
                btnWar.Visible = false;
                btnDrawWar.Visible = false;
                pictureBox2.Image = Resources.facedown;
                pictureBox3.Image = Resources.facedown;
                //Resetting boolean isWar false to false
                isWar = false;
            }
            else
            {
                //Resetting boolean isWar false to false
                isWar = false;

                // Adds the pictures items to player 2 list
                player2.Add(pictureBox3.Image);
                player2.Add(pictureBox2.Image);

                pictureBox2.Image = Resources.facedown;
                pictureBox3.Image = Resources.facedown;

               
                BtnTakeCardP1.Visible = false;
                btnTakeCardP2.Visible = false;



                btnWar.Visible = false;
                // Return count of each list
                label1.Text = player1.Count.ToString();
                label2.Text = player2.Count.ToString();
                Winner();

            }
        }

        private void btnWar_Click(object sender, EventArgs e)
        {
            // method called
            war();
           
        }

        // This method will handel war scenario
        private void war()
        {
            btnDrawWar.Visible = true;
            btnDraw.Visible = false;
            // get a random integer from the lists
            card = rnd.Next(player1.Count);
            card2 = rnd.Next(player2.Count);

            // get a random integer from the lists
            warCard1 = rnd.Next(player1.Count);
            warCard2 = rnd.Next(player2.Count);

            //Setting Picturebox values
            pictureP1War1.Image = player1[warCard1];
            pictureP2War1.Image = player2[warCard2];

            //Setting Picture box values
            pictureP1War2.Image = player1[card];
            pictureP2War2.Image = player2[card2];

            //Assigning Values to player list
            player1[card2] = pictureP1War2.Image;
            player2[card2] = pictureP2War2.Image;
            player1[warCard1] = pictureP1War1.Image;
            player2[warCard2] = pictureP2War1.Image;
           
            // removing items 
            player1.Remove(pictureP1War2.Image);
            player2.Remove(pictureP2War2.Image);
            // UI Channges
            btnDraw.Visible = false;
            pictureP1War1.Visible = true;
            pictureP1War2.Visible = true;
            pictureP2War1.Visible = true;
            pictureP2War2.Visible = true;
            // returns the count of the lists
            label1.Text = player1.Count.ToString();
            label2.Text = player2.Count.ToString();
            btnDrawWar.Visible = false;
            isWar = true;
           
            Winner();
        }

        // this button event handler is used to draw cards while in war mode
        private void btnDrawWar_Click(object sender, EventArgs e)
        {

            // get a random integer from the lists
            card = rnd.Next(player1.Count);
            card2 = rnd.Next(player2.Count);
            // Setting picture box to an item in the list
            pictureP1War2.Image = player1[card];
            pictureP2War2.Image = player2[card2];

            player1[card] = pictureP1War2.Image;
            player2[card2] = pictureP2War2.Image;
            //Removing itmes b/c card is drawn
            player1.Remove(pictureP1War2.Image);
            player2.Remove(pictureP2War2.Image);

            // returns the count of the list
            label1.Text = player1.Count.ToString();
            label2.Text = player2.Count.ToString();
            Winner();
        }

        // button event handler for player 1 to take cards 
        private void BtnTakeCardP1_Click(object sender, EventArgs e)
        {

            btnDraw.Visible = true;

            if (isWar == true)
            {
                // removing items from the list
                player1.Remove(pictureP1War1.Image);
                player2.Remove(pictureP2War1.Image);

                // adding items to player1 list
                player1.Add(pictureP2War1.Image);
                player1.Add(pictureP2War2.Image);
                player1.Add(pictureP1War1.Image);
                player1.Add(pictureP1War2.Image);
                player1.Add(pictureBox3.Image);
                player1.Add(pictureBox2.Image);
                //returning count of list
                label1.Text = player1.Count.ToString();
                label2.Text = player2.Count.ToString();
                Winner();
                // UI Changes
                pictureP1War1.Visible = false;
                pictureP1War2.Visible = false;
                pictureP2War1.Visible = false;
                pictureP2War2.Visible = false;
                BtnTakeCardP1.Visible = false;
                btnTakeCardP2.Visible = false;
                btnWar.Visible = false;
                btnDrawWar.Visible = false;
                pictureBox2.Image = Resources.facedown;
                pictureBox3.Image = Resources.facedown;
                isWar = false;

            }
            else
            {
                isWar = false;


                // adding items to player 1 list
                player1.Add(pictureBox3.Image);
                player1.Add(pictureBox2.Image);



                pictureBox2.Image = Resources.facedown;
                pictureBox3.Image = Resources.facedown;
                
                //UI Changes
                BtnTakeCardP1.Visible = false;
                btnTakeCardP2.Visible = false;

                
                btnWar.Visible = false;

                // Return count for lists
                label1.Text = player1.Count.ToString();
                label2.Text = player2.Count.ToString();
                Winner();
            }
        }

        // Method to check if there is a winner. If a player obtains 52 cards, they win the game
        public void Winner()
        {
            // condition
            if(player1.Count == 52)
            {
                MessageBox.Show("Player1 Won");
                this.Hide();//closes form
                Form1 fm = new Form1();
                fm.Show();//Form 1 shown
            }
            //Condition
            if(player2.Count == 52)
            {
                MessageBox.Show("Player2 Won!");
                this.Hide();// closes form
                Form1 fm = new Form1();
                fm.Show();
            }

        }


           

        }
    }

