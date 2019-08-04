using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace RenanRolo.ApiExceptions.TratarLog
{
    public class LogDao
    {
        internal void InserirLogJson(LogVO log)
        {
            var error = new Dictionary<string, object>
            {
                {"DataErro", log.DataHora.ToString("yyyy/MM/dd HH:mm:ss.fff", CultureInfo.InvariantCulture)},
                {"Exception", ExceptionParaDictionary(log.Exception)}
            };

            string logJson = JsonConvert.SerializeObject(error);

            GravarArquivo(logJson);
        }

        private void GravarArquivo(string objetoJson)
        {
            string filepath = CaminhoDoArquivo();

            File.AppendAllText(filepath, objetoJson + Environment.NewLine);
        }

        private string CaminhoDoArquivo()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "Log";
            Directory.CreateDirectory(basePath);
            return basePath + "\\log.txt";
        }

        private Dictionary<string, object> ExceptionParaDictionary(Exception ex)
        {
            if (ex == null)
                return null;

            return new Dictionary<string, object>
            {
                { "Type", ex.GetType().ToString() },
                { "Message", ex.Message },
                { "StackTrace", ex.StackTrace },
                { "Data", ex.Data },
                { "InnerException", ExceptionParaDictionary(ex.InnerException)  }
            };
        }
    }
}
