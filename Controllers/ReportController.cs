using FastReport;
using FastReport.Export.Html;
using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using Payslip.Models;
using System.Linq;
using Payslip.Data;

namespace PaySlip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly SalarySlipContext _context;

        public ReportController(IWebHostEnvironment env, SalarySlipContext context)
        {
            _env = env;
            _context = context;
        }

        [HttpGet("{empId}")]
        public async Task<IActionResult> ExportSalarySlipToPdfAsync(int empId)
        {
            // Resolve the report path
            string reportPath = Path.Combine(_env.ContentRootPath, "Reports", "payslip.frx");


            // Create a report instance
            Report report = new Report();

            try
            {
                // Load the report template
                report.Load(reportPath);

                // Fetch data from PostgreSQL database
                var salarySlip = _context.SalarySlips.FirstOrDefault(s => s.EMPID == empId);

                if (salarySlip == null)
                {
                    return NotFound("Employee not found.");
                }

                // Register the SalarySlip data as a data source
                report.RegisterData(new[] { salarySlip }, "SalarySlip");

                // Enable the data source
                report.GetDataSource("SalarySlip").Enabled = true;

                // Set the EMPID parameter in the report
                report.SetParameterValue("EMPID", empId);

                // Prepare the report
                report.Prepare();

                // Export the report to HTML
                var htmlExport = new HTMLExport
                {
                    EmbedPictures = true // Ensure images are embedded
                };

                using var htmlStream = new MemoryStream();
                htmlExport.Export(report, htmlStream);

                // Ensure the stream position is reset to the beginning before reading
                htmlStream.Position = 0;

                // Convert the HTML to a string
                string htmlContent;
                using (var reader = new StreamReader(htmlStream))
                {
                    htmlContent = await reader.ReadToEndAsync();
                }

                // Setup PuppeteerSharp to convert HTML to PDF
                var browserFetcher = new BrowserFetcher();
                await browserFetcher.DownloadAsync();
                using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
                using var page = await browser.NewPageAsync();

                // Set HTML content and convert to PDF
                await page.SetContentAsync(htmlContent);
                var pdfStream = await page.PdfStreamAsync();

                // Convert the PDF stream to a memory stream
                using var memoryStream = new MemoryStream();
                await pdfStream.CopyToAsync(memoryStream);

                // Ensure the stream position is reset to the beginning before returning
                memoryStream.Position = 0;

                // Return the PDF file as a stream
                return File(memoryStream.ToArray(), "application/pdf", "SalarySlip.pdf");
            }
            catch (Exception ex)
            {
                // Handle exceptions
                return BadRequest(ex.Message);
            }
            finally
            {
                // Dispose of the report
                report.Dispose();
            }
        }
    }
}
