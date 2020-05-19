using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using IBL.Core.Models;
using IBL.Core.Engine;

namespace IBL.Forms
{
    public partial class HomeForm : Form
    {
        public readonly ClassificadorIbl _ibl;
        public HomeForm()
        {
            _ibl = new ClassificadorIbl();
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Importar Excel";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel File|*.xlsx;*.xls";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var itens = LerExcel(openFileDialog1.FileName);

                _ibl.CarregarDados(itens);

                var classes = itens.GroupBy(x => x.Classe).Select(x => new
                {
                    Classe = x.Key,
                    Quantidade = x.Count()
                });

                lblImportar.Text = $"Importação OK - {itens.Count} exemplos\n";
                foreach(var item in classes)
                    lblImportar.Text += $"{item.Classe} -> {item.Quantidade} exemplos\n";
            }
            else
            {
                lblImportar.Text = "";
            }
        }

        private List<Item> LerExcel(string fileName)
        {
            var lstItens = new List<Item>();
            var xlApp = new Excel.Application();
            var xlWorkBook = xlApp.Workbooks.Open(fileName);

            var a = xlWorkBook.Worksheets;

            var xlWorkSheet = xlWorkBook.Worksheets[1];

            for (var iRow = 2; iRow <= xlWorkSheet.Rows.Count; iRow++)
            {
                if (xlWorkSheet.Cells[iRow, 1].value == null)
                    break;

                lstItens.Add(new Item
                {
                    X = new Atributo { Valor = xlWorkSheet.Cells[iRow, 1].value },
                    Y = new Atributo { Valor = xlWorkSheet.Cells[iRow, 2].value },
                    Classe = xlWorkSheet.Cells[iRow, 3].value
                });
            }

            xlWorkBook.Close();
            xlApp.Quit();

            return lstItens;
        }

        private void btnTreinar_Click(object sender, EventArgs e)
        {
            var acertos = 0;
            var erros = 0;
            for(int i = 0; i < _ibl._dataset.Itens.Count; i++)
            {
                var oneOut = _ibl._dataset.Itens[i];
                var newDataset = new ClassificadorIbl();
                newDataset.CarregarDados(_ibl._dataset.Itens.Where(x => x != oneOut).Select(x => x.ItemOriginal));

                var classificacao = newDataset.Classificar(oneOut.ItemOriginal);

                if (classificacao.ItemOriginal.Classe == oneOut.ItemOriginal.Classe)
                    acertos++;
                else
                    erros++;
            }

            decimal total = acertos + erros;

            lblLeave.Text = "COMPLETO!\n";
            lblLeave.Text += $"Acertos: {acertos} ({(100 * acertos / total):N2}%)\n";
            lblLeave.Text += $"Erros: {erros} ({(100 * erros / total):N2}%)";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var item = new Item
            {
                X = new Atributo { Valor = txtAttr1.Text },
                Y = new Atributo { Valor = txtAttr2.Text },
            };

            var novo = _ibl.Classificar(item);

            lblClassificacao.Text = novo.ItemOriginal.Classe;
        }

        private void btnFronteiras_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FronteirasForm(_ibl, this).Show();
        }
    }
}
