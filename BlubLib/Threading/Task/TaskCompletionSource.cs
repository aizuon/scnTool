using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlubLib.Threading.Tasks
{
    public class TaskCompletionSource
    {
        private readonly TaskCompletionSource<object> _tcs;

        public Task Task => _tcs.Task;

        public TaskCompletionSource()
        {
            _tcs = new TaskCompletionSource<object>();
        }

        public TaskCompletionSource(TaskCreationOptions creationOptions)
        {
            _tcs = new TaskCompletionSource<object>(creationOptions);
        }

        public TaskCompletionSource(object state)
        {
            _tcs = new TaskCompletionSource<object>(state);
        }

        public TaskCompletionSource(object state, TaskCreationOptions creationOptions)
        {
            _tcs = new TaskCompletionSource<object>(state, creationOptions);
        }

        public bool TrySetException(Exception exception)
        {
            return _tcs.TrySetException(exception);
        }

        public void SetException(Exception exception)
        {
            _tcs.SetException(exception);
        }

        public bool TrySetResult()
        {
            return _tcs.TrySetResult(null);
        }

        public void SetResult()
        {
            _tcs.SetResult(null);
        }

        public bool TrySetCanceled()
        {
            return _tcs.TrySetCanceled();
        }

        public bool TrySetCanceled(CancellationToken cancellationToken)
        {
            return _tcs.TrySetCanceled(cancellationToken);
        }

        public void SetCanceled()
        {
            _tcs.SetCanceled();
        }
    }
}
