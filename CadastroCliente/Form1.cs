using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroCliente
{
    public partial class FrmCadastroCliente : Form
    {

        string connectionString = @"";
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

        }
    }
}
