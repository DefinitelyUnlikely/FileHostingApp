import type { LayoutServerLoad } from './$types';
import { User } from '$lib/models';
import type { RequestEvent } from '@sveltejs/kit';

export const load: LayoutServerLoad = async ({ cookies }: RequestEvent) => {
    const token = cookies.get('token');
    const email = cookies.get('userinfo');

    if (!token || !email) {
        return {
            isLoggedIn: false,
            user: new User('')
        };
    }

    const user = new User(email);

    return {
        isLoggedIn: true,
        user: user
    };
};