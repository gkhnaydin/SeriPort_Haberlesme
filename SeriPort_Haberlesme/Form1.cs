using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeriPort_Haberlesme
{
    public partial class Form1 : Form
    {
        private static readonly int[] BaudRateArry = { 9600};

        private byte startBit { get; } = 0x01;
        private byte stopBit { get; } = 0x04;
        private byte displayBit { get; } = 0x35;
        private List<string> DeviceList = new List<string>();

        private SerialPort Port { get; set; }

        byte[] commandEkrandakiYaziyiSil = new byte[] { 0x01, 0x30, 0x31, 0x36, 0x04 }; //Ekrandaki yazıyı siler.
        byte[] commandKartiOkutunuz = new byte[] { 0x01, 0x30, 0x31, 0x32, 0x04 };//kartı okutunuz
        byte[] commandKartiOkutunuzSil = new byte[] { 0x01, 0x30, 0x31, 0x33, 0x04 };//kartı okutunuz siler.
        byte[] commandOkutulanKartBilgisiVer = new byte[] { 0x01, 0x30, 0x31, 0x31, 0x04 };//okutulan kart bilgisini verir.
        byte[] commandOkutulanIdSil = new byte[] { 0x01, 0x30, 0x31, 0x34, 0x04 };//1 nolu cihaza okutulan id siler.
        byte[] commandEkranaMetinYaz = new byte[] { 0x01, 0x30, 0x31, 0x35, 0x31, 0x32, 0x33, 0x31, 0x32, 0x33, 0x04 };//metin yazdırmak için


        private byte[] comingDataArry;
        private byte[] deviceAddressArry;
        List<byte> messageByteList = new List<byte>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Control.CheckForIllegalCrossThreadCalls = false;// iş parçacıklarının çakışmasını önler.
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                comboMessageType.SelectedIndex = 0;

                var portlar = SerialPort.GetPortNames();
                comboPortAdi.Items.Clear();
                foreach (string prt in portlar)
                {
                    comboPortAdi.Items.Add(prt);
                }

                foreach (var baud in BaudRateArry)
                {
                    comboBaudRate.Items.Add(baud);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message + Environment.NewLine + ex.InnerException?.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (null != Port)
            {
                Port.Write(commandOkutulanKartBilgisiVer, 0, 5);
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            try
            {
                var ports = SerialPort.GetPortNames();
                comboPortAdi.Items.Clear();
                foreach (string prt in ports)
                {
                    comboPortAdi.Items.Add(prt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message + Environment.NewLine + ex.InnerException?.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaglan_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBaudRate.SelectedItem == null || comboPortAdi.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen gerekli parametreleri seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Port != null)
                {
                    Port.Close();
                    Port = null;
                }

                Port = new SerialPort(comboPortAdi.SelectedItem.ToString(), int.Parse(comboBaudRate.SelectedItem.ToString()), Parity.None);
                Port.Open();
                listState.Items.Add("Bağlantı sağlandı.");
            }
            catch (Exception ex)
            {
                Port.Close();
                MessageBox.Show("Bağlantı hatası:" + ex.Message + Environment.NewLine + ex.InnerException?.Message, "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private byte[] comeData;

        private void threadWork()
        {
            try
            {
                while (true)
                {
                    commandOkutulanKartBilgisiVer[1] = deviceAddressArry[0];
                    commandOkutulanKartBilgisiVer[2] = deviceAddressArry[1];

                    Port.Write(commandOkutulanKartBilgisiVer, 0, commandOkutulanKartBilgisiVer.Length);

                    comeData = new byte[Port.BytesToRead];

                    Array.Clear(comeData, 0, comeData.Length);

                    Port.Read(comeData, 0, comeData.Length);
                    List<byte> data = new List<byte>();
                    data.Clear();

                    int startIndex = -1;
                    int stopIndex = -1;

                    if (comeData.Contains((byte)1) && comeData.Contains((byte)4))
                    {
                        for (int i = 0; i < comeData.Length; i++)
                        {
                            if ((byte)1 == comeData[i])
                                startIndex = i;

                            if ((byte)4 == comeData[i])
                                stopIndex = i;

                            if (-1 != startIndex && -1 != stopIndex)
                                break;
                        }
                    }

                    //Gelen data uzunluk kontrolü yapılacak.
                    //if()
                    //{

                    //}

                    for (int i = startIndex + 3; i < stopIndex; i++)
                    {
                        data.Add(comeData[i]);
                    }

                    var deviceID = string.Empty;
                    deviceID = System.Text.Encoding.UTF8.GetString(data.ToArray());

                    if (!DeviceList.Contains(deviceID) && !string.IsNullOrEmpty(deviceID))
                    {
                        listAlinanData.Items.Clear();
                        listAlinanData.Items.Add(deviceID + Environment.NewLine);

                        DeviceList.Clear();
                        DeviceList.Add(deviceID);
                    }

                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                listState.Items.Add("Hata!\n" + ex.Message + Environment.NewLine + ex.InnerException?.Message);
                Thread.Sleep(500);
            }
        }

        private void work2()
        {
            try
            {
                commandOkutulanKartBilgisiVer[1] = deviceAddressArry[0];
                commandOkutulanKartBilgisiVer[2] = deviceAddressArry[1];

                Port.Write(commandOkutulanKartBilgisiVer, 0, commandOkutulanKartBilgisiVer.Length);

                comeData = new byte[Port.BytesToRead];

                Array.Clear(comeData, 0, comeData.Length);

                Port.Read(comeData, 0, comeData.Length);
                List<byte> data = new List<byte>();
                data.Clear();

                int startIndex = -1;
                int stopIndex = -1;

                if (comeData.Contains((byte)1) && comeData.Contains((byte)4))
                {
                    for (int i = 0; i < comeData.Length; i++)
                    {
                        if ((byte)1 == comeData[i])
                            startIndex = i;

                        if ((byte)4 == comeData[i])
                            stopIndex = i;

                        if (-1 != startIndex && -1 != stopIndex)
                            break;
                    }
                }
                else
                    return;

                //Gelen data uzunluk kontrolü yapılacak.
                //if()
                //{

                //}

                for (int i = startIndex + 3; i < stopIndex; i++)
                {
                    data.Add(comeData[i]);
                }

                var deviceID = string.Empty;
                deviceID = System.Text.Encoding.UTF8.GetString(data.ToArray());

                if (!DeviceList.Contains(deviceID))
                {
                    listAlinanData.Items.Clear();
                    listAlinanData.Items.Add(deviceID + Environment.NewLine);

                    DeviceList.Clear();
                    DeviceList.Add(deviceID);
                }
            }
            catch (Exception ex)
            {
                listState.Items.Add("Hata!\n" + ex.Message + Environment.NewLine + ex.InnerException?.Message);
            }
        }
        Thread thread;

        private void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                comingDataArry = new byte[Port.BytesToRead];

                if (Port == null || !int.TryParse(teDeviceID.Text, out int DeviceID))
                {
                    MessageBox.Show("Lütfen Port adı,Cihaz Id ile Baud hızını Seçiniz ve 'BAĞLAN' butonuna tıklayınız.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    UTF8Encoding encode = new UTF8Encoding();
                    var id = string.Empty;
                    if (DeviceID < 10)
                    {
                        id = "0" + teDeviceID.Text;
                    }
                    else
                    {
                        id = DeviceID.ToString();
                    }
                    deviceAddressArry = encode.GetBytes(id);

                    if (null == thread)
                    {
                        thread = new Thread(() => threadWork());
                        thread.Priority = ThreadPriority.Lowest;
                        thread.Start();
                    }

                    if (0 == comboMessageType.SelectedIndex)
                    {
                        ByteSet(commandOkutulanKartBilgisiVer, deviceAddressArry);
                        OkutulanKartBilgisiDoner();
                        work2();
                    }

                    if (1 == comboMessageType.SelectedIndex)
                    {
                        ByteSet(commandKartiOkutunuz, deviceAddressArry);
                        EkranaKartOkutunuzYaz();
                    }

                    if (2 == comboMessageType.SelectedIndex)
                    {
                        ByteSet(commandKartiOkutunuzSil, deviceAddressArry);
                        EkrandanKartOkutunuzSiler();
                    }

                    if (3 == comboMessageType.SelectedIndex)
                    {
                        ByteSet(commandOkutulanIdSil, deviceAddressArry);
                        OkutulanKartBilgisiSil();
                    }

                    if (4 == comboMessageType.SelectedIndex)
                    {
                        ByteSet(commandEkrandakiYaziyiSil, deviceAddressArry);
                        EkrandakiYaziSil();
                    }

                    if (5 == comboMessageType.SelectedIndex)
                    {
                        ByteSet(commandEkranaMetinYaz, deviceAddressArry);
                        EkranaVeriYaz();
                    }
                    listState.Items.Add("Veri Gönderildi");
                }

            }
            catch (Exception ex)
            {
                listState.Items.Add("Hata! Veri gönderilemedi." + ex.Message + Environment.NewLine + ex.InnerException?.Message);
            }
        }

        private void OkutulanKartBilgisiDoner()
        {
            Port.RtsEnable = true;
            Port.DtrEnable = true;
            Port.Write(commandOkutulanKartBilgisiVer, 0, commandOkutulanKartBilgisiVer.Length);
        }

        private void EkranaKartOkutunuzYaz()
        {
            Port.RtsEnable = true;
            Port.DtrEnable = true;
            Port.Write(commandKartiOkutunuz, 0, commandKartiOkutunuz.Length);
        }

        private void EkrandanKartOkutunuzSiler()
        {
            Port.RtsEnable = true;
            Port.DtrEnable = true;
            Port.Write(commandKartiOkutunuzSil, 0, commandKartiOkutunuzSil.Length);
        }

        private void OkutulanKartBilgisiSil()
        {
            Port.RtsEnable = true;
            Port.DtrEnable = true;
            Port.Write(commandOkutulanIdSil, 0, commandOkutulanIdSil.Length);
        }

        private void EkrandakiYaziSil()
        {
            Port.RtsEnable = true;
            Port.DtrEnable = true;
            Port.Write(commandEkrandakiYaziyiSil, 0, commandEkrandakiYaziyiSil.Length);
        }

        private void EkranaVeriYaz()
        {
            #region String Mesaj Yazdırma
            var someString = "fdfdgsg";
            byte[] bytes = Encoding.ASCII.GetBytes(someString);

            messageByteList = new List<byte>();
            messageByteList.Add(startBit);
            messageByteList.Add(deviceAddressArry[0]);
            messageByteList.Add(deviceAddressArry[1]);
            messageByteList.Add(displayBit);
            foreach (var item in bytes)
            {
                messageByteList.Add(item);
            }
            messageByteList.Add(stopBit);
            #endregion

            Port.Write(messageByteList.ToArray(), 0, messageByteList.Count);
        }
        private void ByteSet(byte[] byt, byte[] value)
        {
            byt[1] = value[0];
            byt[2] = value[1];
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (null != Port)
                if (Port.IsOpen)
                    Port.Close();

        }
    }
}
