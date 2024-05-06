CREATE DATABASE VentaHardware;

--        --
-- Tablas --
--        --

CREATE TABLE users
(
  ID CHAR(5) PRIMARY KEY,
  Usuario VARCHAR(50) NOT NULL,
  Rol_usuario ENUM('SuperAdmin','Administrador', 'Vendedor') NOT NULL,
  Contraseña VARCHAR(30) NOT NULL,
  Estatus ENUM('Activo', 'Inactivo')
);

CREATE TABLE corte_caja
(
  N°_corte INT PRIMARY KEY AUTO_INCREMENT,
  Usuario VARCHAR(50),
  Fecha_corte DATETIME NOT NULL,
  Total_ventas INT DEFAULT 0 NOT NULL,
  Total_Efectivo DOUBLE DEFAULT 0 NOT NULL
);

CREATE TABLE bitacora
(
  Numero_bitacora INT PRIMARY KEY AUTO_INCREMENT,
  usuario VARCHAR(50) NOT NULL,
  Fecha_entrada DATETIME NOT NULL,
  Fecha_salida DATETIME NOT NULL
);

CREATE TABLE Categoria
(
  ID INT PRIMARY KEY AUTO_INCREMENT,
  Nombre VARCHAR(100) NOT NULL,
  Descripcion TEXT NOT NULL,
  Estatus ENUM('Activo', 'Inactivo')
);

CREATE TABLE Proveedor
(
  ID CHAR(5) PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL,
  RFC VARCHAR(10) NOT NULL,
  Telefono CHAR(10) NOT NULL,
  Direccion VARCHAR(100) NOT NULL,
  Pagina_web TEXT NOT NULL,
  Estatus ENUM('Activo', 'Inactivo')
);


CREATE TABLE Producto
(
  SKU VARCHAR(5) PRIMARY KEY,
  Nombre VARCHAR(100) NOT NULL,
  Stock INT DEFAULT 0 NOT NULL,
  Precio DOUBLE NOT NULL,
  Precio_Venta DOUBLE DEFAULT 0 NOT NULL,
  ID_categoria INT DEFAULT 0 NOT NULL,
  ID_proveedor CHAR(5) NOT NULL,
  Estatus ENUM('Activo', 'Inactivo') NOT NULL,
  CONSTRAINT FOREIGN KEY (ID_categoria) REFERENCES categoria (ID),
  CONSTRAINT FOREIGN KEY (ID_proveedor) REFERENCES proveedor (ID)
);

CREATE TABLE detalle_venta 
(
  Num_factura INT NOT NULL AUTO_INCREMENT,
  SKU VARCHAR(10) NOT NULL,
  Nombre_producto VARCHAR(100) NOT NULL,
  Cantidad INT DEFAULT 0 NOT NULL,
  Precio DOUBLE DEFAULT 0 NOT NULL,
  Importe DOUBLE DEFAULT 0 NOT NULL,
  CONSTRAINT FOREIGN KEY (Num_factura) REFERENCES venta (Numero_factura),
  CONSTRAINT FOREIGN KEY (SKU) REFERENCES producto (SKU)
);

CREATE TABLE Venta
(
  Numero_factura INT PRIMARY KEY AUTO_INCREMENT,
  Fecha DATE NOT NULL,
  ID_cliente CHAR(5) NOT NULL,
  ID_usuario CHAR(5) NOT NULL,
  Monto_final DOUBLE DEFAULT 0,
  CONSTRAINT FOREIGN KEY (ID_cliente) REFERENCES cliente (ID),
  CONSTRAINT FOREIGN KEY (ID_usuario) REFERENCES users (ID)
);


CREATE TABLE Cliente
(
  ID CHAR(5) PRIMARY KEY,
  Nombre VARCHAR(80) NOT NULL,
  Email VARCHAR(100) NOT NULL,
  CP CHAR(5) NOT NULL,
  Ciudad VARCHAR(100) NOT NULL,
  Comuna VARCHAR(100) NOT NULL,
  Calle VARCHAR(100) NOT NULL,
  Numero_casa INT DEFAULT 0,
  Estatus ENUM('Activo', 'Inactivo')
);


