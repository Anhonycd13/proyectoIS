using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using gStoreMedicPlus.Models;
using Microsoft.AspNetCore.Http;

namespace gStoreMedicPlus.Clases
{
    public class VariablesGlobales
    {
        public static string IdUsuario { get; set; }
        public static string NombreUsuario { get; set; }

        public VariablesGlobales()
        {
            
        }

        public void GetUser() {


        }
    }
}
