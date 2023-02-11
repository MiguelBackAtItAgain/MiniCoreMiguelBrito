using Microsoft.AspNetCore.Mvc;
using MiniCore.Data;
using MiniCore.Models;

namespace MiniCore.Controllers
{
    public class CalculoController : Controller
    {
        private readonly MiniCoreContext _context;

        public CalculoController(MiniCoreContext context)
        {
            _context = context;
        }

        public IActionResult Index(DateTime fechaini, DateTime fechafin)
        {

            var Response = new List<Cruce>();
            var a = (from c in _context.Cliente
                     join o in _context.Contrato on c.ClienteId equals o.ClienteID
                     where (o.Fecha >= fechaini && o.Fecha <= fechafin)
                     select new Cruce
                     {
                         Id = c.ClienteId,
                         Nombre = c.Nombre,
                         SumaMontos = o.Monto

                     }).ToList();

            var usuariosID = a.Select(a => a.Id).Distinct().ToList();

            foreach (var usuario in usuariosID)
            {
                var Objeto = new Cruce();

                var elhurvo = a.Where(c => c.Id == usuario);
                float? suma = 0;
                foreach (var monto in elhurvo)
                {
                    suma += monto.SumaMontos;
                }

                Objeto.SumaMontos = suma;
                var nombre = elhurvo.Select(a => a.Nombre).FirstOrDefault();
                Objeto.Nombre = nombre;

                Response.Add(Objeto);
            }

            return View(Response);

        }
    }
}
