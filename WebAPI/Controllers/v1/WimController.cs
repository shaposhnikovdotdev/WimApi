using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net;
using WebAPI.Wrappers;
using Wim;
using Wim.DataObjects;

namespace WebAPI.Controllers.v1
{

    [ApiVersion("1.0")]
    public class WimController
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpPost("data")]
        [ProducesResponseType(200)]
        public async Task<Response<List<Completed>>> Data()
        {
            Random random = new Random();
            List<Completed> completedList = new List<Completed>();

            for (int i = 0; i < 5; i++)
            {
                Completed completedInstance = new Completed
                {
                    dynWeight = random.Next(100, 1000).ToString(),
                    isDualTire = new List<bool> { random.NextDouble() > 0.5, random.NextDouble() > 0.5 },
                    getWeightV = random.Next(500, 2000).ToString(),
                    AxInfo = new List<string> { "100", "200", "300" },
                    getWeightAx = new List<string> { random.Next(100, 500).ToString(), random.Next(100, 500).ToString(), random.Next(100, 500).ToString() },
                    getAx = random.Next(1, 5),
                    getSpeed = random.Next(60, 120).ToString(),
                    getDistTire = new List<string> { random.Next(1, 10).ToString(), random.Next(1, 10).ToString() },
                    dateTime = DateTime.Now.ToString()
                };

                completedList.Add(completedInstance);
            }
            return new Response<List<Completed>>(completedList);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        [HttpPost("status")]
        [ProducesResponseType(200)]
        public async Task<Response<List<Status>>> status()
        {
            Random random = new Random();
            List<Status> statusList = new List<Status>();

            for (int i = 0; i < 5; i++)
            {
                Status statusInstance = new Status
                {
                    isConnected = random.NextDouble() > 0.5,
                    isLost = random.NextDouble() > 0.5,
                    isError = random.NextDouble() > 0.5,
                    chError = GenerateRandomString(10), // Генерация случайной строки, например, длиной 10 символов
                    dateTime = DateTime.Now.ToString()
                };

                statusList.Add(statusInstance);
            }

            return new Response<List<Status>>(statusList);
        }

        [HttpPost("StatusLog")]
        [ProducesResponseType(200)]
        public async Task<Response<List<Log>>> StatusLog()
        {
            List<Log> logList = new List<Log>();

            for (int i = 0; i < 5; i++)
            {
                Log logInstance = new Log
                {
                    log = GenerateRandomString(20), // Например, генерация случайной строки длиной 20 символов для поля log
                    dateTime = DateTime.Now.ToString()
                };

                logList.Add(logInstance);
            }

            return new Response<List<Log>>(logList);
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
