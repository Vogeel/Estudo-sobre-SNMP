using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Windows.Forms;

namespace SnmpSearchForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if(getRB.Checked) 
                GetSNMP(ipText.Text, oidText.Text);
            else
                WalkSNMP(ipText.Text);

        }

        private void SearchIpBtn_Click(object sender, EventArgs e)
        {
            SearchIPsOnNetwork();

        }

        private void SearchIPsOnNetwork()
        {
            Process process = new();

            process.StartInfo.FileName = "arp";

            process.StartInfo.Arguments = "-a";

            process.StartInfo.RedirectStandardOutput = true;

            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.UseShellExecute = false;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit(); // Aguarda o término do processo

            // Divide a saída em linhas e adiciona ao DataGridView
            string[] linhas = output.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string linha in linhas)
            {
                viewInScreen.Rows.Add(linha.Split(""));
            }
        }

        public void WalkSNMP(string ipEndPoint)
        {
            int cont = 0;
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


                foreach (var item in listResult)
                {
                    viewInScreen.Rows[cont].Cells[0].Value = oidText.Text;
                    viewInScreen.Rows[cont].Cells[1].Value = item.Data.ToString();
                    cont++;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public void GetSNMP(string ipEndPoint, string oidWrite)
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

                var value = result[0].Data.ToString();

                viewInScreen.Rows[0].Cells[0].Value = oidText.Text;
                viewInScreen.Rows[0].Cells[1].Value = value;

            }
            catch
            {
                MessageBox.Show($"Erro ao bucar a oid:{oidText.Text}", "Erro");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Controls.Add(viewInScreen);

            viewInScreen.Columns.Add("OID", "OID");
            viewInScreen.Columns.Add("Value", "Value");

        }

    }
}
