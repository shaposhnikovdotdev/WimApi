using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WIM_Controller_SPP;

namespace Wim
{
    public class WimService
    {
        private readonly SPPController _controller;

        public WimService()
        {
            _controller = new SPPController();


            #region Subscribing to the controller events

            // hooking up the inputs received event handler 
            _controller.Inputs_Received += new SPPController.Inputs_Event_Handler(myWIMController_Inputs_Received);

            // hooking up the jitter received event handler 
            _controller.Jitter_Received += new SPPController.Jitter_Event_Handler(myWIMController_Jitter_Received);

            // hooking up the staggered weight event handler 
            _controller.StaggeredWeight_received += new SPPController.StaggeredWeight_Handler(myWIMController_StaggeredWeight_received);

            // hooking up the connection lost event handler 
            _controller.Connection_Lost += new SPPController.Connection_Lost_Handler(myWIMController_Connection_Lost);

            // hooking up the static weight received event handler 
            _controller.Static_Weight_Received += new SPPController.Static_Weight_Received_Event_Handler(myWIMController_Static_Weight_Received);

            // hooking up the dynamic weight received event handler 
            _controller.Dynamic_Weight_Received += new SPPController.Dynamic_Weight_Received_Event_Handler(myWIMController_Dynamic_Weight_Received);

            // hooking up the vehicle event handler 
            _controller.Dynamic_Vehicle_Complete += new SPPController.Dynamic_Vehicle_Complete_Handler(myWIMController_Dynamic_Vehicle_Complete);

            // hooking up the firmware settings event handler 
            _controller.Firmware_Settings_Received += new SPPController.Firmware_Event_Handler(myWIMController_Firmware_Settings_Received);

            // hooking up the second firmware settings event handler 
            _controller.Firmware_Settings2_Received += new SPPController.Firmware_Event_Handler2(myWIMController_Firmware_Settings2_Received);

            // hooking up the dual tire event handler 
            _controller.Dual_Tire_Received += new SPPController.Dual_Tire_Received_Event_Handler(myWIMController_Dual_Tire_Received);

            #endregion

        }
        #region public
        public void Connect()
        {
            _controller.SetAddress("localhost");
            _controller.SetPort(10001);
            _controller.Connect();
        }

        public void Disconnect()
        {
            _controller.Disconnect();
        }

        public void SetAddress(string address)
        {
            throw new NotImplementedException();
        }

        public void SetPort(int port)
        {
            throw new NotImplementedException();
        }

        public void SetWeighingMode(SPPController.WeighingMode weighingMode)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region private

        //Display the staggered weight. Value1 is the calibrated weight of the odd scale in the 
        //staggered pair or the left side of the vehicle and Value2 is the calibrated weight of the 
        //even scale in the staggered pair or the right side of the vehicle 
        void myWIMController_StaggeredWeight_received(Double Value1, Double Value2, Double time,
        EventArgs e)
        {
            Console.WriteLine("Left Side = " + Value1 + " Right Side = " + Value2);
        }

        //Display the static data such as WheelWeight, ScaleNumber, Errors, and Jitter received 
        //in static mode. 
        void myWIMController_Static_Weight_Received(SPPStaticWeightMessage Message, EventArgs e)
        {
            Console.WriteLine(Message.WheelWeight);
        }

        //Display the dynamic data such as Scalenumber, WheelWeight, Errors, and Jitter 
        void myWIMController_Dynamic_Weight_Received(SPPDynamicWeightMessage Message, EventArgs e)
        {
            Console.WriteLine(Message.WheelWeight);
        }

        //Display message regarding input change such as change in the loop or beam inputs 
        void myWIMController_Inputs_Received(SPPInputsMessage Message, EventArgs e)
        {
            if (Message.InputBytes[4])
            {
                Console.WriteLine("Loop Off");
            }
            else
            {
                Console.WriteLine("Loop On");
            }
        }

        //Display dual tire info such as DualTire 
        void myWIMController_Dual_Tire_Received(SPPDualTireMessage Message, EventArgs e)
        {
            Console.WriteLine(Message.DualTire);
        }

        //Display Jitter, BadPower status and Scale Error that occurred during Dynamic Weighing 
        void myWIMController_Jitter_Received(SPPJitterMessage Message, EventArgs e)
        {
            Console.WriteLine(Message.Jitter[0].ToString());
        }

        //Display the Firmware settings such as Firmware, LoadCellType, Mode, 
        //DynamicConversionFactor, StaggerConversionFactor, Threshold, and SpeedLimit 
        void myWIMController_Firmware_Settings_Received(SPPFirmwareMessage Message, EventArgs e)
        {
            Console.WriteLine(Message.Firmware);
        }

        //Display the second Firmware settings such as Threshold  
        void myWIMController_Firmware_Settings2_Received(SPPFirmwareMessage2 Message, EventArgs e)
        {
            Console.WriteLine(Message.Threshold);
        }

        //Display the error message send by the Connection_Lost event. 
        void myWIMController_Connection_Lost(String ErrorMessage, EventArgs e)
        {
            Console.WriteLine(ErrorMessage);
        }

        //Display the complete vehicle data such as TotalWeight, Speed, ScaleAxleIdWeight, 
        //AxleCountPerScale, AxleSpacing, AxleWeight 
        void myWIMController_Dynamic_Vehicle_Complete(Vehicle Message, EventArgs e)
        {
            Console.WriteLine(Message.TotalWeight);
        }

        #endregion
    }
}
