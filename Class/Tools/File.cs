using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Tools
{
    internal class File : IDisposable
    {
        #region 声明字段
        private string FilePath;
        private bool disposedValue;
        #endregion

        #region 构造方法
        internal File(string FilePath = "Stone Weather\\Log\\Log1.log")
        {
            if (!Directory.Exists(Path.GetDirectoryName(FilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
            }
            this.FilePath = FilePath;
            if (!System.IO.File.Exists(this.FilePath)) { System.IO.File.Create(this.FilePath); }
        }
        #endregion

        #region 文件操作方法
        internal void WriteStringInFile(string Content, bool Append = true)
        {
            using (StreamWriter Writer = new StreamWriter(this.FilePath, Append))
            {
                Writer.WriteLine(Content);
            }
        }

        internal void WriteByteInFile(byte[] Content, FileMode mode)
        {
            if (!System.IO.File.Exists(this.FilePath)) { using (new StreamWriter(this.FilePath)) { } }
            using (FileStream fs = new FileStream(this.FilePath, mode, FileAccess.Write))
            {
                fs.Write(Content, 0, Content.Length);
            }
        }

        internal byte[] ReadFileByte()
        {
            byte[] Buffer = new byte[1024 * 1024 * 8];
            using (FileStream fs = new FileStream(this.FilePath, FileMode.Open, FileAccess.Read))
            {
                fs.Read(Buffer, 0, Buffer.Length);
            }
            return Buffer;
        }

        internal List<string> ReadFileString()
        {
            using (StreamReader sw = new StreamReader(this.FilePath))
            {
                string line;
                List<string> Contents = new List<string>();
                while ((line = sw.ReadLine()) != null)
                {
                    Contents.Add(line);
                }
                return Contents;
            }
        }
        #endregion

        #region 实现 IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~File()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
