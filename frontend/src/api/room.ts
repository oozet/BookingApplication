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
}