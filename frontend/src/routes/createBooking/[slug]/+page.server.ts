import type { PageServerLoad } from '../$types';
import { error } from '@sveltejs/kit';
import { API_BASE_URL } from '$lib/constants';
import { ActivityApi } from '../../../api/activity';
import { RoomApi } from '../../../api/room';

export const load: PageServerLoad = async ({ params }) => {

    const roomId: string = params.roomId;

    return {
        activities: await ActivityApi.getAll(),
        roomId
    }
};