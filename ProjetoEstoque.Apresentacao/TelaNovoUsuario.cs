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

    public partial class TelaNovoUsuario : Form
    {
        private UsuarioDao _usuarioDao;
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
            Usuario novoUsuario = new Usuario();
            novoUsuario.Nome = textBox1.Text;
            novoUsuario.Login = textBox2.Text;
            novoUsuario.Setor = textBox4.Text;
            novoUsuario.Senha = textBox3.Text;
            novoUsuario.Nivel = comboBox1.SelectedText;

            _usuarioDao = new UsuarioDao();
            _usuarioDao.Adicionar(novoUsuario);

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
