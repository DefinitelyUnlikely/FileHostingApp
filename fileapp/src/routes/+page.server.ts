import { API_BASE_URL } from '$lib/config';
import { error, redirect } from '@sveltejs/kit';
import type { PageServerLoad } from './$types';
import { RefreshToken } from '../stores/auth';

export const load: PageServerLoad = async ({ params, cookies }) => {
    if (!cookies.get("userinfo")) {
        return;
    }

    let response = await fetch(API_BASE_URL + "/folder/root", {
        method: 'GET',
        headers: {
            authorization: "Bearer " + cookies.get("token"),
            'X-Include-Files': "true",
            'content-type': 'application/json'
        },
        body: undefined
    });

    if (!response.ok) {
        RefreshToken();

        response = await fetch(API_BASE_URL + "/folder/root", {
            method: 'GET',
            headers: {
                authorization: "Bearer " + cookies.get("token"),
                'X-Include-Files': "true",
                'content-type': 'application/json'
            },
            body: undefined
        });

        if (!response.ok) {
            error(500, "Cannot fetch valid response, try login in again");
        }
    }

    return {
        response: await response.json()
    };
};