using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;
using System.Text;

namespace IntegrationAdapters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SftpController : ControllerBase
    {
        [HttpGet]
        public IActionResult SendFile()
        {
            try
            {
                using (SftpClient client = new SftpClient(new PasswordConnectionInfo("192.168.0.19", "user", "password")))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("Report:");
                    String medRep = builder.ToString();
                    var test = @"D:\testFiles\report.txt";
                    System.IO.File.WriteAllText(test, medRep);

                    client.Connect();
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
