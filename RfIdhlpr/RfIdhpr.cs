using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RfIdhlpr
{
    public class RfIdhpr : IDisposable
    {
        #region Imports
        [DllImport("kernel32.dll")]
        static extern void Sleep(int dwMilliseconds);

        [DllImport("MasterRD.dll")]
        static extern int lib_ver(ref uint pVer);

        [DllImport("MasterRD.dll")]
        static extern int rf_init_com(int port, int baud);

        [DllImport("MasterRD.dll")]
        static extern int rf_ClosePort();

        [DllImport("MasterRD.dll")]
        static extern int rf_antenna_sta(short icdev, byte mode);

        [DllImport("MasterRD.dll")]
        static extern int rf_init_type(short icdev, byte type);

        [DllImport("MasterRD.dll")]
        static extern int rf_request(short icdev, byte mode, ref ushort pTagType);

        [DllImport("MasterRD.dll")]
        static extern int rf_anticoll(short icdev, byte bcnt, IntPtr pSnr, ref byte pRLength);

        [DllImport("MasterRD.dll")]
        static extern int rf_select(short icdev, IntPtr pSnr, byte srcLen, ref sbyte Size);

        [DllImport("MasterRD.dll")]
        static extern int rf_halt(short icdev);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_authentication2(short icdev, byte mode, byte secnr, IntPtr key);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_initval(short icdev, byte adr, Int32 value);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_increment(short icdev, byte adr, Int32 value);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_decrement(short icdev, byte adr, Int32 value);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_readval(short icdev, byte adr, ref Int32 pValue);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_read(short icdev, byte adr, IntPtr pData, ref byte pLen);

        [DllImport("MasterRD.dll")]
        static extern int rf_M1_write(short icdev, byte adr, IntPtr pData);

        [DllImport("MasterRD.dll")]
        static extern int rf_beep(short icdev, byte sec);
        #endregion

        private int _port, _baud;
        private bool _pollReader;
        private bool disposed;
        private bool _postponePollingEvents;
        public event EventHandler<RfIdReadEvent> CardRead;
        public event EventHandler<RfIdConnectionEvent> ReaderConnectionStateChanged;
        static RfIdhpr _reader;
        public static RfIdhpr GetReader(int Port, int Baud)
        {
            if (_reader == null)
                _reader = new RfIdhpr(Port, Baud);
            return _reader;
        }

        public static RfIdhpr Reader
        {
            get { return _reader; }
        }


        RfIdhpr(int port, int baud)
        {
            _port = port;
            _baud = baud;
        }

        static char[] hexDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
        private bool bConnectedDevice;



        public bool IsConnected { get { return bConnectedDevice; } }

        public static byte GetHexBitsValue(byte ch)
        {
            byte sz = 0;
            if (ch <= '9' && ch >= '0')
                sz = (byte)(ch - 0x30);
            if (ch <= 'F' && ch >= 'A')
                sz = (byte)(ch - 0x37);
            if (ch <= 'f' && ch >= 'a')
                sz = (byte)(ch - 0x57);

            return sz;
        }
        //

        #region byteHEX

        public static String byteHEX(Byte ib)
        {
            String _str = String.Empty;
            try
            {
                char[] Digit = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A',
				'B', 'C', 'D', 'E', 'F' };
                char[] ob = new char[2];
                ob[0] = Digit[(ib >> 4) & 0X0F];
                ob[1] = Digit[ib & 0X0F];
                _str = new String(ob);
            }
            catch (Exception)
            {
                new Exception("对不起有错。");
            }
            return _str;

        }
        #endregion

        public static string ToHexString(byte[] bytes)
        {
            String hexString = String.Empty;
            for (int i = 0; i < bytes.Length; i++)
                hexString += byteHEX(bytes[i]);

            return hexString;
        }

        public static byte[] ToDigitsBytes(string theHex)
        {
            byte[] bytes = new byte[theHex.Length / 2 + (((theHex.Length % 2) > 0) ? 1 : 0)];
            for (int i = 0; i < bytes.Length; i++)
            {
                char lowbits = theHex[i * 2];
                char highbits;

                if ((i * 2 + 1) < theHex.Length)
                    highbits = theHex[i * 2 + 1];
                else
                    highbits = '0';

                int a = (int)GetHexBitsValue((byte)lowbits);
                int b = (int)GetHexBitsValue((byte)highbits);
                bytes[i] = (byte)((a << 4) + b);
            }

            return bytes;
        }

        public bool Connect()
        {

            var state = bConnectedDevice;
            int port = 0;
            int baud = 0;
            int status = 0;
            port = _port;
            baud = _baud;
            try
            {
                status = rf_init_com(port, baud);
                if (0 == status)
                {
                    bConnectedDevice = true;
                }
                else
                {
                    bConnectedDevice = false;
                    //throw new ApplicationException("כישלון בחיבור לקורא קרטיסים");
                }
            }
            catch (Exception ex)
            {
                bConnectedDevice = false;
            }

            if (state != bConnectedDevice)// status have changed
                RaiseConnectionEvent(bConnectedDevice);
            return bConnectedDevice;

        }

        public void Disconnect()
        {
            rf_ClosePort();
            _pollReader = false;
            bConnectedDevice = false;
            RaiseConnectionEvent(bConnectedDevice);
        }

        public void StartPolling()
        {
            _pollReader = true;
            Task.Factory.StartNew(() =>
            {
                while (_pollReader)
                {
                    while (_postponePollingEvents)
                        Thread.Sleep(2000);

                    bConnectedDevice = Connect();
                    if (!bConnectedDevice)
                    {
                        Thread.Sleep(2000);
                        continue;
                    }
                    ReadCardSN();
                    Thread.Sleep(800);
                }
            });
        }

        public void StopPolling()
        {
            _pollReader = false;
        }

        public string ReadOnce()
        {
            if (!_postponePollingEvents)  // only if Postpone called previously
                return "";

            var sn = "";
            var cnt = 0;
            do
            {
                Thread.Sleep(200);
                sn = ReadCardSN();
                cnt++;

            } while (string.IsNullOrEmpty(sn) && cnt <= 5);


            return sn;
        }
        short icdev = 0x0000;
        public string ReadCardSN()
        {

            int status;
            byte type = (byte)'A';//mifare one 卡询卡方式为A
            byte mode = 0x52;
            ushort TagType = 0;
            byte bcnt = 0x04;//mifare 卡都用4
            IntPtr pSnr;
            byte len = 255;
            sbyte size = 0;
            String m_cardNo = String.Empty;

            if (!bConnectedDevice)
            {
                return "";
                //throw new ApplicationException("ההתקו אינו מחובר");
            }
            pSnr = Marshal.AllocHGlobal(1024);
            for (int i = 0; i < 2; i++)
            {
                status = rf_antenna_sta(icdev, 0);//关闭天线 close antenna  
                if (status != 0)
                    continue;

                Sleep(20);
                status = rf_init_type(icdev, type);
                if (status != 0)
                    continue;

                Sleep(20);
                status = rf_antenna_sta(icdev, 1);//启动天线 Open antenna
                if (status != 0)
                    continue;

                Sleep(50);     // After open the antenna, it needs about 50ms delay before request.
                status = rf_request(icdev, mode, ref TagType);//搜寻没有休眠的卡，request card  
                if (status != 0)
                    continue;

                status = rf_anticoll(icdev, bcnt, pSnr, ref len);//防冲突得到返回卡的序列号, anticol--get the card sn
                if (status != 0)
                    continue;

                status = rf_select(icdev, pSnr, len, ref size);//锁定一张ISO14443-3 TYPE_A 卡, select one card
                if (status != 0)
                    continue;

                byte[] szBytes = new byte[len];

                for (int j = 0; j < len; j++)
                {
                    szBytes[j] = Marshal.ReadByte(pSnr, j);
                }

                for (int q = 0; q < len; q++)
                {
                    m_cardNo += byteHEX(szBytes[q]);
                }

                Beep();
                break;
            }

            Marshal.FreeHGlobal(pSnr);
            if (!string.IsNullOrEmpty(m_cardNo) && prevCardSn != m_cardNo && !_postponePollingEvents)
            {
                if (CardRead != null)
                    CardRead(this, new RfIdReadEvent { CardSN = m_cardNo });

                lastread = DateTime.Now;
            }
            prevCardSn = m_cardNo;  // prevent double reading
            return m_cardNo;
        }

        private string prevCardSn;
        private DateTime lastread;
        public void Beep()
        {
            rf_beep(icdev, 40);
        }

        public void PostponePolling()
        {
            _postponePollingEvents = true;  // stop polling and events
        }


        public void ResumePolling()
        {
            _postponePollingEvents = false; // resume pollings and events;
        }



        private void RaiseConnectionEvent(bool isConnected)
        {

            if (ReaderConnectionStateChanged != null)
            {
                ReaderConnectionStateChanged(this, new RfIdConnectionEvent { Connected = isConnected });
            }
        }

        // Public implementation of Dispose pattern callable by consumers. 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern. 
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                prevCardSn = "";
                Disconnect();
                if (CardRead != null)
                {
                    var delegates = CardRead.GetInvocationList();
                    foreach (Delegate d in delegates)
                        CardRead -= (d as EventHandler<RfIdReadEvent>);
                }

                if (ReaderConnectionStateChanged != null)
                {
                    var delegates = ReaderConnectionStateChanged.GetInvocationList();
                    foreach (Delegate d in delegates)
                        ReaderConnectionStateChanged -= (d as EventHandler<RfIdConnectionEvent>);
                }


                _reader = null;
            }

            // Free any unmanaged objects here. 
            //
            disposed = true;
        }

    }


    public class RfIdReadEvent : EventArgs
    {
        public string CardSN { get; set; }
    }
    public class RfIdConnectionEvent : EventArgs
    {
        public bool Connected { get; set; }
    }
}
