public static class WebClient {
    public static void Main() {


        //客服端
        //每次链接，只能进行一次请求
        HttpClient client = new HttpClient();

        client.BaseAddress = new Uri("http://localhost:5218/");

        GetDL(client);

    }
    static void GetDL(HttpClient client) {
        HttpResponseMessage respones = client.GetAsync("/dl").Result;
        byte[] data = respones.Content.ReadAsByteArrayAsync().Result;
        System.Console.WriteLine(data.Length);
        // 存成文件
        File.WriteAllBytes("dl.zip", data);
    }
    static void GetHome(HttpClient client) {
        try {
            HttpResponseMessage respone = client.GetAsync("/").Result;
            byte[] data = respone.Content.ReadAsByteArrayAsync().Result;
            Console.WriteLine(data.Length);
            string resString = respone.Content.ReadAsStringAsync().Result;
            Console.WriteLine(resString);
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }
}