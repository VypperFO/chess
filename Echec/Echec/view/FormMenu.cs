namespace Echec.view
{
    public partial class FormMenu : Form
    {
        private Echec chess;
        private int nbPlayer;
        public FormMenu(Echec chess)
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

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            chess.NewGame();
            chess.sendPlayers(label7.Text, label8.Text);
        }

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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


        private void button2_Click(object sender, EventArgs e)
        {
            string text = listBox1.Text;
            if (label7.Text.Length > 0 && nbPlayer < 2 && label7.Text != listBox1.Text)
            {
                label8.Text = text;
                nbPlayer++;
            } else if(nbPlayer < 2 && label7.Text != listBox1.Text) { 
                label7.Text = text;
                nbPlayer++;
            }

 
        }

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
