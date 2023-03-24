using Echec.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Echec.view
{
    public partial class FormMenu : Form
    {
        private Echec chess;
        public FormMenu(Echec chess)
        {

            this.chess = chess;
            InitializeComponent();
            List<string> strings = chess.readStats();
    
            foreach(string s in strings)
            {
                listBox1.Items.Add(s);
            }
              
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            chess.newGame(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                chess.newPlayer(textBox1.Text);
                textBox1.Text = "";
                listBox1.Items.Clear();
                List<string> strings = chess.readStats();

                foreach (string s in strings)
                {
                    listBox1.Items.Add(s);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            int index = listBox1.SelectedIndex;
            List<string> strings = chess.getStats(index);
            string nbNull = strings.ElementAt(0);
           string nbVictory = strings.ElementAt(1);
            string nbDefeat = strings.ElementAt(2);
            string label1text = label1.Text;
            label1.Text = "Null : " + nbNull;
            string label2text = label2.Text;
            label2.Text = "Victoire : " + nbVictory;
            string label3text = label3.Text;
            label3.Text = "Défaite : " + nbDefeat;      
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            label5.Text = "";
            string text = listBox1.Text;
            label4.Text = "joueur1 :" + text;
        }
    }
}
