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
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text == "root") && (textBox2.Text == "abc123"))
            {
                TelaAdmin frm = new TelaAdmin();
                frm.Show();
                this.Visible = false;
            }
            else if ((textBox1.Text == "comum") && (textBox2.Text == "abc123")) {
                TelaUsuario frm = new TelaUsuario();
                frm.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Login ou senha inválidos!");
            }
        }
    }
}
