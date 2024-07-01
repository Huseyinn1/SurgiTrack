using Newtonsoft.Json;
using SurgiTrackUI.Models;

public static class ApiService
{
   

    public static List<Hasta> GetHastaListesi()
    {
        using var httpClient = new HttpClient();

        var apiUrl = "https://localhost:7207/api/Hasta/GetAllHasta";
        var response = httpClient.GetStringAsync(apiUrl).Result;
        var hastaListesi = JsonConvert.DeserializeObject<List<Hasta>>(response);

        return hastaListesi;
    }
    public static List<Ameliyat> GetAmeliyatListesi()
    {
        using var httpClient = new HttpClient();

        var apiUrl = "https://localhost:7207/api/Ameliyat/GetAllAmeliyat";
        var response = httpClient.GetStringAsync(apiUrl).Result;
        var ameliyatListesi = JsonConvert.DeserializeObject<List<Ameliyat>>(response);

        return ameliyatListesi;
    }
    public static  List<Doktor> GetDoktorListesi()
    {
        using var httpClient = new HttpClient();

        var apiUrl = "https://localhost:7207/api/Doktor/GetAllDoktor";
        var response = httpClient.GetStringAsync(apiUrl).Result;
        var doktorListesi = JsonConvert.DeserializeObject<List<Doktor>>(response);

        return doktorListesi;
    }
    public static List<Hasta> GetHasta(int id)
    {
        using var httpClient = new HttpClient();

        var apiUrl = "https://localhost:7207/api/Hasta/GetAllHasta";
        var response = httpClient.GetStringAsync(apiUrl).Result;

        // JSON formatı değiştiyse, aşağıdaki gibi deserializasyonu güncelleyin
        var hasta = JsonConvert.DeserializeObject<List<Hasta>>(response);
        var hastas = hasta.Where(a => a.Id == id).ToList();

        return hastas;

    }
    public static List<Doktor> GetDoktor(int id)
    {
        using var httpClient = new HttpClient();

        var apiUrl = "https://localhost:7207/api/Doktor/GetAllDoktor";
        var response = httpClient.GetStringAsync(apiUrl).Result;

        // JSON formatı değiştiyse, aşağıdaki gibi deserializasyonu güncelleyin
        var doktor = JsonConvert.DeserializeObject<List<Doktor>>(response);
        var doktors = doktor.Where(a => a.Id == id).ToList();

        return doktors;

    }
    public static List<Ameliyat> GetAmeliyat(int id)
    {
        using var httpClient = new HttpClient();

        var apiUrl = "https://localhost:7207/api/Ameliyat/GetAllAmeliyat";
        var response = httpClient.GetStringAsync(apiUrl).Result;

        // JSON formatı değiştiyse, aşağıdaki gibi deserializasyonu güncelleyin
        var ameliyat = JsonConvert.DeserializeObject<List<Ameliyat>>(response);
        var ameliyats = ameliyat.Where(a => a.Id == id).ToList();

        return ameliyats;

    }
}
