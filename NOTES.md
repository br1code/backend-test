# Backend: API en .NET Core





# Frontnend: React?



# DB: ???

Necesito relaciones?

Entidades:
- Event:
  - Title
  - Description
  - Date List (Date List sería una relación one to many: un evento, muchas fechas)
    - Date
    - Time
    - Price
  - Location (TODO: por ahora solo un string, pero sería mejor usar lat/lng y google maps)
  - Featured
  - Image (TODO: agregar soporte N imágenes?)


Usaremos PostgreSQL, porque probablemente necesite relaciones para 'Date List' y 'Image List'. Y porque tengo ganas de practicar PostgreSQL.

## Event

CREATE TABLE events (
    id SERIAL PRIMARY KEY,
    title VARCHAR,
    description VARCHAR,
    location VARCHAR,
    featured BOOLEAN,
    image VARCHAR
);

CREATE TABLE event_dates (
    id SERIAL PRIMARY KEY,
    event_id INTEGER REFERENCES events(id)
    date timestamp,
    price decimal
);