public interface IAdRepository {
    List<string> getAdsByLocation(string location);

    string upload(String line, StreamReader reader);
}