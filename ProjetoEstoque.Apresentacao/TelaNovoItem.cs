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
    public partial class TelaNovoItem : Form
    {
        private ItemDao _itemDao;

        public TelaNovoItem()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item novoItem = new Item();
            novoItem.Nome = textBox1.Text;
            novoItem.Descricao = textBox2.Text;

            _itemDao = new ItemDao();
            _itemDao.Adicionar(novoItem);

            TelaAdmin frm = new TelaAdmin();
            frm.Show();
            this.Visible = false;
        }
    }
}
