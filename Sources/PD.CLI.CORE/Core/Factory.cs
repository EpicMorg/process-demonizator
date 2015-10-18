using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD.CLI.CORE.Core
{

    public interface IFactory<T> {

        T Get();

    }
}
