using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodieBFCapstone.Identity.Interface
{
    public interface IdentityConnectionInterface
    {
        ConnectionStringSettings Connection { get; set; }
    }
}
