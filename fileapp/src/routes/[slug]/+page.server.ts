import { API_BASE_URL } from '$lib/config';
import { error, redirect } from '@sveltejs/kit';
import type { PageServerLoad } from './$types';
import { Logout } from '../../stores/auth';

export const load: PageServerLoad = async ({ params, cookies }) => {
    if (!cookies.get("userinfo")) {
        return;
    }

    let response = await fetch(API_BASE_URL + "/folder/" + params.slug, {
        method: 'GET',
        headers: {
            authorization: "Bearer " + cookies.get("token"),
            'X-Include-Files': "true",
            'content-type': 'application/json'
        },
        body: undefined
    });

    if (!response.ok) {
        error(404, "That does not seem to be a valid route. Make sure the folder id is correct.")
    }

    return {
        response: await response.json(),
        slug: params.slug
    };
};