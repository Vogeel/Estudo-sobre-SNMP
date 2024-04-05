using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System.Net;
using System.Net.NetworkInformation;

namespace SnmpSearchForm
{
    public partial class Form1 : Form
    {
        public VersionCode version { get; set; }
        public IPEndPoint IPEndPoints => new IPEndPoint(IPAddress.Parse(ipText.Text), 161);
        public List<Variable> Oid => new List<Variable> { new Variable(new ObjectIdentifier(oidText.Text)) };
        public List<Variable> ListResult;

        public Form1()
        {
            InitializeComponent();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            viewInScreen.Rows.Clear();
            if (CheckFields())
            {
                CheckVersion(version);
                if (getRB.Checked)
                    GetSNMP(ipText.Text, version);
                else if (walkRB.Checked)
                    WalkSNMP(ipText.Text, version);
                else
                    SetSNMP(ipText.Text, version);
            }
        }

        private bool CheckFields()
        {
            if(String.IsNullOrEmpty(ipText.Text) || String.IsNullOrEmpty(oidText.Text) || setRB.Checked && String.IsNullOrEmpty(valueText.Text))
            {
                MessageBox.Show("Preencha os campos");
                return false;
            }
            return true;
        }

        private void SetSNMP(string ip, VersionCode version)
        {
            var oid = new ObjectIdentifier(oidText.Text);
            var newValue = new OctetString(valueText.Text);
            try
            {
                var result = Messenger.Set(version,
                    IPEndPoints,
                    new OctetString("public"),
                    new[] { new Variable(oid, newValue) },
                    60000);
                MessageBox.Show($"Item alterado: {oid} para o valor {newValue}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void WalkSNMP(string ipEndPoint, VersionCode version)
        {
            int cont = 0;
            try
            {
                Messenger.Walk(version,
                                   IPEndPoints,
                                   new OctetString("public"),
                                   new ObjectIdentifier(oidText.Text),
                                   ListResult,
                                   60000,
                                   WalkMode.WithinSubtree);


                foreach (var item in ListResult)
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


        public void GetSNMP(string ipEndPoint, VersionCode version)
        {
            try
            {
                //var oid = new List<Variable> { new Variable(new ObjectIdentifier(oidWrite)) };
                var result = Messenger.Get(
                   version,
                   IPEndPoints,
                   new OctetString("public"),
                   Oid,
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

        private VersionCode CheckVersion(VersionCode version)
        {
            if (v1RB.Checked)
                version = VersionCode.V1;
            else if (v2RB.Checked)
                version = VersionCode.V2;
            else if (v3RB.Checked)
                version = VersionCode.V3;

            return version;
        }

        private void setRB_CheckedChanged(object sender, EventArgs e)
        {
            valueText.Visible = setRB.Checked;
            valueLabel.Visible = setRB.Checked;
        }
    }
}
