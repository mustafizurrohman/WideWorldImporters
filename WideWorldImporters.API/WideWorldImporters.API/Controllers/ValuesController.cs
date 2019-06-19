﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using WideWorldImporters.API.Controllers.Base;
using WideWorldImporters.Core.Helpers;
using WideWorldImporters.Models.Database;
using WideWorldImporters.Services.Interfaces;
using WideWorldImporters.Services.ServiceCollections;

namespace WideWorldImporters.API.Controllers
{

    /// <summary>
    /// Sample controller
    /// </summary>
    public class ValuesController : BaseAPIController
    {

        private readonly ISampleService _sampleService;
        


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="applicationServices"></param>
        /// <param name="sampleService"></param>
        public ValuesController(
            ApplicationServices applicationServices, 
            ISampleService sampleService) 
            : base(applicationServices)
        {
            this._sampleService = sampleService;
        }
        

        /// <summary>
        /// Test
        /// </summary>
        /// <returns></returns>
        [HttpGet("Test")]
        public IActionResult Test()
        {
            string data = _sampleService.HelloWorld();

            return Ok(data);
        }

        /// <summary>
        /// Db Test
        /// </summary>
        /// <returns></returns>
        [HttpGet("VehicleTemperatures/odata")]
        [Produces("application/json")]
        public IActionResult GetDataAsync()
        {
            DbSet<VehicleTemperatures> vehicleTemps = AppServices.DbContext.VehicleTemperatures;

            var data = DbContext.VehicleTemperatures.Take(1000);
            
            return Ok(data);
        }

        /// <summary>
        /// Db Test using service
        /// </summary>
        /// <returns></returns>
        [HttpGet("VehicleTemperatures/service")]
        public async Task<IActionResult> GetDataFromServiceAsync()
        {

            var data = await _sampleService.GetVehicleTempsAsync();

            return Ok(data);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("performance")]
        public IActionResult SortPerformance()
        {
            List<int> numbers = Enumerable.Range(0, 10000000)
                    .Select(x => IntHelpers.GetRandomNumber(int.MaxValue))
                    .ToList();

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            numbers.Sort();

            stopwatch.Stop();

            return Ok(numbers);




        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("exception")]
        public IActionResult NotImplementedFunction()
        {
            throw new NotImplementedException();
        }



        #region -- Sample Methods -- 

        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// GET api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// POST api/values
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /// <summary>
        /// PUT api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DELETE api/values/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
