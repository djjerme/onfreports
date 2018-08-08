namespace PBA.OnfInfo
{
    using System;

    public class FedexShippingMethod
    {
        public FedexShipMethod ShipMethod;

        public FedexShippingMethod(string shipMethod)
        {
            switch (shipMethod.ToLower())
            {
                case "domestic 2 day":
                    this.ShipMethod = FedexShipMethod.FEDEX_2_DAY;
                    break;

                case "domestic 3 day":
                    this.ShipMethod = FedexShipMethod.FEDEX_3_DAY;
                    break;

                case "standard overnight":
                case "overnight":
                    this.ShipMethod = FedexShipMethod.STANDARD_OVERNIGHT;
                    break;

                case "priority overnight":
                    this.ShipMethod = FedexShipMethod.PRIORITY_OVERNIGHT;
                    break;

                case "international economy":
                    this.ShipMethod = FedexShipMethod.INTERNATIONAL_ECONOMY;
                    break;

                case "international priority":
                    this.ShipMethod = FedexShipMethod.INTERNATIONAL_PRIORITY;
                    break;

                default:
                    this.ShipMethod = FedexShipMethod.FEDEX_GROUND;
                    break;
            }
        }
    }
}