CREATE TABLE Telefono_cliente
(
  ID_cliente CHAR(5) NOT NULL,
  Telefono CHAR(10) NOT NULL,
  CONSTRAINT FOREIGN KEY (ID_cliente) REFERENCES Cliente (ID)
);

INSERT INTO users VALUES
('00007', 'Angel', 'SuperAdmin', '123.zxc', 'Activo'),
('00009', 'Zacarias', 'Vendedor', '132', 'Activo');

--                            --
-- PROCEDIMIENTOS ALMACENADOS --
--                            --

-- PROCEDIMIENTO ALMACENADO PARA AGREGAR LA BITACORA
CREATE PROCEDURE AddBitacora (usuario VARCHAR(50), fecha_e DATETIME, fecha_s DATETIME)
BEGIN
  INSERT INTO bitacora VALUES (NULL, usuario, fecha_e, fecha_s);
END$$

-- PROCEDIMIENTOS ALMANCENADOS PARA CORTE DE CAJA
CREATE PROCEDURE AddCorte (usuario VARCHAR(50), fcorte DATETIME, ventas INT, efectivo DOUBLE)
BEGIN
  INSERT INTO corte_caja VALUES (NULL, usuario, fcorte, ventas, efectivo);
END$$

-- PROCEDIMIENTOS ALMACENADOS DE USERS 

CREATE PROCEDURE AddUser(_id CHAR(5), _usuario VARCHAR(50), _rol ENUM('SuperAdmin','Administrador', 'Vendedor'), _contraseña VARCHAR(30))
BEGIN
  DECLARE estatus VARCHAR(20);
  SET estatus = 'Activo';
  INSERT INTO users VALUES (_id, _usuario, _rol, _contraseña, estatus);
END$$

CREATE PROCEDURE DeleteUser(_id CHAR(5), _estatus ENUM('Activo', 'Inactivo'))
BEGIN
  UPDATE users SET Estatus = _estatus WHERE ID = _id;
END$$

CREATE PROCEDURE UpdateUser(_id CHAR(5), _usuario VARCHAR(50), _rol ENUM('SuperAdmin','Administrador', 'Vendedor'), _contraseña VARCHAR(30))
BEGIN
  UPDATE users SET Usuario = _usuario, Rol_usuario = _rol, Contraseña = _contraseña WHERE ID = _id;
END$$

CREATE PROCEDURE UpdateContraseña (_id CHAR(5), _contraseña VARCHAR(30))
BEGIN
  UPDATE users SET Contraseña = _contraseña WHERE ID = _id;
END$$

-- PROCEDIMIENTOS ALMACENADOS CATEGORIA
CREATE PROCEDURE AddCategoria(_nombre VARCHAR(100), _descripcion TEXT)
BEGIN
  DECLARE Estatus VARCHAR(20);
  SET Estatus = 'Activo';
  INSERT INTO categoria VALUES(NULL, _nombre, _descripcion, Estatus);
END$$

CREATE PROCEDURE DeleteCategoria(_id INT, _estatus ENUM('Activo', 'Inactivo'))
BEGIN
  UPDATE categoria SET Estatus = _estatus WHERE ID = _id;
END$$

CREATE PROCEDURE UpdateCategoria(_Id INT, _nombre VARCHAR(100), _descripcion TEXT)
BEGIN
  UPDATE categoria SET Nombre = _nombre, Descripcion = _descripcion WHERE ID = _Id;
END$$

-- PROCEDIMIENTOS ALMACENADOS CLIENTE
CREATE PROCEDURE AddCliente
(_id CHAR(5), _nombre VARCHAR(80), _email VARCHAR(100), _cp CHAR(5), _ciudad VARCHAR(100), _comuna VARCHAR(100), _calle VARCHAR(100), _numero INT)
BEGIN
  DECLARE Estatus VARCHAR(20);
  SET Estatus = 'Activo';
  INSERT INTO cliente VALUES (_id, _nombre, _email, _cp, _ciudad, _comuna,_calle, _numero, Estatus);
