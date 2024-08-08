using GameZone.Models;

namespace GameZone.Services
{
    public class GamesService : IGamesServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagesPath;

        public GamesService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagesPath = $"{_webHostEnvironment.WebRootPath}{Settings.FileSettings.ImagesPath}";
        }

        public async Task Create(CreateGameFormViewModel model)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var path = Path.Combine(_imagesPath, coverName) ;

            using var stream = File.Create(path) ;
            await model.Cover.CopyToAsync(stream) ;

            Game game = new() 
            { 
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Devices = model.SelectedDevices.Select(d => new GameDevice {DeviceId = d }).ToList(),
                Cover = coverName,
            };
            _context.Add(game);
            _context.SaveChanges();

        }
    }
}
