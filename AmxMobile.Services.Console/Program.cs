using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BootFX.Common;
using BootFX.Common.Xml;
using BootFX.Common.Data;
using BootFX.Common.Entities;
using BootFX.Common.Services;
using BootFX.Common.Management;
using BootFX.Cms;

namespace AmxMobile.Services
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServicesRuntime.Start("Console");

                // access cms in order to get dbupdate to handle it...
                EntityType.LoadFromAttributes(typeof(CmsContentItem).Assembly);

                // database...
                DatabaseUpdate.Current.Update(null, new DatabaseUpdateArgs());
                ServicesRuntime.CheckReferenceData();

                // ok...
                Console.WriteLine("Database update OK.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (System.Diagnostics.Debugger.IsAttached)
                    Console.ReadLine();
            }
        }
    }
}
