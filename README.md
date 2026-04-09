# Sistema de Gestión Académica - Colegio Don Bosco
## 📝 Descripción
Este programa es una aplicación de consola desarrollada en **C#** para el **Desafío Práctico 2**. Suobjetivo es automatizar el registro de calificaciones, el cálculo de promedios ponderados y la generación de reportes para un máximo de 20 estudiantes, cumpliendo con los lineamientos de
modularización (procedimientos y funciones) y manejo de arreglos paralelos.
## 🚀 Funcionalidades Principal (Menú)
El sistema cuenta con una interfaz de usuario basada en consola con las siguientes opciones:
1. **Registrar Estudiantes:** Permite el ingreso de nombre, carnet y 4 notas parciales. Incluye
     una validación en tiempo real para asegurar que las notas estén en el rango de 0.0 a 10.0.
2. **Reporte Individual:** (Módulo en desarrollo) Permite buscar a un estudiante específico
     por su número de lista o carnet y ver su detalle de notas.
3. **Lista Completa:** Genera una tabla con todos los estudiantes registrados, mostrando sus
     nombres, carnets y promedios finales calculados.
4. **Estadísticas:** (Módulo en desarrollo) Mostrará datos globales como la nota más alta, la
     más baja y el porcentaje de aprobados.
5. **Salir:** Finaliza la ejecución del programa de forma segura.
## 🛠️ Detalles Técnicos
Para cumplir con los requerimientos académicos, el programa implementa:

**Estructura de Datos (Arreglos Paralelos)**

Se utilizan arreglos estáticos de tamaño 20 para mantener la integridad de los datos de forma
sincronizada mediante un índice común (pos):
- *nombres[]* y *carnets[]* (Tipo String)
- *parcial1[], parcial2[], parcial3[], parcialfinal[]* y *promedios[]* (Tipo Double)

**Lógica de Evaluación**

El promedio se calcula mediante una función con retorno que aplica los siguientes pesos
porcentuales:

<img width="731" height="31" alt="image" src="https://github.com/user-attachments/assets/a5c0da01-a06a-440a-8ae4-0b02612760ef" />


**Modularización**
- **Procedimientos *(static void)*:** Controlan el flujo visual (Bienvenida, Menú, Registro).
- **Funciones *(static bool/double)*:** Realizan validaciones lógicas y cálculos matemáticos fuera del bloque principal (*Main*).

## 📖 Instrucciones de Uso
1. Al iniciar, presione cualquier tecla para pasar la pantalla de bienvenida.
2. Seleccione la **Opción 1** para ingresar datos. Si intenta ingresar una nota inválida (ej. -5 o 11), el sistema le solicitará el dato nuevamente mediante un ciclo de validación.
3. Utilice la **Opción 3** para verificar que los datos se guardaron correctamente en los
arreglos.
4. Para cerrar el programa, utilice siempre la **Opción 5** del menú.
## ✒️ Autores
- María Fernanda Campos Mejía.
- Emma Abigail Romero Rivas.

<p align="center">
   - Estudiantes de Ingeniería en Ciencias de la Computación -
</p>
