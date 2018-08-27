using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ManageCredentials.Utility
{
   
    public  class Container
    {
        private readonly IHostingEnvironment environment;
        public Container(IHostingEnvironment env)
        {
            environment = env;
        }
        public string[] Content()
        {
            var data = environment.ContentRootPath + "\\Views\\Test\\Index.cshtml";
            var body = File.ReadAllLines(data);
            return body;
        }
        public const string EmailContent = @"
        Lorem ipsum dolor sit amet, consectetur adipisicing elit,
        sed do eiusmod tempor incididunt ut labore et dolore magna
        aliqua. Ut enim ad minim veniam, quis nostrud exercitation
        ullamco laboris nisi ut aliquip ex ea commodo consequat.
        Duis aute irure dolor in reprehenderit in voluptate velit
        esse cillum dolore eu fugiat nulla pariatur. Excepteur
        sint occaecat cupidatat non proident, sunt in culpa qui 
        officia deserunt mollit anim id est laborum.
        ";
    }
}
