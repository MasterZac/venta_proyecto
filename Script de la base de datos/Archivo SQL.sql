-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.6.8-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para ventahardware
CREATE DATABASE IF NOT EXISTS `ventahardware` /*!40100 DEFAULT CHARACTER SET utf8mb3 */;
USE `ventahardware`;

-- Volcando estructura para procedimiento ventahardware.AddBitacora
DELIMITER //
CREATE PROCEDURE `AddBitacora`(usuario VARCHAR(50), fecha_e DATETIME, fecha_s DATETIME)
BEGIN
  INSERT INTO bitacora VALUES (NULL, usuario, fecha_e, fecha_s);
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.AddCategoria
DELIMITER //
CREATE PROCEDURE `AddCategoria`(_nombre VARCHAR(100), _descripcion TEXT)
BEGIN
  DECLARE Estatus VARCHAR(20);
  SET Estatus = 'Activo';
  INSERT INTO categoria VALUES(NULL, _nombre, _descripcion, Estatus);
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.AddCliente
DELIMITER //
CREATE PROCEDURE `AddCliente`(
	IN `_id` CHAR(5),
	IN `_nombre` VARCHAR(80),
	IN `_email` VARCHAR(100),
	IN `_cp` CHAR(5),
	IN `_ciudad` VARCHAR(100),
	IN `_comuna` VARCHAR(100),
	IN `_calle` VARCHAR(100),
	IN `_numero` INT
)
BEGIN
  DECLARE Estatus VARCHAR(20);
  SET Estatus = 'Activo';
  INSERT INTO cliente VALUES (_id, _nombre, _email, _cp, _ciudad, _comuna,_calle, _numero, Estatus);
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.AddCorte
DELIMITER //
CREATE PROCEDURE `AddCorte`(usuario VARCHAR(50), fcorte DATETIME, ventas INT, efectivo DOUBLE)
BEGIN
  INSERT INTO corte_caja VALUES (NULL, usuario, fcorte, ventas, efectivo);
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.AddDetalle_venta
DELIMITER //
CREATE PROCEDURE `AddDetalle_venta`(_numero_factura INT,_sku_producto VARCHAR(10), _nombre_producto VARCHAR(100),_cantidad INT, _precio DOUBLE)
BEGIN
  DECLARE importe DOUBLE;
  SELECT CalcularImporte(_cantidad, _precio) INTO importe;
  INSERT INTO detalle_venta VALUES(_numero_factura, _sku_producto, _nombre_producto, _cantidad, _precio, importe);
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.AddProducto
DELIMITER //
CREATE PROCEDURE `AddProducto`(_sku VARCHAR(5), _nombre VARCHAR(100), _stock INT, _precio DOUBLE, _precio_venta DOUBLE, _id_categoria INT, _id_proveedor CHAR(5))
BEGIN
  DECLARE Estatus VARCHAR(20);
  SET Estatus = 'Activo';
  INSERT INTO producto VALUES (_sku, _nombre, _stock, _precio, _precio_venta, _id_categoria, _id_proveedor, Estatus);
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.AddProveedor
DELIMITER //
CREATE PROCEDURE `AddProveedor`(_id CHAR(5), _nombre VARCHAR(100), _rfc VARCHAR(10), _telefono CHAR(10), _direccion VARCHAR(100), _pagina_web TEXT)
BEGIN
  DECLARE Estatus VARCHAR(20);
  SET Estatus = 'Activo';
  INSERT INTO proveedor VALUES(_id, _nombre, _rfc, _telefono, _direccion, _pagina_web, Estatus);
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.AddTelefono_cliente
DELIMITER //
CREATE PROCEDURE `AddTelefono_cliente`(_id_cliente CHAR(5), _telefono CHAR(10))
BEGIN
  INSERT INTO telefono_cliente VALUES(_id_cliente, _telefono);
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.AddUser
DELIMITER //
CREATE PROCEDURE `AddUser`(_id CHAR(5), _usuario VARCHAR(50), _rol ENUM('SuperAdmin','Administrador', 'Vendedor'), _contraseña VARCHAR(30))
BEGIN
  DECLARE estatus VARCHAR(20);
  SET estatus = 'Activo';
  INSERT INTO users VALUES (_id, _usuario, _rol, _contraseña, estatus);
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.AddVenta
DELIMITER //
CREATE PROCEDURE `AddVenta`(_fecha DATETIME, _id_cliente CHAR(5), _id_usuario CHAR(5), _monto_final DOUBLE)
BEGIN
  INSERT INTO venta VALUES(NULL, _fecha, _id_cliente, _id_usuario, _monto_final);
END//
DELIMITER ;

