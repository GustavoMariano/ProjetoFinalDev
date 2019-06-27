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
    public partial class TelaNovoUsuario : Form
    {
        public TelaNovoUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelaAdmin frm = new TelaAdmin();
            frm.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaAdmin frm = new TelaAdmin();
            frm.Show();
            this.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
