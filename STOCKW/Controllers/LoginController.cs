using Microsoft.AspNetCore.Mvc;
using STOCKW.Data;
using STOCKW.Models;
using System;
using System.Linq; // Para usar o LINQ

namespace STOCKW.Controllers
{
    public class LoginController : Controller
    {
        private readonly MeuDbContext _context;

        public LoginController(MeuDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Buscando o usuário no banco de dados
                    var usuario = _context.Usuarios
                        .FirstOrDefault(u => u.Nome == loginModel.Login);

                    if (usuario != null && usuario.Senha == loginModel.Senha)
                    {
                        // Login correto
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Login ou senha inválidos
                        TempData["MensagemErro"] = "Usuário ou senha errada, tente novamente.";
                    }
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível realizar seu login, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
