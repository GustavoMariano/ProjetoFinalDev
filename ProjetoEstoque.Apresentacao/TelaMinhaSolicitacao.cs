using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoEstoque.Apresentacao
{
    public partial class TelaMinhaSolicitacao : Form
    {
        public TelaMinhaSolicitacao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaUsuario frm = new TelaUsuario();
            frm.Show();
            this.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
