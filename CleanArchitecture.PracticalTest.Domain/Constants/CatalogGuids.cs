using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Domain.Constants
{
    public static class CatalogGuids
    {
        // Guids estáticos para Estados
        public static readonly Guid Registrado = Guid.Parse("d12a3456-7890-abcd-ef01-234567890abc");
        public static readonly Guid EnBodega = Guid.Parse("e23b4567-8901-bcde-f012-345678901bcd");
        public static readonly Guid EnTransito = Guid.Parse("f34c5678-9012-cdef-0123-456789012cde");
        public static readonly Guid EnReparto = Guid.Parse("d12a3456-7890-abcd-ef01-234567890abe");
        public static readonly Guid Entregado = Guid.Parse("e23b4567-8901-bcde-f012-345678901bce");
        public static readonly Guid Devuelto = Guid.Parse("f34c5678-9012-cdef-0123-456789012cdc");

        // Guids estáticos para Rutas
        public static readonly Guid RutaNorte = Guid.Parse("a45d6789-0123-def0-1234-567890123def");
        public static readonly Guid RutaSur = Guid.Parse("b56e7890-1234-ef01-2345-678901234ef0");
        public static readonly Guid RutaCentro = Guid.Parse("c67f8901-2345-f012-3456-789012345f01");
    }
}
