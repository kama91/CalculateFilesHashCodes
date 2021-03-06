﻿using System;
using System.Threading;
using CalculateFilesHashCodes.Interfaces;
using CalculateFilesHashCodes.Services;

namespace CalculateFilesHashCodes.Common
{
    public static class Extensions
    {
        public static void HandlingData<T>(this IDataService<T> service, Action action)
        {
            while (service.Status != ServiceStatus.Complete)
            {
                if (service.DataQueue.IsEmpty)
                {
                    Thread.Sleep(300);
                }
                else
                {
                    action.Invoke();
                }
            }

            action.Invoke();
        }
    }
}
