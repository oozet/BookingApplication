import { API_BASE_URL } from "$lib/constants";
import { error } from "@sveltejs/kit";

export class RoomApi {
    static async GetAll() {
        let response = await fetch(API_BASE_URL + "room")

        if (!response.ok) {
            error(404, "Could not get all rooms, check the URL")
        }

        return await response.json();
    }

    static async Delete(id: string) {
        let response = await fetch(API_BASE_URL + 'room/' + id, {
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

    static async Create(name: string, number: number, limit: number, area: number, price: number) {
        let response = await fetch(API_BASE_URL + "room", {
            method: 'POST',
            credentials: 'include',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ name: name, roomNumber: number, limit: limit, area: area, price: price })
        })

        if (!response.ok) {
            return "Could not create a new room: " + response.status;
        }

        return response.status.toString();
    }
}