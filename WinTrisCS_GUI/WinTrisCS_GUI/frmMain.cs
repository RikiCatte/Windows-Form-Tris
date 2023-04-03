using System;
using System.Windows.Forms;

namespace WinTrisCS_GUI
{
    public partial class frmMain : Form
    {
        //TAG=0 PIC EMPTY, TAG=1 PLAYER1, TAG=2 PLAYER2

        uint matchesCount;
        int victoriesCount; // Incremented if there is a victory, decrement if not
        uint winRate; // wins / defeats %
        Random r = new Random();
        int picChoosen;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = "WinTris by RikiCatte#1371";
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            StartPosition = FormStartPosition.CenterScreen;
            txtMatches.ReadOnly = true;
            txtVictories.ReadOnly = true;
            txtWinRate.ReadOnly = true;
            matchesCount = 0;
            victoriesCount = 0;
            Initialize();
        }

        /// <summary>
        /// Initializes the game field, MUST be called at the beginning of every match
        /// </summary>
        private void Initialize()
        {
            pic1.Image = pic12.Image;
            pic2.Image = pic12.Image;
            pic3.Image = pic12.Image;
            pic4.Image = pic12.Image;
            pic5.Image = pic12.Image;
            pic6.Image = pic12.Image;
            pic7.Image = pic12.Image;
            pic8.Image = pic12.Image;
            pic9.Image = pic12.Image;
            pic1.Tag = "0";
            pic2.Tag = "0";
            pic3.Tag = "0";
            pic4.Tag = "0";
            pic5.Tag = "0";
            pic6.Tag = "0";
            pic7.Tag = "0";
            pic8.Tag = "0";
            pic9.Tag = "0";
        }

        /// <summary>
        /// Must be called when a player finishes his turn, in this way the enemy cannot overwrite an already occupied field
        /// </summary>
        private void SwitchPlayer()
        {
            pic1.Enabled = !pic1.Enabled;
            pic2.Enabled = !pic2.Enabled;
            pic3.Enabled = !pic3.Enabled;
            pic4.Enabled = !pic4.Enabled;
            pic5.Enabled = !pic5.Enabled;
            pic6.Enabled = !pic6.Enabled;
            pic7.Enabled = !pic7.Enabled;
            pic8.Enabled = !pic8.Enabled;
            pic9.Enabled = !pic9.Enabled;
        }

        /// <summary>
        /// Updates the score in the relatives gaps in frmMain
        /// </summary>
        private void UpdateScore()
        {
            txtMatches.Text = matchesCount.ToString();
            txtVictories.Text = victoriesCount.ToString();
            winRate = (uint)Math.Round(100 * ((double)victoriesCount / matchesCount));
            txtWinRate.Text = winRate.ToString() + "%";
        }

