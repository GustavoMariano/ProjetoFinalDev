using ProjetoEstoque.Dominio;
using ProjetoEstoque.Infra.Dados;
using System;
using System.Windows.Forms;


namespace ProjetoEstoque.Apresentacao
{
    public partial class TelaNovaSolicitacao : Form
    {
        private SolicitacaoDao _solicitacaoDao;

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
            Solicitacao novaSolicitacao = new Solicitacao();
            novaSolicitacao.DataCriacao = DateTime.Today;
            novaSolicitacao.Status = "Pendente";
            novaSolicitacao.DataFinalizacao = DateTime.Today.AddMonths(1);
            novaSolicitacao.Usuario = ".";
            novaSolicitacao.Prioridade = comboBox2.Text;
            novaSolicitacao.Itens =  textBox1.Text + textBox2.Text + textBox3.Text + numericUpDown1.TabIndex + "; " + 
                                     textBox4.Text + textBox5.Text + textBox6.Text + numericUpDown2.TabIndex + "; " +
                                     textBox7.Text + textBox8.Text + textBox9.Text + numericUpDown3.TabIndex + "; ";

            _solicitacaoDao = new SolicitacaoDao();
            _solicitacaoDao.Solicitar(novaSolicitacao);

            TelaUsuario frm = new TelaUsuario();
            frm.Show();
            this.Visible = false;
        }
    }
}
