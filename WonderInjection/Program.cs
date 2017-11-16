using System;
using System.Windows.Forms;

namespace WonderInjection
{
    static class Program
    {
        public static NTR ntrClient;
        public static ScriptHelper scriptHelper;
        public static RemoteControl helper;
        public static LookupTable PKTable;
        public static Boolean Connected = false;
        public static MainForm f1;
        public static PKHeX pkhex;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ntrClient = new NTR();
            scriptHelper = new ScriptHelper();
            helper = new RemoteControl();
            pkhex = new PKHeX();
            PKTable = new LookupTable();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            f1 = new MainForm();
            Application.Run(f1);
        }
    }
}
