using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KohonenMap
{
    public partial class MDI : Form
    {
        public int kmapSize = 16;
        public int cellSize = 10;


        public KohonenMap kmap;
        public List<Net> netForms;
        public Net activeNetForm;
        public int activeParam;
        public double[,] inputVectors;
        public Dictionary<string, int> parameters;
        public Dictionary<int, Dictionary<string, double>> minmaxParams;

        int mdiHeight;
        public MDI()
        {
            InitializeComponent();
            mdiHeight = this.Height;
            netForms = new List<Net>();
        }

        private void Cascade_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void Horizontal_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void Vertical_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void LoadData_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    inputVectors = GetTrainData(openFileDialog1.FileName);
                    ParametersList.DropDownItems.Clear();
                    SetParam(openFileDialog1.FileName);
                    kmap = new KohonenMap(kmapSize, inputVectors);
                    MessageBox.Show("Данные загружены", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetParam(string path)
        {
            string[] data = File.ReadAllLines(path);

            parameters = new Dictionary<string, int>();
            MatchCollection matches = Regex.Matches(data[0], @"([^|])+");
            for (int i = 0; i < matches.Count; i++)
            {
                parameters.Add(matches[i].Value, i);
                ParametersList.DropDownItems.Add(matches[i].Value);
                ParametersList.DropDownItems[i].Click += new EventHandler(ToolStripMenuItem_Click);
            }
        }

        public double[,] GetTrainData(string path)
        {
            double min = 10000;
            double max = -10000;

            string[] data = File.ReadAllLines(path);

            int resCount = data.Length - 1;
            double[,] res = new double[resCount, Regex.Matches(data[1], @"\S+").Count];

            MatchCollection matches;
            for (int i = 0; i < resCount; i++)
            {
                matches = Regex.Matches(data[i + 1], @"\S+");
                res[i, 0] = matches[0].Value.Equals("М") ? 1 : 0;
                res[i, 1] = matches[1].Value.Equals("Да") ? 1 : 0;
                for (int j = 2; j < matches.Count; j++)
                {
                    res[i, j] = Convert.ToInt32(matches[j].Value) / 100.0;
                }
            }

            minmaxParams = new Dictionary<int, Dictionary<string, double>>();
            for (int i = 0; i < res.GetLength(1); i++)
            {
                for (int j = 0; j < res.GetLength(0); j++)
                {
                    if (res[j, i] > max) max = res[j, i];
                    if (res[j, i] < min) min = res[j, i];
                }
                Dictionary<string, double> tmp = new Dictionary<string, double>();
                tmp.Add("min", min);
                tmp.Add("max", max);
                minmaxParams.Add(i, tmp);
                min = 10000;
                max = -10000;
            }

            //string tmpp = "";
            //for (int i = 0; i < res.GetLength(0); i++)
            //{
            //    for (int j = 0; j < res.GetLength(1); j++)
            //    {
            //        tmpp += res[i,j].ToString().Replace(",",".")+" ";
            //    }
            //    tmpp += "\r\n";
            //}
            //File.WriteAllText("1.txt", tmpp);
            return res;
        }


        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            activeParam = parameters[tsi.Text];

            Net net = new Net(this, activeParam);
            net.kmapSize = kmapSize;
            net.cellSize = cellSize;
            activeNetForm = net;
            net.MdiParent = this;
            net.Text = tsi.Text;
            netForms.Add(net);
            net.Show();
        }

        private void Recalculate_Click(object sender, EventArgs e)
        {
            RecalculateMap();
        }

        private void ClusterMap_Click(object sender, EventArgs e)
        {
            if (ClusterMap.Checked)
            {
                ClusterMap.Checked = false;
                ClustersCount.Enabled = false;
                activeNetForm.clusterMap = false;
            }
            else
            {
                ClusterMap.Checked = true;
                ClustersCount.Enabled = true;
                activeNetForm.clusterMap = true;
                activeNetForm.clustersCount = (int)ClustersCount.Value;
            }
            activeNetForm.NetPicture.Refresh();
            activeNetForm.RangeScale.Refresh();
        }

        private void HexagonMap_Click(object sender, EventArgs e)
        {
            HexagonMap.Checked = true;
            PixelMap.Checked = false;
            activeNetForm.hexagonMap = true;
            activeNetForm.pixelMap = false;
            activeNetForm.NetPicture.Refresh();
            activeNetForm.RangeScale.Refresh();
        }

        private void PixelMap_Click(object sender, EventArgs e)
        {
            HexagonMap.Checked = false;
            PixelMap.Checked = true;
            activeNetForm.hexagonMap = false;
            activeNetForm.pixelMap = true;
            activeNetForm.NetPicture.Refresh();
            activeNetForm.RangeScale.Refresh();
        }

        private void RangeFromSample_Click(object sender, EventArgs e)
        {
            FullRange.Checked = false;
            activeNetForm.fullRange = false;
            RangeFromSample.Checked = true;
            activeNetForm.rangeFromSample = true;
            activeNetForm.NetPicture.Refresh();
            activeNetForm.RangeScale.Refresh();
        }

        private void FullRange_Click(object sender, EventArgs e)
        {
            FullRange.Checked = true;
            activeNetForm.fullRange = true;
            RangeFromSample.Checked = false;
            activeNetForm.rangeFromSample = false;
            activeNetForm.NetPicture.Refresh();
            activeNetForm.RangeScale.Refresh();
        }

        private void ClustersCount_ValueChanged(object sender, EventArgs e)
        {
            activeNetForm.clustersCount = (int)ClustersCount.Value;
            activeNetForm.NetPicture.Refresh();
            activeNetForm.RangeScale.Refresh();
        }

        private void NodeSizeBox_ValueChanged(object sender, EventArgs e)
        {
            activeNetForm.cellSize = (int)NodeSizeBox.Value;
            activeNetForm.NetPicture.Refresh();
            //foreach (Net nf in netForms)
            //{
            //    nf.cellSize = (int)NodeSizeBox.Value;
            //    nf.NetPicture.Refresh();
            //}
        }

        private void RecalculateMap()
        {
            int mapSize = (int)MapSizeBox.Value;
            kmapSize = mapSize;
            kmap = new KohonenMap(mapSize, inputVectors);
            foreach (Net nf in netForms)
            {
                nf.kmapSize = mapSize;
                nf.map = kmap.GetMap(nf.activeParam);
                nf.NetPicture.Refresh();
                nf.RangeScale.Refresh();
            }
        }


        private void MDI_Resize(object sender, EventArgs e)
        {
            Point p = new Point();
            p = NodeSizeBox.Location;
            p.Y += Height - mdiHeight;
            mdiHeight = Height;

            p.X = NodeSizeBox.Location.X;
            NodeSizeBox.Location = p;
            p.X = MapSizeBox.Location.X;
            MapSizeBox.Location = p;
            p.X = ClustersCount.Location.X;
            ClustersCount.Location = p;
        }
    }
}
