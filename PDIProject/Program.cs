using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System.Net;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        string options;
        string oid;
        do
        {
            Console.WriteLine("Bem-vindo ao projeto sobre SNMP!");
            Console.WriteLine("Oque deseja fazer? \n 1- Fazer um walk na rede (Ip pré-definido) \n 2- Buscar o value por um OID especifico \n 0 para SAIR ");
            options = Console.ReadLine();

            switch (options)
            {
                case "1":
                    WalkSNMP();
                    break;

                case "2":
                    Console.WriteLine("Escreva a oid que deseja pesquisar");
                    oid = Console.ReadLine();
                    GetSNMP(oid);
                    break;

                case "0":
                    Console.WriteLine("Tchau...");
                    break;

                default:
                    Console.WriteLine("Valor inválido");
                    break;
            }
        } while (options != "0");
    }

    public static void GetSNMP(string oidWrite)
    {
        try
        {
            var oid = new List<Variable> { new Variable(new ObjectIdentifier(oidWrite)) };
            var result = Messenger.Get(
                VersionCode.V1,
                new IPEndPoint(IPAddress.Parse("192.168.100.40"), 161),
                new OctetString("public"),
                oid,
                60000);

            if (result != null && result.Count > 0)
            {
                var value = result[0].Data.ToString();

                Console.WriteLine($"A OID: {oid[0].Id} tem o seu value de: {value}");
            }
            else
            {
                Console.WriteLine("Erro ao obter o valor do OID.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public static void WalkSNMP()
    {
        try
        {
            var listResult = new List<Variable>();
            Messenger.Walk(VersionCode.V1,
                               new IPEndPoint(IPAddress.Parse("192.168.100.40"), 161),
                               new OctetString("public"),
                               new ObjectIdentifier("1.3.6.1.2.1.1"),
                               listResult,
                               60000,
                               WalkMode.WithinSubtree);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("List Result:");

            foreach (var item in listResult)
            {
                sb.AppendLine($" OID: {item.Id.ToString()}");
                sb.AppendLine($" Value: {item.Data.ToString()}");
                sb.AppendLine("-------");
            }

            string resultString = sb.ToString();
            Console.WriteLine(resultString);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}