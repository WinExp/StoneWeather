using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Crypto
{
    internal class AES : IDisposable
    {
        #region 声明字段
        private readonly byte[] IV;
        private bool disposedValue;
        #endregion

        #region 构造方法
        internal AES(string IV = "")
        {
            this.IV = GetStringBytes(IV, 16);
        }
        #endregion

        #region 核心方法
        /// <summary>
        /// Crop data.
        /// </summary>
        /// <param name="Data">The data that needs to be cropped.</param>
        /// <param name="Length">Cut to length.</param>
        /// <returns>Cropped data.</returns>
        private byte[] GetBytes(byte[] Data, int Length = 32)
        {
            byte[] Result = new byte[Length];
            if (Data == null)
            {
                return null;
            }
            if (Data.Length > Length)
            {
                Array.Copy(Data, 0, Result, 0, Length);
            }
            else
            {
                Array.Copy(Data, 0, Result, 0, Data.Length);
            }
            return Result;
        }

        /// <summary>
        /// Crop string.
        /// </summary>
        /// <param name="Data">需要裁剪的字符串。</param>
        /// <param name="Length">Cut to length.</param>
        /// <returns>Trimmed string.</returns>
        private byte[] GetStringBytes(string Data, int Length = 32)
        {
            byte[] ByteData = Encoding.UTF8.GetBytes(Data);
            return GetBytes(ByteData, Length);
        }

        /// <summary>
        /// AES encryption of data.
        /// </summary>
        /// <param name="Data">Bytes to be encrypted.</param>
        /// <param name="Key">The encryption key.</param>
        /// <returns>The encrypted data.</returns>
        internal byte[] Encrypt(byte[] Data, string Key)
        {
            byte[] ByteKey = GetStringBytes(Key);
            byte[] encrypt = null;
            Aes aes = Aes.Create();
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(ByteKey, this.IV), CryptoStreamMode.Write))
                {
                    cStream.Write(Data, 0, Data.Length);
                    cStream.FlushFinalBlock();
                    encrypt = mStream.ToArray();
                }
            }
            aes.Clear();
            return encrypt;
        }

        /// <summary>
        /// AES decryption of data.
        /// </summary>
        /// <param name="Data">Bytes to be decrypted.</param>
        /// <param name="Key">The decryption key.</param>
        /// <returns>The decrypted data.</returns>
        internal byte[] Decrypt(byte[] Data, string Key)
        {
            byte[] ByteKey = GetStringBytes(Key);
            byte[] decrypt = null;
            Aes aes = Aes.Create();
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(ByteKey, this.IV), CryptoStreamMode.Write))
                {
                    cStream.Write(Data, 0, Data.Length);
                    cStream.FlushFinalBlock();
                    decrypt = mStream.ToArray();
                }
            }
            aes.Clear();
            return decrypt;
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
