﻿using System.Threading.Tasks;

namespace UltimaCR.Rotations
{
    public sealed partial class Pugilist
    {
        public override async Task<bool> Pull()
        {
            return await Combat();
        }
    }
}