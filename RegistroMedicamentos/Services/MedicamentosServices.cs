
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace RegistroMedicamentos.Services
{
    public class MedicamentosServices
    {

        private readonly Context _contexto;

        public MedicamentosServices(Context contexto)
        {
            _contexto = contexto;
        }



        public async Task<bool> Guardar(Medicamentos medicamentos)
        {

            if(!await Existe(medicamentos.MedicamentoId))
            {

                return await Insertar(medicamentos);




            }


            else
            {


                return await Modificar(medicamentos);


            }
            
        }



        public async Task<bool> Existe(int MedicamentoId)
        {

            return await _contexto.medicamentos.AnyAsync(m => m.MedicamentoId == MedicamentoId );

        }



        public async Task<bool> Insertar(Medicamentos medicamentos)
        {

           _contexto.medicamentos.Add(medicamentos);
            return await _contexto.SaveChangesAsync() > 0;


        }



        public async Task<bool> Modificar(Medicamentos medicamentos)

        {

            _contexto.medicamentos.Update(medicamentos);
            return await _contexto.SaveChangesAsync() > 0;


        }

        public async Task<Medicamentos> Buscar(int MedicamentoId)
        {
            return await _contexto.medicamentos.FirstOrDefaultAsync(m => m.MedicamentoId == MedicamentoId);

        }



        public async Task<bool> Eliminar(int MedicamentoId)
        {

          var medicamento = await _contexto.medicamentos.FirstOrDefaultAsync(m => m.MedicamentoId == MedicamentoId);
            if(medicamento == null)  await Insertar(medicamento);


            _contexto.Remove(medicamento);
            return await _contexto.SaveChangesAsync() > 0;


        }




        public async Task<List<Medicamentos>> Listar(Expression<Func<Medicamentos, bool>> criterio)
        {


            return await _contexto.medicamentos
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();

        }
    }
}
