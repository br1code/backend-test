import './App.css';
import React from 'react';
import EventsService from './EventsService';
import { Link } from "react-router-dom";

// TODO: change to use react hooks
class EventsList extends React.Component {
    constructor(props) {
        super(props);

        // TODO: use react hooks
        this.state = { events: [] };
    }

    componentDidMount() {
        // TODO: dependency injection???
        EventsService.getEvents(false, 1, 10)
            .then(response => response.json())
            .then(response => this.setState({ events: [...response, ...this.state.events] }));
    }

    render() {
        return (
            <div>
                <ul>
                    {this.state.events.map(e => {
                        return (
                            <li key={e.eventDateId}>
                                <h1>{e.title}</h1>
                                <h1>{e.date}</h1>
                                <Link to={`/event/${e.eventId}`}>
                                    <button className='py-2 px-5 border-solid border-2 border-black text-sm'>
                                        View
                                    </button>
                                </Link>
                            </li>
                        )
                    })}
                </ul>
            </div>
        );
    }
}

// TODO: change to use react hooks
class FeaturedEventsList extends React.Component {
    constructor(props) {
        super(props);

        // TODO: use react hooks
        this.state = { events: [] };
    }

    componentDidMount() {
        // TODO: dependency injection???
        // TODO: add support for pagination
        EventsService.getEvents(true, 1, 5)
            .then(response => response.json())
            .then(response => this.setState({ events: [...response, ...this.state.events] }));
    }

    render() {
        return (
            <div>
                <h1 className='text-lg font-bold'>Featured Events</h1>
                <ul>
                    {this.state.events.map(e => {
                        return (
                            <li key={e.eventDateId}>
                                <h1>{e.title}</h1>
                                <h1>{e.date}</h1>
                                <button className='py-2 px-5 border-solid border-2 border-black text-sm'>View</button>
                            </li>
                        )
                    })}
                </ul>
            </div>
        );
    }
}

// TODO: build the home page layout
function App() {
    return (
        <div>
            <h1 className="text-3xl font-bold">
                Events
            </h1>
            <div>
                <EventsList />
                <hr />
                <FeaturedEventsList />
            </div>
        </div>
    );
}

export default App;
