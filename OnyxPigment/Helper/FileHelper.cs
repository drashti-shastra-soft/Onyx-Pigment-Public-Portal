namespace OnyxPigment.Helper
{
    public class FileHelper : IDisposable
    {
        private bool _disposed = false;

        public string Reader(string filePath)
        {
            string htmlContent = string.Empty;
            try
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
                htmlContent = File.ReadAllText(fullPath);
            }
            catch (Exception)
            {
                throw;
            }
            return htmlContent;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here (if any)
                }

                // Dispose unmanaged resources here (if any)

                _disposed = true;
            }
        }

        ~FileHelper()
        {
            Dispose(false);
        }
    }
}
