# Mutants_Validate_Demo

Proyecto realizado para la necesidad de Magneto de identificar a los mutantes de los Humanos.

# Validar En un ambiente local

## Base de datos

La base de datos utilizada para la aplicacion es hecha en MYSQL, en caso de querer crearla en un servidor local los script se encuentran en la carpeta "Script"

## Codigo fuente 🖥🖥

Para correr el codigo fuente en un ambiente local se recomienda tener instalado visual studio 2019 e tener instalado MysqlClient version 8.0

```
git clone https://github.com/davidsant7e/Mutants_Validate_Demo.git
```
Al descargar - Clonar el codigo fuente de la aplicacion es necesario abrir la solucion de la aplicacion la cual se encuentra en la primera carpeta "MercadoLibre_Muntantes".

la aplicacion se encuentra apuntando a una base de datos publicada en smarterasp.net, en caso de querer ejecutar dicha base de datos de forma local se debe de cambiar la cadena de conexion en el archivo appsettings.json, en la variable MYSQL.


# despliegue de codigo 🌪☁☁🌪

El servicio web fue desplegado en smarterasp.net, para realizar el despligue de este proyecto se utilizo la documentacion brindada por la plataforma 
```
https://www.smarterasp.net/support/kb/a2135/how-to-publish-asp_net-core-web-application-via-visual-studio-2019.aspx
```

## Endpoint de servicios.
### Post/mutant

```
http://davidsant7-001-site1.htempurl.com/api/mutant
```
_Ejemplo JSON_
```
{
  "dna": [
    "ATGCGA",
    "CAGTGC",
    "TTATGT",
    "AGAAGG",
    "CCCCTA",
    "TCACTG"
  ]
}
```

### Get/Stats
```
http://davidsant7-001-site1.htempurl.com/api/Stats
```

## Autores
David Santiago Escobar 
💻🐕🐱‍🚀
(https://github.com/davidsant7e)
