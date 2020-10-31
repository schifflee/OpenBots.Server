using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenBots.Server.Business
{
    public interface IDirectoryManager
    {
        DirectoryInfo CreateDirectory(string path);

        bool Exists(string path);
    }
}
