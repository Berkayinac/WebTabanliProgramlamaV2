using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorningCoffee.Core.Utilities.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, Exception exception) { }

        public override void Intercept(IInvocation invocation)
        {
            OnBefore(invocation);
            bool isSuccess = false;
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                isSuccess = true;
                OnException(invocation, exception);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
