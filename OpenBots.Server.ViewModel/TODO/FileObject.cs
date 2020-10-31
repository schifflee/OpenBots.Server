using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenBots.Server.ViewModel
{
    public class FileObject 
    {
        public virtual string Name { get; set; }        
        public virtual string ContentType { get; set; }
        public virtual string StoragePath { get; set; }
        public virtual FileStream BlobStream {get; set; }
    }
}
