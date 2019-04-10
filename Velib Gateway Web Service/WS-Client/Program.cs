using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WS_Client.IntermediaryDecaux;

namespace WS_Client
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            /*IntermediaryDecauxClient client = new IntermediaryDecauxClient();
            client.GetData(5);*/


            //IntermediaryDecaux a = new IntermediaryDecaux();
            //ServiceReference1 serviceReference1 = new WS_Client.ServiceReference1();
        }
    }
}
