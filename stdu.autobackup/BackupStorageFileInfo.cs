using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace stdu.autobackup
{
    class BackupStorageFileInfo
    {
        public String Name
        {
            get { return _fileInfo.Name; }
        }

        public DateTime CreateTime
        {
            get { return _fileInfo.CreationTime; }
        }

        public long Size
        {
            get { return _fileInfo.Length; }
        }

        public String GetFulName()
        {
            return _fileName;
        }

        private FileInfo _fileInfo;
        private String _fileName;

        public BackupStorageFileInfo(String fileName)
        {
            _fileName = fileName;
            _fileInfo = new FileInfo(fileName);
        }
    }
}
