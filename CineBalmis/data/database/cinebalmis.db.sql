BEGIN TRANSACTION;
DROP TABLE IF EXISTS "sesiones";
CREATE TABLE IF NOT EXISTS "sesiones" (
	"idSesion"	INTEGER,
	"pelicula"	INTEGER,
	"sala"	INTEGER,
	"hora"	TEXT,
	FOREIGN KEY("sala") REFERENCES "salas"("idSala"),
	FOREIGN KEY("pelicula") REFERENCES "peliculas"("idPelicula"),
	PRIMARY KEY("idSesion" AUTOINCREMENT)
);
DROP TABLE IF EXISTS "ventas";
CREATE TABLE IF NOT EXISTS "ventas" (
	"idVenta"	INTEGER,
	"sesion"	INTEGER,
	"cantidad"	INTEGER,
	"pago"	TEXT,
	FOREIGN KEY("sesion") REFERENCES "sesiones"("idSesion"),
	PRIMARY KEY("idVenta" AUTOINCREMENT)
);
DROP TABLE IF EXISTS "salas";
CREATE TABLE IF NOT EXISTS "salas" (
	"idSala"	INTEGER,
	"numero"	TEXT,
	"capacidad"	INTEGER,
	"disponible"	BOOLEAN DEFAULT (true),
	PRIMARY KEY("idSala" AUTOINCREMENT)
);
DROP TABLE IF EXISTS "peliculas";
CREATE TABLE IF NOT EXISTS "peliculas" (
	"idPelicula"	INTEGER,
	"titulo"	TEXT,
	"cartel"	TEXT,
	"año"	INTEGER,
	"genero"	TEXT,
	"calificacion"	TEXT,
	PRIMARY KEY("idPelicula")
);
INSERT INTO peliculas VALUES(null, "El indomable Will Hunting", "../../../assets/carteles/El_Indomable_Will_Hunting.jpg", 1997, "Drama", "APTA_TP");
INSERT INTO peliculas VALUES(null, "Buscando a Nemo", "../../../assets/carteles/Buscando_A_Nemo.jpg", 2003, "Animación", "APTA_TP");
INSERT INTO peliculas VALUES(null, "Oppenheimer", "../../../assets/carteles/Oppenheimer.jpg", 2023, "Thriller", "NRM_12");
INSERT INTO peliculas VALUES(null, "El resplandor", "../../../assets/carteles/El_Resplandor.png", 1980, "Terror", "NRM_16");
INSERT INTO peliculas VALUES(null, "Rocky", "../../../assets/carteles/Rocky.jpg", 1976, "Acción", "NRM_18");
INSERT INTO peliculas VALUES(null, "Borat", "../../../assets/carteles/Borat.jpg", 2006, "Comedia", "NRM_12");
INSERT INTO salas VALUES (null, "1", 120, True);
INSERT INTO salas VALUES (null, "2", 120, True);
INSERT INTO salas VALUES (null, "3", 60, True);
INSERT INTO salas VALUES (null, "4", 60, True);
INSERT INTO sesiones VALUES (null, 4, 1, "17:00");
INSERT INTO sesiones VALUES (null, 2, 1, "20:00");
INSERT INTO sesiones VALUES (null, 4, 1, "22:30");
UPDATE salas SET disponible = False WHERE idSala = 1;
COMMIT;
