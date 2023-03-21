namespace Echec
{
     public class Echec
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Echec Jeu = new Echec();
        }

        public Echec() {
            ApplicationConfiguration.Initialize();
            view.FormMenu menu = new view.FormMenu();
            Application.Run(menu);
        }
    }
}