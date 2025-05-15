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

TRUNCATE TABLE Localidades;
INSERT INTO Localidades (Nombre, DepartamentoID) VALUES
('Montevideo', (SELECT ID FROM Departamentos WHERE Nombre='Montevideo')),
('Las Piedras', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Pando', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Maldonado', (SELECT ID FROM Departamentos WHERE Nombre='Maldonado')),
('Punta del Este', (SELECT ID FROM Departamentos WHERE Nombre='Maldonado')),
('Colonia del Sacramento', (SELECT ID FROM Departamentos WHERE Nombre='Colonia')),
('Mercedes', (SELECT ID FROM Departamentos WHERE Nombre='Soriano')),
('Trinidad', (SELECT ID FROM Departamentos WHERE Nombre='Flores')),
('Durazno', (SELECT ID FROM Departamentos WHERE Nombre='Durazno')),
('Salto', (SELECT ID FROM Departamentos WHERE Nombre='Salto')),
('Paysandú', (SELECT ID FROM Departamentos WHERE Nombre='Paysandú')),
('Tacuarembó', (SELECT ID FROM Departamentos WHERE Nombre='Tacuarembó')),
('Rivera', (SELECT ID FROM Departamentos WHERE Nombre='Rivera')),
('Melo', (SELECT ID FROM Departamentos WHERE Nombre='Cerro Largo')),
('Treinta y Tres', (SELECT ID FROM Departamentos WHERE Nombre='Treinta y Tres')),
('Minas', (SELECT ID FROM Departamentos WHERE Nombre='Lavalleja')),
('Florida', (SELECT ID FROM Departamentos WHERE Nombre='Florida')),
('Rocha', (SELECT ID FROM Departamentos WHERE Nombre='Rocha')),
('San José de Mayo', (SELECT ID FROM Departamentos WHERE Nombre='San José')),
('Artigas', (SELECT ID FROM Departamentos WHERE Nombre='Artigas')),
('Fray Bentos', (SELECT ID FROM Departamentos WHERE Nombre='Río Negro')),
('Bella Unión', (SELECT ID FROM Departamentos WHERE Nombre='Artigas')),
('Young', (SELECT ID FROM Departamentos WHERE Nombre='Río Negro')),
('Dolores', (SELECT ID FROM Departamentos WHERE Nombre='Soriano')),
('Carmelo', (SELECT ID FROM Departamentos WHERE Nombre='Colonia')),
('Nueva Helvecia', (SELECT ID FROM Departamentos WHERE Nombre='Colonia')),
('Libertad', (SELECT ID FROM Departamentos WHERE Nombre='San José')),
('Rosario', (SELECT ID FROM Departamentos WHERE Nombre='Colonia')),
('Nueva Palmira', (SELECT ID FROM Departamentos WHERE Nombre='Colonia')),
('Chuy', (SELECT ID FROM Departamentos WHERE Nombre='Rocha')),
('Piriápolis', (SELECT ID FROM Departamentos WHERE Nombre='Maldonado')),
('Salinas', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Parque del Plata', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Lascano', (SELECT ID FROM Departamentos WHERE Nombre='Rocha')),
('Castillos', (SELECT ID FROM Departamentos WHERE Nombre='Rocha')),
('Tranqueras', (SELECT ID FROM Departamentos WHERE Nombre='Rivera')),
('Sarandí del Yí', (SELECT ID FROM Departamentos WHERE Nombre='Durazno')),
('San Ramón', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Tarariras', (SELECT ID FROM Departamentos WHERE Nombre='Colonia')),
('Paso de los Toros', (SELECT ID FROM Departamentos WHERE Nombre='Tacuarembó')),
('Juan Lacaze', (SELECT ID FROM Departamentos WHERE Nombre='Colonia')),
('San Carlos', (SELECT ID FROM Departamentos WHERE Nombre='Maldonado')),
('Ciudad del Plata', (SELECT ID FROM Departamentos WHERE Nombre='San José')),
('Barros Blancos', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('La Paz', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Canelones', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Santa Lucía', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Progreso', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Paso de Carrasco', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Río Branco', (SELECT ID FROM Departamentos WHERE Nombre='Cerro Largo')),
('Aguas Corrientes', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Atlántida', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Sauce', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Toledo', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Migues', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('San Bautista', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('San Luis', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Dr. Francisco Soca', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Montes', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('La Floresta', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('San Antonio', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Villa San José', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Villa Felicidad', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Juanicó', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Castellanos', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Jaureguiberry', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Santa Ana', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Los Titanes', (SELECT ID FROM Departamentos WHERE Nombre='Canelones')),
('Araminda', (SELECT ID FROM Departamentos WHERE Nombre='Canelones'));

TRUNCATE TABLE Departamentos;

INSERT INTO Departamentos (Nombre, PaisID) VALUES
('Montevideo', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Canelones', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Maldonado', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Colonia', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Soriano', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Flores', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Durazno', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Salto', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Paysandú', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Tacuarembó', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Rivera', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Cerro Largo', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Treinta y Tres', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Lavalleja', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Florida', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Rocha', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('San José', (SELECT ID FROM Paises WHERE Nombre='Uruguay')),
('Artigas', (SELECT ID FROM Paises WHERE Nombre='Uruguay'));

TRUNCATE TABLE Paises;

INSERT INTO Paises (Nombre) VALUES 
('Afganistán'), ('Albania'), ('Alemania'), ('Andorra'), ('Angola'), ('Antigua y Barbuda'), ('Arabia Saudita'), ('Argelia'), ('Argentina'), ('Armenia'), ('Australia'), ('Austria'), ('Azerbaiyán'), ('Bahamas'), ('Bangladés'), ('Barbados'), ('Baréin'), ('Bélgica'), ('Belice'), ('Benín'), ('Bielorrusia'), ('Birmania'), ('Bolivia'), ('Bosnia y Herzegovina'), ('Botsuana'), ('Brasil'), ('Brunéi'), ('Bulgaria'), ('Burkina Faso'), ('Burundi'), ('Bután'), ('Cabo Verde'), ('Camboya'), ('Camerún'), ('Canadá'), ('Catar'), ('Chad'), ('Chile'), ('China'), ('Chipre'), ('Colombia'), ('Comoras'), ('Corea del Norte'), ('Corea del Sur'), ('Costa de Marfil'), ('Costa Rica'), ('Croacia'), ('Cuba'), ('Dinamarca'), ('Dominica'), ('Ecuador'), ('Egipto'), ('El Salvador'), ('Emiratos Árabes Unidos'), ('Eritrea'), ('Eslovaquia'), ('Eslovenia'), ('España'), ('Estados Unidos'), ('Estonia'), ('Etiopía'), ('Filipinas'), ('Finlandia'), ('Fiyi'), ('Francia'), ('Gabón'), ('Gambia'), ('Georgia'), ('Ghana'), ('Granada'), ('Grecia'), ('Guatemala'), ('Guinea'), ('Guinea-Bisáu'), ('Guinea Ecuatorial'), ('Guyana'), ('Haití'), ('Honduras'), ('Hungría'), ('India'), ('Indonesia'), ('Irak'), ('Irán'), ('Irlanda'), ('Islandia'), ('Israel'), ('Italia'), ('Jamaica'), ('Japón'), ('Jordania'), ('Kazajistán'), ('Kenia'), ('Kirguistán'), ('Kiribati'), ('Kuwait'), ('Laos'), ('Lesoto'), ('Letonia'), ('Líbano'), ('Liberia'), ('Libia'), ('Liechtenstein'), ('Lituania'), ('Luxemburgo'), ('Madagascar'), ('Malasia'), ('Malaui'), ('Maldivas'), ('Malí'), ('Malta'), ('Marruecos'), ('Mauricio'), ('Mauritania'), ('México'), ('Micronesia'), ('Moldavia'), ('Mónaco'), ('Mongolia'), ('Montenegro'), ('Mozambique'), ('Namibia'), ('Nauru'), ('Nepal'), ('Nicaragua'), ('Níger'), ('Nigeria'), ('Noruega'), ('Nueva Zelanda'), ('Omán'), ('Países Bajos'), ('Pakistán'), ('Palaos'), ('Panamá'), ('Papúa Nueva Guinea'), ('Paraguay'), ('Perú'), ('Polonia'), ('Portugal'), ('Reino Unido'), ('República Centroafricana'), ('República Checa'), ('República del Congo'), ('República Democrática del Congo'), ('República Dominicana'), ('Ruanda'), ('Rumania'), ('Rusia'), ('Samoa'), ('San Cristóbal y Nieves'), ('San Marino'), ('San Vicente y las Granadinas'), ('Santa Lucía'), ('Santo Tomé y Príncipe'), ('Senegal'), ('Serbia'), ('Seychelles'), ('Sierra Leona'), ('Singapur'), ('Siria'), ('Somalia'), ('Sri Lanka'), ('Sudáfrica'), ('Sudán'), ('Sudán del Sur'), ('Suecia'), ('Suiza'), ('Surinam'), ('Tailandia'), ('Tanzania'), ('Tayikistán'), ('Timor Oriental'), ('Togo'), ('Tonga'), ('Trinidad y Tobago'), ('Túnez'), ('Turkmenistán'), ('Turquía'), ('Tuvalu'), ('Ucrania'), ('Uganda'), ('Uruguay'), ('Uzbekistán'), ('Vanuatu'), ('Vaticano'), ('Venezuela'), ('Vietnam'), ('Yemen'), ('Yibuti'), ('Zambia'), ('Zimbabue');