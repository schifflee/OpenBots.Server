using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenBots.Server.Business;
using OpenBots.Server.DataAccess.Repositories;
using OpenBots.Server.Model.Core;
using OpenBots.Server.Model.Identity;
using OpenBots.Server.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EllipticCurve;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace OpenBots.Server.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ClientDetailsController : EntityController<ApplicationVersion>
    {
        readonly IHttpContextAccessor httpContextAccessor;

        public ClientDetailsController(
            IApplicationVersionRepository repository,
            IMembershipManager membershipManager,
            ApplicationIdentityUserManager userManager,
            IHttpContextAccessor httpContextAccessor) : base(repository, userManager, httpContextAccessor, membershipManager)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected static string APPNAME = "OpenBots.Server";


        [HttpGet("BrowsersList")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status304NotModified)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> BrowsersList()
        {
            List<string> browsers = new List<string>();

            try
            {
                //List<Browser> browsers = new List<Browser>();
                string clientIP = "";
                string errormessage = "";
                try
                {
                    List<System.Net.IPAddress> IpAddresses = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.ToList();

                    if (IpAddresses != null && IpAddresses.Count > 0)
                        clientIP = IpAddresses.Last().ToString();//"192.168.1.146";//httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }
                catch (Exception ex)
                {
                    browsers.Add("clientIPError: " + ex.Message);
                    errormessage = ex.Message;

                    try {
                        clientIP = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    }
                    catch (Exception ex2)
                    { 
                        browsers.Add("clientIPError2: " + ex2.Message);
                        clientIP = "192.168.1.146";
                        errormessage = errormessage + " :2nd Error: " + ex.Message;

                    }
                }
                browsers.Add("clientIP: " + clientIP);

                //var reg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, clientIP);
                //var key = reg.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\");
                //string version = (string)key.GetValue("CurrentVersion");
                //reg.Close();

                //browsers.Add("reg: " + reg);
                //browsers.Add("key: " + key);
                //browsers.Add("version: " + version);
                browsers.Add("CurrentDirectory: " + Environment.CurrentDirectory);
                browsers.Add("MachineName: " + Environment.MachineName);
                browsers.Add("OSVersion: " + Environment.OSVersion.ToString());
                browsers.Add("UserDomainName: " + Environment.UserDomainName);
                browsers.Add("UserName: " + Environment.UserName);
                browsers.Add("Is64BitOperatingSystem: " + Environment.Is64BitOperatingSystem.ToString());


                //browsers.Add("OSInfo: " + getOSInfo());
                var machineInfo = GetMachineNameFromIPAddress(clientIP);
                var machineIP = GetIPAddressFromMachineName(Environment.MachineName);
                var machineInternalIP = GetIPAddress();

                browsers.Add("MachineInfo: " + machineInfo);
                browsers.Add("MachineIP: " + machineIP);
                browsers.Add("MachineInternalIP: " + machineInternalIP);

                //var browsersList = GetBrowsers(clientIP);
                //var OSInfo = getOSInfo();
                //var outlook = getOutlookVersion();
                //var officeInfo = GetComponentPath();

                var my_jsondata = new
                {
                    ClientIP = clientIP,
                    //Registry = reg,
                    //Key = key,
                    //Version = version,
                    //OutlookVersion = outlook,
                    //OfficeVersion = officeInfo,
                    Directory = Environment.CurrentDirectory,
                    OsVersion = Environment.OSVersion,
                    MachineInfo = machineInfo,
                    MachineIp = machineIP,
                    MachineInternalIp = machineInternalIP,
                    ErrorMessage = errormessage
                    //BrowsersList = browsersList,
                    //OsInfo = OSInfo

                };

                //Tranform it to Json object
                //string json_data = JsonConvert.SerializeObject(my_jsondata);

                //var browsersList = PlatformBrowser.GetInstalledBrowsers();

                //foreach (var item in browsersList)
                //{
                //    browsers.Add(item);
                //}

                return Ok(my_jsondata);
            }
            catch (Exception ex)
            {
                return Ok(browsers);
            }
        }

        private string GetIPAddress()
        {
            //System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = "";// context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return ipAddress;// context.Request.ServerVariables["REMOTE_ADDR"];
        }

        private static string GetMachineNameFromIPAddress(string ipAdress)
        {
            string machineName = string.Empty;
            try
            {
                System.Net.IPHostEntry hostEntry = System.Net.Dns.GetHostEntry(ipAdress);
                machineName = hostEntry.HostName;
            }
            catch (Exception ex)
            {
                //log here
            }
            return machineName;
        }

        private static string GetIPAddressFromMachineName(string machinename)
        {
            string ipAddress = string.Empty;
            try
            {
                System.Net.IPAddress ip = System.Net.Dns.GetHostEntry(machinename).AddressList.Where(o => o.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First();
                ipAddress = ip.ToString();
            }
            catch (Exception ex)
            {
                //log here
            }
            return ipAddress;
        }

        private string getOutlookVersion()
        {
            //var fileVersionInfo = FileVersionInfo.GetVersionInfo(@"C:\Program Files (x86)\Microsoft Office\root\Office16\WINWORD.EXE");
            //var version = new Version(fileVersionInfo.FileVersion);

            //// On a running instance using the `Process` class
            //var process = Process.GetProcessesByName("winword").First();
            //string fileVersionInfo = process.MainModule.FileVersionInfo.FileVersion;
            //var version = Version(fileVersionInfo);



            string regOutlook32Bit = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\OUTLOOK.EXE";
            string regOutlook64Bit = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\App Paths\OUTLOOK.EXE";
            
            string outlookPath = Registry.LocalMachine.OpenSubKey(regOutlook32Bit).GetValue("", "").ToString();

            if (string.IsNullOrEmpty(outlookPath))
            {
                outlookPath = Registry.LocalMachine.OpenSubKey(regOutlook64Bit).GetValue("", "").ToString();
            }

            if (!string.IsNullOrEmpty(outlookPath))
            {
                var outlookFileInfo = FileVersionInfo.GetVersionInfo(outlookPath);
                return string.Format("Outlook version: {0}", outlookFileInfo.FileVersion);
            }

            return "";
        }
        
        private string getOSInfo()
        {
            //Get Operating system information.
            OperatingSystem os = Environment.OSVersion;
            //Get version information about the os.
            Version vs = os.Version;

            //Variable to hold our return value
            string operatingSystem = "";

            if (os.Platform == PlatformID.Win32Windows)
            {
                //This is a pre-NT version of Windows
                switch (vs.Minor)
                {
                    case 0:
                        operatingSystem = "95";
                        break;
                    case 10:
                        if (vs.Revision.ToString() == "2222A")
                            operatingSystem = "98SE";
                        else
                            operatingSystem = "98";
                        break;
                    case 90:
                        operatingSystem = "Me";
                        break;
                    default:
                        break;
                }
            }
            else if (os.Platform == PlatformID.Win32NT)
            {
                switch (vs.Major)
                {
                    case 3:
                        operatingSystem = "NT 3.51";
                        break;
                    case 4:
                        operatingSystem = "NT 4.0";
                        break;
                    case 5:
                        if (vs.Minor == 0)
                            operatingSystem = "2000";
                        else
                            operatingSystem = "XP";
                        break;
                    case 6:
                        if (vs.Minor == 0)
                            operatingSystem = "Vista";
                        else if (vs.Minor == 1)
                            operatingSystem = "7";
                        else if (vs.Minor == 2)
                            operatingSystem = "8";
                        else
                            operatingSystem = "8.1";
                        break;
                    case 10:
                        operatingSystem = "10";
                        break;
                    default:
                        break;
                }
            }
            //Make sure we actually got something in our OS check
            //We don't want to just return " Service Pack 2" or " 32-bit"
            //That information is useless without the OS version.
            if (operatingSystem != "")
            {
                //Got something.  Let's prepend "Windows" and get more info.
                operatingSystem = "Windows " + operatingSystem;
                //See if there's a service pack installed.
                if (os.ServicePack != "")
                {
                    //Append it to the OS name.  i.e. "Windows XP Service Pack 3"
                    operatingSystem += " " + os.ServicePack;
                }
                //Append the OS architecture.  i.e. "Windows XP Service Pack 3 32-bit"
                //operatingSystem += " " + getOSArchitecture().ToString() + "-bit";
            }
            //Return the information we've gathered.
            return operatingSystem;
        }

        private List<Browser> GetBrowsers(string clientIP)
        {
            //var reg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, clientIP);
            RegistryKey browserKeys;
            //on 64bit the browsers are in a different location
            browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
            //RegistryKey browserKeys;
            //browserKeys = reg.OpenSubKey(@"SOFTWARE\WOW6432Node\Clients\StartMenuInternet");
            if (browserKeys == null)
                browserKeys = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Clients\StartMenuInternet");
            string[] browserNames = browserKeys.GetSubKeyNames();
            List<Browser> browsers = new List<Browser>();
            for (int i = 0; i < browserNames.Length; i++)
            {
                Browser browser = new Browser();
                RegistryKey browserKey = browserKeys.OpenSubKey(browserNames[i]);
                browser.Name = (string)browserKey.GetValue(null);
                RegistryKey browserKeyPath = browserKey.OpenSubKey(@"shell\open\command");
                browser.Path = StripQuotes(browserKeyPath.GetValue(null).ToString());
                browsers.Add(browser);
                if (browser.Path != null)
                    browser.Version = FileVersionInfo.GetVersionInfo(browser.Path).FileVersion;
                else
                    browser.Version = "unknown";
            }

            Browser edgeBrowser = GetEdgeVersion(clientIP);
            if (edgeBrowser != null)
            {
                browsers.Add(edgeBrowser);
            }
            return browsers;
        }

        private Browser GetEdgeVersion(string clientIP)
        {
            //var reg = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, clientIP);

            //RegistryKey edgeKey = reg.OpenSubKey(@"SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\SystemAppData\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\Schemas");
            RegistryKey edgeKey =
            Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppModel\SystemAppData\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\Schemas");

            if (edgeKey != null)
            {
                string version = StripQuotes(edgeKey.GetValue("PackageFullName").ToString());
                Match result = Regex.Match(version, "(((([0-9.])\\d)+){1})");
                if (result.Success)
                {
                    return new Browser
                    {
                        Name = "MicrosoftEdge",
                        Version = result.Value
                    };
                }
            }
            return null;
        }

        private OfficeComponents GetComponentPath()
        {
            const string RegKey = @"Software\Microsoft\Windows\CurrentVersion\App Paths";
            string toReturn = string.Empty;
            string _key = string.Empty;
            OfficeComponents officeComponent = new OfficeComponents();

            var values = Enum.GetValues(typeof(OfficeComponent));
            foreach (var component in values)
            {
                switch (component)
                {
                    case OfficeComponent.Word:
                        _key = "winword.exe";
                        break;
                    case OfficeComponent.Excel:
                        _key = "excel.exe";
                        break;
                    case OfficeComponent.PowerPoint:
                        _key = "powerpnt.exe";
                        break;
                    case OfficeComponent.Outlook:
                        _key = "outlook.exe";
                        break;
                }

                //looks inside CURRENT_USER:
                RegistryKey _mainKey = Registry.CurrentUser;
                try
                {
                    _mainKey = _mainKey.OpenSubKey(RegKey + "\\" + _key, false);
                    if (_mainKey != null)
                    {
                        toReturn = _mainKey.GetValue(string.Empty).ToString();
                    }
                }
                catch
                { }

                //if not found, looks inside LOCAL_MACHINE:
                _mainKey = Registry.LocalMachine;
                if (string.IsNullOrEmpty(toReturn))
                {
                    try
                    {
                        _mainKey = _mainKey.OpenSubKey(RegKey + "\\" + _key, false);
                        if (_mainKey != null)
                        {
                            toReturn = _mainKey.GetValue(string.Empty).ToString();
                        }
                    }
                    catch
                    { }
                }

                string componentVersion = "";

                if (!string.IsNullOrEmpty(toReturn))
                {
                    var outlookFileInfo = FileVersionInfo.GetVersionInfo(toReturn);
                    componentVersion = outlookFileInfo.FileVersion;
                }

                //closing the handle:
                if (_mainKey != null)
                    _mainKey.Close();

                switch (component)
                {
                    case OfficeComponent.Word:
                        officeComponent.Word  = componentVersion;
                        break;
                    case OfficeComponent.Excel:
                        officeComponent.Excel  = componentVersion;
                        break;
                    case OfficeComponent.PowerPoint:
                        officeComponent.PowerPoint = componentVersion;
                        break;
                    case OfficeComponent.Outlook:
                        officeComponent.Outlook = componentVersion;
                        break;
                }

            }
            
            return officeComponent;

        }

        private string StripQuotes(string str)
        {
            if (String.IsNullOrEmpty(str))
                return str;

            int length = str.Length;
            if (length > 1 && str[0] == '\"' && str[length - 1] == '\"')
                str = str.Substring(1, length - 2);

            return str;
        }

    }

    public class Browser
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Version { get; set; }
    }
    public enum OfficeComponent
    {
        Word,
        Excel,
        PowerPoint,
        Outlook
    }
    public class OfficeComponents
    {
        public string Word { get; set; }
        public string Excel { get; set; }
        public string PowerPoint { get; set; }
        public string Outlook { get; set; }
        
    }
 
}