using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torito.Core.Tests.Fixtures.Json
{
    internal static partial class ConstantsTestData
    {
        public static readonly (string, string)[] RetweetTweets =
        {
            (@"RT @damplin: Av. Revolución entre Ramón López Velarde y Av. San Rafael, por plaza revolución. 

#Toritojalisco #AlcoholimetroGDL #ToritoGDL…",
                "Av. Revolución entre Ramón López Velarde y Av. San Rafael, por plaza revolución."),

            (@"RT @damplin: Av. Juan Gil Preciado y Arco del Triunfo, por walmart la Cima.

#Toritojalisco #AlcoholimetroGDL #ToritoGDL #AntiToritoGDL #Cu…",
                "Av. Juan Gil Preciado y Arco del Triunfo, por walmart la Cima."),
            (@"RT @damplin: Av. Revolución entre Lázaro Cárdenas y Niños Héroes, por la bodega Aurrera.

#Toritojalisco #AlcoholimetroGDL #ToritoGDL #Anti…",
                "Av. Revolución entre Lázaro Cárdenas y Niños Héroes, por la bodega Aurrera."),
            (@"RT @damplin: Av. Juan Gil Preciado y Arco del Triunfo, por walmart la Cima.

#Toritojalisco #AlcoholimetroGDL #ToritoGDL #AntiToritoGDL #Cu…",
                "Av. Juan Gil Preciado y Arco del Triunfo, por walmart la Cima."),
            (@"RT @damplin: Periférico Norte y la Calzada Independencia.

#Toritojalisco #AlcoholimetroGDL #ToritoGDL #AntiToritoGDL #CurvaGDL 🍷 🍸 🍹 🍺 🍻 🍾…",
                "Periférico Norte y la Calzada Independencia.")
        };
    }
}
