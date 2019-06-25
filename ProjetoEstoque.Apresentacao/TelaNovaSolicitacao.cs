using System;
using System.Windows.Forms;

namespace ProjetoEstoque.Apresentacao
{
    public partial class TelaNovaSolicitacao : Form
    {
        public TelaNovaSolicitacao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaUsuario frm = new TelaUsuario();
            frm.Show();
            this.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //IGNORA
        }

        private void button2_Click(object sender, EventArgs e)
        {



            TelaUsuario frm = new TelaUsuario();
            frm.Show();
            this.Visible = false;
        }
    }
}
