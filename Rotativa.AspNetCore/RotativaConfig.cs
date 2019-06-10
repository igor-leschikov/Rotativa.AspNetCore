using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;

namespace Rotativa.AspNetCore
{
    public static class RotativaConfiguration
    {
        private static string _RotativaPath;
        internal static string RotativaPath
        {
            get
            {
                if (string.IsNullOrEmpty(_RotativaPath))
                {
#if NET45
                    _RotativaUrl = System.Configuration.ConfigurationManager.AppSettings["RotativaUrl"];
#endif
                }
                return _RotativaPath;
            }
        }

        /// <summary>
        /// Setup Rotativa library
        /// </summary>
        /// <param name="_IHostingEnvironment">The IHostingEnvironment object</param>
        /// <param name="wkhtmltopdfRelativePath">Optional. Relative path to the directory containing wkhtmltopdf.exe. Default is "Rotativa". Download at https://wkhtmltopdf.org/downloads.html</param>
        [Obsolete]
        public static void Setup(Microsoft.AspNetCore.Hosting.IHostingEnvironment _IHostingEnvironment, string wkhtmltopdfRelativePath = "Rotativa")
        {
            var rotativaPath = Path.Combine(_IHostingEnvironment.WebRootPath, wkhtmltopdfRelativePath);

            if (!Directory.Exists(rotativaPath))
            {
                throw new ApplicationException("Folder containing wkhtmltopdf.exe not found, searched for " + rotativaPath);
            }

            _RotativaPath = rotativaPath;
        }
        /// <summary>
        /// Setup Rotativa library
        /// </summary>
        /// <param name="_IHostEnvironment">The IHostEnvironment object</param>
        /// <param name="wkhtmltopdfRelativePath">Optional. Relative path to the directory containing wkhtmltopdf.exe. Default is "Rotativa". Download at https://wkhtmltopdf.org/downloads.html</param>
        public static void Setup(IHostEnvironment _IHostEnvironment, string wkhtmltopdfRelativePath = "Rotativa") 
        {
            var rotativaPath = Path.Combine(_IHostEnvironment.ContentRootPath+"/wwwroot", wkhtmltopdfRelativePath);

            if (!Directory.Exists(rotativaPath))
            {
                throw new ApplicationException("Folder containing wkhtmltopdf.exe not found, searched for " + rotativaPath);
            }

            _RotativaPath = rotativaPath;
        }

    }
}
