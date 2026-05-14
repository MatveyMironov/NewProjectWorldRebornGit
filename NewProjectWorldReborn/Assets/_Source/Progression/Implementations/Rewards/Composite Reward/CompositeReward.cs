using CustomInfoSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProgressionSystem
{
    public class CompositeReward : IReward
    {
        private readonly HashSet<IReward> _parts;

        public CompositeReward(IReward[] parts, CompositeRewardDisplayerMB displayerPrefab)
        {
            if (parts is null) throw new ArgumentNullException(nameof(parts));

            _parts = new(parts);
            _parts.Remove(this);

            Info = new CompositeRewardInfo(this, displayerPrefab);
        }

        public IReward[] Parts => _parts.ToArray();
        public ICustomInfo Info { get; }

        public void Reward()
        {
            foreach (var part in _parts)
            {
                part.Reward();
            }
        }
    }
}