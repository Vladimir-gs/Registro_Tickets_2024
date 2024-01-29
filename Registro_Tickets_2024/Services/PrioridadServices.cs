using Microsoft.EntityFrameworkCore;
using Registro_Tickets_2024.DAL;
using Registro_Tickets_2024.Models;
using System.Linq.Expressions;

namespace Registro_Tickets_2024.Services
{
    public class PrioridadServices
    {
        private readonly Contexto _contexto;

        public PrioridadServices(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Guardar(Prioridades prioridad)
        {
            if (_contexto.Prioridades!.Any(p => p.Descripcion!.ToLower().Replace(" ", "") == prioridad.Descripcion!.ToLower().Replace(" ", "")
            && p.PrioridadId != prioridad.PrioridadId))
            {
                return false;
            }
            if (!await Existe(prioridad.PrioridadId))
                return await Insertar(prioridad);
            else
                return await Modificar(prioridad);
        }

        private async Task<bool> Insertar(Prioridades prioridad)
        {
            _contexto.Prioridades!.Add(prioridad);
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> Modificar(Prioridades prioridad)
        {
            _contexto.Update(prioridad);
            int cantidad = await _contexto.SaveChangesAsync();
            _contexto.Entry(prioridad).State = EntityState.Detached;
            return cantidad > 0;
        }

        public async Task<bool> Existe(int PrioridadId)
        {
            return await _contexto.Prioridades!
                .AnyAsync(p => p.PrioridadId == PrioridadId);
        }

        public async Task<bool> Eliminar(Prioridades prioridad)
        {
            var cantidad = await _contexto.Prioridades!
                .Where(p => p.PrioridadId == prioridad.PrioridadId)
                .ExecuteDeleteAsync();
            return cantidad > 0;
        }

        public async Task<Prioridades?> Buscar(int prioridadId)
        {
            return await _contexto.Prioridades!
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.PrioridadId == prioridadId);
        }

        public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
        {
            return await _contexto.Prioridades!
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
