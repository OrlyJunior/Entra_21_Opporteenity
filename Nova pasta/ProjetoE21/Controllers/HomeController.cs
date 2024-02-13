﻿using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;
using System.Diagnostics;
using ProjetoE21.Dao;
using ProjetoE21.Dados;

namespace ProjetoE21.Controllers
{
    public class HomeController : Controller
    {
        DaoServico DaoS = new();
        DaoCadastro DaoC = new();
        DaoEmpresa DaoEmp = new();
        DaoEmprego DaoE = new();
        DaoFavoritos DaoF = new();
        DaoCurriculo DaoCur = new();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginEmpresa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginEmpresa(EmpresaLogin empresa)
        {
            if (!ModelState.IsValid)
            {
                return View(empresa);
            }

            Listas.cadastrosE = DaoEmp.consultar();

            foreach (var i in Listas.cadastrosE)
            {
                if (i.Email == empresa.Email && i.Senha == empresa.Senha)
                {
                    Usuario.LogadoJ = null;
                    Usuario.LogadoE = i;
                    Listas.empregos = DaoE.consultar();
                    Listas.servicos = DaoS.consultar();

                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("userIncorreto", "Email ou senha incorretos!");
            return View(empresa);
        }

        [HttpGet]
        public IActionResult LoginJovem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginJovem(JovemLogin jovem)
        {
            if (!ModelState.IsValid)
            {
                return View(jovem);
            }

            Listas.cadastrosJ = DaoC.consultar();

            foreach (var i in Listas.cadastrosJ)
            {
                if (i.Email == jovem.Email && i.Senha == jovem.Senha)
                {
                    List<Curriculo> curriculos = DaoCur.consultar();
                    Usuario.LogadoE = null;
                    Usuario.LogadoJ = i;

                    Usuario.LogadoJ.Curriculo = curriculos.FirstOrDefault(cr => cr.JovemId == Usuario.LogadoJ.Id);

                    Listas.empregos = DaoE.consultar();
                    Listas.servicos = DaoS.consultar();

                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("userIncorreto", "Email ou senha incorretos!");
            return View(jovem);
        }

        public IActionResult Favoritar(int id)
        {
            List<Emprego> empregos = DaoE.consultar();

            Emprego emprego = empregos.FirstOrDefault(em => em.Id == id);

            DaoF.adicionar(emprego);

            return RedirectToAction("Index");
        }

        public IActionResult Candidatar(int id)
        {
            if (Usuario.LogadoJ.Curriculo != null)
            {
                DaoCur.candidatar(id);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}