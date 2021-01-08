using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPrescriptionMicroservice.Service
{
    public interface ISftpService
    {
        void UploadFile(string file);
    }
}
