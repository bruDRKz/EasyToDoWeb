using EasyToDoWeb.Context;
using EasyToDoWeb.Models;
using EasyToDoWeb.Repositories.Interfaces;

namespace EasyToDoWeb.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            _context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Categoria Adicionada");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Delete(int id)
        {
            var categoria = _context.Categoria.FirstOrDefault(c => c.CategoriaID == id);

            if (categoria != null)
            {
                _context.Remove(categoria);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Categoria> GetAll => _context.Categoria.ToList();

        public Categoria GetById(int id) => _context.Categoria.FirstOrDefault(c => c.CategoriaID == id);

        public void Update(Categoria categoria)
        {
            _context.Update(categoria);
            _context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Categoria >>>> {categoria.NomeCategoria} <<<< foi alterada com sucesso!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
