using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MatrixTable
{
    partial class UCMatrixTable
    {

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            for (int i = 1; i <= NoRows; i++)
            {
                for (int j = 1; j <= NoCols; j++)
                {
                    if (Cells[i, j] != null)
                    {
                        Cells[i, j].Dispose();
                    }
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UCMatrixTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UCMatrixTable";
            this.Size = new System.Drawing.Size(771, 474);
            this.Load += new System.EventHandler(this.MatrixTable_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MatrixTable_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion
    }

    public partial class UCMatrixTable : UserControl, IDisposable//, INotifyPropertyChanged
    {
        public int NoRows { get; set; } = 10;
        public int NoCols { get; set; } = 10;
        public string[] ColumnNames { get; set; } = new string[10];
        public string[] RowNames { get; set; } = new string[10];

        //sau nen doi sang dung dictionnary va truy cap kieu [i,j]
        public Cell[,] Cells = new Cell[15, 15];
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Cell this[int columnIndex, int rowIndex]
        {
            get
            {
                if (columnIndex <= NoCols && rowIndex <= NoRows)
                    return this.Cells[rowIndex, columnIndex];
                return null;
            }
        }
        class LocationInfo
        {
            public int Row { get; set; }
            public int Col { get; set; }
        }

        string GetKeySelect(int i, int j) { return string.Format("{0}-{1}", i, j); }
        Dictionary<string, LocationInfo> SelectedCells = new Dictionary<string, LocationInfo>();
        Cell _selectedItem;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Cell SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                ChangeSelectCell(value);
            }
        }

        //sau nen doi sang dung dictionnary va truy cap kieu [i,j]
        IEnumerable<IMatrixTableObject> _dataSource;


        public void Refresh(int row, int col)
        {
            int i = row;
            int j = col;

            if (Cells[i, j] != null && Cells[i, j].DataBoundItem != null)
            {
                Cells[i, j].DataBoundItem = null;
            }
            if (_dataSource != null)
            {
                foreach (var v in _dataSource)
                {
                    if (v.Row == row && v.Col == col && Cells[i, j] != null)
                    {
                        Cells[i, j].DataBoundItem = v;
                        Cells[i, j].BackGroundColor = v.Color;
                    }
                }
            }
        }
        public new void Refresh()
        {
            for (int i = 1; i <= NoRows; i++)
            {
                for (int j = 1; j <= NoCols; j++)
                {
                    if (Cells[i, j] != null)
                    {
                        if (Cells[i, j].DataBoundItem != null) Cells[i, j].DataBoundItem = null;
                        Cells[i, j].IsSelected = false;
                    }
                }
            }
            if (_dataSource != null)
            {
                foreach (var v in _dataSource)
                {
                    int i = v.Row;
                    int j = v.Col;

                    if (Cells[i, j] != null)
                    {
                        Cells[i, j].DataBoundItem = v;
                        Cells[i, j].BackGroundColor = v.Color;
                    }
                }
            }
        }
        public void LoadDataSource<T>(IEnumerable<T> value) where T : IMatrixTableObject, new()
        {
            var lstResult = new List<IMatrixTableObject>();
            var lsttest = value as IEnumerable<T>;
            if (lsttest != null)
            {
                foreach (var item in lsttest)
                {
                    var itest = (IMatrixTableObject)item as IMatrixTableObject;
                    lstResult.Add(itest);
                }
            }
            else lstResult = null;

            this.LoadDataSource(lstResult);
        }
        public void LoadDataSource(object value)
        {
            this._dataSource = (IEnumerable<IMatrixTableObject>)value as IEnumerable<IMatrixTableObject>;
            PropertyChanged?.Invoke(this, null);
        }
        public IEnumerable<IMatrixTableObject> GetDataSource()
        {
            return _dataSource;
        }
        public Color Color
        {
            set
            {
                BackColor = value;
            }
        }

        public Color AlternatingColor
        {
            set
            {
                for (int i = 1; i <= NoRows - 1; i++)
                {
                    for (int j = 0; j <= NoCols - 1; j++)
                    {
                        if (i % 2 != 0)
                        {
                            if (Cells[i, j] != null) Cells[i, j].BackGroundColor = value;
                        }
                    }
                }
            }
        }

        public Color TextCellColor
        {
            set
            {
                for (int i = 1; i <= NoRows - 1; i++)
                {
                    for (int j = 1; j <= NoCols - 1; j++)
                    {
                        if (Cells[i, j] != null) Cells[i, j].TextColor = value;
                    }
                }
            }
        }

        public Color TextHeaderColor
        {
            set
            {
                Cells[0, 0].TextColor = value;

                for (int i = 1; i < NoCols; i++)
                {
                    if (Cells[0, i] != null) Cells[0, i].TextColor = value;
                }

                for (int i = 1; i < NoCols; i++)
                {
                    if (Cells[i, 0] != null) Cells[i, 0].TextColor = value;
                }
            }
        }

        public event EventHandler CellClick;
        public event EventHandler SelectedChange;

        public event EventHandler PropertyChanged;

        private void CreateColumnHeader()
        {
            for (int i = 1; i <= NoCols; i++)
            {
                if (Cells[0, i] == null)
                {
                    var cell = new Cell
                    {
                        Col = i,
                        Row = 0
                    };
                    cell.Location = new Point(cell.Width * i, 0);
                    cell.Text = (this.ColumnNames != null && i <= this.ColumnNames.Length && !string.IsNullOrEmpty(this.ColumnNames[i - 1])) ?
                        this.ColumnNames[i - 1] : i.ToString();//(this.ColumnNames != null && i <= this.ColumnNames.Length) ? this.ColumnNames[i - 1] :
                    //cell.Text = ((char)(i + 64)).ToString();

                    cell.BackGroundColor = Color.FromArgb(50, Color.Black);
                    cell.label.MouseMove -= cell.MouseMoveAction;
                    cell.label.MouseLeave -= cell.MouseLeaveAction;

                    Cells[0, i] = cell;

                    this.Controls.Add(cell);
                }
            }
        }
        private void CreateRowHeader()
        {
            for (int i = 1; i <= NoRows; i++)
            {
                if (Cells[i, 0] == null)
                {
                    var cell = new Cell
                    {
                        Row = i,
                        Col = 0
                    };
                    cell.Location = new Point(0, cell.Height * i);
                    cell.Text = (this.RowNames != null && i <= this.RowNames.Length && !string.IsNullOrEmpty(this.RowNames[i - 1])) ?
                        this.RowNames[i - 1] : i.ToString();// (this.RowNames != null && i <= this.RowNames.Length) ? this.RowNames[i - 1] :

                    cell.BackGroundColor = Color.FromArgb(50, Color.Black);
                    cell.label.MouseMove -= cell.MouseMoveAction;
                    cell.label.MouseLeave -= cell.MouseLeaveAction;

                    Cells[i, 0] = cell;

                    this.Controls.Add(cell);
                }
            }
        }
        private void CreateCornerCell()
        {
            if (Cells[0, 0] == null)
            {
                var cell = new Cell
                {
                    Location = new Point(0, 0),
                    Text = "Hàng/Cột",
                    Row = 0,
                    Col = 0
                };
                cell.BackGroundColor = Color.FromArgb(75, Color.Black);
                cell.label.MouseMove -= cell.MouseMoveAction;
                cell.label.MouseLeave -= cell.MouseLeaveAction;

                Cells[0, 0] = cell;
                this.Controls.Add(cell);
            }
        }

        private void SetWidthAndHeight()
        {
            var cellWidth = Cells[1, 1].Width;
            var cellHeight = Cells[1, 1].Height;

            Width = cellWidth * (NoCols + 1);
            Height = cellHeight * (NoRows + 1);
        }

        public T GetItemByRowCol<T>(int row, int col)
        {
            return (T)Cells[row, col]?.DataBoundItem;
        }

        public void NextSelect()
        {
            if (_selectedItem != null)
            {
                var row = _selectedItem.Row;
                var col = _selectedItem.Col;

                ResetAllSelected();
                if (col < NoCols) col++;
                else if (row < NoRows)
                {
                    row++;
                    col = 1;
                }
                SelectedItem = Cells[row, col];
            }
        }
        void ChangeSelectCell(object value)
        {
            if (value != null)
            {
                var v = (Cell)value;

                //select lai cung vị tri do thi thoi
                if (_selectedItem != null && v.Row == _selectedItem.Row && v.Col == _selectedItem.Col)
                {
                    if (!_selectedItem.IsSelected)
                    {
                        _selectedItem.IsSelected = true;
                        Cells[v.Row, v.Col].IsSelected = true;
                    }

                    return;
                }

                ResetAllSelected();

                _selectedItem = v;
                _selectedItem.IsSelected = true;

                int row = _selectedItem.Row;
                int col = _selectedItem.Col;
                Cells[row, col].IsSelected = true;

                SelectedCells.Clear();
                SelectedCells.Add(GetKeySelect(row, col), new LocationInfo
                {
                    Row = row,
                    Col = col
                });
                SelectedChange?.Invoke(this, null);

            }
            else
            {
                bool chk = _selectedItem != null;
                ResetAllSelected();
                if (chk)
                    SelectedChange?.Invoke(this, null);
                //if (_selectedItem != null)
                //{
                //    ResetSelectedCell(new Location { Row = _selectedItem.Row, Col = _selectedItem.Col });
                //    SelectedCells.Remove(GetKeySelect(_selectedItem.Row, _selectedItem.Col));
                //}
            }
        }
        void ResetSelectedCell(LocationInfo location)
        {
            if (Cells[location.Row, location.Col] != null &&
                Cells[location.Row, location.Col].IsSelected == true)
            {
                Cells[location.Row, location.Col].IsSelected = false;
            }
        }
        void ResetAllSelected()
        {
            _selectedItem = null;
            foreach (var l in SelectedCells)
            {
                ResetSelectedCell(l.Value);
            }
            SelectedCells.Clear();
        }
        private void OnCellClick(object s, EventArgs e)
        {
            ResetAllSelected();
            SelectedItem = (Cell)s;
        }
        public UCMatrixTable()
        {
            InitializeComponent();
            //this.RowNames = new string[NoRows];
            //this.ColumnNames = new string[NoCols];
            ////if (this.RowNames.Length > NoRows)
            //{
            //    for (int i = 1; i <= NoRows; i++)
            //    {
            //        this.RowNames[i - 1] = i.ToString();
            //    }
            //}
            ////if (this.ColumnNames.Length > NoCols)
            //{
            //    for (int j = 1; j <= NoCols; j++)
            //    {
            //        this.ColumnNames[j - 1] = j.ToString();
            //    }
            //}

        }
        private void MatrixTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                NextSelect();
            }
        }
        void InitView() { }
        void Init()
        {
            for (int i = 1; i <= NoRows; i++)
            {
                for (int j = 1; j <= NoCols; j++)
                {
                    if (Cells[i, j] == null)
                    {
                        var cell = new Cell
                        {
                            Row = i,
                            Col = j
                        };
                        cell.Location = new Point(cell.Width * j, cell.Height * i);

                        cell.label.Click += (s, e) =>
                        {
                            CellClick?.Invoke(cell, null);
                        };

                        cell.PropertyChanged += Cell_PropertyChanged;

                        cell.Cursor = System.Windows.Forms.Cursors.Hand;

                        //cell.BorderColor = Color.Black;
                        Cells[i, j] = cell;

                        this.Controls.Add(cell);
                    }
                }
            }
        }

        private void Cell_PropertyChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void MatrixTable_Load(object sender, EventArgs e)
        {
            CreateCornerCell();
            CreateColumnHeader();
            CreateRowHeader();

            Init();

            this.Width = this.Parent.Width;

            CellClick -= OnCellClick;
            CellClick += OnCellClick;
            PropertyChanged -= (s, es) =>
            {
                Refresh();
            };
            PropertyChanged += (s, es) =>
            {
                Refresh();
            };
        }
    }

}
