namespace MercadoLibre_Muntantes.Static
{
    using System.Collections.Generic;
    using MercadoLibre_Muntantes.Dto;
    using MercadoLibre_Muntantes.Enums;

    public class CadenaADN
    {

        #region variables
        /// <summary>
        /// listado de los caracteres a evaluar
        /// </summary>
        public static List<dtoADN> ListAdn = new List<dtoADN>();
        /// <summary>
        /// Tamaño de la cadena de ADN en X
        /// </summary>
        public static int Tamanho_X;
        /// <summary>
        /// Tamaño de la cadena de ADN en Y
        /// </summary>
        public static int Tamanho_Y;
        /// <summary>
        /// Cadena de de caractreres en string
        /// </summary>
        public static string Cadena;
        /// <summary>
        /// Almacena la cantidad de secuencias que tiene los caracteres iguales y secuenciales 
        /// </summary>
        public static int SecuenciasEncontradas;

        /// <summary>
        /// Cantidad minima de caracteres que deben de ser iguales y consecutivos para que sea un ADN mutante valido
        /// </summary>
        public static int CantidadCaracteresIGuales = 4;
        /// <summary>
        /// Posicion Maxima a buscar de caracteres empezando desde cero ( x - 1)
        /// </summary>
        public static int PosicionMaximaABuscar = CantidadCaracteresIGuales - 1;
        /// <summary>
        /// Secuencias de caracteres minimos que deben de tener para culmplir con la regla
        /// </summary>
        public static int SecuenciasMinimasRequeridas = 2;
        /// <summary>
        /// Enum que indica que regla no cumplio
        /// </summary>
        public static EnumReglas ReglaNoCumplida;

        /// <summary>
        /// se valida si se encuentra con la cantidad de secuencia minima requerida
        /// </summary>
        public static bool SecuenciaEncontrada
        {
            get
            {
                if (SecuenciasEncontradas >= SecuenciasMinimasRequeridas)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        #endregion


        /// <summary>
        /// metodo encargado de inicializar la clase
        /// </summary>
        public static void Iniciar()
        {
            ListAdn.Clear();
            Cadena = string.Empty;
            SecuenciasEncontradas = 0;
            Tamanho_X = 0;
            Tamanho_Y = 0;
            ReglaNoCumplida = 0;
        }
        /// <summary>
        /// se realiza la asignacion de los caracteres a la lista de ADN
        /// </summary>
        /// <param name="vparCadenaADN">Lista de ADN</param>
        /// <returns>Si se proceso correctamento o hubo se encontro un caractere no valido</returns>
        public static bool AsignarADN(string[] vparCadenaADN)
        {
            Iniciar();

            int Position_X = 0;
            Tamanho_X = vparCadenaADN.Length;

            foreach (var vItemFila in vparCadenaADN)
            {
                if (Tamanho_Y == 0)
                {
                    Tamanho_Y = vItemFila.Length;
                }
                Cadena = Cadena + "'" + vItemFila + "',";

                int Posicion_Y = 0;
                for (int i = 0; i < vItemFila.Length; i++)
                {
                    Posicion_Y = i;

                    dtoADN vlocAdn = new dtoADN();
                    vlocAdn.Caracter = vItemFila.Substring(Posicion_Y, 1);
                    vlocAdn.Posicion_X = Position_X;
                    vlocAdn.Posicion_Y = Posicion_Y;

                    ///se valida que todos los caracteres sean validos
                    if (!vlocAdn.CaracterPermitido)
                    {
                        ReglaNoCumplida = EnumReglas.CaracterNoValido;
                        return false;
                    }
                    ListAdn.Add(vlocAdn);
                }
                Position_X++;

                ///se valida que todas las filas tengan la misma cantidad de caracteres
                if (vItemFila.Length != Tamanho_Y)
                {
                    ReglaNoCumplida = EnumReglas.UnStringNoCumpleConLaCantidadRequerida;
                    return false;
                }
            }

            ///se valida que la cadena sea NxN
            if (Tamanho_X != Tamanho_Y)
            {
                ReglaNoCumplida = EnumReglas.LaCadenaNoEsNXN;
                return false;
            }
            return true;

        }

    }
}
