using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.ViewComponents
{
    public class DoctorsOrClinicsViewComponent:ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult<IViewComponentResult>(View());
        }
    }
}
