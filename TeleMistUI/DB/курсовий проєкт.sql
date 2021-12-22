CREATE TYPE "user_gender" AS ENUM (
  'Чоловіча',
  'Жіноча'
);

CREATE TYPE "appointment_status" AS ENUM (
  'Заплановано',
  'Завершено'
);

CREATE TABLE "patient" (
  "id" SERIAL PRIMARY KEY,
  "avatar" blob,
  "surname" varchar,
  "name" varchar,
  "patronym" varchar,
  "date_of_birth" date,
  "gender" user_gender,
  "residence" varchar,
  "insurance" varchar
);

CREATE TABLE "doctor" (
  "id" SERIAL PRIMARY KEY,
  "avatar" blob,
  "surname" varchar,
  "name" varchar,
  "patronym" varchar,
  "date_of_birth" date,
  "gender" user_gender,
  "residence" varchar,
  "specialty" varchar
);

CREATE TABLE "appointment" (
  "id" SERIAL PRIMARY KEY,
  "patient_id" int,
  "doctor_id" int,
  "date_time" datetime,
  "reason" text,
  "diagnose" text,
  "recommendations" text,
  "status" appointment_status
);

ALTER TABLE "appointment" ADD FOREIGN KEY ("patient_id") REFERENCES "patient" ("id");

ALTER TABLE "appointment" ADD FOREIGN KEY ("doctor_id") REFERENCES "doctor" ("id");
