using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase.DataProcessors
{
    public abstract record DataProcessOperation
    {
        /// <summary>
        /// from 0.0 (0%) to 1.0 (100%) 
        /// </summary>
        public double Progress { get; protected set; }

        public Task? Task { get; private set; }
        public bool HasBegun { get; private set; }
        public bool WasStopped { get; private set; }

        protected readonly object SyncRoot = new();
        public CancellationTokenSource CancellationSource { get; } = new();

        public virtual void Begin()
        {
            lock (SyncRoot)
                HasBegun = HasBegun ? throw new InvalidOperationException("This operation has already begun before this call") : WasStopped ? throw new InvalidOperationException("The operation cannot begin again after it has been stopped") : true;
            Task = Task.Run(() => Process(CancellationSource.Token), CancellationSource.Token);
        }

        public virtual void Stop()
        {
            lock (SyncRoot)
                if (HasBegun && !WasStopped)
                {
                    HasBegun = false;
                    WasStopped = true;
                    CancellationSource.Cancel();
                }
                else
                    throw new InvalidOperationException($"The Operation cannot be stopped if it hasn't begun or if it was already stopped. HasBegun: {HasBegun}, WasStopped: {WasStopped}");
        }

        protected abstract Task Process(CancellationToken cancellationToken);
    }
}
