using DevExpress.Xpf.Spreadsheet;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CellTemplateSelectorExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            spreadsheetControl1.LoadDocument("vlookup.xlsx");
            #region #celltemplate_code
            spreadsheetControl1.CellTemplateSelector = spreadsheetControl1.TryFindResource("CellTemplateSelector") as DataTemplateSelector;
            #endregion #celltemplate_code
        }
    }

    public class CellTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            CellData data = item as CellData;
            return CanApplyCustomTemplate(data.Cell.GetReferenceA1()) ? GetCellTemplate(data.Cell, (SpreadsheetControl)container) : base.SelectTemplate(item, container);
        }
        List<string> customTemplateCells = new List<string>() { "A2", "A3", "A4", "A5", "A6" };
        private bool CanApplyCustomTemplate(string cellPosition)
        {
            return customTemplateCells.Contains(cellPosition);
        }
        private DataTemplate GetCellTemplate(DevExpress.Spreadsheet.Cell cell, SpreadsheetControl control)
        {
            string templateName = cell.HasFormula ? "FormulaTemplate" : "EmptyTemplate";
            return control.TryFindResource(templateName) as DataTemplate;
        }
    }
}
