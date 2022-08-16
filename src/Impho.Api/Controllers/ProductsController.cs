using CsvHelper;
using CsvHelper.Configuration;
using Impho.Application.Contracts;
using Impho.Application.Parameters;
using Impho.Application.Queries.ProductQueries;
using Impho.Core.Data.Pagination.Interfaces;
using Impho.Core.Exporter.Csv;
using Impho.Core.Messaging.Dispatchers.Interfaces;
using Impho.Domain.Commands.ProductCommands;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Impho.Api.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IDataCsvExporter _dataCsvExporter;

        public ProductsController(IQueryDispatcher queryDispatcher,
                                 ICommandDispatcher commandDispatcher,
                                 IDataCsvExporter dataCsvExporter)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
            _dataCsvExporter = dataCsvExporter;
        }

        [HttpGet]
        [Route("api/products")]
        public async Task<IActionResult> Get([FromQuery] ProductParameters parameters)
        {
            var query = new PagedProductsQuery(parameters);
            return Ok(await _queryDispatcher.Dispatch<PagedProductsQuery, IPagedList<ProductDto>>(query, CancellationToken.None));
        }

        [HttpGet]
        [Route("api/products:export")]
        public async Task<IActionResult> Export()
        {
            var query = new ExportProductsQuery();
            var products = await _queryDispatcher.Dispatch<ExportProductsQuery, IEnumerable<ProductForExportDto>>(query, CancellationToken.None);

            return CsvFileResult(_dataCsvExporter.Export(products, "products.csv"));
        }

        [HttpPost]
        [Route("api/products")]
        public async Task<IActionResult> Post([FromBody] ProductCreationDto creationDto)
        {
            var command = new AddProductCommand(creationDto.Name, creationDto.Description, creationDto.QuantityAvailable, creationDto.UnitOfMeasurement, creationDto.CurrencyValue, creationDto.CurrencyCode);
            await _commandDispatcher.Dispatch(command, CancellationToken.None);
            return NoContent();
        }

        [HttpPost]
        [Route("api/products:import")]
        public async Task<IActionResult> Import(IFormFile file)
        {
            using var memoryStream = new MemoryStream(new byte[file.Length]);
            await file.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };

            using (var reader = new StreamReader(memoryStream))
            using (var csvReader = new CsvReader(reader, configuration))
            {
                csvReader.Context.RegisterClassMap<ProductCsvMap>();
                var records = csvReader.GetRecords<ProductForExportDto>().ToList();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("api/products/{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] ProductCreationDto creationDto)
        {
            var command = new UpdateProductCommand(id, creationDto.Name, creationDto.Description, creationDto.QuantityAvailable, creationDto.UnitOfMeasurement, creationDto.CurrencyValue, creationDto.CurrencyCode);
            await _commandDispatcher.Dispatch(command, CancellationToken.None);
            return NoContent();
        }

        [HttpDelete]
        [Route("api/products/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new RemoveProductCommand(id);
            await _commandDispatcher.Dispatch(command, CancellationToken.None);
            return NoContent();
        }

        public class ProductCsvMap : ClassMap<ProductForExportDto>
        {
            public ProductCsvMap()
            {
                Map(x => x.Name).Index(0);
                Map(x => x.Description).Index(1);
                Map(x => x.QuantityAvailable).Index(2);
                Map(x => x.UnitOfMeasurement).Index(3);
                Map(x => x.CurrencyValue).Index(4);
                Map(x => x.CurrencyCode).Index(5);
            }
        }
    }
}
