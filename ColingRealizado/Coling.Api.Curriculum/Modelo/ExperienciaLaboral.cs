﻿using Azure;
using Azure.Data.Tables;
using Coling.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.API.Curriculum.Modelo
{
    public class ExperienciaLaboral : IExperienciaLaboral, ITableEntity
    {
       
        public int IdAfiliado {  get; set; }
        public string IdInstitucion { get; set; }
        public string CargoTitulo { get; set; }
        public DateTimeOffset FechaInicio { get; set; }
        public DateTimeOffset FechaFinal { get; set; }
        public string Estado { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
