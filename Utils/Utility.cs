using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;


namespace StoreASP.Utils
{
    public class Utility
    {
        public async Task<string> Upload(IFormFile file, IWebHostEnvironment env)
        {
            try
            {
                var fileName = Path.GetFileName(file.FileName);
                var saveName = "Upload/" + Guid.NewGuid().ToString() + "_" + fileName;
                var serverPath = Path.Combine(env.WebRootPath, saveName);
                await file.CopyToAsync(new FileStream(serverPath, FileMode.Create));
                return saveName;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
