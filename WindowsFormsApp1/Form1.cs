using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static WindowsFormsApp1.StorageService;

namespace MatrixTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void LoadTrayMatrix(List<StorageTrayDetailInfo> source)
        {
            if (source != null) ucMatrixTable1.LoadDataSource(source);
            else ucMatrixTable1.LoadDataSource(null);

            ucMatrixTable1.SelectedItem = ucMatrixTable1.Cells[1, 1];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //ucMatrixTable1.LoadDataSource(new List<Sample>
            //    {
            //    new Sample { Row = 2, Col = 2, TextDisplay = "2, 2" },
            //        new Sample { Row = 3, Col = 2, TextDisplay = "3, 2" },
            //        new Sample { Row = 4, Col = 3, TextDisplay = "4, 3" },
            //        new Sample { Row = 7, Col = 5, TextDisplay = "7, 5" },
            //        new Sample { Row = 9, Col = 2, TextDisplay = "9, 2" }
            //    });


            LoadTrayMatrix(new List<StorageTrayDetailInfo>
                {
                    new StorageTrayDetailInfo { RowIndex = 2, ColumnName = "B", SID = "2, 2" , Type = "N"},
                    new StorageTrayDetailInfo { RowIndex = 3, ColumnName = "B", SID = "3, 2" , Type = "N"},
                    new StorageTrayDetailInfo { RowIndex = 4, ColumnName = "D", SID = "4, 3" , Type = "N"},
                    new StorageTrayDetailInfo { RowIndex = 7, ColumnName = "E", SID = "7, 5" , Type = "N"},
                    new StorageTrayDetailInfo { RowIndex = 9, ColumnName = "B", SID = "9, 2" , Type = "N"}
                });

        }

        static char test = 'A';
        static bool ex = false;
        int row = 1;
        int col = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            test++;
            ex ^= true;
            if (row == 10) row = 1;
            LoadTrayMatrix(new List<StorageTrayDetailInfo>
                {
                new StorageTrayDetailInfo { RowIndex = row, ColumnName = "B", SID = "2, 2" , Type = test.ToString(), IsExport = ex},
                    new StorageTrayDetailInfo { RowIndex = row+1, ColumnName = "B", SID = "3, 2" , Type = test.ToString(), IsExport = ex},
                    new StorageTrayDetailInfo { RowIndex = row+2, ColumnName = "D", SID = "4, 3" , Type = test.ToString(), IsExport = ex},
                    new StorageTrayDetailInfo { RowIndex = row+3, ColumnName = "E", SID = "7, 5" , Type = test.ToString(), IsExport = ex},
                    new StorageTrayDetailInfo { RowIndex = row+4, ColumnName = "B", SID = "9, 2" , Type = test.ToString(), IsExport = ex}
                });
            ucMatrixTable1.SelectedItem = ucMatrixTable1.Cells[row, col];
            ucMatrixTable1.NextSelect();
            row = ucMatrixTable1.SelectedItem.Row;
            col = ucMatrixTable1.SelectedItem.Col;
        }
    }
}
