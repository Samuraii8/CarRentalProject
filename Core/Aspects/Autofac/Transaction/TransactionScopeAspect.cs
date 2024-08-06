using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    // Metodu çalıştır.
                    invocation.Proceed();
                    // İşlem tamamlandı olarak tanımla.
                    transactionScope.Complete();
                }
                catch (Exception e)
                {
                    // Herhangi bir exception yakalandıysa işlemi geri alır.
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}
