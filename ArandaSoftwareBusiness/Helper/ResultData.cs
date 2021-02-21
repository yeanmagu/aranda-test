using System;
using System.Collections.Generic;
using System.Text;

namespace ArandaSoftwareBusiness.Helper
{
    public class ResultData<T>
    {
        public Exception Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public bool IsSuccess
        {
            get;
            set;
        }

        public T Result
        {
            get;
            set;
        }

        public ResultData()
        {
        }

        public static ResultData<T> Sucess(T result, string message)
        {
            return new ResultData<T>()
            {
                Message = message,
                IsSuccess = true,
                Result = result
            };
        }

        public static ResultData<T> Issue(T result, string message, Exception ex)
        {
            //Se pueden guardar los logs directamente a la  base de datos pero para esta ocassion lo vamos a omitir
            //LogData logData = new LogData();
            //var log = new Log()
            //{
            //    CreatedOnDate = DateTime.Now,
            //    Description = $"Message: {ex.Message} Stacktrace: {ex.StackTrace} Inner: {ex.InnerException}",
            //    Source = "ResultData",
            //    Type = ex.GetType().ToString()
            //};
            //logData.Add(log);

            return new ResultData<T>()
            {
                Message = message,
                IsSuccess = false,
                Result = result,
                Error = ex
            };
        }
    }
}
