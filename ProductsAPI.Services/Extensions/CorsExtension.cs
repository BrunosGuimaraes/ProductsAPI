namespace ProductsAPI.Services.Extensions
{
    public static class CorsExtension
    {
        private static string _policyName = "DefaultPolicy";

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(s => s.AddPolicy(_policyName, builder =>
            {
                //qualquer domínio pode acessar a API
                builder.AllowAnyOrigin()
                       //qualquer método (POST, PUT, DELETE, GET etc) pode ser acessado
                       .AllowAnyMethod()
                       //qualquer parâmetro de cabeçalho de requisição pode ser enviado
                       .AllowAnyHeader();
            }));

            return services;
        }

        public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors(_policyName);
            return app;
        }
    }
}
