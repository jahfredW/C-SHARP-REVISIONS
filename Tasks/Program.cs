using System.Security.Cryptography.X509Certificates;

namespace Tasks
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await DelegateHandle(SayHello);
        }

        static async Task DelegateHandle(Func<Task> fonction)
        {
            Console.WriteLine("Je suis exécuté dans la fonction DelegateHandle");
            await fonction();
        }

        static async Task SayHello()
        {
            await Task.Delay(1000);
            Console.WriteLine("Je suis SayHello");
        }

    }
}
