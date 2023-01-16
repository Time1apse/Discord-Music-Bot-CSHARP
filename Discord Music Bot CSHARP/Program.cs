namespace Discord_Music_Bot_CSHARP.Core;
public class Program {
    public static async Task Main(string[] args) => new Bot().MainAsync().GetAwaiter().GetResult();
}