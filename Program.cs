public static class WebClient
{
    public static void Main()
    {


        //客服端
        //每次链接，只能进行一次请求
        HttpClient clien = new HttpClient();

        clien.BaseAddress = new Uri("http://localhost:5218/");

        try
        {
            HttpResponseMessage respone = clien.GetAsync("/").Result;
            byte[] data = respone.Content.ReadAsByteArrayAsync().Result;
            Console.WriteLine(data.Length);
            string resString = respone.Content.ReadAsStringAsync().Result;
            Console.WriteLine(resString);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}