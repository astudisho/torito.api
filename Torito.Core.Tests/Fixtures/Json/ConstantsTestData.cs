using System;
using System.Collections.Generic;
using System.Text;

namespace Torito.Core.Tests.Fixtures.Json
{
    internal static class ConstantsTestData
    {
        public static readonly (string, string)[] ParenthesisTweets =
        {
            (@"Circuito Metropolitano Sur (Pedro Parra) y Lopez Mateos, a la altura de Residencial Vista Sur y banus.",
            "Circuito Metropolitano Sur  y Lopez Mateos, a la altura de Residencial Vista Sur y banus."),
            (@"Av. Tonaltecas (Periférico) y Juarez, por la gasera.",
                "Av. Tonaltecas  y Juarez, por la gasera."),
            (@"Av. del Tesoro y Vista a la Campiña (Isla Gomera).",
             "Av. del Tesoro y Vista a la Campiña ."),
            (@"Av. Tonaltecas y Juárez (Río Nilo).",
            "Av. Tonaltecas y Juárez .")
        };

        public static readonly (string,string)[] AddressTweets =
        {
            (@"Alcoholímetro:

Av. Vallarta y Niño Obrero, por la cámara de comercio de Guadalajara.

#Toritojalisco #AlcoholimetroGDL #ToritoGDL #AntiToritoGDL #CurvaGDL 🍷 🍸 🍹 🍺 🍻 🍾 🚔 👮 🚓 🐂 11:10 p. m. · 3 ene. 202", "Av. Vallarta y Niño Obrero, por la cámara de comercio de Guadalajara."),
            (@"Alcoholímetro:

Calzada Independencia y Periférico Norte, a la altura de plaza independencia y la bodega de coca cola.

#Toritojalisco #AlcoholimetroGDL #ToritoGDL #AntiToritoGDL #CurvaGDL 🍷 🍸 🍹 🍺 🍻 🍾 🚔 👮 🚓 🐂", "Calzada Independencia y Periférico Norte, a la altura de plaza independencia y la bodega de coca cola."),
            (@"Alcoholímetro:

Av. Tonaltecas y Av. Tonala, por la clínica #93 del @Tu_IMSS.

#Toritojalisco #AlcoholimetroGDL #ToritoGDL #AntiToritoGDL #CurvaGDL 🍷 🍸 🍹 🍺 🍻 🍾 🚔 👮 🚓 🐂", "Av. Tonaltecas y Av. Tonala, por la clínica #93 del @Tu_IMSS."),
            (@"Alcoholímetro:

Av. Cruz del Sur y Lapislázuli.

#Toritojalisco #AlcoholimetroGDL #ToritoGDL #AntiToritoGDL #CurvaGDL 🍷 🍸 🍹 🍺 🍻 🍾 🚔 👮 🚓 🐂", "Av. Cruz del Sur y Lapislázuli."),
            (@"Alcoholímetro:

Av. México y Av. Abedules, a la altura de plaza bonita.

#Toritojalisco #AlcoholimetroGDL #ToritoGDL #AntiToritoGDL #CurvaGDL 🍷 🍸 🍹 🍺 🍻 🍾 🚔 👮 🚓 🐂", "Av. México y Av. Abedules, a la altura de plaza bonita."),
            (@"Alcoholímetro:

Av. Servidor Público entre Av. Santa Margarita y Av. Valle de Atemajac, por la plaza real center.

#Toritojalisco #AlcoholimetroGDL #ToritoGDL #AntiToritoGDL #CurvaGDL 🍷 🍸 🍹 🍺 🍻 🍾 🚔 👮 🚓 🐂", "Av. Servidor Público entre Av. Santa Margarita y Av. Valle de Atemajac, por la plaza real center."),
            (@"Alcoholímetro: 

Circuito Metropolitano Sur, a la altura del autódromo.

#Toritojalisco #AlcoholimetroGDL #ToritoGDL #AntiToritoGDL #CurvaGDL 🍷 🍸 🍹 🍺 🍻 🍾 🚔 👮 🚓 🐂", "Circuito Metropolitano Sur, a la altura del autódromo.")
        };
    }
}
