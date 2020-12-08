using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndPlay
{
    public static class Utilitaires
    {
        public static string Afficher<T>(T? nullable, string defaultString) where T : struct =>
            nullable.HasValue ? nullable.Value.ToString() : defaultString;

        public static string Afficher<T>(T reference, string defaultString) where T : class =>
            reference != null ? reference.ToString() : defaultString;

        public static string AfficherAnnee(DateTime? date, string defaultString)  =>
            date != null ? date.Value.Year.ToString() : defaultString;
    }
}
