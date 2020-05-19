using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Extensions;
using DevExpress.Utils.Extensions;
using DevExpress.XtraCharts;
using IBL.Core.Engine;
using IBL.Core.Models;

namespace IBL.Forms
{
    public partial class FronteirasForm : Form
    {
        private ClassificadorIbl _ibl;
        private HomeForm _homeForm;
        public FronteirasForm(ClassificadorIbl ibl, HomeForm home)
        {
            _ibl = ibl;
            _homeForm = home;
            InitializeComponent();
        }

        private Color Cores(int index)
        {
            switch(index)
            {
                case 0: return Color.Blue;
                case 1: return Color.Red;
                case 2: return Color.Green;
                case 3: return Color.Yellow;
                case 4: return Color.Purple;
                case 5: return Color.Pink;
                default: return Color.Black;
            }
        }

        private Color CoresLigth(int index)
        {
            switch (index)
            {
                case 0: return Color.LightBlue;
                case 1: return Color.LightPink;
                case 2: return Color.LightGreen;
                case 3: return Color.LightYellow;
                case 4: return Color.Brown;
                case 5: return Color.LightSalmon;
                default: return Color.LightGray;
            }
        }

        private double Incremento(double referencia)
        {
            return referencia / 100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChartControl pointChart = new ChartControl();
            int contadorClasse = 0;
            var classes = _ibl.Classes();

            var serieClass = new Series("Fronteira", ViewType.Point);
            serieClass.CheckableInLegend = false;
            serieClass.ShowInLegend = false;
            serieClass.ArgumentScaleType = ScaleType.Auto;

            var incrementoX = Incremento(_ibl._dataset.MaiorX - _ibl._dataset.MenorX); 
            var incrementoY = Incremento(_ibl._dataset.MaiorY - _ibl._dataset.MenorY); 

            for (var i = _ibl._dataset.MenorX - (incrementoX * 10); i < _ibl._dataset.MaiorX + (incrementoX * 10); i = i + incrementoX)
                for (var j = _ibl._dataset.MenorY - (incrementoY * 10); j < _ibl._dataset.MaiorY + (incrementoY * 10); j = j + incrementoY)
                {
                    var item = new Item
                    {
                        X = new Atributo { Valor = i },
                        Y = new Atributo { Valor = j },
                    };

                    var novo = _ibl.Classificar(item);

                    var ponto = new SeriesPoint(item.X.Valor, item.Y.Valor);
                    ponto.Color = CoresLigth(Array.IndexOf(classes, novo.ItemOriginal.Classe));
                    serieClass.Points.Add(ponto);
                }

            pointChart.Series.Add(serieClass);

            PointSeriesView viewClass = (PointSeriesView)serieClass.View;
            viewClass.PointMarkerOptions.Kind = MarkerKind.Square;
            viewClass.PointMarkerOptions.StarPointCount = 5;
            viewClass.PointMarkerOptions.Size = 20;

            //EXISTENTES
            foreach (var classe in classes)
            {
                var serie = new Series(classe, ViewType.Point);
                serie.ArgumentScaleType = ScaleType.Auto;
                foreach (var item in _ibl._dataset.Itens.Where(x => x.ItemOriginal.Classe == classe))
                {
                    var ponto = new SeriesPoint(item.ItemOriginal.X.Valor, item.ItemOriginal.Y.Valor);
                    ponto.Color = Cores(contadorClasse);
                    serie.Points.Add(ponto);
                }
                pointChart.Series.Add(serie);

                PointSeriesView myView1 = (PointSeriesView)serie.View;
                myView1.PointMarkerOptions.Kind = (MarkerKind)contadorClasse;
                myView1.PointMarkerOptions.StarPointCount = 5;
                myView1.PointMarkerOptions.Size = 5;

                contadorClasse++;
            }

            pointChart.Titles.Add(new ChartTitle());
            pointChart.Titles[0].Text = "IBL 1";

            pointChart.Dock = DockStyle.Fill;
            this.Controls.Add(pointChart);
        }

        private void FronteirasForm_Leave(object sender, EventArgs e)
        {
            //_homeForm.Show();
        }

        private void FronteirasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _homeForm.Show();
        }
    }
}
