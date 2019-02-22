using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

using FastReport;
using Spire.Pdf;

namespace PDFPrintDemo
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Report report = new Report();

            MemoryStream ms =
                new MemoryStream(Properties.Resources.Demo);
            report.Load(ms);

            PrinterSettings settings = new PrinterSettings();
            settings.PrinterName = "Microsoft Print To PDF";
            settings.PrintToFile = true;
            settings.PrintFileName = @"C:\Temp\Demo.pdf";

            MemoryStream rpt = new MemoryStream();
            if (report.Prepare())
            {
                report.PrintPrepared(settings);
            }

            if (File.Exists(@"C:\Temp\Demo.pdf"))
            {
                PdfDocument doc = new PdfDocument();
                doc.LoadFromFile(@"C:\Temp\Demo.pdf", FileFormat.PDF);
                doc.PrintSettings.PrintController = new StandardPrintController();
                doc.Print();
                doc.Close();
            }
        }
    }
}
