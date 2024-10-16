using Soneta.Business;

namespace Rekrutacja.Interfaces.Services
{
    public interface IContextualService
    {
        Context Context { get; }
        void SetContext(Context context);
    }
}
