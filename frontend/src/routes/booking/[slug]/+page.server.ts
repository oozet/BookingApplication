// This file will be used to fetch data and load it per booking.
import type { PageServerLoad } from './$types';

export const load: PageServerLoad = async ({ params }) => {
    return {
        slug: params.slug
    };
};