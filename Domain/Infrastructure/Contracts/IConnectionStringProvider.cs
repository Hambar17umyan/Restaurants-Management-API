using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastructure.Contracts;

public interface IConnectionStringProvider
{
    string GetConnectionString();
}
