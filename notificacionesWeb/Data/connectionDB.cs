namespace notificacionesWeb.Data
{
    public static class connectionDB
    {
        private static string cadenaConnection =  "";

        public static string CadenaConnection
        {


            get
            {
                if (String.IsNullOrEmpty(cadenaConnection))
                {
                    IConfiguration configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .Build();

                    return cadenaConnection = configuration.GetConnectionString("DefaultConnection") ?? "";
                }
                else
                {
                    return cadenaConnection;
                }
            }

        }





    }
}