        /// <summary>
        /// Check if someone has won, MUST be called at every turn
        /// </summary>
        /// <returns></returns>
        private bool VictoryCheck()
        {
            // First row check
            if ((pic1.Tag != "0") && (pic1.Tag == pic2.Tag) && (pic1.Tag == pic3.Tag))
                return true;
            // Second row check
            else if ((pic4.Tag != "0") && (pic4.Tag == pic5.Tag) && (pic4.Tag == pic6.Tag))
                return true;
            // Third row check
            else if ((pic7.Tag != "0") && (pic7.Tag == pic8.Tag) && (pic7.Tag == pic9.Tag))
                return true;
            // First column check
            else if ((pic1.Tag != "0") && (pic1.Tag == pic4.Tag) && (pic1.Tag == pic7.Tag))
                return true;
            // Second column check
            else if ((pic2.Tag != "0") && (pic2.Tag == pic5.Tag) && (pic2.Tag == pic8.Tag))
                return true;
            // Third column check
            else if ((pic3.Tag != "0") && (pic3.Tag == pic6.Tag) && (pic3.Tag == pic9.Tag))
                return true;
            // Principal diagonal check
            else if ((pic1.Tag != "0") && (pic1.Tag == pic5.Tag) && (pic1.Tag == pic9.Tag))
                return true;
            // Secondary diagonal check 
            else if ((pic3.Tag != "0") && (pic3.Tag == pic5.Tag) && (pic3.Tag == pic7.Tag))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Check if all fields are occupied, MUST be called EVER
        /// </summary>
        /// <returns>true if the game field is complete, false if not</returns>
        private bool IsGameFinished()
        {
            if (pic1.Tag != "0" && pic2.Tag != "0" && pic3.Tag != "0" && pic4.Tag != "0" && pic5.Tag != "0" && pic6.Tag != "0" && pic7.Tag != "0" && pic8.Tag != "0" && pic9.Tag != "0")
                return true; // Game finished
            else
                return false; // Game not finished
        }

        /// <summary>
        /// Used in Bot() method
        /// </summary>
        private int ChoosePictureBox()
        {
            return r.Next(1, 10); // Generates a number between 1 and 9 to random choose a picbox
        }

        /// <summary>
        /// Pc's turn here
        /// </summary>
        private void Bot() // MUST BE DONE BETTER
        {
        rnd:
            picChoosen = ChoosePictureBox();

            if (picChoosen == 1 && pic1.Tag == "0")
            {
                pic1.Tag = "2"; // Marks the PictureBox as occupied by the pc
                pic1.Image = pic11.Image; // Loads the X image
            }
            else if (picChoosen == 2 && pic2.Tag == "0")
            {
                pic2.Tag = "2";
                pic2.Image = pic11.Image;
            }
            else if (picChoosen == 3 && pic3.Tag == "0")
            {
                pic3.Tag = "2";
                pic3.Image = pic11.Image;
            }
            else if (picChoosen == 4 && pic4.Tag == "0")
            {
                pic4.Tag = "2";
                pic4.Image = pic11.Image;
            }
            else if (picChoosen == 5 && pic5.Tag == "0")
            {
                pic5.Tag = "2";
                pic5.Image = pic11.Image;
            }
            else if (picChoosen == 6 && pic6.Tag == "0")
            {
                pic6.Tag = "2";
                pic6.Image = pic11.Image;
            }
            else if (picChoosen == 7 && pic7.Tag == "0")
            {
                pic7.Tag = "2";
                pic7.Image = pic11.Image;
            }
            else if (picChoosen == 8 && pic8.Tag == "0")
            {
                pic8.Tag = "2";
                pic8.Image = pic11.Image;
            }
            else if (picChoosen == 9 && pic9.Tag == "0")
            {
                pic9.Tag = "2";
                pic9.Image = pic11.Image;
            }
            else
                goto rnd; // Need another number because the field is already occupied

            if (VictoryCheck())
            {
                matchesCount++;
                victoriesCount--;
                UpdateScore();

                if (MessageBox.Show("You lose!\n\nDo you want to play again?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) // Game ended
                    Close();
                else
                    Initialize();
            }
            else if (IsGameFinished())
            {
                if (MessageBox.Show("No one won!\n\nDo you want to play again?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) // Game ended
                    Close();
                else
                    Initialize();
            }
            else
                SwitchPlayer(); // Game not ended
        }


        private void pic1_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.Image = pic10.Image;
            pic.Tag = "1"; // Marks the PictureBox as occupied by the player

            if (VictoryCheck())
            {
                matchesCount++;
                victoriesCount++;
                UpdateScore();

                if (MessageBox.Show("You won!\n\nDo you want to play again?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) // Game ended
                    Close();
                else
                    Initialize();

                return;
            }
            else if(IsGameFinished())
            {
                matchesCount++;
                UpdateScore();

                if (MessageBox.Show("No one won!\n\nDo you want to play again?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) // Game ended
                    Close();
                else
                    Initialize();
            }
            else
            {
                SwitchPlayer(); // Changes the turn into bot's turn
                Bot();
            }
        }
    }
}
