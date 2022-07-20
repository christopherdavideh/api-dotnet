/*
 Navicat Premium Data Transfer

 Source Server         : PostgreSQL
 Source Server Type    : PostgreSQL
 Source Server Version : 140002
 Source Host           : localhost:5432
 Source Catalog        : company_db
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 140002
 File Encoding         : 65001

 Date: 19/07/2022 23:56:48
*/


-- ----------------------------
-- Sequence structure for departments_employees_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."departments_employees_id_seq";
CREATE SEQUENCE "public"."departments_employees_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for departments_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."departments_id_seq";
CREATE SEQUENCE "public"."departments_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for employees_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."employees_id_seq";
CREATE SEQUENCE "public"."employees_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Sequence structure for enterprises_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."enterprises_id_seq";
CREATE SEQUENCE "public"."enterprises_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

-- ----------------------------
-- Table structure for departments
-- ----------------------------
DROP TABLE IF EXISTS "public"."departments";
CREATE TABLE "public"."departments" (
  "id" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "created_by" varchar(50) COLLATE "pg_catalog"."default",
  "created_date" timestamptz(6) DEFAULT CURRENT_TIMESTAMP,
  "modified_by" varchar(50) COLLATE "pg_catalog"."default",
  "modified_date" timestamptz(6),
  "status" bool DEFAULT true,
  "description" varchar(255) COLLATE "pg_catalog"."default",
  "name" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "phone" varchar(13) COLLATE "pg_catalog"."default" NOT NULL,
  "id_enterprise" int4 NOT NULL
)
;

-- ----------------------------
-- Records of departments
-- ----------------------------
INSERT INTO "public"."departments" OVERRIDING SYSTEM VALUE VALUES (1, 'admin', '2022-07-19 09:42:20.898922-05', NULL, NULL, 't', 'Development Apps', 'Development', '2875968', 1);
INSERT INTO "public"."departments" OVERRIDING SYSTEM VALUE VALUES (3, 'admin', '2022-07-19 22:59:39.313316-05', NULL, NULL, 't', 'UIX Experts', 'Desing and UI', '099999999', 1);
INSERT INTO "public"."departments" OVERRIDING SYSTEM VALUE VALUES (2, 'admin', '2022-07-19 09:43:23.673842-05', NULL, NULL, 't', 'Backend Development ', 'Development Rapp', '2568790', 2);

-- ----------------------------
-- Table structure for departments_employees
-- ----------------------------
DROP TABLE IF EXISTS "public"."departments_employees";
CREATE TABLE "public"."departments_employees" (
  "id" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "created_by" varchar(50) COLLATE "pg_catalog"."default",
  "created_date" timestamptz(6) DEFAULT CURRENT_TIMESTAMP,
  "modified_by" varchar(50) COLLATE "pg_catalog"."default",
  "modified_date" timestamptz(6),
  "status" bool DEFAULT true,
  "id_department" int4 NOT NULL,
  "id_employee" int4 NOT NULL
)
;

-- ----------------------------
-- Records of departments_employees
-- ----------------------------
INSERT INTO "public"."departments_employees" OVERRIDING SYSTEM VALUE VALUES (5, 'admin', '2022-07-19 10:52:16.521605-05', NULL, NULL, 't', 2, 5);

