using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                // run middleware i sonlandirici bir middleware dir 
                // burada yazilan koddan sonra akis geriye donecek
                //request buraya girdigi anda daha ileriye controllerlara gidemeyecek buradan geri donecek
                // ASP.NET Core'da ara katman (Middleware) yapısı, uygulama çalıştığında bir istemciden (Client) gelen taleplerin (Request)
                // istemciye geri döndürülmesi (Response) sürecindeki işlemleri gerçekleştirmek ve sürece yön vermek için kullanılmaktadır


                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }
        
    }
}
