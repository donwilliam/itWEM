using System;
using System.Threading;
using System.IO;

using System.Text;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using GHIElectronics.NETMF.FEZ;
using GHIElectronics.NETMF.Hardware;
using GHIElectronics.NETMF.Net;
using GHIElectronics.NETMF.Net.NetworkInformation;




namespace HeatLightSensor {
    public class Program {

        private const ushort address = 79;
        private const int clockRateKHz = 79;
        private const int updateTime = 15000;
        private static OutputPort led;
        private static I2CDevice.Configuration config;
        private static I2CDevice device;
        private static bool ledState = true;

        public static void Main() {
            
            led = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.LED, ledState);
            config = new I2CDevice.Configuration(address, clockRateKHz);
            device = new I2CDevice(config);
            WIZnet_W5100.Enable(SPI.SPI_module.SPI1, (Cpu.Pin)FEZ_Pin.Digital.Di10, (Cpu.Pin)FEZ_Pin.Digital.Di7, true);
            Dhcp.EnableDhcp(new byte[] { 0x00, 0x26, 0x1C, 0x7B, 0x29, 0xE8 }, "tt");
            

            while (true) {
                      
                
                
                uploadData(gatherData());
                getHeaterStatus();
                setHeaterStatus();

                Thread.Sleep(updateTime);
            }

        }

        private static void uploadData(byte[] b) {
            double tmp = b[0];
            if (b[1] == 128) {
                tmp += 0.5;
                }
            Debug.Print("tmp is: " + tmp);
            String url = "http://itwem.azurewebsites.net/Default.aspx?Tmp=" + tmp;
            
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.KeepAlive = false;

            WebResponse resp = null;
            try {
                resp = request.GetResponse();
            } catch (Exception e) {
                Debug.Print("Exception in HttpWebRequest.GetResponse(): " + e.ToString());
            }
           
        }

        private static void getHeaterStatus() {
            String url = "http://itwem.azurewebsites.net/HeaterStatus.ashx";
            ledState = !ledState;
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            request.KeepAlive = false;

            WebResponse resp = null;
            try {
                resp = request.GetResponse();
            } catch (Exception e) {
                Debug.Print("Exception in HttpWebRequest.GetResponse(): " + e.ToString());
            }
            Stream respStream = null;
            try {
                 respStream = resp.GetResponseStream();
            } catch (Exception e) {
                Debug.Print("Exception in resp.GetResponseStream(): " + e.ToString());
            }
            if (respStream != null) {
                byte[] byteData = new byte[1];
                respStream.Read(byteData, 0, 1);
                Debug.Print("" + byteData[0]);
                ledState = byteData[0] == 49;
            }

            
        }

        private static void setHeaterStatus() {
            
            led.Write(ledState);
                  
        }

        private static byte[] gatherData() {
            byte[] inBuffer = new byte[2];
            I2CDevice.I2CReadTransaction readTransaction = I2CDevice.CreateReadTransaction(inBuffer);
            I2CDevice.I2CTransaction[] transaction = new I2CDevice.I2CTransaction[1];


            transaction[0] = readTransaction;


            int transferred = device.Execute(transaction, 100);
            
            /*Debug.Print("Transferred " + transferred.ToString() + " bytes!");
            foreach (byte b in inBuffer) {

                Debug.Print("" + b);
            }*/
            return inBuffer;

        }

    }
}
