using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault(); // property deki ilk degeri al diyoruz o da zaten ornek verecek olursak getbyid de sadece id parametresi var onu alacak mesela
            if(idValue == null )
            {
                await next.Invoke();
                return;
            }
            var id = (int)idValue;// artik girilen id yi tuttuk
            var anyEntity = await _service.AnyAsync(x=>x.Id==id);
            // entity nin id si baseentity tarafindan gelen id ile denklestirilir
            if(anyEntity)//eger entity varsa next diyip cikis yapariz yoksa..
            {
                await next.Invoke();
                return;
            }
            //eger entity yoksa hata donduruyoruz
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not FOUND"));

        }
    }
}