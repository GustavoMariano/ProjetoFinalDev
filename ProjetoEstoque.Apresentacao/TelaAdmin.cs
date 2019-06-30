using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoEstoque.Dominio;
using ProjetoEstoque.Infra.Dados;

namespace ProjetoEstoque.Apresentacao
{
    public partial class TelaAdmin : Form
    {
        public TelaAdmin()
        {
            InitializeComponent();
            

        }

        private void TelaAdmin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TelaLogin frm = new TelaLogin();
            frm.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaNovoUsuario frm = new TelaNovoUsuario();
            frm.Show();
            this.Visible = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
