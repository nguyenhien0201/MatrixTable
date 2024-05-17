using System;
using System.Drawing;


namespace WindowsFormsApp1
{
    public class StorageService
    {
        public class StorageTrayDetailInfo : MatrixTable.IMatrixTableObject
        {
            public string TrayID { get; set; }
            public string SID { get; set; }
            public string Type { get; set; }
            public int RowIndex { get; set; }
            public string ColumnName { get; set; }
            public string UserE { get; set; }
            public DateTime? ExportTime { get; set; }
            public bool IsExport { get; set; } = false;

            public string UserI { get; set; }

            //dung cho binding len matrix
            public Color Color
            {
                get
                {
                    if (IsExport) return Color.FromArgb(255, 223, 128);

                    if (!string.IsNullOrEmpty(SID) && !string.IsNullOrEmpty(Type))
                        return Color.FromArgb(57, 172, 115);

                    return Color.White;
                }
                //set;
            }
            public int Row { get { return RowIndex; } }
            public int Col
            {
                get { return ColumnName[0] - 'A' + 1; }
                //set { ColumnName = ((char)(value + (int)'A' - 1)).ToString(); }
            }
            public string TextDisplay
            {
                get
                {
                    var idxCut = SID.IndexOf('-') + 1;
                    return string.Format("{0}\n{1}", SID.Substring(idxCut, SID.Length - idxCut), Type);
                }
            }
        }
    }

}
