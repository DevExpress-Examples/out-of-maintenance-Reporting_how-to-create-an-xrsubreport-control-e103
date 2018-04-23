using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
// ...

namespace CreateSubreport {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public XtraReport CreateCompositeReport(XtraReport detailReport) {
            // Create a report.
            XtraReport mainReport = new XtraReport();

            // Create a Subreport.
            XRSubreport subreport = new XRSubreport();

            // Create a detail band and add it to the main report.
            DetailBand detailBand = new DetailBand();
            mainReport.Bands.Add(detailBand);

            // Set the subreport's location.
            subreport.Location = new Point(110, 100);

            // Specify a detail report as a report source for the subreport.
            subreport.ReportSource = detailReport;

            // Add the subreport to the detail band.
            detailBand.Controls.Add(subreport);

            return mainReport;
        }

        private void button1_Click(object sender, System.EventArgs e) {
            XtraReport report = CreateCompositeReport(new XtraReport1());
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }
    }
}