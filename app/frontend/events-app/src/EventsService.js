const EVENTS_API_URL = 'https://localhost:7297/api/Events';

class EventsService {
    getEvents(featured, pageNumber, pageSize) {
        let url = EVENTS_API_URL;

        url += `?featured=${featured}`;

        if (pageNumber) {
            url += `&pageNumber=${pageNumber}`;
        }

        if (pageSize) {
            url += `&pageSize=${pageSize}`;
        }

        console.log(`Calling ${url} ...`);

        return fetch(url);
    }

    getEvent(id) {
        return fetch(`${EVENTS_API_URL}/${id}`);
    }

    createEvent(newEvent) {
        const formData = new FormData();
    
        formData.append('title', newEvent.title);
        formData.append('description', newEvent.description);
        formData.append('location', newEvent.location);
        formData.append('featured', newEvent.featured);
        formData.append('image', newEvent.image);

        // for (const date of newEvent.dates) {
        //     formData.append('dates', date);
        // }

        // TODO: for multiple imgs
        // for (const img of data.imgs) {
        //     formData.append('img', img);
        // }

        return fetch(EVENTS_API_URL, {
            method: 'POST',
            cache: 'no-cache',
            body: formData
        });
    }
}


export default new EventsService();