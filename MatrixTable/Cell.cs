using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MatrixTable
{
    partial class Cell
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
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 13);
            this.label.TabIndex = 0;
            this.label.Text = "label1";
            // 
            // Cell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.label);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Cell";
            this.Size = new System.Drawing.Size(73, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label;
    }
    public partial class Cell : UserControl, IDisposable//, INotifyPropertyChanged
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public string Text
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public string BindingProperty { get; set; } = "TextDisplay";
        object _databoundItem;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataBoundItem
        {
            get { return _databoundItem; }
            set
            {
                _databoundItem = value;
                DataBoundItemChanged();
            }
        }
        public Color BackGroundColor
        {
            get { return label.BackColor; }
            set { label.BackColor = value; }
        }

        public Color TextColor
        {
            get { return label.ForeColor; }
            set { label.ForeColor = value; }
        }

        public Color BorderColor
        {
            get { return BackColor; }
            set { BackColor = value; }
        }

        Color _originalColor = Color.White;
        public Color OriginalColor
        {
            get { return _originalColor; }
            set { _originalColor = value; }
        }
        bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnSelecting();
            }
        }

        void Refresh()
        {
            DataBoundItemChanged();
            OnSelecting();
        }
        private void OnSelecting()
        {
            if (_isSelected == true)
            {
                BackGroundColor = Color.FromArgb(77, 136, 255);
            }
            else
            {
                BackGroundColor = _originalColor;
            }
        }
        //public event EventHandler Click;
        private void DataBoundItemChanged()
        {
            Text = "";
            if (_databoundItem != null && !string.IsNullOrEmpty(BindingProperty))
            {
                Text = _databoundItem.GetType().GetProperty(BindingProperty)
                            .GetValue(_databoundItem, null)?.ToString();
                _originalColor = (Color)_databoundItem.GetType().GetProperty("Color")
                                .GetValue(_databoundItem, null);
            }
            else _originalColor = Color.White;

            BackGroundColor = _originalColor;
            this.Invalidate();
        }
        // Phương thức triển khai từ giao diện
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public Cell()
        {
            InitializeComponent();
            this.Width = 90;
            this.Height = 50;

            label.TextAlign = ContentAlignment.MiddleCenter;
            label.AutoSize = false;

            label.Location = new Point(0, 0);
            //label.Dock = DockStyle.Fill;

            label.Width = Width - 1;
            label.Height = Height - 1;

            BackGroundColor = Color.White;
            Text = "";
            //BorderColor = Color.FromArgb(15, Color.Black);

            //this.BorderStyle = BorderStyle.

            label.MouseMove += MouseMoveAction;
            label.MouseLeave += MouseLeaveAction;

            //label.MouseClick += (s, e) =>
            //{
            //    Click?.Invoke(this, null);
            //};

            PropertyChanged += (s, e) =>
            {
                Refresh();
            };
        }

        public event EventHandler PropertyChanged;

        public void MouseMoveAction(object s, EventArgs e)
        {
            if (!_isSelected)
            {
                BackGroundColor = Color.FromArgb(15, Color.Black);
            }
        }

        public void MouseLeaveAction(object s, EventArgs e)
        {
            if (!_isSelected)
            {
                BackGroundColor = _originalColor;
            }
        }
    }
}
