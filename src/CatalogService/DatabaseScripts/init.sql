CREATE DATABASE "CatalogDb" 
  WITH ENCODING = 'UTF8' 
       OWNER = postgres;

\connect "CatalogDb"

CREATE TABLE catalog_brands (
    id uuid PRIMARY KEY,
    name varchar(50) UNIQUE NOT NULL
);

CREATE TABLE catalog_categories (
    id uuid PRIMARY KEY,
    name varchar(50) UNIQUE NOT NULL
);

CREATE TABLE catalog_products (
    id uuid PRIMARY KEY,
    name varchar(50) UNIQUE NOT NULL,
    description varchar(300) NOT NULL,
    price numeric CHECK (price >= 0) NOT NULL,
    in_stock integer NOT NULL CHECK (in_stock >= 0 AND in_stock <= stock_capacity),
    reserved_stock integer NOT NULL CHECK (reserved_stock >= 0 AND reserved_stock <= in_stock),
    stock_capacity integer NOT NULL CHECK (stock_capacity >= 0),
    
    brand_id uuid REFERENCES catalog_brands(id) ON DELETE RESTRICT,
    category_id uuid REFERENCES catalog_categories(id) ON DELETE RESTRICT
);