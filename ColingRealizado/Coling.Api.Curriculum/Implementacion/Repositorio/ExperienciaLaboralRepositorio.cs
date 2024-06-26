﻿using Azure.Data.Tables;
using Coling.API.Curriculum.Contratos.Repositorio;
using Coling.API.Curriculum.Modelo;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.API.Curriculum.Implementacion.Repositorio
{
    public class ExperienciaLaboralRepositorio : IExperienciaLaboralRepositorio
    {
        private readonly string? cadenaConexion;
        private readonly string tablaNombre;
        private readonly IConfiguration configuration;
        public ExperienciaLaboralRepositorio(IConfiguration conf)
        {
            configuration = conf;
            cadenaConexion = configuration.GetSection("cadenaconexion").Value;
            tablaNombre = "ExperienciaLaboral";
        }
        public async Task<bool> Create(ExperienciaLaboral experienciaLaboral)
        {
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                await tablaCliente.UpsertEntityAsync(experienciaLaboral);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Delete(string partitionkey, string rowkey)
        {
            try
            {
                var tableCliente = new TableClient(cadenaConexion, tablaNombre);
                await tableCliente.DeleteEntityAsync(partitionkey, rowkey);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<ExperienciaLaboral> Get(string rowkey)
        {
            
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                var experiencia = await tablaCliente.GetEntityAsync<ExperienciaLaboral>("Experiencia", rowkey);
                return experiencia.Value;
            
        }

        public async  Task<List<ExperienciaLaboral>> GetAll()
        {
            List<ExperienciaLaboral> lista = new List<ExperienciaLaboral>();
            var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
            var filtro = $"PartitionKey eq 'Experiencia'";

            await foreach (ExperienciaLaboral experienciaLaboral in tablaCliente.QueryAsync<ExperienciaLaboral>(filter: filtro))
            {
                lista.Add(experienciaLaboral);
            }

            return lista;
        }

        public async Task<bool> Update(ExperienciaLaboral experienciaLaboral)
        {
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                await tablaCliente.UpdateEntityAsync(experienciaLaboral, experienciaLaboral.ETag);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
