using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleLibrary
{
    public class Animal : IDisposable
    {
        public Animal()
        {
            // allocate unmanaged resource
        }

        ~Animal() // Finalizer
        {
            if (disposed)
            {
                return;
            }
            Dispose(false);
        }

        bool disposed = false; // have resources been released?

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // Tell the garbage collection to not call the finalizer
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposed)
            {
                return;
            }
            // deallocate the unmanaged resources
            // . . .
            if(disposing)
            {
                // deallocate any other *managed* resources
                // . . .
            }
            disposed = true;
        }
    }
}
