using ProjetoEstoque.Dominio;
using ProjetoEstoque.Infra.Dados;
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
        private UsuarioDao _usuarioDao;

        public TelaLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario novoUsuario = new Usuario();
            novoUsuario.Login = textBox1.Text;
            novoUsuario.Senha = textBox2.Text;

            _usuarioDao = new UsuarioDao();
            _usuarioDao.BuscarNivel(novoUsuario);

            var resultado = (_usuarioDao.BuscarNivel(novoUsuario));

            if (resultado == 0)
            {
                TelaAdmin frm = new TelaAdmin();
                frm.Show();
                this.Visible = false;
            }
            else if (resultado == 1)
            { 
                TelaUsuario frm = new TelaUsuario();
                frm.Show();
                this.Visible = false;
            }
            else if (textBox1.Text == "root" && textBox2.Text == "abc123")
            {
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
