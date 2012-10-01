using System;
using System.Threading;

using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;


using GHIElectronics.NETMF.FEZ;

namespace HeatLightSensor {
    public class Program {

        private const ushort address = 72;
        private const int clockRateKHz = 100;

        public static void Main() {
            // turn off LED
            bool ledState = true;
            OutputPort led = new OutputPort((Cpu.Pin)FEZ_Pin.Digital.LED, ledState);
            
            led.Write(ledState);

            I2CDevice.Configuration config = new I2CDevice.Configuration(address, clockRateKHz);
            I2CDevice device = new I2CDevice(config);

            byte[] inBuffer = new byte[2];
            I2CDevice.I2CReadTransaction readTransaction = I2CDevice.CreateReadTransaction(inBuffer);
            I2CDevice.I2CTransaction[] transaction = new I2CDevice.I2CTransaction[1];
         
            transaction[0] = readTransaction;
            int transferred = device.Execute(transaction,100);

            Debug.Print("Transferred " + transferred.ToString() + " bytes!");
            
            
            foreach (byte b in inBuffer) {
                Debug.Print("" + b);
            }

        }

    }
}
