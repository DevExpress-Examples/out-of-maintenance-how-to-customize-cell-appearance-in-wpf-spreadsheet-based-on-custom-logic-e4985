<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/CellTemplateSelectorExample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/CellTemplateSelectorExample/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/CellTemplateSelectorExample/MainWindow.xaml.cs) (VB: [MainWindow.xaml](./VB/CellTemplateSelectorExample/MainWindow.xaml))
<!-- default file list end -->
# How to customize cell appearance in WPF Spreadsheet based on custom logic


<p>Cell template in WPF Spreadsheet allows you to change the visual presentation of cells. To assign a cell template, use the <a href="http://help.devexpress.com/#WPF/DevExpressXpfSpreadsheetSpreadsheetControl_CellTemplatetopic"><u>CellTemplate</u></a> property of the SpreadsheetControl, as illustrated in the <a href="https://www.devexpress.com/Support/Center/p/E4984">How to customize cell appearance in WPF Spreadsheet using a cell template</a> example.<br />
The template is applied to all existing cells in the worksheet. However, you can have more than one template and implement custom logic to choose the desired template. This allows you to provide a different visual appearance for individual cells. To choose templates based on a custom logic:<br />
1) Create a template selector class that derives from the <strong>System.Windows.Controls.DataTemplateSelector</strong> class and override the <strong>SelectTemplate </strong>method to return a template which meets the required condition. <br />
2) Assign its instance to the <a href="http://help.devexpress.com/#WPF/DevExpressXpfSpreadsheetSpreadsheetControl_CellTemplateSelectortopic"><u>CellTemplateSelector</u></a> property.</p><p>This example uses template selector to display formulas above certain cells. If a cell does not a contain a formula, it displays a red marker that warns about missing formula.<br />
The result is shown below:<br />
<img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-customize-cell-appearance-in-wpf-spreadsheet-based-on-custom-logic-e4985/14.1.10+/media/172caafb-5e07-4749-9fd2-a295bc8323e7.png"></p><br />
<br />


<br/>


