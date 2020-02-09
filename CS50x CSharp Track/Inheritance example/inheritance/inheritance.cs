using System;

namespace inheritance
{
    public abstract class monster
        {
            int health { get; set; }

            string name { get; set; }

            public abstract void attack();
        }
}