-- ----------------------------
-- Table structure for employees
-- ----------------------------
DROP TABLE IF EXISTS "public"."employees";
CREATE TABLE "public"."employees" (
  "id" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "created_by" varchar(50) COLLATE "pg_catalog"."default",
  "created_date" timestamptz(6) DEFAULT CURRENT_TIMESTAMP,
  "modified_by" varchar(50) COLLATE "pg_catalog"."default",
  "modified_date" timestamptz(6),
  "status" bool DEFAULT true,
  "age" int4 NOT NULL,
  "email" varchar(100) COLLATE "pg_catalog"."default" NOT NULL,
  "name" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "position" varchar(100) COLLATE "pg_catalog"."default" NOT NULL,
  "surname" varchar(50) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of employees
-- ----------------------------
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (1, 'admin', '2022-07-19 08:18:34.994307-05', NULL, NULL, 't', 26, 'example@example.com', 'Christopher Erazo', 'Developer', 'cerazo');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (2, 'admin', '2022-07-19 08:19:08.995804-05', NULL, NULL, 't', 25, 'example@example.com', 'David Mejia', 'Developer', 'dmejia');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (3, 'admin', '2022-07-19 08:19:50.305829-05', NULL, NULL, 't', 27, 'example@example.com', 'Daniel Chalapu', 'UI/UIX', 'dchalapu');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (4, 'admin', '2022-07-19 09:47:54.015664-05', NULL, NULL, 't', 30, 'example@example.com', 'Jordy Erazo', 'UI Desing', 'jerazo');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (5, 'admin', '2022-07-19 10:02:44.290123-05', 'admin', '2022-07-19 10:52:12.051861-05', 't', 18, 'example@example.com', 'David Salazar', 'UI Desing', 'dsalazar');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (16, 'user4', '2022-07-19 12:14:19.665663-05', NULL, NULL, 'f', 22, 'example@example.com', 'David Salazar6', 'UI Desi6ng', 'dsalazar7');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (15, 'user4', '2022-07-19 11:22:06.579883-05', NULL, NULL, 'f', 22, 'example@example.com', 'David Salazar6', 'UI Desi6ng', 'dsalazar7');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (14, 'user3', '2022-07-19 11:19:37.961237-05', NULL, NULL, 'f', 22, 'example@example.com', 'David Salazar6', 'UI Desi6ng', 'dsalazar6');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (13, 'user3', '2022-07-19 11:17:30.576479-05', NULL, NULL, 'f', 22, 'example@example.com', 'David Salazar6', 'UI Desi6ng', 'dsalazar6');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (12, 'user', '2022-07-19 11:14:10.26335-05', NULL, NULL, 'f', 22, 'example@example.com', 'David Salazar6', 'UI Desi6ng', 'dsalazar6');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (11, 'user', '2022-07-19 11:12:22.787134-05', NULL, NULL, 'f', 22, 'example@example.com', 'David Salazar6', 'UI Desi6ng', 'dsalazar6');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (10, 'admin', '2022-07-19 11:02:55.938646-05', NULL, NULL, 'f', 22, 'example@example.com', 'David Salazar6', 'UI Desi6ng', 'dsalazar6');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (9, 'admin', '2022-07-19 10:42:12.051861-05', NULL, NULL, 'f', 22, 'example@example.com', 'David Salazar5', 'UI Desi5ng', 'dsalazar5');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (8, 'admin', '2022-07-19 10:40:13.955985-05', NULL, NULL, 'f', 22, 'example@example.com', 'David Salazar4', 'UI Desi4ng', 'dsalazar4');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (7, 'admin', '2022-07-19 10:24:37.223996-05', NULL, NULL, 't', 32, 'lex@example.com', 'Alexander Montenegro', 'Desing and Visual', 'amontenegro');
INSERT INTO "public"."employees" OVERRIDING SYSTEM VALUE VALUES (6, 'admin', '2022-07-19 10:14:07.719942-05', NULL, NULL, 't', 22, 'example@example.com', 'David Salazar2', 'UI Desi2ng', 'dsalazar2');

-- ----------------------------
-- Table structure for enterprises
-- ----------------------------
DROP TABLE IF EXISTS "public"."enterprises";
CREATE TABLE "public"."enterprises" (
  "id" int4 NOT NULL GENERATED ALWAYS AS IDENTITY (
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
),
  "created_by" varchar(50) COLLATE "pg_catalog"."default",
  "created_date" timestamptz(6) DEFAULT CURRENT_TIMESTAMP,
  "modified_by" varchar(50) COLLATE "pg_catalog"."default",
  "modified_date" timestamptz(6),
  "status" bool DEFAULT true,
  "address" varchar(100) COLLATE "pg_catalog"."default" NOT NULL,
  "name" varchar(50) COLLATE "pg_catalog"."default" NOT NULL,
  "phone" varchar(13) COLLATE "pg_catalog"."default" NOT NULL
)
;

-- ----------------------------
-- Records of enterprises
-- ----------------------------
INSERT INTO "public"."enterprises" OVERRIDING SYSTEM VALUE VALUES (4, 'admin', '2022-07-19 05:34:09.322145-05', NULL, NULL, 't', 'Reino Unido', 'Facebook', '0255855');
INSERT INTO "public"."enterprises" OVERRIDING SYSTEM VALUE VALUES (3, 'admin', '2022-07-19 05:19:56.516936-05', NULL, NULL, 't', 'Colombia', 'Platzi', '333333');
INSERT INTO "public"."enterprises" OVERRIDING SYSTEM VALUE VALUES (1, 'admin', '2022-07-18 01:44:36.811272-05', 'admin', '2022-07-19 05:21:42.446-05', 't', 'Silicon Valley', 'Google', '0122922221');
INSERT INTO "public"."enterprises" OVERRIDING SYSTEM VALUE VALUES (2, 'admin', '2022-07-18 01:45:43.895712-05', 'admin', '2022-07-19 05:21:22.446-05', 'f', 'QUITO', 'SICPA', '2999999');
INSERT INTO "public"."enterprises" OVERRIDING SYSTEM VALUE VALUES (5, 'admin', '2022-07-19 14:39:07.925596-05', NULL, NULL, 't', 'Inglaterra', 'Relic', '999999999');
INSERT INTO "public"."enterprises" OVERRIDING SYSTEM VALUE VALUES (6, 'admin', '2022-07-19 14:42:36.587156-05', NULL, NULL, 't', 'California', 'Netflix', '28999999');
INSERT INTO "public"."enterprises" OVERRIDING SYSTEM VALUE VALUES (7, 'admin', '2022-07-19 14:50:15.550662-05', NULL, NULL, 't', 'London', 'Warner Bros.', '01165328651');
INSERT INTO "public"."enterprises" OVERRIDING SYSTEM VALUE VALUES (8, 'admin', '2022-07-19 14:59:58.159458-05', NULL, NULL, 't', 'Ecuador', 'SiCPA', '58513156484');
INSERT INTO "public"."enterprises" OVERRIDING SYSTEM VALUE VALUES (9, 'admin', '2022-07-19 15:02:40.351298-05', NULL, NULL, 't', 'Colombia', 'Nissan', '2342424242');
INSERT INTO "public"."enterprises" OVERRIDING SYSTEM VALUE VALUES (10, 'admin', '2022-07-19 15:07:49.911375-05', NULL, NULL, 't', 'Peru', 'Rappi', '323424324');
INSERT INTO "public"."enterprises" OVERRIDING SYSTEM VALUE VALUES (11, 'admin', '2022-07-19 16:41:59.854298-05', NULL, NULL, 'f', 'bbbbcccc', 'bbbb', '9999999');

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."departments_employees_id_seq"
OWNED BY "public"."departments_employees"."id";
SELECT setval('"public"."departments_employees_id_seq"', 6, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."departments_id_seq"
OWNED BY "public"."departments"."id";
SELECT setval('"public"."departments_id_seq"', 4, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."employees_id_seq"
OWNED BY "public"."employees"."id";
SELECT setval('"public"."employees_id_seq"', 17, true);

-- ----------------------------
-- Alter sequences owned by
-- ----------------------------
ALTER SEQUENCE "public"."enterprises_id_seq"
OWNED BY "public"."enterprises"."id";
SELECT setval('"public"."enterprises_id_seq"', 12, true);

-- ----------------------------
-- Primary Key structure for table departments
-- ----------------------------
ALTER TABLE "public"."departments" ADD CONSTRAINT "departments_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table departments_employees
-- ----------------------------
ALTER TABLE "public"."departments_employees" ADD CONSTRAINT "departments_employees_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table employees
-- ----------------------------
ALTER TABLE "public"."employees" ADD CONSTRAINT "employees_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Primary Key structure for table enterprises
-- ----------------------------
ALTER TABLE "public"."enterprises" ADD CONSTRAINT "enterprises_pkey" PRIMARY KEY ("id");

-- ----------------------------
-- Foreign Keys structure for table departments
-- ----------------------------
ALTER TABLE "public"."departments" ADD CONSTRAINT "Fk_enterprises_departments" FOREIGN KEY ("id_enterprise") REFERENCES "public"."enterprises" ("id") ON DELETE SET NULL ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Keys structure for table departments_employees
-- ----------------------------
ALTER TABLE "public"."departments_employees" ADD CONSTRAINT "FK_departments_departments_employees" FOREIGN KEY ("id_department") REFERENCES "public"."departments" ("id") ON DELETE SET NULL ON UPDATE NO ACTION;
ALTER TABLE "public"."departments_employees" ADD CONSTRAINT "FK_employees_departments_employees" FOREIGN KEY ("id_employee") REFERENCES "public"."employees" ("id") ON DELETE CASCADE ON UPDATE NO ACTION;
