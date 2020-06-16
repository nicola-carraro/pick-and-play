using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public static class Utilitaires
    {

        public static string Display<T>(Nullable<T> nullable, string defaultString) where T : struct => 
            nullable.HasValue ? nullable.Value.ToString() : defaultString;


        public static string Display<T>(T reference, string defaultString) where T : class => 
            reference != null ? reference.ToString() : defaultString;
    }
}
