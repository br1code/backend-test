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



# TODO

## Backend
- create an endpoint that returns a list of events sorted by date (asc and desc)
  - when not authenticated
- create an endpoint that returns a single event
- create an endpoint that returns a list of featured events
  - how many events?


## Frontend
- As a site visitor looking at an event I should be able to click the share button:
  - This button will share the event on twitter with the following text: "I will attend to [Name of the event] @ [Date of the event]"
  
- As a visitor of the site, clicking an event should take me to the event detail view. The detail page will show all the event details like dates, location, etc.

- As a visitor of the site on the homepage, I should see a list of featured events on the right of the screen.
