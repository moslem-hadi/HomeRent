namespace WebApp.Infrastructure;

public static class ApiUri
{
    public static class Product
    { 
        public static string GetAllProducts(string baseUri)
        {
            return $"{baseUri}products";
        }
    }
}
