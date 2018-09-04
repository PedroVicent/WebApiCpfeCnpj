using ApiTamoAi.Models;
using ApiTamoAi.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTamoAi.Controllers
{
    [RoutePrefix("api/pessoa")]
    public class PessoaController : ApiController
    {

        [Route("pessoaFisica")]
        [HttpGet]
        public HttpResponseMessage GetPessoasFisica()
        {
            var pessoas = PessoaContexto.ConsultarPessoasFisica();

            return Request.CreateResponse(HttpStatusCode.OK, pessoas);
        }

        [Route("pessoaJuridica")]
        [HttpGet]
        public HttpResponseMessage GetPessoasJuridica()
        {
            var pessoas = PessoaContexto.ConsultarPessoasJuridica();

            return Request.CreateResponse(HttpStatusCode.OK, pessoas);
        }

        public HttpResponseMessage Get()
        {
            var cpf = PessoaContexto.GerarCpf();

            return Request.CreateResponse(HttpStatusCode.OK, cpf);
        }

        [Route("pessoaFisica")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]PessoaFisica pessoa)
        {
            PessoaContexto.AddPessoaFisica(pessoa);

            return Request.CreateResponse(HttpStatusCode.Created, PessoaContexto.ConsultarPessoasFisica());
        }

        [Route("pessoaJuridica")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]PessoaJuridica pessoa)
        {
            PessoaContexto.AddPessoaJuridica(pessoa);

            return Request.CreateResponse(HttpStatusCode.Created, PessoaContexto.ConsultarPessoasJuridica());
        }

    }
}
