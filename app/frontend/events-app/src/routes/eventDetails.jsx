import React, { useState, useEffect } from 'react';
import { Link, useParams } from "react-router-dom";
import EventsService from '../EventsService';
import Moment from 'moment';

export default function EventDetails() {
    const [event, setEvent] = useState(null);
    let params = useParams();
    let eventId = params.eventId;

    useEffect(() => {
        async function getEvent() {
            const result = await EventsService.getEvent(eventId);
            const event = await result.json();
            setEvent(event);
        }

        getEvent();
    }, [eventId]);

    if (!event) {
        return <h1>Loading ....</h1>;
    }

    return (
        <div>
            <h1>{event.title}</h1>
            <h1>{event.description}</h1>
            <h1>{event.location}</h1>
            {event.featured ? <h1>Featured</h1> : ''}
            <img src={event.image} alt={event.title}></img>
            <table className='table-auto'>
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Time</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
                    {event.eventDates.map(e => {
                        // TODO: use a library like moment js to format these dates
                        const momentDate = Moment(e.date);
                        const date = momentDate.format('DD MMM');
                        const time = momentDate.format('LT');

                        return (
                            <tr key={e.id}>
                                <td>{date}</td>
                                <td>{time}</td>
                                <td>{`$${e.price}`}</td>
                            </tr>
                        )
                    })}
                </tbody>
            </table>
            <Link to='/createEvent'>
                <button className='py-2 px-5 border-solid border-2 border-black text-sm'>Create Event</button>
            </Link>
        </div>
    );
}