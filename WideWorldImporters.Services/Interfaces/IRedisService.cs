﻿using System.Threading.Tasks;

namespace WideWorldImporters.Services.Interfaces
{

    /// <summary>
    /// Interface for Redis Service
    /// </summary>
    public interface IRedisService
    {

        /// <summary>
        /// Sets an object of type T to a redis key
        /// </summary>
        /// <typeparam name="T">Type of object to set</typeparam>
        /// <param name="key">Key to access the object</param>
        /// <param name="value"></param>
        /// <returns></returns>
        Task SetAsync<T>(string key, T value);

        /// <summary>
        /// Gets the data corresponding to a redis key
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="key">Key to access the object</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string key);

        /// <summary>
        /// Returns true if an entry with specified redis key exists
        /// </summary>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <param name="key">Key to verify</param>
        /// <returns></returns>
        Task<bool> ExistAsync<T>(string key);

        /// <summary>
        /// Deletes a specified redis key asynchronisly
        /// </summary>
        /// <param name="key">Key to delete</param>
        /// <returns></returns>
        Task DeleteAsync(string key);

    }

}
