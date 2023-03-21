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
            chess.readStats();
            foreach(Joueur test in chess.listAllPlayer)
            {
                listBox1.Items.Add(test);
            }
            
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            chess.newGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
