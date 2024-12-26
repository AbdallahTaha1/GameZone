using GameZone.Attributes;

namespace GameZone.ViewModels
{
    public class CreateGameFormViewModel : GameFormViewModel
    {

        [AllowedExtentions(FileSettings.AllowedExtentions),
            MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;

    }
}
