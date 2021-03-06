﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WideWorldImporters.Models.Database;

namespace WideWorldImporters.Services.Interfaces
{
    /// <summary>
    /// Interface for Sample Service for Testing
    /// </summary>
    public interface ISampleService
    {
        /// <summary>
        /// Hello World
        /// </summary>
        /// <returns></returns>
        string HelloWorld();

        /// <summary>
        /// Gets vehicle temperatures
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<VehicleTemperatures>> GetVehicleTempsAsync();
    }
}
