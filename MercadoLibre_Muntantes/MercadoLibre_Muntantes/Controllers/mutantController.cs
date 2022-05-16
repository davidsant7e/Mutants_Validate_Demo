using Microsoft.AspNetCore.Mvc;
using System;
using MercadoLibre_Muntantes.Dto;
using MercadoLibre_Muntantes.Static;
using MercadoLibre_Muntantes.Bussines;
using MercadoLibre_MYSQL.Model;
using MercadoLibre_MYSQL.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using MercadoLibre_Muntantes.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MercadoLibre_Muntantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mutantController : ControllerBase
    {


        private readonly IADNRepository _ADNRepository;

        public mutantController(IADNRepository vparADNRepository)
        {
            _ADNRepository = vparADNRepository;
        }


        // Servicio encargado de validar si es o no es un mutante 
        [HttpPost]
        public ActionResult<bool> isMutant(DtoObjeto dtoObjeto)
        {
            try
            {
                if (CadenaADN.AsignarADN(dtoObjeto.DNA))
                {
                    Validaciones VlocValidaciones = new Validaciones();
                    VlocValidaciones.ValidarSecuenciaADN();
                } 
                
                ADN vlocADN = new ADN();
                vlocADN.CadenaADN = CadenaADN.Cadena;
                vlocADN.EsMutante = CadenaADN.SecuenciaEncontrada;
                vlocADN.Descripcion_Not_Mutante = CadenaADN.ReglaNoCumplida.ToString();
                _ADNRepository.AlmacenarADN(vlocADN);

                if(vlocADN.EsMutante)
                {
                    return Ok(vlocADN.EsMutante);
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
        }


    }
}
