using Microsoft.AspNetCore.Mvc;
using TesteRebaseComVisualStudio.Models;

namespace TesteRebaseComVisualStudio.Controllers
{
    public class UsuarioController : Controller
    {
        private List<UsuarioModel> usuarios = new List<UsuarioModel>
        {
            new UsuarioModel { Id = 1, Nome = "João", Email = "joao@example.com" },
            new UsuarioModel { Id = 2, Nome = "Maria", Email = "maria@example.com" },
            new UsuarioModel { Id = 3, Nome = "Pedro", Email = "pedro@example.com" }
        };

        public ActionResult Index()
        {
            return View(usuarios);
        }

        public ActionResult Edit(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Edit(UsuarioModel usuario)
        {
            var existingUsuario = usuarios.FirstOrDefault(u => u.Id == usuario.Id);
            if (existingUsuario == null)
            {
                return HttpNotFound();
            }

            existingUsuario.Nome = usuario.Nome;
            existingUsuario.Email = usuario.Email;

            return RedirectToAction("Index");
        }
    }
}
