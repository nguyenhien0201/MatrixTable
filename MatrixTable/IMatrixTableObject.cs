using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MatrixTable
{
    public interface IMatrixTableObject
    {
        Color Color { get; }
        int Row { get; }
        int Col { get; }
        string TextDisplay { get; }
    }
}
