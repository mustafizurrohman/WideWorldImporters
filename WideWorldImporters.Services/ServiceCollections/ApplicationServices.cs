﻿using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System;
using WideWorldImporters.AuthenticationProvider.Database;
using WideWorldImporters.Core.CoreServices.Interfaces;
using WideWorldImporters.Logger.Implementation;
using WideWorldImporters.Models.Database;

namespace WideWorldImporters.Services.ServiceCollections
{

    /// <summary>
    /// Utility Services for the application
    /// </summary>
    public class ApplicationServices
    {

        #region -- Public Properties -- 

        /// <summary>
        /// Application Database context
        /// </summary>
        public WideWorldImportersContext DbContext { get; }

        /// <summary>
        /// Authentication Provider DATA
        /// </summary>
        public AuthenticationProviderContext AuthDbContext { get; }

        /// <summary>
        /// AutoMapper 
        /// </summary>
        public IMapper AutoMapper { get; }

        /// <summary>
        /// InMemory Local Caching
        /// </summary>
        public IMemoryCache MemoryCache { get; }

        /// <summary>
        /// Redis Caching
        /// </summary>
        public IRedisService RedisService { get; }

        /// <summary>
        /// Logging service
        /// </summary>
        public AppLoggers Logger { get; }

        /// <summary>
        /// The console logger.
        /// </summary>
        public ConsoleLogger ConsoleLogger { get; }

        /// <summary>
        /// The file logger.
        /// </summary>
        public NLogFileLogger FileLogger { get; }

        #endregion

        #region -- Constructor -- 

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext">Database context</param>
        /// <param name="autoMapper">AutoMapper</param>
        /// <param name="memoryCache">Memory Caching</param>
        /// <param name="redisService">Redis Caching</param>
        /// <param name="logger">Logging Service</param>
        /// <param name="authDbContext">Authorization Database Context</param>
        public ApplicationServices(
            WideWorldImportersContext dbContext,
            IMapper autoMapper,
            IMemoryCache memoryCache,
            IRedisService redisService,
            AppLoggers logger,
            AuthenticationProviderContext authDbContext)
        {
            DbContext = dbContext;
            AutoMapper = autoMapper;
            MemoryCache = memoryCache;
            RedisService = redisService;
            AuthDbContext = authDbContext;
            Logger = logger;
            ConsoleLogger = logger.ConsoleLogger;
            FileLogger = logger.FileLogger;
        }

        #endregion

        #region -- Utility Logging Methods -- 

        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message) => Logger.LogInfo(message);

        /// <summary>
        /// Logs an exception
        /// </summary>
        /// <param name="ex"></param>
        public void Log(Exception ex) => Logger.Log(ex);

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="message">The Debug message to log.</param>
        public void LogDebug(string message) => Logger.LogDebug(message);

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The Debug message to log.</param>
        public void LogError(string message) => Logger.LogError(message);

        /// <summary>
        /// Logs an exception.
        /// </summary>
        /// <param name="ex"></param>
        public void LogException(Exception ex) => Logger.LogException(ex);

        /// <summary>
        /// Logs an informational message.
        /// </summary>
        /// <param name="message">The informational message to log.</param>
        public void LogInfo(string message) => Logger.LogInfo(message);

        /// <summary>
        /// Logs an warning message.
        /// </summary>
        /// <param name="message">The warning message to log.</param>
        public void LogWarn(string message) => Logger.LogWarn(message);

        #endregion

    }

}
