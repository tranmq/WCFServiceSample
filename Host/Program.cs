using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using WrgPrototype.Contracts;
using WrgPrototype.Implementations;

namespace Host
{
    internal class Program
    {
        private static void Main()
        {
            ServiceHost sh = new ServiceHost(typeof (UserService), new Uri("http://localhost:8080"));
            bool openSucceeded = false;
            try
            {
                ServiceEndpoint se = sh.AddServiceEndpoint(typeof (IUserService), new WebHttpBinding(), "Prototype");
                se.Behaviors.Add(new WebHttpBehavior());
                sh.Open();
                openSucceeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ServiceHost failed to open {0}", ex);
            }
            finally
            {
                if (! openSucceeded)
                {
                    sh.Abort();
                }
            }

            if (openSucceeded)
            {
                Console.WriteLine(" Service is running...");
                Console.WriteLine("Listening on http://localhost:8080/Prototype");
                Console.WriteLine("Press <ENTER> to continue.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(" Service failed to open");
            }

            bool closeSucceeded = false;
            try
            {
                sh.Close();
                closeSucceeded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" ServiceHost failed to close {0}", ex);
                Console.WriteLine("Press <ENTER> to continue.");
                Console.ReadLine();
            }
            finally
            {
                if (! closeSucceeded)
                {
                    sh.Abort();
                }
            }
        }
    }
}