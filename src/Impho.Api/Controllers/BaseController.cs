using Impho.Core.Exporter.Csv;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Impho.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult ServiceUnavailable(object value)
        {
            return StatusCode(StatusCodes.Status503ServiceUnavailable, value);
        }

        protected IActionResult CsvFileResult(ICsvExportedFile exportedFile)
        {
            return new FileContentResult(Encoding.ASCII.GetBytes(exportedFile.Content), "text/csv")
            {
                FileDownloadName = exportedFile.Name
            };
        }
    }
}
