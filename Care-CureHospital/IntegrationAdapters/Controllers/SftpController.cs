using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System.Text;
using Backend.Model.DoctorMenager;
using Backend.Repository.DirectorRepository;
using Model.DoctorMenager;
using Service.MedicamentService;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SftpController : ControllerBase
    {
        public ReportRepository reportRepository;
        public MedicamentService medicamentService;

        [HttpGet]
        public IActionResult SendFile()
        {
            try
            {
                using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.0.27", "user", "password")))
                {
                   // client.Connect();
                    StringBuilder builder = new StringBuilder();
                    builder.Append("Report:");
                   /* foreach(Report report in reportRepository.GetAllEntities())
                    {
                        
                        builder.Append("Id:" + report.Id + "\n");
                        builder.Append("Medication id: " + report.MedicamentId + "\n");
                        builder.Append("Medication name: " + report.MedicamentName + "\n");
                        builder.Append("Quantity: " + report.Quantity + "\n");
                        builder.Append("From date: " + report.FromDate + "\n");
                        builder.Append("To date: " + report.ToDate + "\n");
                        
                    }*/
                  
                    String medRep = builder.ToString();
                    var test = @"D:\testFiles\report.txt";
                    System.IO.File.WriteAllText(test, medRep);

                    client.Connect();

                    //  string sourceFile = @"D:\testFiles\report.txt";
                    // using (Stream stream = System.IO.File.OpenRead(sourceFile))
                    //  {
                    //  client.UploadFile(stream, @"\public\" + Path.GetFileName(sourceFile), x => { Console.WriteLine(x); });
                    // }

                    client.UploadFile(System.IO.File.OpenRead(test), @"\public\" + Path.GetFileName(test), x => { Console.WriteLine(x); });

                    string serverFile = @"\public\report.txt";
                    string localFile = @"D:\localFiles\Report.txt";
                    using (Stream stream = System.IO.File.OpenWrite(localFile))
                    {
                        client.DownloadFile(serverFile, stream, x => Console.WriteLine(x));
                    }
                    client.Disconnect();
                }
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message + "Failed");
            }
        }
    }
}
