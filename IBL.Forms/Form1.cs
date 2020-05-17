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
    public partial class Form1 : Form
    {
        private ClassificadorIbl _ibl;
        public Form1()
        {
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

        private void CarregarDataset()
        {
            var lstItens = new List<Item>();
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 35 },
                Y = new Atributo { Valor = 14 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 45 },
                Y = new Atributo { Valor = 10 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 44 },
                Y = new Atributo { Valor = 11 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 40 },
                Y = new Atributo { Valor = 11 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 35 },
                Y = new Atributo { Valor = 20 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 36 },
                Y = new Atributo { Valor = 18 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 37 },
                Y = new Atributo { Valor = 17 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 39 },
                Y = new Atributo { Valor = 20 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 41 },
                Y = new Atributo { Valor = 14 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 41 },
                Y = new Atributo { Valor = 14 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 38 },
                Y = new Atributo { Valor = 12 },
                Classe = "SIM"
            });

            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 36 },
                Y = new Atributo { Valor = 9 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 47 },
                Y = new Atributo { Valor = 6 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 46 },
                Y = new Atributo { Valor = 8 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 70 },
                Y = new Atributo { Valor = 21 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 47 },
                Y = new Atributo { Valor = 22 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 50 },
                Y = new Atributo { Valor = 25 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 55 },
                Y = new Atributo { Valor = 27 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 46 },
                Y = new Atributo { Valor = 55 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 20 },
                Y = new Atributo { Valor = 1 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 34 },
                Y = new Atributo { Valor = 5 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 33 },
                Y = new Atributo { Valor = 57 },
                Classe = "NAO"
            });

            //var jsonString = JsonConvert.SerializeObject(lstItens.Select(a => new { 
            //    x = a.X.Valor,
            //    y = a.Y.Valor,
            //    title = a.Classe
            //}));

            //File.WriteAllText("sim.json", jsonString);

           
            _ibl = new ClassificadorIbl();
            _ibl.CarregarDados(lstItens);

            //var item = new Item
            //{
            //    X = new Atributo { Valor = 34 },
            //    Y = new Atributo { Valor = 9 },
            //};

            //var novo = _ibl.Classificar(item);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarDataset();
            ChartControl pointChart = new ChartControl();
            int contadorClasse = 0;
            var classes = _ibl.Classes();

            var serieClass = new Series("Fronteira", ViewType.Point);
            serieClass.CheckableInLegend = false;
            serieClass.ShowInLegend = false;
            serieClass.ArgumentScaleType = ScaleType.Auto;

            for (var i = _ibl._dataset.MenorX - 10; i < _ibl._dataset.MaiorX + 10; i++)
                for(var j = _ibl._dataset.MenorY - 10; j < _ibl._dataset.MaiorY + 10; j++)
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
    }
}
