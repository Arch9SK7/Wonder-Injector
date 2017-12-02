using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderInjection
{
    class RemoteControl
    {
        // Class variables
        private int timeout = 10; // Max timeout in seconds
        public uint lastRead = 0; // Last read from RAM
        public byte[] lastArray;
        public int pid = 0;
        PKHeX validator = new PKHeX();

        // Offsets for remote controls
        private int hid_pid = 0x10;
        public const int BOXSIZE = 30;
        public const int POKEBYTES = 232;

        // Log Handler
        private void WriteLastLog(string str)
        {
            Program.f1.lastlog = str;
        }

        private bool CompareLastLog(string str)
        {
            return Program.f1.lastlog.Contains(str);
        }

        private uint gethexcoord(decimal Xvalue, decimal Yvalue)
        {
            uint hexX = Convert.ToUInt32(Math.Round(Xvalue * 0xFFF / 319));
            uint hexY = Convert.ToUInt32(Math.Round(Yvalue * 0xFFF / 239));
            return 0x01000000 + hexY * 0x1000 + hexX;
        }

        // Memory Read Handler
        private void handleMemoryRead(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            if (args.data.Length == 4)
            {
                lastRead = BitConverter.ToUInt32(args.data, 0);
                lastArray = args.data;
            }
            else
            {
                lastArray = args.data;
            }

        }

        public async Task<bool> waitNTRread(uint address)
        {
            lastRead = 0;
            WriteLastLog("");
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMemoryRead, null);
            Program.f1.addwaitingForData(Program.scriptHelper.data(address, 0x04, pid), myArgs);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 100; readcount++)
            {
                await Task.Delay(10);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount == timeout * 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> waitNTRread(uint address, uint size)
        {
            lastRead = 0;
            lastArray = null;
            WriteLastLog("");
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[size], handleMemoryRead, null);
            Program.f1.addwaitingForData(Program.scriptHelper.data(address, size, pid), myArgs);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 100; readcount++)
            {
                await Task.Delay(10);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount == timeout * 100)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void handlePokeRead(object args_obj)
        {
            DataReadyWaiting args = (DataReadyWaiting)args_obj;
            validator.Data = PKHeX.decryptArray(args.data);
        }

        public async Task<long> waitPokeRead(int box, int slot)
        {
            uint dumpOff = Program.f1.boxOff + (Convert.ToUInt32(box * BOXSIZE + slot) * POKEBYTES);
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handlePokeRead, null);
            Program.f1.addwaitingForData(Program.scriptHelper.data(dumpOff, POKEBYTES, pid), myArgs);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 100; readcount++)
            {
                await Task.Delay(10);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount == timeout * 100)
                return -2; // No data received
            else if (validator.Species != 0)
            {
                Program.f1.dumpedPKHeX.Data = validator.Data;
                return validator.PID;
            }
            else // Empty slot
                return -1;
        }

        public async Task<long> waitPartyRead(uint partyOff, int slot)
        {
            uint dumpOff = Program.f1.partyOff + Convert.ToUInt32(slot * 484);
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[POKEBYTES], handlePokeRead, null);
            Program.f1.addwaitingForData(Program.scriptHelper.data(dumpOff, POKEBYTES, pid), myArgs);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 100; readcount++)
            {
                await Task.Delay(10);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount == timeout * 100)
                return -2; // No data received
            else if (validator.Species != 0)
            {
                Program.f1.dumpedPKHeX.Data = validator.Data;
                return validator.PID;
            }
            else // Empty slot
                return -1;
        }

        public async Task<bool> memoryinrange(uint address, uint value, uint range)
        {
            lastRead = 0;
            WriteLastLog("");
            DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMemoryRead, null);
            Program.f1.addwaitingForData(Program.scriptHelper.data(address, 0x04, pid), myArgs);
            int readcount = 0;
            for (readcount = 0; readcount < timeout * 100; readcount++)
            {
                await Task.Delay(10);
                if (CompareLastLog("finished"))
                    break;
            }
            if (readcount < timeout * 100)
            { // Data received
                if (lastRead >= value && lastRead < value + range)
                    return true;
                else
                    return false;
            }
            else // No data received
                return false;
        }

        public async Task<bool> timememoryinrange(uint address, uint value, uint range, int tick, int maxtime)
        {
            int time = 0;
            while (time < maxtime)
            { // Ask for data
                lastRead = 0;
                WriteLastLog("");
                DataReadyWaiting myArgs = new DataReadyWaiting(new byte[0x04], handleMemoryRead, null);
                Program.f1.addwaitingForData(Program.scriptHelper.data(address, 0x04, pid), myArgs);
                // Wait for data
                int readcount = 0;
                for (readcount = 0; readcount < timeout * 100; readcount++)
                {
                    await Task.Delay(10);
                    time += 100;
                    if (CompareLastLog("finished"))
                        break;
                }
                if (readcount < timeout * 100)
                { // Data received
                    if (lastRead >= value && lastRead < value + range)
                        return true;
                    else
                    {
                        await Task.Delay(tick);
                        time += tick;
                    }
                } // If no data received or not in range, try again
            }
            return false;
        }

        // Memory Write handler
        public async Task<bool> waitNTRwrite(uint address, uint data, int pid)
        {
            byte[] command = BitConverter.GetBytes(data);
            Program.scriptHelper.write(address, command, pid);
            int waittimeout;
            for (waittimeout = 0; waittimeout < timeout * 100; waittimeout++)
            {
                WriteLastLog("");
                await Task.Delay(10);
                if (CompareLastLog("finished"))
                    break;
            }
            if (waittimeout < timeout * 100)
                return true;
            else
                return false;
        }

        public async Task<bool> waitNTRwrite(uint address, byte[] data, int pid)
        {
            Program.scriptHelper.write(address, data, pid);
            int waittimeout;
            for (waittimeout = 0; waittimeout < timeout * 100; waittimeout++)
            {
                WriteLastLog("");
                await Task.Delay(10);
                if (CompareLastLog("finished"))
                    break;
            }
            if (waittimeout < timeout * 100)
                return true;
            else
                return false;
        }
    }
}