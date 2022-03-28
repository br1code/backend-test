import React, { useState } from 'react';
import EventsService from '../EventsService';
import { useNavigate } from "react-router-dom";

export default function CreateEvent() {
    const [newEvent, setNewEvent] = useState({
        title: '',
        description: '',
        location: '',
        featured: false,
        image: '',
        dates: []
    });

    const navigate = useNavigate();

    // TODO: improve this function
    const handleChange = event => {
        let propertyToUpdate = event.target.name;
        let valueToUpdate = '';

        switch (event.target.type) {
            case 'checkbox': {
                valueToUpdate = event.target.checked;
                break;
            }

            case 'textarea':
            case 'text': {
                valueToUpdate = event.target.value;
                break;
            }

            default: {
                console.log(event.target.type);
                break;
            }
        }

        setNewEvent(prevProps => ({
            ...prevProps,
            [propertyToUpdate]: valueToUpdate
        }));

    };

    // TODO: listener for adding a new date (date + price)
    const handleDateSubmit = event => {

    };

    const handleSubmit = event => {
        event.preventDefault();

        EventsService.createEvent(newEvent)
            .then(response => response.json())
            .then(response => {
                navigate(`/event/${response}`);
            });
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <div className='mb-6'>
                    <label htmlFor="title" className="block mb-2 text-md text-black">Event Name</label>
                    <input type='text' name='title' onChange={handleChange} className="border border-black text-black text-sm" required></input>
                </div>

                <div className='mb-6'>
                    <label htmlFor="description" className="block mb-2 text-md text-black">Event Description</label>
                    <textarea type='text' name='description' onChange={handleChange} className="border border-black text-black text-sm" required></textarea>
                </div>

                <div className='mb-6'>
                    <label htmlFor="location" className="block mb-2 text-md text-black">Location</label>
                    <input type='text' name='location' onChange={handleChange} className="border border-black text-black text-sm" required></input>
                </div>

                <div className='mb-6'>
                    <label htmlFor="featured" className="block mb-2 text-md text-black">Featured</label>
                    <input type='checkbox' name='featured' onChange={handleChange} className="border border-black text-black text-sm" required></input>
                </div>

                <div className='mb-6'>
                    <label htmlFor="image" className="block mb-2 text-md text-black">Image</label>
                    <input type='text' name='image' onChange={handleChange} className="border border-black text-black text-sm" required></input>
                </div>

                <input className='py-2 px-5 border-solid border-2 border-black text-sm' type="submit" value="Submit" />
            </form>
        </div>
    );
}