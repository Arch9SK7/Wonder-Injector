using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WonderInjection
{
    public partial class MainForm : Form
    {

        public delegate void LogDelegate(string l);
        public LogDelegate delLastLog;
        public string lastlog = "";
        public int pid = 0;
        public PKHeX dumpedPKHeX = new PKHeX();
        /* Possibly Ultra box layout Offset? 0x33015AB0
        Possibly Ultra Wondercard Offset? 0x33075BF4
        Possibly Ultra Egg Location Offset? 0x3307B1EC */
        public uint boxOff;
        public uint wcOff;
        public uint partyOff;
        private uint eggOff;
        public EggBot eggbot;



        static Dictionary<uint, DataReadyWaiting> waitingForData = new Dictionary<uint, DataReadyWaiting>();

        public MainForm()
        {
            Program.ntrClient.DataReady += handleDataReady;
            Program.ntrClient.Connected += connectCheck;
            Program.ntrClient.InfoReady += getGame;
            delLastLog = new LogDelegate(lastLog);
            InitializeComponent();
            ofd_Injection.Title = "Select an EKX/PKX file";
            ofd_Injection.Filter = "Gen 7 pokémon files|*.pk7";
            ofd_WCInjection.Title = "Select a WC7 file";
            ofd_WCInjection.Filter = "Gen 7 wondercard files|*.wc7";
            string path = @Application.StartupPath;
            ofd_Injection.InitialDirectory = path;
            ofd_WCInjection.InitialDirectory = path;
            btn_Disconnect.Enabled = false;
            btn_ConvertMode.Enabled = false;
        }

        public void startAutoDisconnect()
        {
            disconnectTimer.Enabled = true;
        }

        public void lastLog(string l)
        {
            lastlog = l;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            string szIp = tb_IP.Text;

            if (!Program.Connected)
            {
                Program.scriptHelper.connect(szIp, 8000);
            }
            else
            {
                MessageBox.Show("You are already connected!");
            }

        }

        // Ultra Games

        public void getGame(object sender, EventArgs e)
        {
            InfoReadyEventArgs args = (InfoReadyEventArgs)e;

            string log = args.info;
            // Sun and Moon
            if (log.Contains("niji_loc"))
            {
                string splitlog = log.Substring(log.IndexOf(", pname: niji_loc") - 8, log.Length - log.IndexOf(", pname: niji_loc"));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                Program.helper.pid = pid;
                Program.scriptHelper.write(0x3E14C0, BitConverter.GetBytes(0xE3A01000), pid);
                MessageBox.Show("Connection Successful!");
                Program.f1.ChangeStatus("Pokémon Sun/Moon Connected!");
                Gamename = "SUMO";

                boxOff = 0x330D9838;
                wcOff = 0x331397E4;
                partyOff = 0x34195E10;
                eggOff = 0x3313EDD8;
            }

            // Ultra Sun and Moon
            else if (log.Contains(", pname:   momiji"))
            {
                string splitlog = log.Substring(log.IndexOf(", pname:   momiji") - 8, log.Length - log.IndexOf(", pname:   momiji"));
                pid = Convert.ToInt32("0x" + splitlog.Substring(0, 8), 16);
                Program.helper.pid = pid;

                Program.scriptHelper.write(0x3E14C0, BitConverter.GetBytes(0xE3A01000), pid);
                MessageBox.Show("Connection Successful!");
                Program.f1.ChangeStatus("Pokémon Ultra - Sun/Moon Connected!");
                Gamename = "USUM";

                boxOff = 0x33015AB0;
                wcOff = 0x33075BF4;
                partyOff = 0x33F7FA44;
                eggOff = 0x3307B1E8;
    }
            this.Gamename = Gamename;
            //Change Offsets of GameVersions
            if (Gamename == "SUMO")
            {
                boxOff = 0x330d9838; //To inject the pokemon into box1slot1
                wcOff = 0x331397E4;
                eggOff = 0x3313EDD8;
    }
            else if (Gamename == "USUM")
            {
                boxOff = 0x33015AB0;
                wcOff = 0x33075BF4;
                eggOff = 0x326601C4;
    }
        }
        EggBot workerObject = null;
        public string Gamename { get; private set; }

        public void setupButtons()
        {
            btn_Connect.Enabled = false;
            btn_Disconnect.Enabled = true;
            btn_Inject.Enabled = true;
            btn_Delete.Enabled = true;
            btn_WCInject.Enabled = true;
            btn_WCDelete.Enabled = true;
            btn_ConvertMode.Enabled = true;
        }

        public void undoButtons()
        {
            btn_Connect.Enabled = true;
            btn_Disconnect.Enabled = false;
            btn_Inject.Enabled = false;
            btn_Delete.Enabled = false;
            btn_WCInject.Enabled = false;
            btn_WCDelete.Enabled = false;
            btn_ConvertMode.Enabled = false;
        }

        public void connectCheck(object sender, EventArgs e)
        {

            Program.scriptHelper.listprocess();
            setupButtons();
            Program.Connected = true;

        }

        static void handleDataReady(object sender, DataReadyEventArgs e)
        { // We move data processing to a separate thread. This way even if processing takes a long time, the netcode doesn't hang.
            DataReadyWaiting args;
            if (waitingForData.TryGetValue(e.seq, out args))
            {
                Array.Copy(e.data, args.data, Math.Min(e.data.Length, args.data.Length));
                Thread t = new Thread(new ParameterizedThreadStart(args.handler));
                t.Start(args);
                waitingForData.Remove(e.seq);
            }
        }

        public void changeOffset(uint boxOff, uint wcOff)
        {
            if (isDefaultOffset(boxOff, wcOff))
            {
                boxOff = 0x33015AB0;
                wcOff = 0x33075BF4;
            }
            else
            {
                boxOff = 0x330D9838;
                wcOff = 0x331397E4;
            }
        }

        public void ChangeStatus(string szNewStatus)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(ChangeStatus), new object[] { szNewStatus });
                return;
            }
            this.rt_status.Text = "Game Version: " + szNewStatus;
        }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.IP = tb_IP.Text;
            Properties.Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tb_IP.Text = Properties.Settings.Default.IP;
        }


        private void btn_BrowseInject_Click(object sender, EventArgs e)
        {
            if (ofd_Injection.ShowDialog() == DialogResult.OK)
            {
                tb_FileInjection.Text = ofd_Injection.FileName;
                ofd_Injection.InitialDirectory = Path.GetDirectoryName(ofd_Injection.FileName);
                if (eggbot != null)
                {
                    eggbot.RequestStop();
                }
            }
        }



        private void btn_Inject_Click(object sender, EventArgs e)
        {

            if (tb_FileInjection.Text == "")
            {
                MessageBox.Show("Please select a file!", "WonderInjection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            byte[] pkmEncrypted = System.IO.File.ReadAllBytes(tb_FileInjection.Text);
            byte[] cloneshort = PKHeX.encryptArray(pkmEncrypted.Take(232).ToArray());
            uint boxIndex = Decimal.ToUInt32((nud_BoxInjection.Value - 1) * 30 + nud_SlotInjection.Value - 1);
            uint count = Decimal.ToUInt32(nud_CountInjection.Value);
            if (boxIndex + count > 32 * 30)
            {
                uint newCount = 32 * 30 - boxIndex;
                count = newCount;
            }

            byte[] dataToWrite = new byte[count * 232];
            for (int i = 0; i < count; i++)
                cloneshort.CopyTo(dataToWrite, i * 232);
            uint offset = boxOff + boxIndex * 232;
            Program.scriptHelper.write(offset, dataToWrite, pid);
            MessageBox.Show("Injection Successful!");
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            if (Program.Connected)
            {
                if (eggbot != null)
                {
                    eggbot.RequestStop();
                }

                Program.scriptHelper.disconnect();

                if (!Program.Connected)
                {
                    MessageBox.Show("Disconnection Successful!");
                    undoButtons();
                }
            }
            else
            {
                MessageBox.Show("You are already disconnected!");
                undoButtons();
            }
        }

        public void addwaitingForData(uint newkey, DataReadyWaiting newvalue)
        {
            waitingForData.Add(newkey, newvalue);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Program.ntrClient.sendHeartbeatPacket();
            }
            catch (Exception)
            {

            }
        }

        private void nud_BoxInjection_ValueChanged(object sender, EventArgs e)
        {
            nud_CountInjection.Maximum = 32 * 30 - (Decimal.ToUInt32((nud_BoxInjection.Value - 1) * 30 + nud_SlotInjection.Value - 1));
        }

        private void nud_SlotInjection_ValueChanged(object sender, EventArgs e)
        {
            nud_CountInjection.Maximum = 32 * 30 - (Decimal.ToUInt32((nud_BoxInjection.Value - 1) * 30 + nud_SlotInjection.Value - 1));
        }

        private void tp_Injection_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void tp_Injection_DragDrop(object sender, DragEventArgs e)
        {
            string input = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            if (!File.GetAttributes(input).HasFlag(FileAttributes.Directory))
            {
                tb_FileInjection.Text = input;
            }
            else
            {
                MessageBox.Show("Please drag a file!", "WonderInjection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            byte[] cloneshort = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x26, 0x06, 0x00, 0x00, 0x7E, 0xE9, 0x71, 0x52, 0xB0, 0x31, 0x42, 0x8E, 0xCC, 0xE2, 0xC5, 0xAF, 0xDB, 0x67, 0x33, 0xFC, 0x2C, 0xEF, 0x5E, 0xFC, 0xC5, 0xCA, 0xD6, 0xEB, 0x3D, 0x99, 0xBC, 0x7A, 0xA7, 0xCB, 0xD6, 0x5D, 0x78, 0x91, 0xA6, 0x27, 0x8D, 0x61, 0x92, 0x16, 0xB8, 0xCF, 0x5D, 0x37, 0x80, 0x30, 0x7C, 0x40, 0xFB, 0x48, 0x13, 0x32, 0xE7, 0xFE, 0xE6, 0xDF, 0x0E, 0x3D, 0xF9, 0x63, 0x29, 0x1D, 0x8D, 0xEA, 0x96, 0x62, 0x68, 0x92, 0x97, 0xA3, 0x49, 0x1C, 0x03, 0x6E, 0xAA, 0x31, 0x89, 0xAA, 0xC5, 0xD3, 0xEA, 0xC3, 0xD9, 0x82, 0xC6, 0xE0, 0x5C, 0x94, 0x3B, 0x4E, 0x5F, 0x5A, 0x28, 0x24, 0xB3, 0xFB, 0xE1, 0xBF, 0x8E, 0x7B, 0x7F, 0x00, 0xC4, 0x40, 0x48, 0xC8, 0xD1, 0xBF, 0xB6, 0x38, 0x3B, 0x90, 0x23, 0xFB, 0x23, 0x7D, 0x34, 0xBE, 0x00, 0xDA, 0x6A, 0x70, 0xC5, 0xDF, 0x84, 0xBA, 0x14, 0xE4, 0xA1, 0x60, 0x2B, 0x2B, 0x38, 0x8F, 0xA0, 0xB6, 0x60, 0x41, 0x36, 0x16, 0x09, 0xF0, 0x4B, 0xB5, 0x0E, 0x26, 0xA8, 0xB6, 0x43, 0x7B, 0xCB, 0xF9, 0xEF, 0x68, 0xD4, 0xAF, 0x5F, 0x74, 0xBE, 0xC3, 0x61, 0xE0, 0x95, 0x98, 0xF1, 0x84, 0xBA, 0x11, 0x62, 0x24, 0x80, 0xCC, 0xC4, 0xA7, 0xA2, 0xB7, 0x55, 0xA8, 0x5C, 0x1C, 0x42, 0xA2, 0x3A, 0x86, 0x05, 0xAD, 0xD2, 0x11, 0x19, 0xB0, 0xFD, 0x57, 0xE9, 0x4E, 0x60, 0xBA, 0x1B, 0x45, 0x2E, 0x17, 0xA9, 0x34, 0x93, 0x2D, 0x66, 0x09, 0x2D, 0x11, 0xE0, 0xA1, 0x74, 0x42, 0xC4, 0x73, 0x19, 0x28, 0x22, 0xF0, 0x43, 0x28, 0x54, 0xA6 };
            uint boxIndex = Decimal.ToUInt32((nud_BoxInjection.Value - 1) * 30 + nud_SlotInjection.Value - 1);
            uint count = Decimal.ToUInt32(nud_CountInjection.Value);
            if (boxIndex + count > 32 * 30)
            {
                uint newCount = 32 * 30 - boxIndex;
                count = newCount;
            }

            byte[] dataToWrite = new byte[count * 232];
            for (int i = 0; i < count; i++)
                cloneshort.CopyTo(dataToWrite, i * 232);
            uint offset = boxOff + boxIndex * 232;
            Program.scriptHelper.write(offset, dataToWrite, pid);
            MessageBox.Show("Deletion Successful!");
        }

        public byte[] StringToByteArray(string hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public byte calculateChecksum(byte[] principal)
        {
            byte[] newPrincipal = new byte[4];
            Array.Copy(principal, newPrincipal, 4);
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(newPrincipal);
                byte MyChecksum = (byte)(hash[0] >> 1);
                return MyChecksum;
            }
        }

        public string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        private void disconnectTimer_Tick(object sender, EventArgs e)
        {
            disconnectTimer.Enabled = false;
            Program.ntrClient.disconnect();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ntrClient.disconnect();
            Application.Exit();
        }

        private void btn_WCInject_Click(object sender, EventArgs e)
        {
            if (tb_WCInjection.Text == "")
            {
                MessageBox.Show("Please select a file!", "WonderInjection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            byte[] wc = System.IO.File.ReadAllBytes(tb_WCInjection.Text);
            uint slotIndex = Decimal.ToUInt32(nud_SlotWCInjection.Value) - 1;

            uint offset = wcOff + slotIndex * 264;
            Program.scriptHelper.write(offset, wc, pid);
            MessageBox.Show("Injection Successful!");
        }

        private void btn_WCDelete_Click(object sender, EventArgs e)
        {
            byte[] cloneshort = new byte[264];
            for (int i = 0; i < cloneshort.Length; i++)
            {
                cloneshort[i] = 0x0;
            }
            uint slotIndex = Decimal.ToUInt32(nud_SlotWCInjection.Value) - 1;

            uint offset = wcOff + slotIndex * 264;
            Program.scriptHelper.write(offset, cloneshort, pid);
            MessageBox.Show("Deletion Successful!");
        }

        private void btn_BrowseWCInject_Click(object sender, EventArgs e)
        {
            if (ofd_WCInjection.ShowDialog() == DialogResult.OK)
            {
                tb_WCInjection.Text = ofd_WCInjection.FileName;
                ofd_WCInjection.InitialDirectory = Path.GetDirectoryName(ofd_WCInjection.FileName);
            }
        }

        private void tb_FileInjection_TextChanged(object sender, EventArgs e)
        {

        }

        private void tp_Injection_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btn_ConvertMode_Click(object sender, EventArgs e)
        {
            changeOffset(isDefaultOffset);

            MessageBox.Show("Done!", "WonderInjection", MessageBoxButtons.OK);
            return;
        }

        private void changeOffset(Func<uint, uint, bool> isDefaultOffset)
        {
            if (isDefaultOffset(boxOff, wcOff))
            {
                boxOff = 0x33015AB0;
                wcOff = 0x33075BF4;
            }
            else
            {
                boxOff = 0x330D9838;
                wcOff = 0x331397E4;
            }
        }

        public bool isDefaultOffset(uint boxOff, uint wcOff)
        {
            if ((boxOff == 0x330D9838) && (wcOff == 0x331397E4))
                return true;
            else
                return false;
        }
    
    

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                VisitLink();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        private void VisitLink()
        {
            // Change the color of the link text by setting LinkVisited   
            // to true.  
            linkLabel1.LinkVisited = true;
            //Call the Process.Start method to open the default browser   
            //with a URL:  
            System.Diagnostics.Process.Start("https://github.com/Arch9SK7/Wonder-Injector/releases/latest");
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }

        private void BoxAllInjection_CheckedChanged(object sender, EventArgs e)
        {

        }

        private async void btn_EggOn_Click(object sender, EventArgs e)
        {
            eggbot = new EggBot(pid, Gamename);
            btn_EggOff.Enabled = true;
            btn_EggOn.Enabled = false;
            await eggbot.RunBot();
        }

        private void btn_EggOff_Click(object sender, EventArgs e)
        {
            eggbot.RequestStop();
            btn_EggOn.Enabled = true;
            btn_EggOff.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

    public class DataReadyWaiting
    {
        public byte[] data;
        public object arguments;
        public delegate void DataHandler(object data_arguments);
        public DataHandler handler;

        public DataReadyWaiting(byte[] data_, DataHandler handler_, object arguments_)
        {
            this.data = data_;
            this.handler = handler_;
            this.arguments = arguments_;
        }
    }
}