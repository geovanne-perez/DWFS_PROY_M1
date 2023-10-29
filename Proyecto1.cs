/*
Proyecto Módulo 1
Alumno: Geovanne Pérez
Fecha: 2023/10/28

Algoritmo de Sistema de Costos
*/

//Declaración de Variables
//CONSTANTES:
Caracter _PRODUCTO[1] : "Samsung S22"
Caracter _PRODUCTO[2] : "Samsung Fold 5"
Caracter _PRODUCTO[3] : "Iphone 15"
Caracter _PRODUCTO[4] : "Iphone 15 Pro"
Caracter _PRODUCTO[5] : "Xiaomi Note 12"

decimal _PRECIO[1] : "22000.00"
decimal _PRECIO[2] : "27000.00"
decimal _PRECIO[3] : "18000.00"
decimal _PRECIO[4] : "25000.00"
decimal _PRECIO[5] : "12000.00"

//VARIABLES:
string   v_Producto_Cliente, v_Cupon_Cliente_Texto, v_RequiereEnvio_Texto
decimal  v_precioProducto
int      v_Cantidad_Cliente
bool     v_Cupon_Cliente, v_RequiereEnvio
decimal  v_DescuentoPorCupon, v_porcentaje_Descuento, v_descuento_Mayoreo
decimal  v_Subtotal_cliente, v_total_Cliente
string   v_ciudadEnvio
decimal  v_PesoPaquete, v_precioBaseEnvio, v_precioFinalEnvio 

//Inicio
//Mostrar catálogo al cliente
FUNCION MostrarProductos()

/// Solicitar al cliente escribir el producto a comprar:
ESCRIBIR ("Introduzca el producto a comprar: ")
v_Producto_Cliente = LEER {Solicitar texto al usuario}
ESCRIBIR ("Producto: " + v_Producto_Cliente + " Seleccionado")

/// Llamar función para buscar precio del producto en el catálogo
v_precioProducto = FUNCION BuscarPrecioProducto()

/// Solicitar al cliente intoducir la cantidad:
ESCRIBIR ("Introduzca cantidad: ")
v_Cantidad_Cliente = LEER {Solicitar número al usuario}

// Calcular subtotal
v_Subtotal_cliente = v_Cantidad_Cliente * v_precioProducto
ESCRIBIR ("Su subtotal es: " + v_Subtotal_cliente)

//Aplicar Cupón de Descuento
FUNCION ObtenerDescuentoCupon()

// Aplicar descuento por mayoreo
v_Subtotal_cliente = FUNCION ObtenerDescuentoMayoreo()

// Aplicar Impuestos
v_Subtotal_cliente = v_Subtotal_cliente * (1.16)

// Calcular costo de envío
v_precioFinalEnvio = FUNCION ObtenerCostoEnvio()

// mostrar descuento total (Informativo) al cliente
ESCRIBIR ("Su descuento total es: " + (v_descuento_Mayoreo + v_DescuentoPorCupon))

// mostrar total al cliente
ESCRIBIR ("Su pago total es: " + s_Total_cliente)




/////////////////// FUNCIONES //////////////////////

FUNCION MostrarProductos()
{
ESCRIBIR ("Nombre de producto: " + _PRODUCTO[1] + " - Precio: " + _PRECIO[1])
ESCRIBIR ("Nombre de producto: " + _PRODUCTO[2] + " - Precio: " + _PRECIO[2])
ESCRIBIR ("Nombre de producto: " + _PRODUCTO[3] + " - Precio: " + _PRECIO[3])
ESCRIBIR ("Nombre de producto: " + _PRODUCTO[4] + " - Precio: " + _PRECIO[4])
ESCRIBIR ("Nombre de producto: " + _PRODUCTO[5] + " - Precio: " + _PRECIO[5])
}
/// Función Buscar precio de producto
FUNCIÓN_BuscarPrecioProducto ()
{    
SI ( v_Producto_Cliente = _PRODUCTO[1]) ENTONCES 
	v_precioProducto = _PRECIO[1]
	
SI ( v_Producto_Cliente = _PRODUCTO[2]) ENTONCES 
	v_precioProducto = _PRECIO[2]
	
SI ( v_Producto_Cliente = _PRODUCTO[3]) ENTONCES 
	v_precioProducto = _PRECIO[3]
	
SI ( v_Producto_Cliente = _PRODUCTO[4]) ENTONCES 
	v_precioProducto = _PRECIO[4]
	
SI ( v_Producto_Cliente = _PRODUCTO[5]) ENTONCES 
	v_precioProducto = _PRECIO[5]
	
SINO
	ESCRIBIR ("Error: Producto introducido no existe")
}

