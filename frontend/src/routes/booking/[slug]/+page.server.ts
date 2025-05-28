// This file will be used to fetch data and load it per booking.
// then in the page, we'll use the bookingcard component and send the data we fetch here
// as a prop.
import type { PageServerLoad } from './$types';

export const load: PageServerLoad = async ({ params }) => {
    return {
        slug: params.slug
    };
};