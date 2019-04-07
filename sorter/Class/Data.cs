using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace sorter.Class
{
    public class Data
    {
        private Canvas canvas;
        public Data(Canvas targetCanvas)
        {
            canvas = targetCanvas;
        }
        //データ数
        private int n;
        //データ
        private double[] data_array;
        public double[] data
        {
            get => data_array;
            set
            {
                
                data_array = value;
            }
        }
    }
}
