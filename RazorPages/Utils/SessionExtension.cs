namespace RazorPages.Utils;
using JsonSerializer = System.Text.Json.JsonSerializer;

public static class SessionExtension
{
    public static void SetList<T>(this ISession session, string key, List<T>? list) where T : class
    {
        var jsonString = JsonSerializer.Serialize(list);
        session.SetString(key, jsonString);
    }
    
    public static List<T>? GetList<T>(this ISession session, string key) where T : class
    {
        var listJson = session.GetString(key);
        return listJson == null ? null : JsonSerializer.Deserialize<List<T>>(listJson);
    }
//test test
}