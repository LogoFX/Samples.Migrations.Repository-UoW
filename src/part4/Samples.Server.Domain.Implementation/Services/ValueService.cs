using Samples.Server.Domain.Contracts;

namespace Samples.Server.Domain.Implementation.Services
{
    internal class ValueService: IValueService
    {
        public int GetValue()
        {
            return 115;
        }
    }
}