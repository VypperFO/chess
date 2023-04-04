namespace ChessGame.view
{
    public partial class FormMenu : Form
    {
        private Chess chess; // controlleur de la partie 
        private int nbPlayer; // nombre de joueur selectionner pour la partie
        public FormMenu(Chess chess)
        {
            this.chess = chess;
            InitializeComponent();
            label7.Text = "";
            label8.Text = "";
            List<string> strings = chess.ReadStats();

            foreach (string s in strings)
            {
                listBox1.Items.Add(s);
            }

        }

        /// <summary>
        /// Event listener sur le boutton pour commencer une nouvelle partie, verifie qu'il y a 2 joueurs de selectionner pour la partie
        /// </summary>
        /// <param name="sender">qui a clicker</param>
        /// <param name="e">Event</param>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (!(label7.Text == "" && label8.Text == ""))
            {
                chess.NewGame();
                chess.sendPlayers(label7.Text, label8.Text);
            }
        }

        /// <summary>
        /// Event listener sur le boutton pour creer un nouveaux joueur
        /// </summary>
        /// <param name="sender">qui a clicker</param>
        /// <param name="e">Event</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                chess.NewPlayer(textBox1.Text);
                textBox1.Text = "";
                listBox1.Items.Clear();
                List<string> strings = chess.ReadStats();

                foreach (string s in strings)
                {
                    listBox1.Items.Add(s);
                }
            }
        }

        /// <summary>
        /// update les statistique qui sont afficher pour ceu du joueur selectioner
        /// </summary>
        /// <param name="sender">qui a clicker</param>
        /// <param name="e">Event</param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> list = chess.ReadStats();

            foreach (string s in list)
            {
                listBox1.Items.Add(s);
            }

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            int index = listBox1.SelectedIndex;
            List<string> strings = chess.GetStats(index);
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


        /// <summary>
        /// ajoute le joueur qui est selectionner dans la partie
        /// </summary>
        /// <param name="sender">qui a clicker</param>
        /// <param name="e">Event</param>
        private void button2_Click(object sender, EventArgs e)
        {
            string text = listBox1.Text;
            if (label7.Text.Length > 0 && nbPlayer < 2 && label7.Text != listBox1.Text)
            {
                label8.Text = text;
                nbPlayer++;
            }
            else if (nbPlayer < 2 && label7.Text != listBox1.Text)
            {
                label7.Text = text;
                nbPlayer++;
            }


        }

        /// <summary>
        /// Enleve 1 des joueur qui est selectionner pour la partie
        /// </summary>
        /// <param name="sender">qui a clicker</param>
        /// <param name="e">Event</param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Text == label7.Text)
            {
                label7.Text = "";
                nbPlayer--;
            }
            else if (listBox1.Text == label8.Text)
            {
                label8.Text = "";
                nbPlayer--;
            }
        }
    }
}
