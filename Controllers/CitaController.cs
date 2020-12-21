using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//Importar a los modelos
using DBClinica_EL01.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DBClinica_EL01.Controllers
{
    public class CitaController : Controller
    {
        //Definir la variable del contexto del EF
        BDCLINICA2020EL01Context bd = new BDCLINICA2020EL01Context();

        //GET: Citas
        public ActionResult Index()
        {
            var lista = bd.Citas.Include(m=>m.CodmedNavigation)
                                .Include(p=>p.CodpacNavigation)
                                .Where(c=>c.Estado == 0)
                                .ToList();
            return View(lista);
        }

        //GET: Citas/Details/5
        public ActionResult Details (int id)
        {
            //Obteniendo los datos de la cita en base a su nro. de cita
            //pero estamos incluyendo la información del medico y del paciente
            var una_cita = bd.Citas.Include(m => m.CodmedNavigation)
                                    .Include(p => p.CodpacNavigation)
                                    .Where(c => c.Nrocita == id)
                                    .First();
            return View(una_cita);
        }

        //GET: Citas/Create
        public ActionResult Create()
        {
            //Enviamos una lista de médicos como una variable ViewBag
            ViewBag.MEDICOS = new SelectList(bd.Medicos.ToList(), "Codmed", "Nommed");

            ViewBag.PACIENTES = new SelectList(bd.Pacientes.ToList(), "Codpac", "Nompac");

            //Definimos una nueva cita
            Citas nueva = new Citas();
            nueva.Fecha = DateTime.Today;

            return View(nueva);
        }

        //POST: Citas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Citas obj)
        {
            //Enviamos una lista de médicos como una variable ViewBag
            ViewBag.MEDICOS = new SelectList(bd.Medicos.ToList(), "Codmed", "Nommed");

            ViewBag.PACIENTES = new SelectList(bd.Pacientes.ToList(), "Codpac", "Nompac");

            try
            {
                bd.Citas.Add(obj);
                bd.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                //
                ViewBag.MENSAJE = "Error al grabar cita";
                return View(obj);
            }
        }

        //GET: Citas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //POST: Citas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET: Citas/Delete/5
        public ActionResult Delete(int id)
        {
            // obteniendo los datos de la cita en base a su nro de cita
            // pero estamos incluyendo la informacion del medido y del
            // paciente
            var una_cita = bd.Citas.Include(m => m.CodmedNavigation)
                                    .Include(p => p.CodpacNavigation)
                                    .Where(c => c.Nrocita == id)
                                    .First();

            return View(una_cita);
        }

        //POST: Citas/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Citas cita_eli = bd.Citas.Find(id);

            try
            {
                // modificar el valor de la columna Estado de cero a 1
                cita_eli.Estado = 1;

                // eliminando la cita pero en Memoria
                // bd.Citas.Remove(cita_eli);
                // guardar los cambios permanentemente
                bd.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
}
