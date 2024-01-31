﻿using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;
using ProjetoE21.Dados;
using ProjetoE21.Dao;

namespace ProjetoE21.Controllers
{
    public class PerfilController : Controller
    {
        DaoCadastro DaoC = new();
        DaoCurriculo DaoCur = new();

        public IActionResult Index()
        {
            if(Usuario.LogadoE == null)
            {
                return RedirectToAction("Jovem");
            }
            else
            {
                return RedirectToAction("Empresa");
            }
        }

        public IActionResult Jovem()
        {
            return View();
        }

        public IActionResult Empresa()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar()
        {
            Jovem jovem = Listas.cadastrosJ.FirstOrDefault(sc => sc.Id == Usuario.LogadoJ.Id);

            return View(jovem);
        }

        [HttpPost]
        public IActionResult Editar(Jovem jovem)
        {
            jovem.Id = Usuario.LogadoJ.Id;

            DaoC.editar(jovem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Curriculo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Curriculo(Curriculo curriculo)
        {
            curriculo.Nome = Usuario.LogadoJ.Nome;

            curriculo.Local = new();

            curriculo.Local = Usuario.LogadoJ.Local;
            curriculo.Telefone = Usuario.LogadoJ.Telefone;
            curriculo.Email = Usuario.LogadoJ.Email;

            DaoCur.adicionar(curriculo);

            return RedirectToAction("Index");
        }
    }
}
