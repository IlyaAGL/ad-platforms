public class AdRepository : IAdRepository
{
    private readonly Dictionary<string, List<string>> _adSources = new Dictionary<string, List<string>>();

    public List<string> getAdsByLocation(string location)
    {
        var result = new HashSet<string>();

        foreach (var source in _adSources)
        {
            foreach (var uploadedLocation in source.Value)
            {
                if (location.StartsWith(uploadedLocation))
                {
                    result.Add(source.Key);
                    break; 
                }
            }
        }

        return new List<string>(result); 
    }

    public void InitializeData(Dictionary<string, List<string>> data)
    {
        _adSources.Clear();

        foreach (var component in data)
        {
            _adSources[component.Key] = new List<string>(component.Value);
        }
    }

    public string upload(string? line, StreamReader reader)
    {
        _adSources.Clear();

        while ((line = reader.ReadLine()) != null)
        {
            var parts = line.Split(':');
            if (parts.Length != 2)
            {
                continue; 
            }

            var source = parts[0];
            var locations = parts[1].Split(',');

            _adSources[source] = new List<string>();
            foreach (var location in locations)
            {
                _adSources[source].Add(location.Trim());
            }
        }

        return "Ok";
    }
}
