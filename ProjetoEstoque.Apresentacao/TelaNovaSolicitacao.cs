using ProjetoEstoque.Dominio;
using ProjetoEstoque.Infra.Dados;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace ProjetoEstoque.Apresentacao
{
    public partial class TelaNovaSolicitacao : Form
    {
        private SolicitacaoDao _solicitacaoDao;

        public TelaNovaSolicitacao()
        {
            InitializeComponent();
            carregaCombo();
        }

        private void carregaCombo()
        {
            //definir a string de conexao
            String strConn = "Data Source=DESKTOP-U8FJF43;Initial Catalog=db_devsis_estoque;Integrated Security=True";

            //define a conexao
            SqlConnection conn = new SqlConnection(strConn);

            //criar um adaptador
            SqlDataAdapter da = new SqlDataAdapter("select nome from tb_item", conn);

            conn.Open();
            DataSet ds = new DataSet();
            //preenche o DataTable
            da.Fill(ds, "Item");

            //carrega as informacoes no combo
            comboBox1.DataSource = ds.Tables["Item"];
            comboBox1.DisplayMember = "Nome";

            comboBox3.DataSource = ds.Tables["Item"];
            comboBox3.DisplayMember = "Nome";

            comboBox4.DataSource = ds.Tables["Item"];
            comboBox4.DisplayMember = "Nome";
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
            novaSolicitacao = new Solicitacao();
            novaSolicitacao.DataCriacao = DateTime.Today;
            novaSolicitacao.Status = "Pendente";
            novaSolicitacao.DataFinalizacao = DateTime.Today.AddMonths(1);
            novaSolicitacao.Usuario = "MELIOR PROFEÇOR";
            novaSolicitacao.Prioridade = comboBox2.Text;
            novaSolicitacao.Item1 = comboBox1.Text + " ; " + textBox3.Text;
            novaSolicitacao.Item2 = comboBox3.Text + " ; " + textBox4.Text;
            novaSolicitacao.Item3 = comboBox4.Text + " ; " + textBox7.Text;
            novaSolicitacao.Qtd1 = textBox1.Text;
            novaSolicitacao.Qtd2 = textBox2.Text;
            novaSolicitacao.Qtd3 = textBox5.Text;

            _solicitacaoDao = new SolicitacaoDao();
            _solicitacaoDao.Solicitar(novaSolicitacao);

            TelaUsuario frm = new TelaUsuario();
            frm.Show();
            this.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void TelaNovaSolicitacao_Load(object sender, EventArgs e)
        {

        }
    }
}
