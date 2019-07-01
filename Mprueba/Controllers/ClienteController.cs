using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mprueba.Models.DataModels;
using Mprueba.Models.ViewModels;

namespace Mprueba.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteViewModel> ListaCliente = new List<ClienteViewModel>();
            using (PruebaEntity db = new PruebaEntity())
            {
                ListaCliente = (from datos in db.CLIENTE
                                select new ClienteViewModel
                                {
                                    ID_CLIENTE = datos.ID_CLIENTE,
                                    NOMBRE_CLIENTE = datos.NOMBRE_CLIENTE,
                                    ESTADO = datos.ESTADO
                                }).ToList();
                return View(ListaCliente);
            }
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        public ActionResult Editar(int id)
        {
            try
            {
                ClienteViewModel Cliente = new ClienteViewModel();
                using (PruebaEntity db = new PruebaEntity())
                {
                    var tabla = db.CLIENTE.Find(id);
                    Cliente.ID_CLIENTE = tabla.ID_CLIENTE;
                    Cliente.NOMBRE_CLIENTE = tabla.NOMBRE_CLIENTE;
                    Cliente.ESTADO = tabla.ESTADO;
                }
                return View(Cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Nuevo(ClienteViewModel Cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PruebaEntity db = new PruebaEntity())
                    {
                        var datoss = new CLIENTE { NOMBRE_CLIENTE = Cliente.NOMBRE_CLIENTE, ESTADO = Cliente.ESTADO};
                        db.CLIENTE.Add(datoss);
                        db.SaveChanges();
                        
                    }
                    return RedirectToAction("Index", "Cliente");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Editar(ClienteViewModel Cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PruebaEntity db = new PruebaEntity())
                    {
                        var tabla = db.CLIENTE.Find(Cliente.ID_CLIENTE);
                        tabla.NOMBRE_CLIENTE = Cliente.NOMBRE_CLIENTE;
                        tabla.ESTADO = Cliente.ESTADO;

                        db.Entry(tabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index", "Cliente");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Eliminar(int id)
        {
            try
            {
                using (PruebaEntity db = new PruebaEntity())
                {
                    var tabla = db.CLIENTE.Find(id);
                    db.CLIENTE.Remove(tabla);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Cliente");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}