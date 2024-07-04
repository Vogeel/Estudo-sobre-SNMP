using SnmpApi.Entites;

namespace SnmpApi.DataBase
{
    public class DeviceRepository
    {

        public static List<Device> DeviceDataBase {  get; set; } = new List<Device>();

        public void FakePopulate()
        {
            Device notebook = new Device("192.168.100.40", "1.3.6.1.2.1.1");
            //Device computer = new Device(2, "192.168.100.8"); Tem que configurar o pc para snmp

            DeviceDataBase.Add(notebook);
            //DeviceDataBase.Add(computer);
        }
    }
}
