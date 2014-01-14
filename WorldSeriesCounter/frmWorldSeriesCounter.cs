using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * Program Name: World Series Counter Ver 1.0
 * Programers: William Mitchell and Kyle Cantor
 * Course: POS/409
 * Instructor: Dr Brad Purdy
 * Date: January 9, 2014
 * Description: Calculates number of times a team has won the World Series
 * */
namespace WorldSeriesCounter
{
    public partial class frmWorldSeriesCounter : Form
    {
        public frmWorldSeriesCounter()
        {
            InitializeComponent();
        }
        
        //creates method for reading the contents of a file to an array
        private ArrayList fileToArrayList(string filename)
        {
            StreamReader file;
            ArrayList list = new ArrayList();
            file = File.OpenText(filename);

            while (!file.EndOfStream)
            {
                list.Add(file.ReadLine());
            }
            file.Close();
            return list;
        }

        //on load populates the list box with the teams.txt file
        private void frmWorldSeriesCounter_Load(object sender, EventArgs e)
        {
            try
            {
                ArrayList teams = fileToArrayList("Teams.txt");
                foreach (string value in teams)
                {
                    this.lbTeams.Items.Add(value);
                }
                                
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        //on button click calculates the number of times a team has won and displays the results
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList winners = fileToArrayList("WorldSeries.txt");
                string selection = this.lbTeams.SelectedItem.ToString();
                int teamCount = 0;
                foreach (string value in winners)
                {
                    if (value == selection)
                    {
                        teamCount++;
                    }
                }
                this.lblResult.Text = "The " + selection + " have won " + teamCount + " World Series";
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
    }
}
