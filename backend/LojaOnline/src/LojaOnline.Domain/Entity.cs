using System;

namespace LojaOnline.Domain
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        
        protected Entity()
        {
        }
    }
}
