using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBiblioteca.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CriadoEm = DateTime.Now;
            IsDeleted = false;
        }

        public int Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public bool IsDeleted { get; private set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }

    }
}
