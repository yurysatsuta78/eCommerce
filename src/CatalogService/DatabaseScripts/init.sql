CREATE DATABASE "CatalogDb" 
  WITH ENCODING = 'UTF8' 
       OWNER = postgres;

\connect "CatalogDb"

CREATE TABLE catalog_brand (
    id uuid PRIMARY KEY,
    name varchar(50) UNIQUE NOT NULL
);

CREATE TABLE catalog_category (
    id uuid PRIMARY KEY,
    name varchar(50) UNIQUE NOT NULL
);

CREATE TABLE catalog_item (
    id uuid PRIMARY KEY,
    name varchar(50) UNIQUE NOT NULL,
    description varchar(300) NOT NULL,
    price numeric CHECK (price >= 0) NOT NULL,
    available_stock integer CHECK (available_stock >= 0) NOT NULL,
    restock_threshold integer CHECK (restock_threshold >= 0) NOT NULL,
    max_stock_threshold integer CHECK (max_stock_threshold >= 0) NOT NULL,
    catalog_brand_id uuid REFERENCES catalog_brand(id) ON DELETE RESTRICT,
    catalog_category_id uuid REFERENCES catalog_category(id) ON DELETE RESTRICT
);