# Pisos.com Backend Coding Challenge

Bienvenido a nuestro reto de backend. ¡Esperamos que lo disfrutes!

Queremos que nos ayudes a implementar una API para nuestros clientes inmobiliarios.

Necesitamos que puedan enviar sus inmuebles a nuestro sistema y actualizarlos o consultarlos.

## Requisistos

Los casos de uso que necesitan implentarse son los siguientes:

* Alta de inmueble
  - Una inmobiliaria debe poder incorporar un nuevo inmueble captado a su cartera
* Actualizar inmueble
  - Una inmobiliaria debe poder actualizar los datos de uno de sus inmuebles en cartera
* Listar inmuebles
  - Una inmobiliaria debe poder consultar los inmubles registrados en su cartera

Para desarrollarlo vamos a usar un enfoque "API First". Para que el cliente pueda 
implementar dicha integración en paralelo le hemos dado las especificaciones de la API,
así que es muy importante que cumplamos con estos contratos.

Te ofrecemos a continuación unas llamadas de ejemplo
que te ayudarán a entender como implementar los distintos end-points de nuestra nueva API.

No necesitas una base de datos, puedes persistirlo todo en memoria.

Esperamos que apliques tus mejores habilidades de programación y que te sientras orgulloso
del código entregado.

¡Suerte!

#### Alta de inmueble

``` bash
curl --location --request POST 'https://localhost:44304/v1/properties' \
--header 'Content-Type: application/json' \
--data-raw '{
    "agencyId": "4d4b1dd3-59c5-401f-a184-01e38340fdf4",
    "price": 1950000.0,
    "location": {
        "city": "Granollers",
        "zipcode": "08420",
        "address": "C/ Anselm Clave 61"
    },
    "operationType": "venta"
    "type": "piso",
    "rooms": 3,
    "baths": 1
}'
```

#### Actualizar inmueble

``` bash
curl --location --request PATCH 'https://localhost:44304/v1/properties/6b29272d-0cc8-4c7f-a987-b6f8df035122' \
--header 'Content-Type: application/json' \
--data-raw '{
    "id": "6b29272d-0cc8-4c7f-a987-b6f8df035122",
    "price": 2000000.0
}'
```

#### Listar inmuebles

``` bash
curl --location --request GET 'https://localhost:44304/v1/properties?agencyId=4d4b1dd3-59c5-401f-a184-01e38340fdf4'
```