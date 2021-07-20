using JetBrains.Annotations;

namespace Samples.Server.Domain.Entities
{
    [UsedImplicitly]
    public class Court
    {
        public int Id { [UsedImplicitly] get; set; }
        public string Name { [UsedImplicitly] get; set; }
        public int LevelId { [UsedImplicitly] get; set; }
    }
}