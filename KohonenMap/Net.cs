using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KohonenMap
{
    public partial class Net : Form
    {
        MDI mdi;

        public int activeParam;
        public double[,] map;
        public bool fullRange = false;
        public bool rangeFromSample = true;
        public bool pixelMap = false;
        public bool hexagonMap = true;
        public bool clusterMap = false;
        public int clustersCount = 3;
        public int kmapSize;
        public int cellSize;

        public Net(MDI mdi, int activeParam)
        {
            this.mdi = mdi;
            this.activeParam = activeParam;
            map = mdi.kmap.GetMap(activeParam);
            InitializeComponent();
        }

        private void Net_Activated(object sender, EventArgs e)
        {
            mdi.toolStrip1.Enabled = true;
            mdi.activeParam = activeParam;
            mdi.activeNetForm = this;
            mdi.MapSizeBox.Enabled = true;
            mdi.NodeSizeBox.Enabled = true;
            mdi.ClustersCount.Enabled = clusterMap;
            mdi.FullRange.Checked = fullRange;
            mdi.RangeFromSample.Checked = rangeFromSample;
            mdi.PixelMap.Checked = pixelMap;
            mdi.HexagonMap.Checked = hexagonMap;
            mdi.ClusterMap.Checked = clusterMap;
            mdi.MapSizeBox.Value = kmapSize;
            mdi.NodeSizeBox.Value = cellSize;
            mdi.ClustersCount.Value = clustersCount;
        }

        private void Net_FormClosed(object sender, FormClosedEventArgs e)
        {
            mdi.activeParam = -1;
            mdi.activeNetForm = null;
            mdi.toolStrip1.Enabled = false;
            mdi.MapSizeBox.Enabled = false;
            mdi.NodeSizeBox.Enabled = false;
            mdi.ClustersCount.Enabled = false;
            mdi.netForms.Remove(this);
        }

        private void RangeScale_Paint(object sender, PaintEventArgs e)
        {
            if (clusterMap)
            {
                DrawScaleClusters(e.Graphics, clustersCount);
            }
            else if (fullRange)
            {
                DrawScale(e.Graphics, 0, 100);
            }
            else
            {
                DrawScale(e.Graphics, mdi.minmaxParams[activeParam]["min"] * 100, mdi.minmaxParams[activeParam]["max"] * 100);
            }
        }

        private void NetPicture_Paint(object sender, PaintEventArgs e)
        {
            if (pixelMap)
            {
                if (clusterMap)
                {
                    if (rangeFromSample)
                    {
                        DrawPixelMap(GetClusters(map,
                            clustersCount,
                            mdi.minmaxParams[activeParam]["min"],
                            mdi.minmaxParams[activeParam]["max"]),
                            cellSize, false, e.Graphics);
                    }
                    else
                    {
                        DrawPixelMap(GetClusters(map,
                            clustersCount),
                            cellSize, false, e.Graphics);
                    }
                }
                else
                {
                    if (rangeFromSample)
                    {
                        DrawPixelMap(GetRangeBlueToRed(map,
                            mdi.minmaxParams[activeParam]["min"],
                            mdi.minmaxParams[activeParam]["max"]),
                            cellSize, false, e.Graphics);
                    }
                    else
                    {
                        DrawPixelMap(GetRangeBlueToRed(map),
                            cellSize, false, e.Graphics);
                    }
                }
            }
            else
            {
                if (clusterMap)
                {
                    if (rangeFromSample)
                    {
                        DrawHexagonMap(GetClusters(map,
                            clustersCount,
                            mdi.minmaxParams[activeParam]["min"],
                            mdi.minmaxParams[activeParam]["max"]),
                            cellSize, false, e.Graphics);
                    }
                    else
                    {
                        DrawHexagonMap(GetClusters(map,
                            clustersCount),
                            cellSize, false, e.Graphics);
                    }
                }
                else
                {
                    if (rangeFromSample)
                    {
                        DrawHexagonMap(GetRangeBlueToRed(map,
                            mdi.minmaxParams[activeParam]["min"],
                            mdi.minmaxParams[activeParam]["max"]),
                            cellSize, false, e.Graphics);
                    }
                    else
                    {
                        DrawHexagonMap(GetRangeBlueToRed(map),
                            cellSize, false, e.Graphics);
                    }
                }
            }
        }


        private void DrawPixelMap(Color[,] mapColors, int cellSize, bool borders, Graphics gr)
        {
            int lineW = 1;

            int tableDimension = mapColors.GetLength(0);
            int w = cellSize * tableDimension;
            int h = cellSize * tableDimension;

            int widthLines = cellSize;
            int heightLines = cellSize;

            if (borders)
            {
                gr.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, w, h));
                for (int i = 0; i < w; i += widthLines)
                {
                    gr.DrawLine(new Pen(Color.Black), new Point(i + widthLines, 0), new Point(i + widthLines, h));
                    gr.DrawLine(new Pen(Color.Black), new Point(0, i + heightLines), new Point(w, i + heightLines));
                }
            }
            else
            {
                lineW = 0;
            }

            SolidBrush color;
            for (int x = 0; x < mapColors.GetLength(0); x++)
            {
                for (int y = 0; y < mapColors.GetLength(1); y++)
                {
                    color = new SolidBrush(mapColors[y, x]);
                    gr.FillRectangle(color, new Rectangle(x * cellSize + lineW, y * cellSize + lineW, widthLines - lineW, heightLines - lineW));
                }
            }
        }

        private void DrawHexagonMap(Color[,] mapColors, int hexR, bool flatTop, Graphics gr)
        {
            int _X = hexR; // координаты точки, 
            int _Y = hexR; // откуда начинается отрисовка

            int flag = 1;
            int R = hexR;
            int x = _X;
            int y = _Y;

            if (flatTop)
            {
                int r = (int)(R * Math.Sqrt(3) / 2);
                for (int i = 0; i < mapColors.GetLength(0); i++)
                {
                    for (int j = 0; j < mapColors.GetLength(1); j++)
                    {
                        DrawHexagon(mapColors[i, j], flatTop, new Point(x, y), R, gr);
                        y += r * 2 + 1;
                    }
                    x += R * 3 / 2 - 1;
                    y = _Y + r * flag;
                    flag = flag == 1 ? 0 : 1;
                }
            }
            else
            {
                int r = (int)(R * Math.Sqrt(3) / 2);
                for (int i = 0; i < mapColors.GetLength(0); i++)
                {
                    for (int j = 0; j < mapColors.GetLength(1); j++)
                    {
                        DrawHexagon(mapColors[i, j], flatTop, new Point(x, y), R, gr);
                        x += r * 2 + 1;
                    }

                    x = _X + r * flag;
                    y += R * 3 / 2 - 1;
                    flag = flag == 1 ? 0 : 1;
                }
            }

        }

        private void DrawHexagon(Color c, bool flatTop, Point center, int R, Graphics gr)
        {
            int _OffSet = flatTop ? 355 : 233; //355 233

            List<Point> p = new List<Point>();

            for (int i = 0; i < 360; i += 60)
            {
                double x = Math.Cos(2 * Math.PI * i / 360 + _OffSet) * R + center.X;
                double y = Math.Sin(2 * Math.PI * i / 360 + _OffSet) * R + center.Y;
                p.Add(new Point((int)x, (int)y));
            }
            //gr.DrawPolygon(Pens.Black, p.ToArray());
            gr.FillPolygon(new SolidBrush(c), p.ToArray());
        }

        private Color[,] GetClusters(double[,] map, int clusterCount, double min = 0, double max = 1)
        {
            Color[,] cMap = new Color[map.GetLength(0), map.GetLength(1)];
            for (int x = 0; x < cMap.GetLength(0); x++)
            {
                for (int y = 0; y < cMap.GetLength(1); y++)
                {
                    cMap[x, y] = GetClusteredColor(map[x, y], clustersCount, min, max);
                }
            }
            return cMap;
        }

        private Color GetClusteredColor(double d, int clusterCount, double min = 0, double max = 1)
        {
            d -= min;
            max -= min;
            min = 0;
            Color res = new Color();
            double clusterRange = Math.Round(max / clusterCount, 5);
            for (double i = clusterRange; i <= max + clusterRange; i += clusterRange)
            {
                if ((i - clusterRange) < d && d < i)
                {
                    res = GetColor(i, min, max);
                }
            }
            return res;
        }

        private Color[,] GetRangeBlueToRed(double[,] map, double min = 0, double max = 1)
        {
            Color[,] cMap = new Color[map.GetLength(0), map.GetLength(1)];
            for (int x = 0; x < cMap.GetLength(0); x++)
            {
                for (int y = 0; y < cMap.GetLength(1); y++)
                {
                    cMap[x, y] = GetColor(map[x, y], min, max);
                }
            }
            return cMap;
        }

        private Color GetColor(double d, double min = 0, double max = 1)
        {
            d -= min;
            max -= min;
            min = 0;

            int rg = 0;
            int gb = 0;
            int r = 0;
            int g = 0;
            int b = 0;

            double middle = min + (max - min) / 2;
            Color res = new Color();

            if (d == max)
            {
                res = Color.FromArgb(255, 0, 0);
            }
            else if (d == middle)
            {
                res = Color.FromArgb(0, 255, 0);
            }
            else if (d == min)
            {
                res = Color.FromArgb(0, 0, 255);
            }
            else if (d < middle)
            {
                gb = (int)(510 * d / middle);
                if (gb <= 255)
                {
                    r = 0;
                    g = gb;
                    b = 255;
                    res = Color.FromArgb(r, g, b);
                }
                else if (gb > 255)
                {
                    r = 0;
                    g = 255;
                    b = 255 - (gb - 255);
                    res = Color.FromArgb(r, g, b);
                }
            }
            else if (d > middle)
            {
                rg = (int)(510 * (d - middle) / middle);
                if (rg <= 255)
                {
                    r = rg;
                    g = 255;
                    b = 0;
                    res = Color.FromArgb(r, g, b);
                }
                else if (rg > 255)
                {
                    r = 255;
                    g = 255 - (rg - 255);
                    b = 0;
                    res = Color.FromArgb(r, g, b);
                }
            }
            return res;
        }

        private void DrawScale(Graphics gr, double min, double max)
        {
            double middle = min + (max - min) / 2;
            ScaleMin.Text = min.ToString();
            ScaleMiddle.Text = middle.ToString();
            ScaleMax.Text = max.ToString();

            double middleRange = RangeScale.Height / 2;
            gr.DrawLine(new Pen(new SolidBrush(Color.Black), 2), 0, 1, RangeScale.Width, 1);
            for (int i = 2; i < RangeScale.Height; i++)
            {
                if (i == middleRange)
                {
                    gr.DrawLine(new Pen(new SolidBrush(Color.Black), 2), 0, i, RangeScale.Width, i);
                }
                else
                {
                    gr.DrawLine(new Pen(new SolidBrush(GetColor(i, 0, RangeScale.Height))), 22, i, RangeScale.Width, i);
                }
            }
            gr.DrawLine(new Pen(new SolidBrush(Color.Black), 2), 0, RangeScale.Height - 1, RangeScale.Width, RangeScale.Height - 1);
        }

        private void DrawScaleClusters(Graphics gr, int clusterCount)
        {
            ScaleMin.Text = "0";
            ScaleMiddle.Text = "";
            ScaleMax.Text = (clusterCount - 1).ToString();

            double fullClust = RangeScale.Height / clusterCount;
            double halfClust = fullClust / 2;

            int start = (int)(fullClust + halfClust);
            int step = (int)fullClust;

            gr.DrawLine(new Pen(new SolidBrush(Color.Black), 2), 0, 1, RangeScale.Width, 1);
            for (int i = 2; i < RangeScale.Height; i++)
            {
                if (i == start && i < RangeScale.Height - step)
                {
                    gr.DrawString((start / step).ToString(), DefaultFont, new SolidBrush(Color.Black), -2, i - 5);
                    gr.DrawLine(new Pen(new SolidBrush(Color.Black), 1), 10, i, RangeScale.Width, i);
                    start += step;
                }
                else
                {
                    gr.DrawLine(new Pen(new SolidBrush(
                        GetClusteredColor(i, clusterCount, 0, RangeScale.Height))),
                        22, i, RangeScale.Width, i);
                }
            }
            gr.DrawLine(new Pen(new SolidBrush(Color.Black), 2), 0, RangeScale.Height - 1, RangeScale.Width, RangeScale.Height - 1);
        }

    }
}
