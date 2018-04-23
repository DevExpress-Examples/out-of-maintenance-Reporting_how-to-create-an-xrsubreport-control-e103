Imports Microsoft.VisualBasic
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraReports.UI
' ...

Namespace CreateSubreport
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Function CreateCompositeReport(ByVal detailReport As XtraReport) As XtraReport
			' Create a report.
			Dim mainReport As New XtraReport()

			' Create a Subreport.
			Dim subreport As New XRSubreport()

			' Create a detail band and add it to the main report.
			Dim detailBand As New DetailBand()
			mainReport.Bands.Add(detailBand)

			' Set the subreport's location.
			subreport.Location = New Point(110, 100)

			' Specify a detail report as a report source for the subreport.
			subreport.ReportSource = detailReport

			' Add the subreport to the detail band.
			detailBand.Controls.Add(subreport)

			Return mainReport
		End Function

		Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles button1.Click
			Dim report As XtraReport = CreateCompositeReport(New XtraReport1())
			Dim printTool As New ReportPrintTool(report)
			printTool.ShowPreviewDialog()
		End Sub
	End Class
End Namespace