// This file will be used to fetch data and load it per booking.
// then in the page, we'll use the bookingcard component and send the data we fetch here
// as a prop.
import type { PageServerLoad } from './$types';
import { error } from '@sveltejs/kit';
import { API_BASE_URL } from '$lib/constants';

export const load: PageServerLoad = async ({ params }) => {

    let booking = await fetch(API_BASE_URL + "booking/" + params.slug);

    if (!booking.ok) {
        error(404, 'Booking not found');
    }

    let bookBody = await booking.json();
    let room = await fetch(API_BASE_URL + "room/" + bookBody.roomId);

    if (!room.ok) {
        error(404, 'Room not found');
    }
    let roomBody = await room.json();

    let user = await fetch(API_BASE_URL + "user/" + bookBody.userId);

    if (!user.ok) {
        error(404, 'No user was found, contact an admin if you want to book this timeslot.');
    }

    let userBody = await user.json()

    let activity = await fetch(API_BASE_URL + "booking/" + bookBody.activityId);
    let activityBody = {}

    if (activity.ok) {
        activityBody = await activity.json();
    }

    return {
        slug: params.slug,
        booking: bookBody,
        room: roomBody,
        activity: activityBody,
        user: userBody
    }

};