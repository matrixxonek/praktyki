using System.Net.Http.Headers;
using System.Threading.Tasks;
HttpClient client = new HttpClient();
async Task ProcessRepositories()
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

    var stringTask = client.GetStringAsync("https://gitlab.com/matrixxonek/my-awesome-project");

    var msg = await stringTask;
    Console.Write(msg);
}
async Task Main(string[] args)
{
    Console.WriteLine("wiad");
    await ProcessRepositories();
}