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
COMMIT;
