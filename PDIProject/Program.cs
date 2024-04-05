using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System.Diagnostics;
using System.Net;
using System.Text;
#nullable disable

internal class Program
{
    private static void Main(string[] args)
    {
        string options;
        string oid;
        string ipEndPoint = "";
        do
        {
            Console.WriteLine("Bem-vindo ao projeto sobre SNMP!");


            if (String.IsNullOrEmpty(ipEndPoint))
            {
                test();
                Console.WriteLine("Aperte qualquer tecla para fazer busca de ip na rede");
                Console.ReadKey();
                GetIpsOnNetwork();
                Console.WriteLine("Digite o IP End Point para fazer a busca");
                ipEndPoint = Console.ReadLine();
            }

            Console.WriteLine("Oque deseja fazer? \n 1- Fazer um walk na rede \n 2- Buscar o value por um OID especifico \n 0 para SAIR ");
            options = Console.ReadLine();

            switch (options)
            {
                case "1":
                    WalkSNMP(ipEndPoint);
                    break;

                case "2":
                    Console.WriteLine("Escreva a oid que deseja pesquisar");
                    oid = Console.ReadLine();
                    GetSNMP(ipEndPoint, oid);
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
    public static void GetIpsOnNetwork()
    {
        Process process = new();

        process.StartInfo.FileName = "arp";

        process.StartInfo.Arguments = "-a";

        process.StartInfo.RedirectStandardOutput = true;

        process.StartInfo.CreateNoWindow = true;

        process.StartInfo.UseShellExecute = false;

        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);

        process.WaitForExit();


    }
    public static void GetSNMP(string ipEndPoint,string oidWrite)
    {
        try
        {
            var oid = new List<Variable> { new Variable(new ObjectIdentifier(oidWrite)) };
             var result = Messenger.Get(
                VersionCode.V2,
                new IPEndPoint(IPAddress.Parse(ipEndPoint), 161),
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

    public static void WalkSNMP(string ipEndPoint)
    {
        int cont = 0;
        int oldCont = 0;
        string res;
        try
        {
            var listResult = new List<Variable>();
            Messenger.Walk(VersionCode.V1,
                               new IPEndPoint(IPAddress.Parse(ipEndPoint), 161),
                               new OctetString("public"),
                               new ObjectIdentifier("1.3.6.1.2.1"),
                               listResult,
                               60000,
                               WalkMode.WithinSubtree);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("List Result:");

            foreach (var item in listResult)
            {
                sb.AppendLine($" OID: {item.Id.ToString()}");
                sb.AppendLine($" Value: {item.Data.ToString()}\n");
                sb.AppendLine("-------\n");
                cont++;
                if(cont == 10)
                {
                    string resultString = sb.ToString();
                    Console.WriteLine(resultString);

                    oldCont =+ cont;
                    cont = 0;
                    Console.WriteLine($"itens listados: {oldCont}, deseja carregar mais? s/n");
                    res = Console.ReadLine();
                    if (res == "s")
                        continue;
                    else
                        break;
                }
            }
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public static void test()
    {
        var ipAddress = IPAddress.Parse("192.168.100.40");
        var target = new IPEndPoint(ipAddress, 161);

        // Defina a comunidade SNMP
        var community = new OctetString("public");

        // Defina a OID base para obter informações sobre as interfaces de rede (IF-MIB)
        var ifMibBase = new ObjectIdentifier("1.3.6.1.2.1.2");

        // Lista para armazenar as informações sobre as interfaces de rede
        var interfaceInfo = new List<Variable>();

        // Envie uma solicitação SNMP Walk para obter informações sobre as interfaces de rede
        Messenger.Walk(VersionCode.V2,
                        target,
                        community,
                        ifMibBase,
                        interfaceInfo,
                        60000,
                        WalkMode.WithinSubtree);
        foreach (Variable variable in interfaceInfo)
        {
            Console.WriteLine($"{variable.Id}: {variable.Data}");
        }
    }
}