using System;
using System.Collections.Generic;
using System.IO;
using iQuest.VendingMachine.UseCases.Reports.Interfaces;
using System.Text;

namespace iQuest.VendingMachine.UseCases.Reports.Services
{
    internal class ZippedReportFileStream : Stream, IZippedReportFileStream, IDisposable
    {
        private Stream streamToWrapp;
        private string path;
        private bool isDisposed = false;

        public ZippedReportFileStream(string path)
        {
            this.path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public override bool CanRead => streamToWrapp.CanRead;

        public override bool CanSeek => streamToWrapp.CanSeek;

        public override bool CanWrite => streamToWrapp.CanWrite;

        public override long Length => streamToWrapp.Length;

        public override long Position { get => streamToWrapp.Position; set => streamToWrapp.Position = value; }

        public override void Flush()
        {
            streamToWrapp.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return streamToWrapp.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return streamToWrapp.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            streamToWrapp.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            using (streamToWrapp = new FileStream(path, FileMode.Create))
            {
                streamToWrapp.Write(buffer, offset, count);
            }
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected override void Dispose(bool isDisposing)
        {
            if (isDisposed)
                return;


            if (isDisposing)
            {
                streamToWrapp?.Dispose();
            }

            isDisposed = true;
        }

        ~ZippedReportFileStream() => Dispose(false);
    }
}