END$$

CREATE PROCEDURE DeleteCliente
(_id CHAR(5), _estatus ENUM('Activo', 'Inactivo'))
BEGIN
  UPDATE cliente SET Estatus = _estatus WHERE ID = _id;
END$$

CREATE PROCEDURE UpdateCliente
(_id CHAR(5), _nombre VARCHAR(100), _email VARCHAR(100), _cp CHAR(5), _ciudad VARCHAR(100), _comuna VARCHAR(100),_calle VARCHAR(100), _numero INT)
BEGIN
  UPDATE cliente 
  SET Nombre = _nombre, Email = _email, CP = _cp, 
  Ciudad = _ciudad, Comuna = _comuna, Calle = _calle, Numero = _numero 
  WHERE ID = _id;
END$$

-- PROCEDIMIENTOS ALMACENADOS PRODUCTO
CREATE PROCEDURE AddProducto
(_sku VARCHAR(5), _nombre VARCHAR(100), _stock INT, _precio DOUBLE, _precio_venta DOUBLE, _id_categoria INT, _id_proveedor CHAR(5))
BEGIN
  DECLARE Estatus VARCHAR(20);
  SET Estatus = 'Activo';
  INSERT INTO producto VALUES (_sku, _nombre, _stock, _precio, _precio_venta, _id_categoria, _id_proveedor, Estatus);
END$$

CREATE PROCEDURE DeleteProducto (_sku VARCHAR(5), _estatus ENUM('Activo', 'Inactivo'))
BEGIN
  UPDATE producto SET Estatus = _estatus WHERE SKU = _sku;
END$$

CREATE PROCEDURE UpdateProducto
(_sku VARCHAR(5), _nombre VARCHAR(100), _stock INT, _precio DOUBLE, _precio_venta DOUBLE, _id_categoria INT, _id_proveedor CHAR(5))
BEGIN
  UPDATE producto SET Nombre = _nombre, Stock = _stock, Precio = _precio, Precio_Venta = _precio_venta, ID_categoria = _id_categoria, ID_proveedor = _id_proveedor WHERE SKU = _sku;
END$$

-- PROCEDIMIENTOS ALMACENADOS PROVEEDOR
CREATE PROCEDURE AddProveedor(_id CHAR(5), _nombre VARCHAR(100), _rfc VARCHAR(10), _telefono CHAR(10), _direccion VARCHAR(100), _pagina_web TEXT)
BEGIN
  DECLARE Estatus VARCHAR(20);
  SET Estatus = 'Activo';
  INSERT INTO proveedor VALUES(_id, _nombre, _rfc, _telefono, _direccion, _pagina_web, Estatus);
END$$

CREATE PROCEDURE DeleteProveedor (_id CHAR(5), _estatus ENUM('Activo', 'Inactivo'))
BEGIN
  UPDATE proveedor SET Estatus = _estatus WHERE ID = _id;
END$$

CREATE PROCEDURE UpdateProveedor (_id CHAR(5), _nombre VARCHAR(100), _rfc VARCHAR(10), _telefono CHAR(10), _direccion VARCHAR(100), _pagina_web TEXT)
BEGIN
  UPDATE proveedor SET Nombre = _nombre, RFC = _rfc, Telefono = _telefono, Direccion = _direccion, Pagina_web = _pagina_web WHERE ID = _id;
END$$


-- PROCEDIMIENTOS ALMACENADOS TELEFONO_CLIENTE
CREATE PROCEDURE AddTelefono_cliente (_id_cliente CHAR(5), _telefono CHAR(10))
BEGIN
  INSERT INTO telefono_cliente VALUES(_id_cliente, _telefono);
END$$

CREATE PROCEDURE DeleteTelefono_cliente (_id_cliente CHAR(5) ,_telefono CHAR(10))
BEGIN
  DELETE FROM telefono_cliente WHERE ID_cliente = _id_cliente AND Telefono = _telefono;
END$$


-- PROCEDIMIENTOS ALMACENADOS DETALLE VENTA 

