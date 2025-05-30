import type { PageServerLoad } from './$types';
import { error } from '@sveltejs/kit';
import { API_BASE_URL } from '$lib/constants';
import { ActivityApi } from '../../api/activity';
import { RoomApi } from '../../api/room';

export const load: PageServerLoad = async ({ params }) => {

    return {
        activities: await ActivityApi.getAll(),
        rooms: await RoomApi.GetAll(),
    }
};