import type { PageServerLoad } from './$types';
import { ActivityApi } from '../../../api/activity';

export const load: PageServerLoad = async ({ params }) => {


    return {
        activities: await ActivityApi.getAll(),
        slug: params.slug
    }
};