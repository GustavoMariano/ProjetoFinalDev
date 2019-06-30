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

    private UsuarioDao _usuarioDao;

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
            Usuario adcUsuario = new Usuario();
            adcUsuario.Nome = textBox1.Text;
            adcUsuario.Login = textBox2.Text;
            adcUsuario.Setor = textBox4.Text;
            adcUsuario.Senha = textBox3.Text;
            adcUsuario.Nivel = comboBox1.SelectedText;

            TelaAdmin frm = new TelaAdmin();
            frm.Show();
            this.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