-- Volcando estructura para tabla ventahardware.bitacora
CREATE TABLE IF NOT EXISTS `bitacora` (
  `Numero_bitacora` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(50) NOT NULL,
  `Fecha_entrada` datetime NOT NULL,
  `Fecha_salida` datetime NOT NULL,
  PRIMARY KEY (`Numero_bitacora`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ventahardware.bitacora: ~33 rows (aproximadamente)
/*!40000 ALTER TABLE `bitacora` DISABLE KEYS */;
INSERT INTO `bitacora` (`Numero_bitacora`, `usuario`, `Fecha_entrada`, `Fecha_salida`) VALUES
	(1, 'Alejandro', '2022-12-11 22:47:43', '2022-12-11 22:47:46'),
	(2, 'Amador', '2022-12-11 22:48:33', '2022-12-11 22:48:35'),
	(3, 'Alejandro', '2022-12-11 23:30:35', '2022-12-11 23:31:49'),
	(4, 'Zacarias', '2022-12-11 23:53:21', '2022-12-11 23:54:00'),
	(5, 'Amador', '2022-12-12 01:55:24', '2022-12-12 01:55:37'),
	(6, 'Alejandro', '2022-12-12 15:58:46', '2022-12-12 15:58:49'),
	(7, 'Alejandro', '2022-12-12 15:59:54', '2022-12-12 16:02:37'),
	(8, 'Alejandro', '2022-12-12 23:59:20', '2022-12-12 23:59:42'),
	(9, 'Alejandro', '2022-12-13 00:13:22', '2022-12-13 00:16:50'),
	(10, 'Zacarias', '2022-12-13 14:35:11', '2022-12-13 14:35:18'),
	(11, 'Zacarias', '2022-12-13 14:55:43', '2022-12-13 14:55:46'),
	(12, 'Alejandro', '2022-12-13 23:57:28', '2022-12-13 23:57:29'),
	(13, 'Alejandro', '2022-12-14 00:10:37', '2022-12-14 00:10:39'),
	(14, 'Alejandro', '2022-12-14 01:58:49', '2022-12-14 01:58:50'),
	(15, 'Alejandro', '2022-12-14 01:59:23', '2022-12-14 01:59:25'),
	(16, 'Robert ', '2022-12-14 02:31:31', '2022-12-14 02:31:35'),
	(17, 'Alejandro', '2022-12-14 02:35:03', '2022-12-14 02:35:04'),
	(18, 'Alejandro', '2022-12-14 02:51:23', '2022-12-14 03:02:29'),
	(19, 'Alejandro', '2022-12-14 03:16:24', '2022-12-14 03:16:43'),
	(20, 'Zacarias ', '2022-12-14 08:24:38', '2022-12-14 08:24:40'),
	(21, 'Alejandro', '2022-12-14 08:35:02', '2022-12-14 08:35:04'),
	(22, 'Zacarias', '2022-12-28 08:02:24', '2022-12-28 08:02:42'),
	(23, 'Zacarias', '2023-01-04 12:54:12', '2023-01-04 12:54:22'),
	(24, 'Zacarias', '0001-01-01 00:00:00', '2023-01-07 19:58:43'),
	(25, 'Zacarias', '2023-01-07 20:01:46', '2023-01-07 20:01:55'),
	(26, 'Zacarias', '2023-01-12 18:59:33', '2023-01-12 18:59:38'),
	(27, 'Alejandro', '0001-01-01 00:00:00', '2023-01-12 19:14:39'),
	(28, 'Alejandro', '2023-01-12 19:17:05', '2023-01-12 19:17:12'),
	(29, 'Alejandro', '0001-01-01 00:00:00', '2023-01-12 19:19:25'),
	(30, 'Alejandro', '0001-01-01 00:00:00', '2023-01-12 19:25:05'),
	(31, 'Alejandro', '0001-01-01 00:00:00', '2023-01-12 19:35:16'),
	(32, 'Zacarias', '2023-01-12 19:41:45', '2023-01-12 19:43:42'),
	(33, 'Zacarias', '2023-01-12 19:45:44', '2023-01-12 19:47:32');
/*!40000 ALTER TABLE `bitacora` ENABLE KEYS */;

-- Volcando estructura para función ventahardware.CalcularImporte
DELIMITER //
CREATE FUNCTION `CalcularImporte`(_cantidad INT, _precio DOUBLE) RETURNS double
BEGIN
  RETURN _cantidad * _precio;
END//
DELIMITER ;

-- Volcando estructura para tabla ventahardware.categoria
CREATE TABLE IF NOT EXISTS `categoria` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) NOT NULL,
  `Descripcion` text NOT NULL,
  `Estatus` enum('Activo','Inactivo') NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ventahardware.categoria: ~6 rows (aproximadamente)
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` (`ID`, `Nombre`, `Descripcion`, `Estatus`) VALUES
	(1, 'AUDIO', 'Audifonos, bocinas, microfonos, reproductores, adaptadores, etc.', 'Activo'),
	(2, 'COMPUTADORAS   ', 'PC escritorio, portatiles, servidores   ', 'Activo'),
	(3, 'ALMACENAMIENTO', 'Memoria flash, Discos duros, unidades de estado solido, etc.', 'Activo'),
	(4, 'CELULARES', 'Celulares android y IOS, relojes inteligentes. ', 'Activo'),
	(5, 'IMPRESION', 'Impresoras y repuesto.', 'Activo'),
	(19, 'OTROS', 'chips', 'Activo');
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;

-- Volcando estructura para tabla ventahardware.cliente
CREATE TABLE IF NOT EXISTS `cliente` (
  `ID` char(5) NOT NULL,
  `Nombre` varchar(80) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `CP` char(5) NOT NULL,
  `Ciudad` varchar(100) NOT NULL,
  `Comuna` varchar(100) NOT NULL,
  `Calle` varchar(100) NOT NULL,
  `Numero` int(11) DEFAULT NULL,
  `Estatus` enum('Activo','Inactivo') NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ventahardware.cliente: ~4 rows (aproximadamente)
/*!40000 ALTER TABLE `cliente` DISABLE KEYS */;
INSERT INTO `cliente` (`ID`, `Nombre`, `Email`, `CP`, `Ciudad`, `Comuna`, `Calle`, `Numero`, `Estatus`) VALUES
	('01531', 'Rogelio', 'rogi@gmail.com', '23144', 'Cosver', 'rayon', 'rayon', 234, 'Activo'),
	('01783', 'grupoVentura', 'grupoV@hotmail.com', '29098', 'Oaxaca', 'Fuentes Balvanera', 'AV casoluengo', 23, 'Activo'),
	('12393', 'Angel Roberto', 'angel@gmail.com', '01229', 'Cosver', 'La nora', 'Av.LaNora', 104, 'Activo'),
	('43579', 'Siemens', 'Siemens@hotmail.com', '34560', 'Boca del rio', 'la playita', 'AV. independencia NO. 241', 403, 'Activo'),
	('90123', 'Chedraui', 'SuperChe@gmail.com', '23470', 'Queretaro', 'Fuentes villanueva', '15 de febrero', 102, 'Activo');
/*!40000 ALTER TABLE `cliente` ENABLE KEYS */;

-- Volcando estructura para tabla ventahardware.corte_caja
CREATE TABLE IF NOT EXISTS `corte_caja` (
  `N°_corte` int(11) NOT NULL AUTO_INCREMENT,
  `Usuario` varchar(50) DEFAULT NULL,
  `Fecha_corte` datetime NOT NULL,
  `Total_ventas` int(11) DEFAULT 0,
  `Total_Efectivo` double DEFAULT 0,
  PRIMARY KEY (`N°_corte`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ventahardware.corte_caja: ~16 rows (aproximadamente)
/*!40000 ALTER TABLE `corte_caja` DISABLE KEYS */;
INSERT INTO `corte_caja` (`N°_corte`, `Usuario`, `Fecha_corte`, `Total_ventas`, `Total_Efectivo`) VALUES
	(1, 'Alejandro', '2022-12-12 18:35:26', 2, 27800),
	(2, 'Alejandro', '2022-12-13 00:18:43', 2, 64700),
	(3, 'Zacarias', '2022-12-13 14:00:00', 0, 0),
	(4, 'Zacarias', '2022-12-13 14:03:46', 0, 0),
	(5, 'Zacarias', '2022-12-14 02:00:11', 2, 37000),
	(6, 'Alejandro', '2022-12-14 02:24:39', 2, 31600),
	(7, 'Alejandro', '2022-12-14 02:32:00', 1, 37200),
	(8, 'Alejandro', '2022-12-14 02:38:36', 2, 191900),
	(9, 'Zacarias ', '2022-12-14 08:23:58', 2, 59050),
	(10, 'Alejandro', '2022-12-14 08:31:41', 1, 6200),
	(11, 'Alejandro', '2022-12-14 08:39:27', 2, 3300),
	(12, 'Alejandro', '2022-12-14 10:33:48', 3, 82000),
	(13, 'Alejandro ', '2022-12-28 11:40:46', 3, 31200),
	(14, 'Zacarias', '2023-01-12 18:59:16', 1, 23500),
	(15, 'Alejandro', '2023-01-12 19:13:39', 1, 64400),
	(16, 'Zacarias', '2023-01-12 19:47:21', 1, 6200);
/*!40000 ALTER TABLE `corte_caja` ENABLE KEYS */;

-- Volcando estructura para procedimiento ventahardware.DeleteCategoria
DELIMITER //
CREATE PROCEDURE `DeleteCategoria`(_id INT, _estatus ENUM('Activo', 'Inactivo'))
BEGIN
  UPDATE categoria SET Estatus = _estatus WHERE ID = _id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.DeleteCliente
DELIMITER //
CREATE PROCEDURE `DeleteCliente`(_id CHAR(5), _estatus ENUM('Activo', 'Inactivo'))
BEGIN
  UPDATE cliente SET Estatus = _estatus WHERE ID = _id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.DeleteProducto
DELIMITER //
CREATE PROCEDURE `DeleteProducto`(_sku VARCHAR(5), _estatus ENUM('Activo', 'Inactivo'))
BEGIN
  UPDATE producto SET Estatus = _estatus WHERE SKU = _sku;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.DeleteProveedor
DELIMITER //
CREATE PROCEDURE `DeleteProveedor`(_id CHAR(5), _estatus ENUM('Activo', 'Inactivo'))
BEGIN
  UPDATE proveedor SET Estatus = _estatus WHERE ID = _id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.DeleteTelefono_cliente
DELIMITER //
CREATE PROCEDURE `DeleteTelefono_cliente`(_id_cliente CHAR(5) ,_telefono CHAR(10))
BEGIN
  DELETE FROM telefono_cliente WHERE ID_cliente = _id_cliente AND Telefono = _telefono;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.DeleteUser
DELIMITER //
CREATE PROCEDURE `DeleteUser`(_id CHAR(5), _estatus ENUM('Activo', 'Inactivo'))
BEGIN
  UPDATE users SET Estatus = _estatus WHERE ID = _id;
END//
DELIMITER ;

-- Volcando estructura para tabla ventahardware.detalle_venta
CREATE TABLE IF NOT EXISTS `detalle_venta` (
  `Num_factura` int(11) NOT NULL,
  `SKU` varchar(10) NOT NULL,
  `Nombre_producto` varchar(100) NOT NULL,
  `Cantidad` int(11) NOT NULL DEFAULT 0,
  `Precio` double NOT NULL DEFAULT 0,
  `Importe` double NOT NULL DEFAULT 0,
  KEY `Num_factura` (`Num_factura`),
  KEY `SKU` (`SKU`),
  CONSTRAINT `detalle_venta_ibfk_1` FOREIGN KEY (`Num_factura`) REFERENCES `venta` (`Numero_factura`),
  CONSTRAINT `detalle_venta_ibfk_2` FOREIGN KEY (`SKU`) REFERENCES `producto` (`SKU`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ventahardware.detalle_venta: ~105 rows (aproximadamente)
/*!40000 ALTER TABLE `detalle_venta` DISABLE KEYS */;
INSERT INTO `detalle_venta` (`Num_factura`, `SKU`, `Nombre_producto`, `Cantidad`, `Precio`, `Importe`) VALUES
	(1, '1DFFG', 'Iphone 12', 3, 20000, 60000),
	(2, '1DFFG', 'Iphone 12', 4, 20000, 80000),
	(3, '09FGV', 'LENOVO', 5, 15000, 75000),
	(4, '2CS13', 'Asus', 2, 39000, 78000),
	(4, '67CVN', 'USB Kingston', 4, 150, 600),
	(4, 'J45DR', 'Audifonos Bose ', 1, 1400, 1400),
	(5, '2R46G', 'JBL', 2, 3100, 6200),
	(6, '09FGV', 'LENOVO', 2, 12400, 24800),
	(6, '67CVN', 'USB Kingston', 3, 150, 450),
	(6, '3RT9V', 'Beat', 3, 1500, 4500),
	(7, '4HV0N', 'Samsung Galaxy s7', 3, 6000, 18000),
	(8, '2VBNM', 'Xaomi Redmi Note 9', 3, 4100, 12300),
	(8, '2CS13', 'Asus', 4, 39000, 156000),
	(9, '4HV0N', 'Samsung Galaxy s7', 3, 6000, 18000),
	(9, 'J45DR', 'Audifonos Bose ', 2, 1400, 2800),
	(10, '2CS13', 'Asus', 3, 39000, 117000),
	(10, '2R46G', 'JBL', 2, 3100, 6200),
	(11, '2CS13', 'Asus', 20, 39000, 780000),
	(12, '1DFFG', 'Iphone 12', 25, 18000, 450000),
	(13, '2CS13', 'Asus', 3, 39000, 117000),
	(14, '4HV0N', 'Samsung Galaxy s7', 2, 6000, 12000),
	(15, '2CS13', 'Asus', 2, 39000, 78000),
	(16, '1234s', 'Toshiba', 2, 2000, 4000),
	(16, '09FGV', 'LENOVO', 2, 12400, 24800),
	(17, 'J45DR', 'Audifonos Bose ', 20, 1400, 28000),
	(17, '1234s', 'Toshiba', 4, 2000, 8000),
	(18, 'J45DR', 'Audifonos Bose ', 2, 1400, 2800),
	(18, '4HV0N', 'Samsung Galaxy s7', 2, 6000, 12000),
	(19, '09FGV', 'LENOVO', 2, 12400, 24800),
	(19, '3RT9V', 'Beat', 3, 1500, 4500),
	(20, '2CS13', 'Asus', 2, 39000, 78000),
	(20, '09FGV', 'LENOVO', 2, 12400, 24800),
	(21, '09FGV', 'LENOVO', 3, 12400, 37200),
	(21, '2CS13', 'Asus', 2, 39000, 78000),
	(22, '09FGV', 'LENOVO', 1, 12400, 12400),
	(23, '09FGV', 'LENOVO', 2, 12400, 24800),
	(24, '09FGV', 'LENOVO', 2, 12400, 24800),
	(25, '09FGV', 'LENOVO', 1, 12400, 12400),
	(26, '09FGV', 'LENOVO', 1, 12400, 12400),
	(27, '09FGV', 'LENOVO', 1, 12400, 12400),
	(28, '67CVN', 'USB Kingston', 1, 150, 150),
	(29, '67CVN', 'USB Kingston', 1, 150, 150),
	(30, '09FGV', 'LENOVO', 2, 12400, 24800),
	(30, '1234s', 'Toshiba', 3, 2000, 6000),
	(30, '2R46G', 'JBL', 2, 3100, 6200),
	(31, '09FGV', 'LENOVO', 2, 12400, 24800),
	(31, '4HV0N', 'Samsung Galaxy s7', 2, 6000, 12000),
	(32, '09FGV', 'LENOVO', 2, 12400, 24800),
	(32, '2R46G', 'JBL', 2, 3100, 6200),
	(33, '09FGV', 'LENOVO', 3, 12400, 37200),
	(33, '4HV0N', 'Samsung Galaxy s7', 2, 6000, 12000),
	(34, 'J45DR', 'Audifonos Bose ', 2, 1400, 2800),
	(35, '09FGV', 'LENOVO', 3, 12400, 37200),
	(35, '4HV0N', 'Samsung Galaxy s7', 2, 6000, 12000),
	(36, '09FGV', 'LENOVO', 2, 12400, 24800),
	(36, '4HV0N', 'Samsung Galaxy s7', 2, 6000, 12000),
	(37, '09FGV', 'LENOVO', 2, 12400, 24800),
	(38, '2R46G', 'JBL', 1, 3100, 3100),
	(39, '67CVN', 'USB Kingston', 1, 150, 150),
	(40, '67CVN', 'USB Kingston', 2, 150, 300),
	(41, '09FGV', 'LENOVO', 1, 12400, 12400),
	(41, '4HV0N', 'Samsung Galaxy s7', 2, 6000, 12000),
	(42, '09FGV', 'LENOVO', 3, 12400, 37200),
	(42, '4HV0N', 'Samsung Galaxy s7', 1, 6000, 6000),
	(43, '09FGV', 'LENOVO', 2, 12400, 24800),
	(43, '3RT9V', 'Beat', 2, 1500, 3000),
	(44, '67CVN', 'USB Kingston', 2, 150, 300),
	(44, '3RT9V', 'Beat', 2, 1500, 3000),
	(45, '09FGV', 'LENOVO', 2, 12400, 24800),
	(46, '4HV0N', 'Samsung Galaxy s7', 2, 6000, 12000),
	(46, '67CVN', 'USB Kingston', 2, 150, 300),
	(47, '3RT9V', 'Beat', 2, 1500, 3000),
	(48, '09FGV', 'LENOVO', 2, 12400, 24800),
	(49, '4HV0N', 'Samsung Galaxy s7', 1, 6000, 6000),
	(50, '09FGV', 'LENOVO', 1, 12400, 12400),
	(51, '09FGV', 'LENOVO', 2, 12400, 24800),
	(51, '3RT9V', 'Beat', 2, 1500, 3000),
	(52, '2CS13', 'Asus', 2, 39000, 78000),
	(53, '4HV0N', 'Samsung Galaxy s7', 2, 6000, 12000),
	(54, '09FGV', 'LENOVO', 2, 12400, 24800),
	(55, '09FGV', 'LENOVO', 2, 12400, 24800),
	(56, '3RT9V', 'Beat', 2, 1500, 3000),
	(57, '09FGV', 'LENOVO', 2, 12400, 24800),
	(58, '3RT9V', 'Beat', 2, 1500, 3000),
	(59, '09FGV', 'LENOVO', 2, 12400, 24800),
	(59, '2R46G', 'JBL', 1, 3100, 3100),
	(60, '4HV0N', 'Samsung Galaxy s7', 2, 6000, 12000),
	(61, '4HV0N', 'Samsung Galaxy s7', 2, 6000, 12000),
	(62, '2CS13', 'Asus', 2, 39000, 78000),
	(63, '2CS13', 'Asus', 2, 39000, 78000),
	(63, '2R46G', 'JBL', 1, 3100, 3100),
	(64, '2VBNM', 'Xaomi Redmi Note 9', 2, 4100, 8200),
	(64, '2R46G', 'JBL', 3, 3100, 9300),
	(64, 'J45DR', 'Audifonos Bose ', 3, 1400, 4200),
	(65, '67CVN', 'USB Kingston', 2, 150, 300),
	(66, '2R46G', 'JBL', 2, 3100, 6200),
	(66, '3RT9V', 'Beat', 2, 1500, 3000),
	(67, '2R46G', 'JBL', 3, 3100, 9300),
	(67, '3RT9V', 'Beat', 2, 1500, 3000),
	(68, '2R46G', 'JBL', 1, 3100, 3100),
	(69, 'p1', 'HP', 1, 100, 100),
	(70, '09FGV', 'LENOVO', 2, 12400, 24800),
	(71, '0345f', 'Oppo', 2, 3400, 6800),
	(72, '0345f', 'Oppo', 2, 3400, 6800),
	(73, '09FGV', 'LENOVO', 2, 12400, 24800),
	(74, '0345f', 'Oppo', 2, 3400, 6800),
	(75, '09FGV', 'LENOVO', 3, 12400, 37200),
	(76, '0345f', 'Oppo', 2, 3400, 6800),
	(76, '2CS13', 'Asus', 1, 39000, 39000),
	(76, '2R46G', 'JBL', 5, 3100, 15500),
	(77, '09FGV', 'LENOVO', 3, 12400, 37200),
	(78, '3RT9V', 'Beat', 3, 1500, 4500),
	(78, '67CVN', 'USB Kingston', 3, 150, 450),
	(79, '09FGV', 'LENOVO', 4, 12400, 49600),
	(80, '2R46G', 'JBL', 2, 3100, 6200),
	(81, '2R46G', 'JBL', 3, 3100, 9300),
	(82, '67CVN', 'USB Kingston', 2, 150, 300),
	(83, '2R46G', 'JBL', 1, 3100, 3100),
	(84, 'p1', 'HP', 2, 100, 200),
	(85, '09FGV', 'LENOVO', 5, 12400, 62000),
	(85, '3RT9V', 'Beat', 5, 1500, 7500),
	(86, 'p1', 'HP', 1, 100, 100),
	(87, '2R46G', 'JBL', 4, 3100, 12400),
	(88, '2VBNM', 'Xaomi Redmi Note 9', 2, 4100, 8200),
	(88, '2R46G', 'JBL', 5, 3100, 15500),
	(89, '3RT9V', 'Beat', 3, 1500, 4500),
	(90, '3RT9V', 'Beat', 2, 1500, 3000),
	(91, '2VBNM', 'Xaomi Redmi Note 9', 5, 4100, 20500),
	(91, '3RT9V', 'Beat', 2, 1500, 3000),
	(92, '4HV0N', 'Samsung Galaxy s7', 3, 6000, 18000),
	(92, '2R46G', 'JBL', 4, 3100, 12400),
	(92, 'o23jd', 'Ipad', 2, 17000, 34000),
	(93, '2R46G', 'JBL', 2, 3100, 6200);
/*!40000 ALTER TABLE `detalle_venta` ENABLE KEYS */;

-- Volcando estructura para procedimiento ventahardware.dgvBitacora
DELIMITER //
CREATE PROCEDURE `dgvBitacora`()
BEGIN
  SELECT * FROM bitacora;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.dgvCategorias
DELIMITER //
CREATE PROCEDURE `dgvCategorias`()
BEGIN
  SELECT * FROM categoria;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.dgvCliente
DELIMITER //
CREATE PROCEDURE `dgvCliente`()
BEGIN
  SELECT * FROM cliente;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.dgvCompras
DELIMITER //
CREATE PROCEDURE `dgvCompras`()
BEGIN
  SELECT * FROM detalle_venta;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.dgvCortes
DELIMITER //
CREATE PROCEDURE `dgvCortes`()
BEGIN
  SELECT * FROM corte_caja;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.dgvProductos
DELIMITER //
CREATE PROCEDURE `dgvProductos`()
BEGIN
  SELECT * FROM producto;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.dgvProveedores
DELIMITER //
CREATE PROCEDURE `dgvProveedores`()
BEGIN
  SELECT * FROM proveedor;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.dgvTelefono_cliente
DELIMITER //
CREATE PROCEDURE `dgvTelefono_cliente`()
BEGIN
  SELECT telefono_cliente.ID_cliente, cliente.Nombre, telefono_cliente.Telefono FROM telefono_cliente, cliente 
  WHERE cliente.ID = telefono_cliente.ID_cliente;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.dgvUsuarios
DELIMITER //
CREATE PROCEDURE `dgvUsuarios`()
BEGIN
  SELECT * FROM users;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.dgvVentas
DELIMITER //
CREATE PROCEDURE `dgvVentas`()
BEGIN
  SELECT * FROM venta;
END//
DELIMITER ;

-- Volcando estructura para tabla ventahardware.producto
CREATE TABLE IF NOT EXISTS `producto` (
  `SKU` varchar(5) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Stock` int(11) NOT NULL DEFAULT 0,
  `Precio` double NOT NULL,
  `Precio_Venta` double NOT NULL DEFAULT 0,
  `ID_categoria` int(11) NOT NULL DEFAULT 0,
  `ID_proveedor` char(5) NOT NULL,
  `Estatus` enum('Activo','Inactivo') NOT NULL,
  PRIMARY KEY (`SKU`),
  KEY `ID_categoria` (`ID_categoria`),
  KEY `ID_proveedor` (`ID_proveedor`),
  CONSTRAINT `producto_ibfk_1` FOREIGN KEY (`ID_categoria`) REFERENCES `categoria` (`ID`),
  CONSTRAINT `producto_ibfk_2` FOREIGN KEY (`ID_proveedor`) REFERENCES `proveedor` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ventahardware.producto: ~13 rows (aproximadamente)
/*!40000 ALTER TABLE `producto` DISABLE KEYS */;
INSERT INTO `producto` (`SKU`, `Nombre`, `Stock`, `Precio`, `Precio_Venta`, `ID_categoria`, `ID_proveedor`, `Estatus`) VALUES
	('0345f', 'Oppo', 27, 3400, 5000, 2, '00342', 'Inactivo'),
	('09FGV', 'LENOVO', 15, 12400, 15000, 2, '00342', 'Inactivo'),
	('1234s', 'Toshiba', 1, 2000, 4000, 1, '00342', 'Inactivo'),
	('1DFFG', 'Iphone 12', 0, 18000, 20000, 4, '39471', 'Inactivo'),
	('2CS13', 'Asus', 1, 39000, 45000, 2, '00342', 'Activo'),
	('2R46G', 'JBL', 34, 3100, 4000, 1, '32910', 'Activo'),
	('2VBNM', 'Xaomi Redmi Note 9', 25, 4100, 5400, 4, '00342', 'Activo'),
	('3RT9V', 'Beat', 63, 1500, 3000, 1, '32910', 'Activo'),
	('4HV0N', 'Samsung Galaxy s7', 67, 6000, 7000, 4, '39471', 'Activo'),
	('67CVN', 'USB Kingston', 47, 150, 250, 3, '00342', 'Activo'),
	('J45DR', 'Audifonos Bose ', 0, 1400, 2700, 1, '32910', 'Activo'),
	('o23jd', 'Ipad', 98, 17000, 20000, 1, '00342', 'Activo'),
	('p1', 'HP', 16, 100, 130, 2, '00342', 'Inactivo');
/*!40000 ALTER TABLE `producto` ENABLE KEYS */;

-- Volcando estructura para tabla ventahardware.proveedor
CREATE TABLE IF NOT EXISTS `proveedor` (
  `ID` char(5) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `RFC` varchar(10) NOT NULL,
  `Telefono` char(10) NOT NULL,
  `Direccion` varchar(100) NOT NULL,
  `Pagina_web` text NOT NULL,
  `Estatus` enum('Activo','Inactivo') NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ventahardware.proveedor: ~5 rows (aproximadamente)
/*!40000 ALTER TABLE `proveedor` DISABLE KEYS */;
INSERT INTO `proveedor` (`ID`, `Nombre`, `RFC`, `Telefono`, `Direccion`, `Pagina_web`, `Estatus`) VALUES
	('00342', 'VEMTEC', 'LFJD100348', '2883445674', 'MORELOS, CALLE 15 DE FEBRERO', 'www.VEMTEC.web', 'Activo'),
	('09887', 'Lania', 'RENTG34212', '2883975472', 'QUERETARO, AV. TECNOLOGICO', 'www.LANIA.web', 'Inactivo'),
	('32910', 'TecnoAUDIO', 'RTXC153927', '2881236745', 'CIUDAD JUARES, AV. INDEPENDENCIA', 'www.TecnoEUDIO.web', 'Inactivo'),
	('39471', 'ServicesTEC', 'FGJK400294', '2882323456', 'VERACRUZ, AV. CENTRO', 'www.ServicesTEC.web', 'Activo'),
	('89123', 'Fedex', 'LFXC100348', '2881123455', 'COSAMALOAPAN. AV. PARQUE', 'www.Fedex.web', 'Activo');
/*!40000 ALTER TABLE `proveedor` ENABLE KEYS */;

-- Volcando estructura para tabla ventahardware.telefono_cliente
CREATE TABLE IF NOT EXISTS `telefono_cliente` (
  `ID_cliente` char(5) NOT NULL,
  `Telefono` char(10) NOT NULL,
  KEY `ID_cliente` (`ID_cliente`),
  CONSTRAINT `telefono_cliente_ibfk_1` FOREIGN KEY (`ID_cliente`) REFERENCES `cliente` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ventahardware.telefono_cliente: ~7 rows (aproximadamente)
/*!40000 ALTER TABLE `telefono_cliente` DISABLE KEYS */;
INSERT INTO `telefono_cliente` (`ID_cliente`, `Telefono`) VALUES
	('43579', '2881273456'),
	('90123', '2882743456'),
	('90123', '3248900124'),
	('01783', '2881394040'),
	('01783', '4425940603'),
	('01783', '4423742129'),
	('01531', '2881243311'),
	('01531', '2881213212'),
	('90123', '2212441155');
/*!40000 ALTER TABLE `telefono_cliente` ENABLE KEYS */;

-- Volcando estructura para procedimiento ventahardware.UpdateCategoria
DELIMITER //
CREATE PROCEDURE `UpdateCategoria`(_Id INT, _nombre VARCHAR(100), _descripcion TEXT)
BEGIN
  UPDATE categoria SET Nombre = _nombre, Descripcion = _descripcion WHERE ID = _Id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.UpdateCliente
DELIMITER //
CREATE PROCEDURE `UpdateCliente`(_id CHAR(5), _nombre VARCHAR(100), _email VARCHAR(100), _cp CHAR(5), _ciudad VARCHAR(100), _comuna VARCHAR(100),_calle VARCHAR(100), _numero INT)
BEGIN
  UPDATE cliente 
  SET Nombre = _nombre, Email = _email, CP = _cp, 
  Ciudad = _ciudad, Comuna = _comuna, Calle = _calle, Numero = _numero 
  WHERE ID = _id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.UpdateContraseña
DELIMITER //
CREATE PROCEDURE `UpdateContraseña`(_id CHAR(5), _contraseña VARCHAR(30))
BEGIN
  UPDATE users SET Contraseña = _contraseña WHERE ID = _id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.UpdateProducto
DELIMITER //
CREATE PROCEDURE `UpdateProducto`(_sku VARCHAR(5), _nombre VARCHAR(100), _stock INT, _precio DOUBLE, _precio_venta DOUBLE, _id_categoria INT, _id_proveedor CHAR(5))
BEGIN
  UPDATE producto SET Nombre = _nombre, Stock = _stock, Precio = _precio, Precio_Venta = _precio_venta, ID_categoria = _id_categoria, ID_proveedor = _id_proveedor WHERE SKU = _sku;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.UpdateProveedor
DELIMITER //
CREATE PROCEDURE `UpdateProveedor`(_id CHAR(5), _nombre VARCHAR(100), _rfc VARCHAR(10), _telefono CHAR(10), _direccion VARCHAR(100), _pagina_web TEXT)
BEGIN
  UPDATE proveedor SET Nombre = _nombre, RFC = _rfc, Telefono = _telefono, Direccion = _direccion, Pagina_web = _pagina_web WHERE ID = _id;
END//
DELIMITER ;

-- Volcando estructura para procedimiento ventahardware.UpdateUser
DELIMITER //
CREATE PROCEDURE `UpdateUser`(
	IN `_id` CHAR(5),
	IN `_usuario` VARCHAR(50),
	IN `_rol` ENUM('SuperAdmin','Administrador', 'Vendedor'),
	IN `_contraseña` VARCHAR(30)
)
BEGIN
  UPDATE users SET Usuario = _usuario, Rol_usuario = _rol, Contraseña = _contraseña WHERE ID = _id;
END//
DELIMITER ;

-- Volcando estructura para tabla ventahardware.users
CREATE TABLE IF NOT EXISTS `users` (
  `ID` char(5) NOT NULL,
  `Usuario` varchar(50) NOT NULL,
  `Rol_usuario` enum('SuperAdmin','Administrador','Vendedor') NOT NULL,
  `Contraseña` varchar(30) NOT NULL,
  `Estatus` enum('Activo','Inactivo') NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ventahardware.users: ~6 rows (aproximadamente)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`ID`, `Usuario`, `Rol_usuario`, `Contraseña`, `Estatus`) VALUES
	('00001', 'Zacarias', 'Administrador', '123.zxc', 'Activo'),
	('00002', 'Amador', 'Vendedor', '019', 'Activo'),
	('00003', 'Alejandro', 'SuperAdmin', '123.zxc', 'Activo'),
	('00004', 'Robert', 'Vendedor', '234', 'Activo'),
	('00007', 'Angel', 'SuperAdmin', '123.zxc', 'Activo'),
	('00009', 'Zacarias', 'Vendedor', '132', 'Activo');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

-- Volcando estructura para tabla ventahardware.venta
CREATE TABLE IF NOT EXISTS `venta` (
  `Numero_factura` int(11) NOT NULL AUTO_INCREMENT,
  `Fecha` datetime NOT NULL,
  `ID_cliente` char(5) NOT NULL,
  `ID_usuario` char(5) NOT NULL,
  `Monto_final` double DEFAULT 0,
  PRIMARY KEY (`Numero_factura`),
  KEY `ID_cliente` (`ID_cliente`),
  KEY `ID_usuario` (`ID_usuario`),
  CONSTRAINT `venta_ibfk_1` FOREIGN KEY (`ID_cliente`) REFERENCES `cliente` (`ID`),
  CONSTRAINT `venta_ibfk_2` FOREIGN KEY (`ID_usuario`) REFERENCES `users` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=94 DEFAULT CHARSET=utf8mb3;

-- Volcando datos para la tabla ventahardware.venta: ~90 rows (aproximadamente)
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
INSERT INTO `venta` (`Numero_factura`, `Fecha`, `ID_cliente`, `ID_usuario`, `Monto_final`) VALUES
	(1, '2022-12-08 11:40:37', '01783', '00003', 74800),
	(2, '2022-12-08 11:51:39', '01531', '00003', 80000),
	(3, '2022-12-08 11:53:09', '01783', '00003', 75000),
	(4, '2022-12-08 13:56:48', '01531', '00003', 80000),
	(5, '2022-12-08 14:11:34', '01783', '00003', 6200),
	(6, '2022-12-08 14:21:29', '01531', '00003', 29750),
	(7, '2022-12-08 14:26:51', '43579', '00003', 18000),
	(8, '2022-12-08 14:59:43', '43579', '00001', 168300),
	(9, '2022-12-08 15:44:57', '01783', '00003', 20800),
	(10, '2022-12-08 18:20:03', '01783', '00003', 123200),
	(11, '2022-12-08 18:23:44', '01783', '00003', 780000),
	(12, '2022-12-08 18:26:18', '90123', '00003', 450000),
	(13, '2022-12-09 13:35:46', '01531', '00003', 117000),
	(14, '2022-12-09 23:52:08', '43579', '00003', 12000),
	(15, '2022-12-09 23:52:48', '43579', '00003', 78000),
	(16, '2022-12-09 23:54:47', '43579', '00003', 28800),
	(17, '2022-12-10 22:09:19', '90123', '00003', 36000),
	(18, '2022-12-11 21:13:13', '01783', '00003', 14800),
	(19, '2022-12-11 21:14:55', '90123', '00003', 29300),
	(20, '2022-12-11 21:33:48', '90123', '00003', 102800),
	(21, '2022-12-11 21:34:14', '01531', '00003', 115200),
	(22, '2022-12-11 21:35:07', '01783', '00003', 12400),
	(23, '2022-12-11 21:40:37', '01783', '00003', 24800),
	(24, '2022-12-11 21:41:08', '43579', '00003', 24800),
	(25, '2022-12-11 21:48:31', '01783', '00003', 12400),
	(26, '2022-12-11 21:48:44', '01531', '00003', 12400),
	(27, '2022-12-11 21:49:23', '43579', '00003', 12400),
	(28, '2022-12-11 21:54:51', '01531', '00003', 150),
	(29, '2022-12-11 21:55:11', '90123', '00003', 150),
	(30, '2022-12-11 23:35:32', '01783', '00003', 37000),
	(31, '2022-12-12 00:02:12', '01783', '00001', 36800),
	(32, '2022-12-12 01:51:50', '01531', '00002', 31000),
	(33, '2022-12-12 01:52:34', '43579', '00002', 49200),
	(34, '2022-12-12 01:53:50', '90123', '00002', 2800),
	(35, '2022-12-12 02:05:15', '01783', '00003', 49200),
	(36, '2022-12-12 02:05:39', '90123', '00003', 36800),
	(37, '2022-12-12 02:10:36', '01531', '00003', 24800),
	(38, '2022-12-12 02:11:07', '43579', '00003', 3100),
	(39, '2022-12-12 02:13:34', '01783', '00001', 150),
	(40, '2022-12-12 02:13:54', '01783', '00001', 300),
	(41, '2022-12-12 15:58:34', '01531', '00003', 24400),
	(42, '2022-12-12 16:15:31', '01783', '00003', 43200),
	(43, '2022-12-12 16:15:57', '01783', '00003', 27800),
	(44, '2022-12-12 16:22:42', '01531', '00004', 3300),
	(45, '2022-12-12 16:22:58', '43579', '00004', 24800),
	(46, '2022-12-12 16:27:02', '90123', '00002', 12300),
	(47, '2022-12-12 16:27:15', '43579', '00002', 3000),
	(48, '2022-12-12 16:32:43', '01531', '00001', 24800),
	(49, '2022-12-12 16:32:56', '90123', '00001', 6000),
	(50, '2022-12-12 17:29:14', '01531', '00003', 12400),
	(51, '2022-12-12 18:17:56', '01531', '00003', 27800),
	(52, '2022-12-12 18:18:15', '43579', '00003', 78000),
	(53, '2022-12-12 18:25:17', '01531', '00003', 12000),
	(54, '2022-12-12 18:25:29', '43579', '00003', 24800),
	(55, '2022-12-12 18:32:15', '01531', '00001', 24800),
	(56, '2022-12-12 18:32:54', '43579', '00001', 3000),
	(57, '2022-12-12 18:35:10', '01783', '00003', 24800),
	(58, '2022-12-12 18:35:23', '90123', '00003', 3000),
	(59, '2022-12-13 00:18:16', '01531', '00003', 27900),
	(60, '2022-12-13 00:18:38', '43579', '00003', 12000),
	(61, '2022-12-13 14:10:51', '01783', '00001', 12000),
	(62, '2022-12-13 14:21:00', '01783', '00001', 78000),
	(63, '2022-12-13 14:29:44', '01783', '00001', 81100),
	(64, '2022-12-13 14:51:38', '90123', '00001', 21700),
	(65, '2022-12-13 14:52:09', '01783', '00001', 300),
	(66, '2022-12-14 01:55:03', '01783', '00003', 9200),
	(67, '2022-12-14 02:00:07', '01531', '00001', 12300),
	(68, '2022-12-14 02:03:03', '43579', '00001', 3100),
	(69, '2022-12-14 02:03:16', '90123', '00001', 100),
	(70, '2022-12-14 02:16:00', '43579', '00003', 24800),
	(71, '2022-12-14 02:16:37', '90123', '00003', 6800),
	(72, '2022-12-14 02:24:23', '43579', '00003', 6800),
	(73, '2022-12-14 02:24:36', '90123', '00003', 24800),
	(74, '2022-12-14 02:25:28', '43579', '00003', 6800),
	(75, '2022-12-14 02:31:57', '43579', '00003', 37200),
	(76, '2022-12-14 02:37:55', '43579', '00003', 61300),
	(77, '2022-12-14 02:38:14', '01531', '00003', 37200),
	(78, '2022-12-14 08:23:26', '43579', '00001', 4950),
	(79, '2022-12-14 08:23:53', '43579', '00001', 49600),
	(80, '2022-12-14 08:31:38', '01783', '00003', 6200),
	(81, '2022-12-14 08:33:02', '01531', '00003', 9300),
	(82, '2022-12-14 08:34:04', '01531', '00003', 300),
	(83, '2022-12-14 08:38:52', '43579', '00003', 3100),
	(84, '2022-12-14 08:39:09', '43579', '00003', 200),
	(85, '2022-12-14 10:32:17', '01531', '00003', 69500),
	(86, '2022-12-14 10:32:30', '43579', '00003', 100),
	(87, '2022-12-14 10:33:30', '90123', '00003', 12400),
	(88, '2022-12-28 11:39:36', '43579', '00003', 23700),
	(89, '2022-12-28 11:40:06', '01531', '00003', 4500),
	(90, '2022-12-28 11:40:43', '90123', '00003', 3000),
	(91, '2023-01-12 18:59:12', '01531', '00001', 23500),
	(92, '2023-01-12 19:13:35', '43579', '00003', 64400),
	(93, '2023-01-12 19:46:48', '01783', '00001', 6200);
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;

-- Volcando estructura para disparador ventahardware.update_stock
SET @OLDTMP_SQL_MODE=@@SQL_MODE, SQL_MODE='STRICT_TRANS_TABLES,ERROR_FOR_DIVISION_BY_ZERO,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION';
DELIMITER //
CREATE TRIGGER update_stock AFTER INSERT ON detalle_venta FOR EACH ROW 
BEGIN
  DECLARE stock_temp INT;
  SET stock_temp = (SELECT Stock FROM producto WHERE SKU = NEW.SKU) - NEW.Cantidad;
  if (stock_temp >= 0) then
  UPDATE producto SET Stock = stock_temp WHERE SKU = NEW.SKU;
  END if;
END//
DELIMITER ;
SET SQL_MODE=@OLDTMP_SQL_MODE;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
