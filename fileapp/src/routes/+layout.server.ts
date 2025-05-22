import type { LayoutServerLoad } from './$types';
import { User } from '$lib/models';
import type { RequestEvent } from '@sveltejs/kit';

const serializeNonPOJOs = (value: object | null) => {
    return structuredClone(value)
};

export const load: LayoutServerLoad = async ({ cookies }: RequestEvent) => {
    const email = cookies.get('userinfo');

    if (!email) {
        return {
            isLoggedIn: false,
            useremail: ''
        };
    }

    return {
        isLoggedIn: true,
        useremail: email
    };
};