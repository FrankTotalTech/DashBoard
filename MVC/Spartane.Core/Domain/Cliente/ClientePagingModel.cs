﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Cliente
{
    public class ClientePagingModel
    {
        public List<Spartane.Core.Domain.Cliente.Cliente> Clientes { set; get; }
        public int RowCount { set; get; }
    }
}
