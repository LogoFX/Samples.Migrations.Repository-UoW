using JetBrains.Annotations;

namespace Samples.Server.Domain.Entities
{
    [UsedImplicitly]
    public class CourtLevel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}