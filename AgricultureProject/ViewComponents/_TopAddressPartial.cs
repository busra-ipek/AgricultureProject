using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureProject.ViewComponents
{
    public class _TopAddressPartial : ViewComponent
    {
        public readonly IAddressService _addressService;
        //Default partial viewda adres tablosundan veri almak istediğimiz için bunu kullandık.
        public _TopAddressPartial(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _addressService.GetListAll();
            return View(values);
        }
        /*Invoke ile Index metodu gibi bir view oluşturmayacağımız için Shared ->
		Components -> _TopAddressPartial adında bir klasör oluşturduk.
		Bu klasörün içine Default adında bir partial view ekledik. */
    }
}