CREATE PROCEDURE AddDetalle_venta (_numero_factura INT,_sku_producto VARCHAR(10), _nombre_producto VARCHAR(100),_cantidad INT, _precio DOUBLE)
BEGIN
  DECLARE importe DOUBLE;
  SELECT CalcularImporte(_cantidad, _precio) INTO importe;
  INSERT INTO detalle_venta VALUES(_numero_factura, _sku_producto, _nombre_producto, _cantidad, _precio, importe);
END$$

-- PROCEDIMIENTOS ALMACENADOS VENTA 
CREATE PROCEDURE AddVenta(_fecha DATETIME, _id_cliente CHAR(5), _id_usuario CHAR(5), _monto_final DOUBLE)
BEGIN
  INSERT INTO venta VALUES(NULL, _fecha, _id_cliente, _id_usuario, _monto_final);
END$$ventahardware

-- PROCEDIMIENTOS PARA CARGAR LOS DATOS EN LOS DATAGRIDVIEW DE LAS INTERFACEZ  
CREATE PROCEDURE dgvCategorias()
BEGIN
  SELECT * FROM categoria;
END$$

CREATE PROCEDURE dgvProveedores()
BEGIN
  SELECT * FROM proveedor;
END

CREATE PROCEDURE dgvCliente()
BEGIN
  SELECT * FROM cliente;
END$$

CREATE PROCEDURE dgvProductos()
BEGIN
  SELECT * FROM producto;
END$$

CREATE PROCEDURE dgvTelefono_cliente()
BEGIN
  SELECT telefono_cliente.ID_cliente, cliente.Nombre, telefono_cliente.Telefono FROM telefono_cliente, cliente 
  WHERE cliente.ID = telefono_cliente.ID_cliente;
END$$

CREATE PROCEDURE dgvUsuarios()
BEGIN
  SELECT * FROM users;
END$$

CREATE PROCEDURE dgvBitacora()
BEGIN
  SELECT * FROM bitacora;
END$$

CREATE PROCEDURE dgvCompras()
BEGIN
  SELECT * FROM detalle_venta;
END$$

CREATE PROCEDURE dgvVentas()
BEGIN
  SELECT * FROM venta;
END$$

CREATE PROCEDURE dgvCortes()
BEGIN
  SELECT * FROM corte_caja;
END$$

--           --
-- FUNCIONES --
--           --

-- FUNCION CALCULAR IMPORTE DE DETALE VENTA
CREATE FUNCTION CalcularImporte(_cantidad INT, _precio DOUBLE)
RETURNS DOUBLE
BEGIN
  RETURN _cantidad * _precio;
END$$

--                         --
-- TRIGGERS / DISPARADORES --
--                         --

-- ESTE TRIGGER RESTA EL STOCK DEPENDIENDO LA CANTIDAD QUE SE VENDIO Y EL PRODUCTO QUE SE VENDIO

CREATE TRIGGER update_stock AFTER INSERT ON detalle_venta FOR EACH ROW 
BEGIN
  DECLARE stock_temp INT;
  SET stock_temp = (SELECT Stock FROM producto WHERE SKU = NEW.SK) - NEW.Cantidad;
  if (stock_temp >= 0) then
  UPDATE producto SET Stock = stock_temp WHERE SKU = NEW.SKU;
  END if;
END$$

-- CONSULTAS BASICAS --

-- 0 Mostrar el nombre y telefono del proveedor que su pagina web es 'www.TecnoEUDIO.com' 

SELECT Nombre, Telefono FROM proveedor WHERE Pagina_web = 'www.TecnoEUDIO.com';

-- 1 Mostrar el nombre de la categoria que contenga 'unidades de estado solido'

SELECT Nombre FROM categoria WHERE Descripcion LIKE '%unidades de estado solido%';

-- 2 Mostrar el nombre de los clientes que contegan 'hotmail' en su correo

SELECT nombre FROM cliente WHERE Email LIKE '%hotmail%';

-- 3 Mostrar los productos que tienen un precio mayor a 5000

SELECT * FROM producto WHERE precio > 5000;

