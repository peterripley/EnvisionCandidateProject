using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku.Common
{
    public interface ICellObserver
    {
        void ReportCellChanged(Cell cell);
        void ReportCellSolved(Cell cell);
    }
}