//Función para Calcular descuento por cupón
FUNCION ObtenerDescuentoCupon()
{
	/// Preguntar al cliente si tiene cupón de descuento
	ESCRIBIR ("Tiene cupón de descuento?? (SI/NO): ")
	v_Cupon_Cliente_Texto = LEER {Solicitar texto al usuario}
	//Evaluar texto introducido
	SI (v_Cupon_Cliente_Texto == "SI")
		{v_Cupon_Cliente = 1}
	// Preguntar al cliente el porcentaje de descuento por pieza	
	SI (v_Cupon_Cliente)
	{
	ESCRIBIR ("Introduzca el porcentaje de descuento del cupón: ")
	v_DescuentoPorCupon = LEER {Solicitar texto al usuario}	
	}
	SINO {
	v_DescuentoPorCupon = 0
	}

	//Crear Variable local
	int PorcentajeDescuento
	// Modificar el precio por producto de acuerdo al descuento
	SI (v_Cupon_Cliente)
	{	
	v_DescuentoPorCupon = v_DescuentoPorCupon * 0.01
	v_precioProducto = v_precioProducto * v_DescuentoPorCupon
	}
}
	
/// Función para Calcular descuento por mayoreo dependiendo de v_Cantidad_Cliente 
FUNCION ObtenerDescuentoMayoreo()
{   
// Inicializar sin descuento (Si no es mayor que 1 unidades)
v_porcentaje_Descuento = 0

SI  v_Cantidad_Cliente > 1 ENTONCES
	v_porcentaje_Descuento = 10
	
SI  v_Cantidad_Cliente >= 10 ENTONCES
	v_porcentaje_Descuento = 20
	
// Convertir numero en porcentaje (Multiplicando por 0.01)
v_porcentaje_Descuento = v_porcentaje_Descuento *0.01
// Aplicar descuento al subtotal
v_descuento_Mayoreo = v_Subtotal_cliente * v_porcentaje_Descuento
v_Subtotal_cliente = v_Subtotal_cliente - v_descuento_Mayoreo
}

//Función para calcular envío
FUNCTION ObtenerCostoEnvio(){
s_Subtotal_cliente
s_Total_cliente 

/// Preguntar al cliente si requiere envío
	ESCRIBIR ("Requiere envío o prefiere recoger el paquete?? (SI/NO): ")
	v_RequiereEnvio_Texto = LEER {Solicitar texto al usuario}
	//Evaluar texto introducido
	SI (v_RequiereEnvio_Texto == "SI")
		{v_RequiereEnvio = 1}
	
	SI (v_RequiereEnvio)
	{
		// Preguntar al cliente la ciudad de envío	
		ESCRIBIR ("Introduzca la ciudad de envío")
		v_ciudadEnvio = LEER {Solicitar texto al usuario}
		// Calcular Peso del paquete (250g por Unidad)
		v_PesoPaquete = v_Cantidad_Cliente * 0.250

		SI(v_ciudadEnvio == "PUEBLA" o "CDMX")
			v_precioBaseEnvio = 100
		SINO
			v_precioBaseEnvio = 300

		// Calcular precio final envío
		// $50 pesos más por KG
		v_precioFinalEnvio = (v_precioBaseEnvio + (v_PesoPaquete * 50))

	}

}
	