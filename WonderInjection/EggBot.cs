using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WonderInjection
{
    public class EggBot
    {

        private volatile int iPID = 0;

        private uint eggOff;

        private bool botstop = false;

        public string Gamename { get; }

        public EggBot(int iP, string Gamename)
        {
            if (Gamename == "USUM")
            {
                eggOff = 0x3307B1E8;
            }
            else if (Gamename == "SUMO")
            {
                eggOff = 0x3313EDD8;
            }
            iPID = iP;
            this.Gamename = Gamename;
        }

        public async Task RunBot()
        {
            while (!botstop)
            {
                await Task.Delay(250);
                await Program.helper.waitNTRwrite(eggOff, 0x1, iPID);
            }
        }

        public void RequestStop()
        {
            botstop = true;
        }



    }
}
