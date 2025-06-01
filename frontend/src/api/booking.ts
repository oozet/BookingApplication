import { API_BASE_URL } from "$lib/constants";
import { error } from "@sveltejs/kit";

export class BookingApi {
    static async GetBooking(id: string) {
        let response = await fetch(API_BASE_URL + "booking/" + id)

        if (!response.ok) {
            error(404, "Could not get booking, check the URL")
        }

        return await response.json();
    }

    static async GetAllForRoom(roomId: string) {
        let response = await fetch(API_BASE_URL + "booking/rooms/" + roomId)

        if (!response.ok) {
            error(404, "Could not get bookings, check the URL")
        }

        return await response.json();
    }

    static async Delete(id: string) {
        let response = await fetch(API_BASE_URL + 'booking/' + id, {
            method: 'DELETE',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            let message = 'could not delete room: ' + response.status;
            return message;
        }

        return response.status;
    }

    static async Create(startDate: Date, endDate: Date, roomId: string, userId: string, activity: string | null) {
        let response = await fetch(API_BASE_URL + "booking", {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ startDate, endDate, roomId, userId, activity })
        })

        if (!response.ok) {
            return "Could not create booking: " + response.status;
        }

        return response.status.toString();
    }
}