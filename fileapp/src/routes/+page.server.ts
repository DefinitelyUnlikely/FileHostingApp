import { API_BASE_URL } from '$lib/config';
import type { PageServerLoad } from './$types';

export const load: PageServerLoad = async ({ params, cookies }) => {

    let response = await fetch(API_BASE_URL + "/folder/root", {
        method: 'GET',
        headers: {
            authorization: "Bearer" + cookies.get("token"),
            'X-Include-Files': "true",
            'content-type': 'application/json'
        },
        body: undefined
    });

    return {
    };
};