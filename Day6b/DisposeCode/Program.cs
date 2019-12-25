using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeCode
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            //o = null;
            o.Display();
            o.Dispose();

            Console.ReadLine();
        }
        static void Main2()
        {
            Class1 o = new Class1();
            using (o)
            {
                o.Display();
            }
            o.Display();

            Console.ReadLine();
        }
        
    }
    public class Class1 : IDisposable
    {
        public void Display()
        {
            Console.WriteLine("Display");
        }

        public void Dispose()
        {
            Console.WriteLine("dispose code called here... free resources here");
        }
    }
}

namespace DisposeCode2
{
    class Program
    {
       
        static void Main()
        {
            Class1 o = new Class1();
            using (o)
            {
                o.Display();
            }
            //o.Display();
            o.Dispose();
            Console.ReadLine();
        }
       
    }
    public class Class1 : IDisposable
    {
        private bool isDisposed=false;
        public void Display()
        {
            CheckDisposed();
            Console.WriteLine("Display");
        }

        public void Dispose()
        {
            CheckDisposed();
            Console.WriteLine("dispose code called here... free resources here");
            isDisposed = true;
        }
        private void CheckDisposed()
        {
            if (isDisposed)
                throw new ObjectDisposedException(this.GetType().Name);
        }
    }

   public class C1 :IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~C1() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
