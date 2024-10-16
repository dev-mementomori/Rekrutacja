using Rekrutacja.Factories.Services;
using Rekrutacja.Interfaces.Services;
using Soneta.Business;

[assembly: Service(typeof(IServiceFactory), typeof(ServiceFactory))]
namespace Rekrutacja.Factories.Services
{
    public interface IServiceFactory
    {
        T Get<T>(Context context);
    }

    public class ServiceFactory : IServiceFactory
    {
        public T Get<T>(Context context)
        {
            T service = default(T);
            // Próbujemy znaleźć usługę typu 'T' w sesji związanej z kontekstem.
            context.Session.GetService<T>(out service);

            // Jeśli usługa została znaleziona i jest typu, który obsługuje kontekst (czyli implementuje IContextualService),
            // wtedy ustawiamy ten kontekst dla usługi.
            if (service != null && service is IContextualService contextualService)
            {
                contextualService.SetContext(context);
            }

            return service;
        }
    }
}
