namespace gStoreMedicPlus.Clases
{
    public class Misc
    {
        public static int CalcularEdad(DateTime FechaNac)
        {
            try
            {
                DateTime FechaActual = DateTime.Now;

                int day = FechaNac.Day;
                int month = FechaNac.Month;
                int year = FechaNac.Year;

                int bi_year = 0; // Año bisiesto 

                // Calcula los anios bisiestos  
                for (int i = year; i < FechaActual.Year; i++)
                {
                    if (DateTime.IsLeapYear(i))
                    {
                        ++bi_year;
                    }
                }

                TimeSpan timeSpan = FechaActual.Subtract(FechaNac);
                day = timeSpan.Days - bi_year;
                int r = 0;

                // Obtener el resultado 

                year = Math.DivRem(day, 365, out r);
                month = Math.DivRem(r, 30, out r);
                day = r;
                return year;
            }
            catch (Exception ex)
            {
                // Guardar el Error en un TXT
                //string path_error = @"" + Program.path_global + "logError" + DateTime.Now.ToString("s").Replace(":", "").Replace("-", "") + ".txt";
                /*
                if (!File.Exists(path_error))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path_error))
                    {
                        sw.WriteLine("ERROR MESSEGE: " + ex.Message + " STACK: " + ex.StackTrace + " SOURCE: " + ex.Source + " MORE DETAILS: HelpLink: " + ex.HelpLink + " - Data: " + ex.Data);
                    }
                }
                */
                return 0;
            }
        }
    }
}
