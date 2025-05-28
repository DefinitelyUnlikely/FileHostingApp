import { API_BASE_URL } from '$lib/config';
import { error, redirect } from '@sveltejs/kit';
import type { PageServerLoad } from './$types';
import { Logout } from '../stores/auth';

export const load: PageServerLoad = async ({ params, cookies }) => {
    if (!cookies.get("userinfo")) {
        return {}
    }

    let response = await fetch(API_BASE_URL + "/folder/root", {
        method: 'GET',
        headers: {
            authorization: "Bearer" + cookies.get("token"),
            'X-Include-Files': "true",
            'content-type': 'application/json'
        },
        body: undefined
    });

    if (!response.ok) {
        console.log(response.status);
        let refresh = cookies.get("refresh");
        let refreshRespone = await fetch(API_BASE_URL + "/refresh", {
            method: 'POST',
            body: '{"refreshtoken":' + refresh + '"}'
        });

        if (!response.ok) {
            console.log(response.status);
            cookies.delete("userinfo", { path: "/" });
            cookies.delete("token", { path: "/" });
            cookies.delete("refresh", { path: "/" });
            redirect(303, "/")
        }
        error(404, "No root folder found")
    }

    return {
        response: await response.json()
    };
};