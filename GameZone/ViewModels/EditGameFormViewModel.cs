using GameZone.Attributes;

namespace GameZone.ViewModels
{
    public class EditGameFormViewModel : GameFormViewModel
    {
        public int Id { get; set; }

        [AllowedExtentions(FileSettings.AllowedExtentions),
            MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public string? currentCover {  get; set; }
        public IFormFile? Cover { get; set; } = default!;
    }
}
