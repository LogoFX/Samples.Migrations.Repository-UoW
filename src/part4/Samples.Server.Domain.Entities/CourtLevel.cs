using System.Collections.Generic;
using JetBrains.Annotations;

namespace Samples.Server.Domain.Entities
{
    [UsedImplicitly]
    public class CourtLevel
    {
        public CourtLevel()
        {
            Courts = new HashSet<Court>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Court> Courts { get; set; }
    }
}