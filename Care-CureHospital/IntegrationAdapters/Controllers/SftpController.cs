using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet;

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
                    client.Connect();

                    string sourceFile = @"D:\testFiles\report.txt";
                    using (Stream stream = System.IO.File.OpenRead(sourceFile))
                    {
                        client.UploadFile(stream, @"\public\" + Path.GetFileName(sourceFile), x => { Console.WriteLine(x); });
                    }

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
