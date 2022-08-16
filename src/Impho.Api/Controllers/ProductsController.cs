﻿using Impho.Api.Export;
using Impho.Application.Contracts;
using Impho.Application.Parameters;
using Impho.Application.Queries.ProductQueries;
using Impho.Core.Data.Pagination.Interfaces;
using Impho.Core.Messaging.Dispatchers.Interfaces;
using Impho.Domain.Commands.ProductCommands;
using Microsoft.AspNetCore.Mvc;

namespace Impho.Api.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public ProductsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
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
            return new ProductCsvResult(products, "products.csv");
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
        public async Task<IActionResult> Import()
        {
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
    }
}
