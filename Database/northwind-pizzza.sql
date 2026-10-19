BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "AppSettings" (
	"SettingId"	INTEGER,
	"SettingKey"	TEXT NOT NULL,
	"SettingValue"	TEXT,
	PRIMARY KEY("SettingId")
);
CREATE TABLE IF NOT EXISTS "Customers" (
	"CustomerId"	INTEGER,
	"FirstName"	TEXT NOT NULL,
	"LastName"	TEXT NOT NULL,
	"Email"	TEXT NOT NULL,
	"Phone"	TEXT,
	"CreatedAt"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	PRIMARY KEY("CustomerId")
);
CREATE TABLE IF NOT EXISTS "Employees" (
	"EmployeeId"	INTEGER,
	"FirstName"	TEXT NOT NULL,
	"LastName"	TEXT NOT NULL,
	"Email"	TEXT NOT NULL,
	"Role"	TEXT NOT NULL DEFAULT 'Employee',
	"IsActive"	INTEGER NOT NULL DEFAULT 1 CHECK("IsActive" IN (0, 1)),
	PRIMARY KEY("EmployeeId")
);
CREATE TABLE IF NOT EXISTS "OrderItems" (
	"OrderItemId"	INTEGER,
	"OrderId"	INTEGER NOT NULL,
	"PizzaId"	INTEGER NOT NULL,
	"Quantity"	INTEGER NOT NULL CHECK("Quantity" > 0),
	"UnitPrice"	REAL NOT NULL CHECK("UnitPrice" >= 0),
	"LineTotal"	REAL NOT NULL CHECK("LineTotal" >= 0),
	PRIMARY KEY("OrderItemId")
);
CREATE TABLE IF NOT EXISTS "OrderStatuses" (
	"OrderStatusId"	INTEGER,
	"Name"	TEXT NOT NULL UNIQUE,
	"Description"	TEXT,
	"DisplayOrder"	INTEGER NOT NULL DEFAULT 0,
	"IsActive"	INTEGER NOT NULL DEFAULT 1 CHECK("IsActive" IN (0, 1)),
	PRIMARY KEY("OrderStatusId")
);
CREATE TABLE IF NOT EXISTS "Orders" (
	"OrderId"	INTEGER,
	"CustomerId"	INTEGER NOT NULL,
	"OrderStatusId"	INTEGER NOT NULL DEFAULT 1,
	"OrderDate"	TEXT NOT NULL DEFAULT CURRENT_TIMESTAMP,
	"TotalAmount"	REAL NOT NULL DEFAULT 0 CHECK("TotalAmount" >= 0),
	PRIMARY KEY("OrderId")
);
CREATE TABLE IF NOT EXISTS "Pizzas" (
	"PizzaId"	INTEGER,
	"Name"	TEXT NOT NULL,
	"Description"	TEXT,
	"BasePrice"	REAL NOT NULL CHECK("BasePrice" >= 0),
	"IsActive"	INTEGER NOT NULL DEFAULT 1 CHECK("IsActive" IN (0, 1)),
	PRIMARY KEY("PizzaId")
);
INSERT INTO "OrderStatuses" VALUES (1,'Pending','Order received and awaiting acceptance',1,1);
INSERT INTO "OrderStatuses" VALUES (2,'Accepted','Order accepted by the restaurant',2,1);
INSERT INTO "OrderStatuses" VALUES (3,'Preparing','Order is being prepared',3,1);
INSERT INTO "OrderStatuses" VALUES (4,'Finishing','Order is nearing completion',4,1);
INSERT INTO "OrderStatuses" VALUES (5,'Ready for Pickup','Order is ready for pickup',5,1);
INSERT INTO "OrderStatuses" VALUES (6,'On the Way','Order is out for delivery',6,1);
INSERT INTO "OrderStatuses" VALUES (7,'Completed','Order has been fulfilled',7,1);
INSERT INTO "OrderStatuses" VALUES (8,'Cancelled','Order has been cancelled',8,1);
COMMIT;
