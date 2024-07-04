namespace SnmpApi.Entites
{
    public class Device
    {
        //public int Id { get; set; }
        public string IpAddress { get; set; }
        public string Oid { get; set; }

        public Device(string ipAddress, string oid)
        {
           // Id = id;
            IpAddress = ipAddress;
            Oid = oid;
        }
    }
}