-- 4 Mostrar todos los productos cuya categoria pertenecen a '3' y '1'

SELECT * FROM producto WHERE Id_categoria IN ('3', '1');

-- 5 Mostrar los productos cuya cantidad almacenada es menor de 30

SELECT * FROM producto WHERE Stock < 30;

-- 6 Mostrar el nombre y el precio productos que no pertenecen a la categoria 1 y 2
SELECT Nombre, Precio FROM producto WHERE Id_categoria NOT IN ('1', '2');

-- CONSULTAS CON FUNCIONES DE AGREGACION --

-- 7 Mostrar la cantidad de categorias

SELECT COUNT(ID) AS Total FROM categoria;

-- 8 Mostrar la cantidad de productos agrupados por categoria

SELECT Id_categoria, COUNT(SKU) AS Total FROM producto GROUP BY Id_categoria;

-- 9 Mostrar el precio maximo y precio minimo de los productos agrupados por Categoria

SELECT ID_categoria, MAX(Precio) AS Precio_Maximo, MIN(Precio) AS Precio_Minimo 
FROM producto 
GROUP BY ID_categoria;

-- 10 Mostrar el promedio de los precios de los productos agrupados por categoria

SELECT ID_categoria, AVG(precio) AS Promedio_precios FROM producto GROUP BY ID_categoria;

-- 11 Mostrar la cantidad de productos agrupados por proveedor

SELECT ID_proveedor, COUNT(SKU) AS Total FROM producto GROUP BY ID_proveedor;

-- 12 Mostrar la Suma de los precios de los productos cuya categoria sea igual a 3

SELECT SUM(Precio) AS Suma_total FROM producto WHERE ID_categoria = '3';

-- CONSULTAS HAVING 

-- 13 Que nos muestre el total de los clientes agrupados por Ciudad a excepcion de aquellos que estan en queretaro
SELECT Ciudad, COUNT(ID) AS Total  FROM cliente GROUP BY Ciudad HAVING Ciudad <> 'Queretaro';

-- 14 Que nos muestre el total  los clientes agrupados por comunidad a excepcion de aquellos que se ubican en fuentes villa nueva
SELECT Comuna, COUNT(ID) AS Total FROM cliente GROUP BY Comuna HAVING Comuna <> 'Fuentes villanueva';

-- 15 Que nos muestre el tota de los numeros telefonicos de los clientes agrupados por nombre del cliente a excepcion del cliente grupoVentura
SELECT cliente.Nombre, count(telefono_cliente.telefono) AS Total_Telefonos FROM cliente, telefono_cliente WHERE 
cliente.ID = telefono_cliente.ID_cliente GROUP BY cliente.Nombre HAVING cliente.Nombre <>'grupoVentura';

-- CONSULTAS MULTITABLAS --

-- 16 Mostrar la cantidad de los productos que se encuentran en la categoria Audio

SELECT COUNT(producto.ID_categoria) AS Total_productos FROM producto, categoria 
WHERE producto.ID_categoria = categoria.ID AND categoria.nombre = 'Audio';

-- 17 Mostrar el nombre y el precio de los productos que abastecio el proveedor 'TecnoAUDIO' 
-- y el telefono y la pagina web del mismo

SELECT producto.Nombre, producto.Precio, proveedor.Telefono, proveedor.Pagina_web FROM producto, proveedor 
WHERE producto.ID_proveedor = proveedor.ID AND proveedor.Nombre = 'TecnoAUDIO';

-- 18 Mostrar el nombre de los productos que se le vendieron al cliente Siemens y la cantidad que se llevo de cada uno

SELECT producto.Nombre, detalle_venta.Cantidad FROM producto, cliente, venta, detalle_venta
WHERE detalle_venta.SKU = producto.SKU AND detalle_venta.Num_factura = venta.Numero_factura 
AND venta.ID_cliente = cliente.ID AND cliente.Nombre = 'Siemens'


-- 19 Mostrar el nombre del cliente que se le hizo una venta con el monto menor a 5000 y  mostrar cual fue 
-- el monto final

