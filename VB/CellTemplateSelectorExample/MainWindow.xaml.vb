Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Spreadsheet
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace CellTemplateSelectorExample
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			spreadsheetControl1.LoadDocument("vlookup.xlsx")
'			#Region "#celltemplate_code"
			spreadsheetControl1.CellTemplateSelector = TryCast(spreadsheetControl1.TryFindResource("CellTemplateSelector"), DataTemplateSelector)
'			#End Region ' #celltemplate_code
		End Sub
	End Class

	Public Class CellTemplateSelector
		Inherits DataTemplateSelector
		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
			Dim data As CellData = TryCast(item, CellData)
			Return If(CanApplyCustomTemplate(data.Cell.Position.ToString()), GetCellTemplate(data.Cell, CType(container, SpreadsheetControl)), MyBase.SelectTemplate(item, container))
		End Function
		Private customTemplateCells As New List(Of String) (New String() {"A2", "A3", "A4", "A5", "A6"})
		Private Function CanApplyCustomTemplate(ByVal cellPosition As String) As Boolean
			Return customTemplateCells.Contains(cellPosition)
		End Function
		Private Function GetCellTemplate(ByVal cell As DevExpress.XtraSpreadsheet.Model.Cell, ByVal control As SpreadsheetControl) As DataTemplate
			Dim templateName As String = If(cell.HasFormula, "FormulaTemplate", "EmptyTemplate")
			Return TryCast(control.TryFindResource(templateName), DataTemplate)
		End Function
	End Class
End Namespace
