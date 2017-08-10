using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroCliente
{
    public partial class FrmCadastroCliente : Form
    {

        string connectionString = @"Server=SERGIO-PC\SQLEXPRESS;Database=CADASTRO;Trusted_Connection=True";
        bool novo;
       

        public FrmCadastroCliente()
        {
            InitializeComponent();
        }

        private void FrmCadastroCliente_Load(object sender, EventArgs e)
        {
            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tsbPesquisar.Enabled = true;
            tstID.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            mskCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            mskFixo.Enabled = false;
            mskCelular.Enabled = false;


        }

        private void tsbNovo_Click(object sender, EventArgs e)
        {
            tsbNovo.Enabled = false;
            tsbSalvar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbExcluir.Enabled = false;
            tstID.Enabled = false;
            tsbPesquisar.Enabled = false;
            txtNome.Enabled = true;
            txtEndereco.Enabled = true;
            mskCEP.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtUF.Enabled = true;
            mskFixo.Enabled = true;
            mskCelular.Enabled = true;
            txtNome.Focus();
            novo = true;
        }

        private void tsbSalvar_Click(object sender, EventArgs e)
        {
            if  (novo)
            {
                string sql = "INSERT INTO CLIENTE(NOME,ENDERECO,CEP,BAIRRO,CIDADE,UF,TELEFONE,TELEFONECEL)" +
                                                    "VALUES ('" + txtNome.Text + "' , '" 
                                                                + txtEndereco.Text + "' , '"
                                                                + mskCEP.Text + "' , '"
                                                                + txtBairro.Text + "' , '"
                                                                + txtCidade.Text + "' , '"
                                                                + txtUF.Text + "' , '"
                                                                + mskFixo.Text + "' , '"
                                                                + mskCelular.Text + "' )";

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                        MessageBox.Show("Cadastro Realizado com Sucesso!!!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                   
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {
                
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(" UPDATE CLIENTE SET  NOME=@NOME,  ENDERECO=@ENDERECO," +
                                                "  CEP=CEP,  BAIRRO=@BAIRRO,  CIDADE=@CIDADE,  UF=@UF, " +
                                                " TELEFONE=@TELEFONE,  TELEFONECEL=@TELEFONECEL WHERE ID=@ID ", con);
                cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = txtId.Text;
                cmd.Parameters.Add("@NOME", SqlDbType.VarChar).Value = txtNome.Text;
                cmd.Parameters.Add("@ENDERECO", SqlDbType.VarChar).Value = txtEndereco.Text;
                cmd.Parameters.Add("@CEP", SqlDbType.VarChar).Value = mskCEP.Text;
                cmd.Parameters.Add("@BAIRRO", SqlDbType.VarChar).Value = txtBairro.Text;
                cmd.Parameters.Add("@CIDADE", SqlDbType.VarChar).Value = txtCidade.Text;
                cmd.Parameters.Add("@UF", SqlDbType.VarChar).Value = txtUF.Text;
                cmd.Parameters.Add("@TELEFONE", SqlDbType.VarChar).Value = mskFixo.Text;
                cmd.Parameters.Add("@TELEFONECEL", SqlDbType.VarChar).Value = mskCelular.Text;
                con.Open();

                try
                {
                   cmd.ExecuteNonQuery();                    
                        MessageBox.Show("Cadastro Atualizado com Sucesso!!!");
                }
                catch (Exception ex)
                {
                        MessageBox.Show("Erro:" + ex.ToString());
                }
                finally
                {
                    con.Close();

                }
            }

            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstID.Enabled = true;
            tsbPesquisar.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            mskCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            mskFixo.Enabled = false;
            mskCelular.Enabled = false;
            txtId.Text = "";
            txtNome.Text= "";
            txtEndereco.Text = "";
            mskCEP.Text = "";
            txtCidade.Text = "";
            txtBairro.Text = "";
            txtUF.Text = "";
            mskFixo.Text = "";
            mskCelular.Text = "";

           
        }

        private void tsbCancelar_Click(object sender, EventArgs e)
        {
            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstID.Enabled = true;
            tsbPesquisar.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            mskCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            mskFixo.Enabled = false;
            mskCelular.Enabled = false;
            txtId.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            mskCEP.Text = "";
            txtCidade.Text = "";
            txtBairro.Text = "";
            txtUF.Text = "";
            mskFixo.Text = "";
            mskCelular.Text = "";
        }

        private void tsbExcluir_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM CLIENTE WHERE ID=" + txtId.Text;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();

            try
            {
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    MessageBox.Show("Registro excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            tsbNovo.Enabled = true;
            tsbSalvar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbExcluir.Enabled = false;
            tstID.Enabled = true;
            tsbPesquisar.Enabled = true;
            txtNome.Enabled = false;
            txtEndereco.Enabled = false;
            mskCEP.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtUF.Enabled = false;
            mskFixo.Enabled = false;
            mskCelular.Enabled = false;
            txtId.Text = "";
            txtNome.Text = "";
            txtEndereco.Text = "";
            mskCEP.Text = "";
            txtCidade.Text = "";
            txtBairro.Text = "";
            txtUF.Text = "";
            mskFixo.Text = "";
            mskCelular.Text = "";
        }

        private void tsbPesquisar_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM CLIENTE WHERE ID=" + tstID.Text;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {

                reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    tsbNovo.Enabled = false;
                    tsbSalvar.Enabled = true;
                    tsbCancelar.Enabled = true;
                    tsbExcluir.Enabled = true;
                    tstID.Enabled = false;
                    tsbPesquisar.Enabled = false;
                    txtNome.Enabled = true;
                    txtEndereco.Enabled = true;
                    mskCEP.Enabled = true;
                    txtBairro.Enabled = true;
                    txtCidade.Enabled = true;
                    txtUF.Enabled = true;
                    mskFixo.Enabled = true;
                    mskCelular.Enabled = true;
                    txtNome.Focus();
                    txtId.Text = reader[0].ToString();
                    txtNome.Text = reader[1].ToString();
                    txtEndereco.Text = reader[2].ToString();
                    mskCEP.Text = reader[3].ToString();
                    txtBairro.Text = reader[4].ToString();
                    txtCidade.Text = reader[5].ToString();
                    txtUF.Text = reader[6].ToString();
                    mskFixo.Text = reader[7].ToString();
                    mskCelular.Text = reader[8].ToString();
                    novo = false;
                }
                else
                {
                    MessageBox.Show("Nenhum Registro Encontrado com o Número Informado!!!!");

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.ToString());
            }
            finally
            {
                con.Close();

            }

            tstID.Text = "";
        }
    }
}
