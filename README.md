# Tienda de electrónica

## Enunciado

Una tienda de reparaciones de electrónica tiene distintos tipos de aparatos contemplados para su reparación: Radios, Televisores, Reproductores de DVD y adaptadores de TDT, cada uno con su tarifa de reparación por hora (5, 10, 10 y 5 euros, respectivamente). De todos los aparatos se guarda su nº de serie, su modelo y su precio de reparación por hora. De las radios se guardan las bandas que es capaz de manejar (AM/FM o ambas), de los televisores sus pulgadas, de los reproductores de DVD si reproducen Blue-Ray y también si graban o no, y en su caso el tiempo de grabación; y de los adaptadores de TDT el tiempo máximo de grabación si la soporta. Una reparación toma el precio por horas para el aparato, y lo aplica en segmentos de media hora, haciendo la oportuna conversión. Si la reparación lleva una hora o menos, se considera sustitución de piezas, y se respeta el precio por hora estipulado para el aparato. En caso de superar la hora, entonces se trata de una reparación compleja, y se cobra aplicando un sobreprecio del 25% a los precios por hora trabajada asignados para cada aparato. Todas las reparaciones tienen un precio base de 10€, y el precio de las piezas se cobra aparte de las horas trabajadas. Debe haber una jerarquía de clases para los   aparatos y para las reparaciones. Las reparaciones creadas serán guardadas automáticamente en `reparaciones.xml` al finalizar la ejecución, y recuperados, de existir el fichero, al finalizarla. Debe haber una jerarquía de clases para los   aparatos y para las reparaciones. Las reparaciones creadas serán guardadas automáticamente en `reparaciones.xml` al finalizar la ejecución, y recuperados, de existir el fichero, al finalizarla.  

Requisitos:

- Aparatos: nº serie, modelo, precio reparación por hora

| Aparato         | Coste horas trabajadas | Campos adicionales                    |
| --------------- | ---------------------- | ------------------------------------- |
| Radio           | 5                      | AM/FM/AM-FM                           |
| Televisor       | 10                     | pulgadas                              |
| Reproductor DVD | 10                     | blue-ray, graba?, tiempo de grabación |
| Adaptador TDT   | 5                      | tiempo máximo de grabación, graba?    |

- Reparación:
  - Precio base: 10€
  - Coste piezas
  - Simple (<= 1 hora): $horas\ trabajadas · precio\ hora$
  - Complejo (> 1 hora): $horas\ trabajadas · precio\ hora · 1.25$
- Archivo de reparaciones:
  - Guardar/Cargar de `reparaciones.xml`

## Proyecto

Crear una aplicación tanto de consola como con interfaz gráfica hecha con Avalonia.