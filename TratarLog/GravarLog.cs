using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RenanRolo.ApiExceptions.TratarLog
{
    public static class GravarLog
    {
        public static void Gravar(Exception ex)
        {
            try
            {
                LogVO log = new LogVO(ex);

                LogDao logDao = new LogDao();
                logDao.InserirLogJson(log);
            }
            catch (Exception bigException)
            {
                Console.WriteLine($"Erro ao gravar log: {bigException.Message}");
            }
        }
    }
}
