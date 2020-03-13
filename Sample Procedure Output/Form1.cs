using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Sample_Procedure_Output
{
    public partial class Form1 : Form
    {
        private DAO dao = new DAO();
        
            public Form1()
        {
            InitializeComponent();
        }

        private void травыBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.травыBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.travkiDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "travkiDataSet.Cборщики". При необходимости она может быть перемещена или удалена.
            this.cборщикиTableAdapter.Fill(this.travkiDataSet.Cборщики);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "travkiDataSet.Травы". При необходимости она может быть перемещена или удалена.
            this.травыTableAdapter.Fill(this.travkiDataSet.Травы);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dao.ReduceHerbsCost();
            травыTableAdapter.Fill(travkiDataSet.Травы);
        }
    }
}
