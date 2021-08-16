using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WBL;
using Entity;
namespace WebApp.Controllers
{
    public class MarcaVehiculoController : Controller
    {
        private readonly IMarcaVehiculoService marcaVehiculoService;

        public MarcaVehiculoController(IMarcaVehiculoService marcaVehiculoService)
        {
            this.marcaVehiculoService = marcaVehiculoService;
        }


        public IEnumerable<MarcaVehiculoEntity> GridList { get; set; } = new List<MarcaVehiculoEntity>();

        public IActionResult Index()
        {
            try
            {

                GridList = marcaVehiculoService.Get();
                return View(GridList);
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

         
        }

        


        public IActionResult Edit(int? id)
        {
            
            try
            {
                var entity = new MarcaVehiculoEntity();

                if (id.HasValue)
                {
                    //actualizar 

                    entity = marcaVehiculoService.GetById(new MarcaVehiculoEntity { MarcaVehiculoId=id });
                }

                return View(entity);


            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }


        public IActionResult Eliminar(int id)
        {
            try
            {
                var result = marcaVehiculoService.Delete(new MarcaVehiculoEntity { MarcaVehiculoId = id });

                if (result.CodeError != 0) throw new Exception(result.MsgError);


                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Save(MarcaVehiculoEntity entity)
        {
            try
            {
               

                var result = new DBEntity();
                if (entity.MarcaVehiculoId.HasValue)
                {
                    //Actualializar
                    result = marcaVehiculoService.Update(entity);
                }
                else
                {
                    //insertar
                    result = marcaVehiculoService.Create(entity);
                }

                if (result.CodeError != 0) throw new Exception(result.MsgError);


                return RedirectToAction("index");

            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }


    }
}
