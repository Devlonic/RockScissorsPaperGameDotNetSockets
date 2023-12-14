﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsp.server {
    internal static class MyTaskExtentions {
        public static Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken) {
            return task.IsCompleted // fast-path optimization
                ? task
                : task.ContinueWith(
                    completedTask => completedTask.GetAwaiter().GetResult(),
                    cancellationToken,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);
        }
    }
}
