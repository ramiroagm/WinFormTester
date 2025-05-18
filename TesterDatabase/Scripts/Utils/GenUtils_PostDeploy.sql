/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- PARA DIRECCIONES
TRUNCATE TABLE Localidades;
TRUNCATE TABLE Departamentos;
TRUNCATE TABLE Paises;

INSERT INTO Paises (Nombre) VALUES 
('Afganistán'), ('Albania'), ('Alemania'), ('Andorra'), ('Angola'), ('Antigua y Barbuda'), ('Arabia Saudita'), ('Argelia'), ('Argentina'), ('Armenia'), ('Australia'), ('Austria'), ('Azerbaiyán'), ('Bahamas'), ('Bangladés'), ('Barbados'), ('Baréin'), ('Bélgica'), ('Belice'), ('Benín'), ('Bielorrusia'), ('Birmania'), ('Bolivia'), ('Bosnia y Herzegovina'), ('Botsuana'), ('Brasil'), ('Brunéi'), ('Bulgaria'), ('Burkina Faso'), ('Burundi'), ('Bután'), ('Cabo Verde'), ('Camboya'), ('Camerún'), ('Canadá'), ('Catar'), ('Chad'), ('Chile'), ('China'), ('Chipre'), ('Colombia'), ('Comoras'), ('Corea del Norte'), ('Corea del Sur'), ('Costa de Marfil'), ('Costa Rica'), ('Croacia'), ('Cuba'), ('Dinamarca'), ('Dominica'), ('Ecuador'), ('Egipto'), ('El Salvador'), ('Emiratos Árabes Unidos'), ('Eritrea'), ('Eslovaquia'), ('Eslovenia'), ('España'), ('Estados Unidos'), ('Estonia'), ('Etiopía'), ('Filipinas'), ('Finlandia'), ('Fiyi'), ('Francia'), ('Gabón'), ('Gambia'), ('Georgia'), ('Ghana'), ('Granada'), ('Grecia'), ('Guatemala'), ('Guinea'), ('Guinea-Bisáu'), ('Guinea Ecuatorial'), ('Guyana'), ('Haití'), ('Honduras'), ('Hungría'), ('India'), ('Indonesia'), ('Irak'), ('Irán'), ('Irlanda'), ('Islandia'), ('Israel'), ('Italia'), ('Jamaica'), ('Japón'), ('Jordania'), ('Kazajistán'), ('Kenia'), ('Kirguistán'), ('Kiribati'), ('Kuwait'), ('Laos'), ('Lesoto'), ('Letonia'), ('Líbano'), ('Liberia'), ('Libia'), ('Liechtenstein'), ('Lituania'), ('Luxemburgo'), ('Madagascar'), ('Malasia'), ('Malaui'), ('Maldivas'), ('Malí'), ('Malta'), ('Marruecos'), ('Mauricio'), ('Mauritania'), ('México'), ('Micronesia'), ('Moldavia'), ('Mónaco'), ('Mongolia'), ('Montenegro'), ('Mozambique'), ('Namibia'), ('Nauru'), ('Nepal'), ('Nicaragua'), ('Níger'), ('Nigeria'), ('Noruega'), ('Nueva Zelanda'), ('Omán'), ('Países Bajos'), ('Pakistán'), ('Palaos'), ('Panamá'), ('Papúa Nueva Guinea'), ('Paraguay'), ('Perú'), ('Polonia'), ('Portugal'), ('Reino Unido'), ('República Centroafricana'), ('República Checa'), ('República del Congo'), ('República Democrática del Congo'), ('República Dominicana'), ('Ruanda'), ('Rumania'), ('Rusia'), ('Samoa'), ('San Cristóbal y Nieves'), ('San Marino'), ('San Vicente y las Granadinas'), ('Santa Lucía'), ('Santo Tomé y Príncipe'), ('Senegal'), ('Serbia'), ('Seychelles'), ('Sierra Leona'), ('Singapur'), ('Siria'), ('Somalia'), ('Sri Lanka'), ('Sudáfrica'), ('Sudán'), ('Sudán del Sur'), ('Suecia'), ('Suiza'), ('Surinam'), ('Tailandia'), ('Tanzania'), ('Tayikistán'), ('Timor Oriental'), ('Togo'), ('Tonga'), ('Trinidad y Tobago'), ('Túnez'), ('Turkmenistán'), ('Turquía'), ('Tuvalu'), ('Ucrania'), ('Uganda'), ('Uruguay'), ('Uzbekistán'), ('Vanuatu'), ('Vaticano'), ('Venezuela'), ('Vietnam'), ('Yemen'), ('Yibuti'), ('Zambia'), ('Zimbabue');

INSERT INTO Departamentos (Nombre, IdPais) VALUES
('Montevideo', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Canelones', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Maldonado', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Colonia', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Soriano', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Flores', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Durazno', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Salto', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Paysandú', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Tacuarembó', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Rivera', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Cerro Largo', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Treinta y Tres', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Lavalleja', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Florida', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Rocha', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('San José', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Artigas', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay')),
('Río Negro', (SELECT IdPais FROM Paises WHERE Nombre='Uruguay'));

INSERT INTO Localidades (Nombre, IdDepartamento) VALUES
('Montevideo', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Montevideo')),
('Las Piedras', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Pando', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Maldonado', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Maldonado')),
('Punta del Este', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Maldonado')),
('Colonia del Sacramento', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Colonia')),
('Mercedes', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Soriano')),
('Trinidad', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Flores')),
('Durazno', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Durazno')),
('Salto', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Salto')),
('Paysandú', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Paysandú')),
('Tacuarembó', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Tacuarembó')),
('Rivera', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Rivera')),
('Melo', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Cerro Largo')),
('Treinta y Tres', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Treinta y Tres')),
('Minas', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Lavalleja')),
('Florida', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Florida')),
('Rocha', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Rocha')),
('San José de Mayo', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='San José')),
('Artigas', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Artigas')),
('Fray Bentos', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Río Negro')),
('Bella Unión', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Artigas')),
('Young', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Río Negro')),
('Dolores', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Soriano')),
('Carmelo', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Colonia')),
('Nueva Helvecia', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Colonia')),
('Libertad', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='San José')),
('Rosario', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Colonia')),
('Nueva Palmira', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Colonia')),
('Chuy', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Rocha')),
('Piriápolis', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Maldonado')),
('Salinas', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Parque del Plata', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Lascano', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Rocha')),
('Castillos', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Rocha')),
('Tranqueras', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Rivera')),
('Sarandí del Yí', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Durazno')),
('San Ramón', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Tarariras', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Colonia')),
('Paso de los Toros', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Tacuarembó')),
('Juan Lacaze', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Colonia')),
('San Carlos', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Maldonado')),
('Ciudad del Plata', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='San José')),
('Barros Blancos', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('La Paz', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Canelones', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Santa Lucía', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Progreso', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Paso de Carrasco', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Río Branco', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Cerro Largo')),
('Aguas Corrientes', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Atlántida', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Sauce', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Toledo', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Migues', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('San Bautista', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('San Luis', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Dr. Francisco Soca', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Montes', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('La Floresta', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('San Antonio', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Villa San José', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Villa Felicidad', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Juanicó', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Castellanos', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Jaureguiberry', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Santa Ana', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Los Titanes', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones')),
('Araminda', (SELECT IdDepartamento FROM Departamentos WHERE Nombre='Canelones'));

-- PARA RELACIONES
INSERT INTO Relacion (Nombre) VALUES 
('Amigos'), ('Compañeros'), ('Familia'), ('Novios');