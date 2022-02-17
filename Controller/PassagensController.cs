using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecdetTeste.Data;
using TecdetTeste.Models;

namespace TecdetTeste.Controller
{

    class PassagensController : ControllerBase
    {
        private readonly IPassagemRepo _repository;

        public PassagensController(IPassagemRepo repository)
        {
            _repository = repository;
        }

        public ActionResult<Passagem> getPassagemById(int id)
        {
            var passagemItem = _repository.getPassagemById(id);
            if (passagemItem != null)
            {
                return Ok(passagemItem);
            }
            return NotFound();
        }

        public ActionResult<Passagem> createPassagem(Passagem passagem)
        {
            _repository.createPassagem(passagem);
            _repository.saveChanges();

            return CreatedAtRoute(nameof(getPassagemById), new { Id = passagem.Id }, passagem);

        }

    }
}
