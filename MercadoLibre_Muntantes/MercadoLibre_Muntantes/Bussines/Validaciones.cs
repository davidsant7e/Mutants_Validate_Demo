/// <summary>
/// Clase encargada de realizar las validaciones correspondientes 
/// </summary>
namespace MercadoLibre_Muntantes.Bussines
{
    using System.Linq;
    using MercadoLibre_Muntantes.Static;
    using MercadoLibre_Muntantes.Enums;
    public class Validaciones
    {
        /// <summary>
        /// Metodo encargado de validar que la cadena de AND cumpla con todas las reglas 
        /// </summary>
        public void ValidarSecuenciaADN()
        {
            foreach (var item in CadenaADN.ListAdn)
            {
                int vlocPosicionX = item.Posicion_X;
                int vlocPosicionY = item.Posicion_Y;
                string vlocCaracter = item.Caracter;
                this.ValidarHorizontal(vlocCaracter, vlocPosicionX, vlocPosicionY);
                this.ValidarVertical(vlocCaracter, vlocPosicionX, vlocPosicionY);
                this.ValidarDiagonal(vlocCaracter, vlocPosicionX, vlocPosicionY);
                if (CadenaADN.SecuenciaEncontrada)
                {
                    break;
                }
            }

            if (!CadenaADN.SecuenciaEncontrada)
            {
                CadenaADN.ReglaNoCumplida = EnumReglas.NoSeEncontroSecuenciasNecesarias;
            }

        }

        /// <summary>
        /// Metodo encargada de validar que de forma horizontal se encuentre una igualdad de caracteres con base al caracter de busqueda y su posicion
        /// </summary>
        /// <param name="vparCaracter">Caracter de busqueda de igualdad</param>
        /// <param name="vpar_X">Posicion en X en la que se encuentra el caracter a validar</param>
        /// <param name="vpar_Y">Posicion en Y en la que se encuentra el caracter a validar</param>
        public void ValidarHorizontal(string vparCaracter, int vpar_X, int vpar_Y)
        {
            int vlocCantidadCoincidencia = (from s in CadenaADN.ListAdn
                                            where s.Caracter == vparCaracter
                                                   && s.Posicion_X == vpar_X
                                                   && (s.Posicion_Y >= vpar_Y && s.Posicion_Y <= vpar_Y + CadenaADN.PosicionMaximaABuscar)
                                            select s).ToList().Count;
            // si se encuentra que la cantidad de caracteres encontrados son iguales a la cantidad requerida se asigna aumenta el valor del contador de secuencias encontradas
            if (vlocCantidadCoincidencia == CadenaADN.CantidadCaracteresIGuales)
            {
                CadenaADN.SecuenciasEncontradas++;
            }
        }

        /// <summary>
        /// Metodo encargada de validar que de forma Vertival  se encuentre una igualdad de caracteres con base al caracter de busqueda y su posicion
        /// </summary>
        /// <param name="vparCaracter">Caracter de busqueda de igualdad</param>
        /// <param name="vpar_X">Posicion en X en la que se encuentra el caracter a validar</param>
        /// <param name="vpar_Y">Posicion en Y en la que se encuentra el caracter a validar</param>
        public void ValidarVertical(string vparCaracter, int vpar_X, int vpar_Y)
        {

            int vlocCantidadCoincidencia = (from s in CadenaADN.ListAdn
                                            where s.Caracter == vparCaracter
                                                   && (s.Posicion_X >= vpar_X && s.Posicion_X <= vpar_X + CadenaADN.PosicionMaximaABuscar)
                                                   && (s.Posicion_Y == vpar_Y)
                                            select s).ToList().Count;
            // si se encuentra que la cantidad de caracteres encontrados son iguales a la cantidad requerida se asigna aumenta el valor del contador de secuencias encontradas
            if (vlocCantidadCoincidencia == CadenaADN.CantidadCaracteresIGuales)
            {
                CadenaADN.SecuenciasEncontradas++;
            }
        }

        /// <summary>
        /// Metodo encargada de validar que de forma diagonal se encuentre una igualdad de caracteres con base al caracter de busqueda y su posicion
        /// </summary>
        /// <param name="vparCaracter">Caracter de busqueda de igualdad</param>
        /// <param name="vpar_X">Posicion en X en la que se encuentra el caracter a validar</param>
        /// <param name="vpar_Y">Posicion en Y en la que se encuentra el caracter a validar</param>
        public void ValidarDiagonal(string vparCaracter, int vpar_X, int vpar_Y)
        {
            int vlocCantidadCoincidencia = 0;
            for (int i = 0; i <= CadenaADN.PosicionMaximaABuscar; i++)
            {
                vlocCantidadCoincidencia += (from s in CadenaADN.ListAdn
                                             where s.Caracter == vparCaracter
                                                    && s.Posicion_X == (vpar_X + i)
                                                    && s.Posicion_Y == (vpar_Y + i)
                                             select s).ToList().Count;
            }
            // si se encuentra que la cantidad de caracteres encontrados son iguales a la cantidad requerida se asigna aumenta el valor del contador de secuencias encontradas
            if (vlocCantidadCoincidencia == CadenaADN.CantidadCaracteresIGuales)
            {
                CadenaADN.SecuenciasEncontradas++;
            }

            vlocCantidadCoincidencia = 0;
            for (int i = 0; i <= CadenaADN.PosicionMaximaABuscar; i++)
            {
                vlocCantidadCoincidencia += (from s in CadenaADN.ListAdn
                                             where s.Caracter == vparCaracter
                                                    && s.Posicion_X == (vpar_X - i)
                                                    && s.Posicion_Y == (vpar_Y + i)
                                             select s).ToList().Count;
            }
            // si se encuentra que la cantidad de caracteres encontrados son iguales a la cantidad requerida se asigna aumenta el valor del contador de secuencias encontradas
            if (vlocCantidadCoincidencia == CadenaADN.CantidadCaracteresIGuales)
            {
                CadenaADN.SecuenciasEncontradas++;
            }

        }

    }
}
