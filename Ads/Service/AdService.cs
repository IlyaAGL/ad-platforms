public class AdService {
    private IAdRepository _adRepository;

    public AdService(IAdRepository adRepository)
    {
        _adRepository = adRepository;
    }
    public List<string> getAdsByLocation(string location) {
        return _adRepository.getAdsByLocation(location);
    }

    public string upload(IFormFile file) {
        if (file == null || file.Length == 0)
        {
            return "File is empty or not uploaded.";
        }

        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            string? line = string.Empty;
            return _adRepository.upload(line, reader);
        }
        
    }
}