SELECT cliente.Nombre, venta.Monto_final FROM cliente, venta
WHERE venta.ID_cliente = cliente.ID AND venta.Monto_final < 10000;

-- 20 Mostrar el telefono de los clientes que se le hizo una venta con un monto entre 100,000 y 10,000 y su monto fue de 23,150

SELECT telefono_cliente.Telefono FROM venta, cliente, telefono_cliente
WHERE cliente.ID = telefono_cliente.ID_cliente  AND venta.ID_cliente = cliente.ID 
AND venta.Monto_final BETWEEN 10000 AND 100000 GROUP BY telefono_cliente.Telefono;

-- 21 Mostrar el nombre y el precio de los productos que se agregaron al numero de factura 5

SELECT producto.nombre, detalle_venta.Precio FROM detalle_venta, producto
WHERE detalle_venta.SKU = producto.SKU AND detalle_venta.Num_factura = 5;

-- 22 Mostrar el monto total de los productos que se agregaron al numero de factura 5

SELECT SUM(detalle_venta.Importe) As Monto_total FROM detalle_venta, producto WHERE detalle_venta.SKU = producto.SKU
AND detalle_venta.Num_factura = 5;

-- SUBCONSULTAS --

-- 23 Mostrar los nombres de los productos que no pertenecen a la categoria de AUDIO

SELECT producto.nombre FROM producto WHERE producto.ID_categoria 
NOT IN (SELECT ID FROM categoria WHERE Nombre = 'AUDIO');

-- 24 Mostrar los datos de los productos que pertenecen a la categoria de Almacenamiento

SELECT * FROM producto WHERE producto.ID_categoria 
IN (SELECT ID FROM categoria WHERE Nombre = 'ALMACENAMIENTO');

-- 25 Mostrar el codigo y el nombre del producto que han sido vendidos

SELECT SKU, Nombre FROM producto WHERE producto.SKU 
IN (SELECT detalle_venta.SKU FROM detalle_venta);

-- 26 Mostrar todos los datos de los producto que no han sido vendidos

SELECT * FROM producto WHERE producto.SKU 
NOT IN (SELECT detalle_venta.SKU FROM detalle_venta);

-- 27 Mostrar la cantidad de productos que se adjuntaron al numero de factura = 5 agrupados por nombre

SELECT producto.Nombre, COUNT(detalle_venta.Cantidad) As Total FROM producto, detalle_venta 
WHERE producto.SKU = detalle_venta.SKU
AND producto.SKU IN (SELECT detalle_venta.SKU FROM detalle_venta WHERE detalle_venta.Num_factura = 5) GROUP BY producto.Nombre;

-- 28 Mostrar el nombre , precio y cantidad de los productos que se le vendieron al cliente con el ID = 43579

SELECT producto.Nombre, detalle_venta.Precio, detalle_venta.Cantidad AS Total_vendidos FROM producto, detalle_venta WHERE producto.SKU = detalle_venta.SKU
AND detalle_venta.Num_factura
IN (SELECT venta.Numero_factura FROM venta WHERE venta.ID_cliente = '43579');


-- JOINS

-- 29 Mostrar el nombre y el precio de los productos y el ID y el nombre del departamento al que pertenecen en una vista general

SELECT producto.Nombre, producto.Precio, categoria.ID,categoria.Nombre FROM producto
 INNER JOIN categoria WHERE producto.ID_categoria = categoria.ID; 

-- 30 Mostrar la clave primaria y el nombre de los productos y tambien el ID, nombre y telefono de el proveedor que lo abstecio
-- en una viste general

SELECT producto.SKU, producto.Nombre, proveedor.ID, proveedor.Nombre, proveedor.Telefono FROM producto 
INNER JOIN proveedor WHERE producto.ID_proveedor = proveedor.ID;

-- 31 Mostrar los nombres de los clientes y su numero de telefono en una vista general

SELECT cliente.Nombre, telefono_cliente.Telefono FROM cliente 
INNER JOIN telefono_cliente WHERE telefono_cliente.ID_cliente = cliente.ID;

